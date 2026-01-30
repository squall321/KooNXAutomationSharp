using System;
using System.Collections.Generic;
using System.Diagnostics;
using NXOpen;
using NXOpen.UF;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Features.StepExporter
{
    /// <summary>
    /// 접촉 분석기 - Octree 기반 효율적인 접촉면 탐지
    /// </summary>
    public class ContactAnalyzer
    {
        private const string ClassName = "ContactAnalyzer";

        private double _tolerance;
        private Octree _octree;
        private UFSession _ufSession;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="tolerance">접촉 판정 허용 오차 (mm)</param>
        public ContactAnalyzer(double tolerance = 0.01)
        {
            _tolerance = tolerance;
            _octree = new Octree(maxDepth: 8, maxFacesPerNode: 10, tolerance: tolerance);
        }

        /// <summary>
        /// 접촉 분석 실행
        /// </summary>
        public ContactAnalysisResult Analyze(
            List<Part> parts,
            Action<int, int, string> progressCallback = null)
        {
            Logger.MethodEntry(ClassName, "Analyze", parts.Count, _tolerance);
            Logger.Separator("접촉 분석 시작");

            Stopwatch stopwatch = Stopwatch.StartNew();

            ContactAnalysisResult result = new ContactAnalysisResult
            {
                ToleranceMm = _tolerance,
                Generated = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
            };

            try
            {
                _ufSession = UFSession.GetUFSession();

                // 1. 면 데이터 수집
                progressCallback?.Invoke(0, 100, "Collecting face data...");
                List<FaceData> allFaces = CollectFaceData(parts, result);
                Logger.Info(ClassName, $"면 데이터 수집 완료: {allFaces.Count}개 면");

                if (allFaces.Count == 0)
                {
                    Logger.Warning(ClassName, "분석할 면이 없습니다");
                    stopwatch.Stop();
                    result.Summary.AnalysisTimeSec = stopwatch.Elapsed.TotalSeconds;
                    return result;
                }

                // 2. Octree 구축
                progressCallback?.Invoke(20, 100, "Building spatial index...");
                _octree.Build(allFaces);

                // 3. 잠재적 접촉 쌍 추출
                progressCallback?.Invoke(40, 100, "Finding potential contacts...");
                var potentialPairs = _octree.GetPotentialContactPairs();
                Logger.Info(ClassName, $"잠재적 접촉 쌍: {potentialPairs.Count}개");

                // 4. 정밀 접촉 검사
                int contactId = 1;
                int checkedCount = 0;
                int totalPairs = potentialPairs.Count;

                foreach (var (face1, face2) in potentialPairs)
                {
                    checkedCount++;

                    if (checkedCount % 50 == 0 || checkedCount == totalPairs)
                    {
                        int progress = 40 + (int)(50.0 * checkedCount / totalPairs);
                        progressCallback?.Invoke(progress, 100, $"Checking contacts ({checkedCount}/{totalPairs})...");
                    }

                    // 접촉 여부 확인
                    ContactPair contact = CheckContact(face1, face2, contactId);
                    if (contact != null)
                    {
                        result.Contacts.Add(contact);
                        contactId++;
                        Logger.Debug(ClassName, $"접촉 발견: {face1} <-> {face2}");
                    }
                }

                // 5. 결과 요약
                stopwatch.Stop();
                result.Summary = new AnalysisSummary
                {
                    TotalContacts = result.Contacts.Count,
                    TiedContacts = result.Contacts.Count,
                    PartsAnalyzed = parts.Count,
                    FacesAnalyzed = allFaces.Count,
                    AnalysisTimeSec = stopwatch.Elapsed.TotalSeconds
                };

                progressCallback?.Invoke(100, 100, "Analysis complete");

                Logger.Separator("접촉 분석 완료");
                Logger.Info(ClassName, $"결과: {result.Contacts.Count}개 접촉 발견 ({result.Summary.AnalysisTimeSec:F2}초 소요)");
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "접촉 분석 중 오류 발생", ex);
                throw;
            }

            Logger.MethodExit(ClassName, "Analyze", result.Contacts.Count);
            return result;
        }

        /// <summary>
        /// 모든 파트의 면 데이터 수집
        /// </summary>
        private List<FaceData> CollectFaceData(List<Part> parts, ContactAnalysisResult result)
        {
            List<FaceData> allFaces = new List<FaceData>();

            foreach (Part part in parts)
            {
                string partName = part.Leaf;
                int faceCount = 0;

                foreach (Body body in part.Bodies)
                {
                    Face[] faces = body.GetFaces();

                    for (int i = 0; i < faces.Length; i++)
                    {
                        Face face = faces[i];

                        try
                        {
                            // Bounding Box 계산
                            BoundingBox3D bb = GetFaceBoundingBox(face);
                            if (bb == null) continue;

                            // 면 유형 확인
                            string faceType = GetFaceType(face);

                            FaceData faceData = new FaceData
                            {
                                NxFace = face,
                                OwnerPart = part,
                                FaceIndex = faceCount,
                                BoundingBox = bb,
                                FaceType = faceType,
                                PartName = partName
                            };

                            allFaces.Add(faceData);
                            faceCount++;
                        }
                        catch (Exception ex)
                        {
                            Logger.Debug(ClassName, $"면 데이터 수집 실패: {partName}.Face{i} - {ex.Message}");
                        }
                    }
                }

                // 파트 정보 추가
                result.Parts.Add(new PartInfo
                {
                    Name = partName,
                    StepFile = $"{partName}.step",
                    FaceCount = faceCount
                });

                Logger.Debug(ClassName, $"파트 {partName}: {faceCount}개 면 수집");
            }

            return allFaces;
        }

        /// <summary>
        /// 면의 Bounding Box 계산
        /// </summary>
        private BoundingBox3D GetFaceBoundingBox(Face face)
        {
            try
            {
                // AskBoundingBox는 6개 값 배열 반환 (minX, minY, minZ, maxX, maxY, maxZ)
                double[] bbox = new double[6];
                _ufSession.Modl.AskBoundingBox(face.Tag, bbox);

                return new BoundingBox3D(
                    bbox[0], bbox[1], bbox[2],
                    bbox[3], bbox[4], bbox[5]
                );
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 면 유형 확인
        /// </summary>
        private string GetFaceType(Face face)
        {
            try
            {
                int faceType;
                _ufSession.Modl.AskFaceType(face.Tag, out faceType);

                switch (faceType)
                {
                    case 16: return "PLANAR";
                    case 17: return "CYLINDRICAL";
                    case 18: return "CONICAL";
                    case 19: return "SPHERICAL";
                    case 20: return "TOROIDAL";
                    case 22: return "BSURF";
                    case 23: return "BLEND";
                    default: return "OTHER";
                }
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 두 면 간 접촉 검사
        /// </summary>
        private ContactPair CheckContact(FaceData face1, FaceData face2, int contactId)
        {
            try
            {
                double[] pt1 = new double[3];
                double[] pt2 = new double[3];
                double minDist;

                _ufSession.Modl.AskMinimumDist(
                    face1.NxFace.Tag, face2.NxFace.Tag,
                    0, new double[3],
                    0, new double[3],
                    out minDist, pt1, pt2);

                // 접촉 판정
                if (minDist <= _tolerance)
                {
                    // 접촉 면적 계산 (선택적)
                    double contactArea = EstimateContactArea(face1, face2);

                    // 접촉점 (두 점의 중간)
                    double[] contactPoint = new double[]
                    {
                        (pt1[0] + pt2[0]) / 2.0,
                        (pt1[1] + pt2[1]) / 2.0,
                        (pt1[2] + pt2[2]) / 2.0
                    };

                    return new ContactPair
                    {
                        Id = contactId,
                        ContactType = "tied",
                        Part1 = new PartFaceInfo
                        {
                            PartName = face1.PartName,
                            FaceId = face1.FaceIndex,
                            FaceType = face1.FaceType
                        },
                        Part2 = new PartFaceInfo
                        {
                            PartName = face2.PartName,
                            FaceId = face2.FaceIndex,
                            FaceType = face2.FaceType
                        },
                        MinDistanceMm = minDist,
                        ContactAreaMm2 = contactArea,
                        ContactPoint = contactPoint
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.Debug(ClassName, $"접촉 검사 실패: {face1} <-> {face2} - {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// 접촉 면적 추정 (BB 겹침 영역 기반)
        /// </summary>
        private double EstimateContactArea(FaceData face1, FaceData face2)
        {
            try
            {
                // 두 BB의 겹침 영역 계산
                var bb1 = face1.BoundingBox;
                var bb2 = face2.BoundingBox;

                double overlapX = Math.Max(0, Math.Min(bb1.MaxX, bb2.MaxX) - Math.Max(bb1.MinX, bb2.MinX));
                double overlapY = Math.Max(0, Math.Min(bb1.MaxY, bb2.MaxY) - Math.Max(bb1.MinY, bb2.MinY));
                double overlapZ = Math.Max(0, Math.Min(bb1.MaxZ, bb2.MaxZ) - Math.Max(bb1.MinZ, bb2.MinZ));

                // 가장 얇은 축을 제외한 두 축의 곱을 면적으로 추정
                double[] overlaps = { overlapX, overlapY, overlapZ };
                Array.Sort(overlaps);

                return overlaps[1] * overlaps[2];
            }
            catch
            {
                return 0.0;
            }
        }
    }
}
