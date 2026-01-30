using System;
using System.Collections.Generic;
using NXOpen;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Features.StepExporter
{
    /// <summary>
    /// 3D Bounding Box
    /// </summary>
    public class BoundingBox3D
    {
        public double MinX { get; set; }
        public double MinY { get; set; }
        public double MinZ { get; set; }
        public double MaxX { get; set; }
        public double MaxY { get; set; }
        public double MaxZ { get; set; }

        public BoundingBox3D() { }

        public BoundingBox3D(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            MinX = minX; MinY = minY; MinZ = minZ;
            MaxX = maxX; MaxY = maxY; MaxZ = maxZ;
        }

        /// <summary>
        /// 중심점
        /// </summary>
        public double[] Center => new double[]
        {
            (MinX + MaxX) / 2.0,
            (MinY + MaxY) / 2.0,
            (MinZ + MaxZ) / 2.0
        };

        /// <summary>
        /// 크기
        /// </summary>
        public double[] Size => new double[]
        {
            MaxX - MinX,
            MaxY - MinY,
            MaxZ - MinZ
        };

        /// <summary>
        /// 다른 BB와 겹치는지 확인
        /// </summary>
        public bool Intersects(BoundingBox3D other)
        {
            if (other == null) return false;

            return !(MaxX < other.MinX || MinX > other.MaxX ||
                     MaxY < other.MinY || MinY > other.MaxY ||
                     MaxZ < other.MinZ || MinZ > other.MaxZ);
        }

        /// <summary>
        /// 마진을 추가한 확장 BB
        /// </summary>
        public BoundingBox3D Expand(double margin)
        {
            return new BoundingBox3D(
                MinX - margin, MinY - margin, MinZ - margin,
                MaxX + margin, MaxY + margin, MaxZ + margin
            );
        }

        /// <summary>
        /// 점이 BB 내부에 있는지 확인
        /// </summary>
        public bool Contains(double x, double y, double z)
        {
            return x >= MinX && x <= MaxX &&
                   y >= MinY && y <= MaxY &&
                   z >= MinZ && z <= MaxZ;
        }

        /// <summary>
        /// 다른 BB를 완전히 포함하는지 확인
        /// </summary>
        public bool Contains(BoundingBox3D other)
        {
            if (other == null) return false;
            return MinX <= other.MinX && MaxX >= other.MaxX &&
                   MinY <= other.MinY && MaxY >= other.MaxY &&
                   MinZ <= other.MinZ && MaxZ >= other.MaxZ;
        }

        /// <summary>
        /// 두 BB를 합친 BB 반환
        /// </summary>
        public static BoundingBox3D Union(BoundingBox3D a, BoundingBox3D b)
        {
            if (a == null) return b;
            if (b == null) return a;

            return new BoundingBox3D(
                Math.Min(a.MinX, b.MinX), Math.Min(a.MinY, b.MinY), Math.Min(a.MinZ, b.MinZ),
                Math.Max(a.MaxX, b.MaxX), Math.Max(a.MaxY, b.MaxY), Math.Max(a.MaxZ, b.MaxZ)
            );
        }
    }

    /// <summary>
    /// 면 데이터 (Octree에 저장되는 요소)
    /// </summary>
    public class FaceData
    {
        public Face NxFace { get; set; }
        public Part OwnerPart { get; set; }
        public int FaceIndex { get; set; }
        public BoundingBox3D BoundingBox { get; set; }
        public string FaceType { get; set; }
        public string PartName { get; set; }

        public override string ToString()
        {
            return $"{PartName}.Face{FaceIndex} ({FaceType})";
        }
    }

    /// <summary>
    /// Octree 노드
    /// </summary>
    public class OctreeNode
    {
        public BoundingBox3D Bounds { get; private set; }
        public List<FaceData> Faces { get; private set; }
        public OctreeNode[] Children { get; private set; }
        public int Depth { get; private set; }

        public bool IsLeaf => Children == null;

        private readonly int _maxFacesPerNode;
        private readonly int _maxDepth;

        public OctreeNode(BoundingBox3D bounds, int depth, int maxFacesPerNode, int maxDepth)
        {
            Bounds = bounds;
            Depth = depth;
            Faces = new List<FaceData>();
            _maxFacesPerNode = maxFacesPerNode;
            _maxDepth = maxDepth;
        }

        /// <summary>
        /// 면 삽입
        /// </summary>
        public void Insert(FaceData face)
        {
            // 이 노드의 영역과 겹치지 않으면 무시
            if (!Bounds.Intersects(face.BoundingBox))
                return;

            // 리프 노드인 경우
            if (IsLeaf)
            {
                Faces.Add(face);

                // 분할 조건: 면 개수 초과 && 최대 깊이 미달
                if (Faces.Count > _maxFacesPerNode && Depth < _maxDepth)
                {
                    Subdivide();
                }
            }
            else
            {
                // 자식 노드들에 삽입
                foreach (var child in Children)
                {
                    child.Insert(face);
                }
            }
        }

        /// <summary>
        /// 8분할
        /// </summary>
        private void Subdivide()
        {
            Children = new OctreeNode[8];

            double[] center = Bounds.Center;
            double midX = center[0];
            double midY = center[1];
            double midZ = center[2];

            // 8개 자식 노드 생성
            Children[0] = new OctreeNode(new BoundingBox3D(Bounds.MinX, Bounds.MinY, Bounds.MinZ, midX, midY, midZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[1] = new OctreeNode(new BoundingBox3D(midX, Bounds.MinY, Bounds.MinZ, Bounds.MaxX, midY, midZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[2] = new OctreeNode(new BoundingBox3D(Bounds.MinX, midY, Bounds.MinZ, midX, Bounds.MaxY, midZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[3] = new OctreeNode(new BoundingBox3D(midX, midY, Bounds.MinZ, Bounds.MaxX, Bounds.MaxY, midZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[4] = new OctreeNode(new BoundingBox3D(Bounds.MinX, Bounds.MinY, midZ, midX, midY, Bounds.MaxZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[5] = new OctreeNode(new BoundingBox3D(midX, Bounds.MinY, midZ, Bounds.MaxX, midY, Bounds.MaxZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[6] = new OctreeNode(new BoundingBox3D(Bounds.MinX, midY, midZ, midX, Bounds.MaxY, Bounds.MaxZ), Depth + 1, _maxFacesPerNode, _maxDepth);
            Children[7] = new OctreeNode(new BoundingBox3D(midX, midY, midZ, Bounds.MaxX, Bounds.MaxY, Bounds.MaxZ), Depth + 1, _maxFacesPerNode, _maxDepth);

            // 기존 면들을 자식 노드로 재분배
            foreach (var face in Faces)
            {
                foreach (var child in Children)
                {
                    child.Insert(face);
                }
            }

            // 이 노드의 면 리스트 클리어
            Faces.Clear();
        }

        /// <summary>
        /// 특정 면과 잠재적으로 접촉할 수 있는 면들 조회
        /// </summary>
        public void GetPotentialContacts(FaceData queryFace, List<FaceData> results)
        {
            // 쿼리 면의 BB가 이 노드와 겹치지 않으면 스킵
            if (!Bounds.Intersects(queryFace.BoundingBox))
                return;

            if (IsLeaf)
            {
                // 리프 노드의 모든 면 추가 (자기 자신 제외)
                foreach (var face in Faces)
                {
                    if (face != queryFace)
                    {
                        results.Add(face);
                    }
                }
            }
            else
            {
                // 자식 노드들 탐색
                foreach (var child in Children)
                {
                    child.GetPotentialContacts(queryFace, results);
                }
            }
        }
    }

    /// <summary>
    /// Octree 메인 클래스
    /// </summary>
    public class Octree
    {
        private OctreeNode _root;
        private readonly int _maxDepth;
        private readonly int _maxFacesPerNode;
        private List<FaceData> _allFaces;
        private double _tolerance;

        public int TotalFaces => _allFaces?.Count ?? 0;

        public Octree(int maxDepth = 8, int maxFacesPerNode = 10, double tolerance = 0.01)
        {
            _maxDepth = maxDepth;
            _maxFacesPerNode = maxFacesPerNode;
            _tolerance = tolerance;
            _allFaces = new List<FaceData>();
        }

        /// <summary>
        /// 면 목록으로 Octree 구축
        /// </summary>
        public void Build(List<FaceData> faces)
        {
            Logger.MethodEntry("Octree", "Build", faces.Count);

            _allFaces = faces;

            if (faces.Count == 0)
            {
                Logger.Warning("Octree", "면 목록이 비어있습니다");
                return;
            }

            // 전체 Bounding Box 계산
            BoundingBox3D totalBounds = null;
            foreach (var face in faces)
            {
                totalBounds = BoundingBox3D.Union(totalBounds, face.BoundingBox);
            }

            // 약간의 마진 추가
            totalBounds = totalBounds.Expand(1.0);

            Logger.Debug("Octree", $"전체 BB: ({totalBounds.MinX:F1}, {totalBounds.MinY:F1}, {totalBounds.MinZ:F1}) ~ ({totalBounds.MaxX:F1}, {totalBounds.MaxY:F1}, {totalBounds.MaxZ:F1})");

            // Root 노드 생성
            _root = new OctreeNode(totalBounds, 0, _maxFacesPerNode, _maxDepth);

            // 모든 면 삽입
            foreach (var face in faces)
            {
                _root.Insert(face);
            }

            Logger.Info("Octree", $"Octree 구축 완료: {faces.Count}개 면");
            Logger.MethodExit("Octree", "Build");
        }

        /// <summary>
        /// 잠재적 접촉 쌍 추출 (같은 파트 내 면은 제외)
        /// </summary>
        public List<(FaceData, FaceData)> GetPotentialContactPairs()
        {
            Logger.MethodEntry("Octree", "GetPotentialContactPairs");

            HashSet<string> checkedPairs = new HashSet<string>();
            List<(FaceData, FaceData)> pairs = new List<(FaceData, FaceData)>();

            foreach (var face in _allFaces)
            {
                List<FaceData> potentialContacts = new List<FaceData>();
                _root?.GetPotentialContacts(face, potentialContacts);

                foreach (var other in potentialContacts)
                {
                    // 같은 파트 내 면은 제외
                    if (face.OwnerPart == other.OwnerPart)
                        continue;

                    // 중복 체크 (A-B와 B-A는 같은 쌍)
                    string pairKey = GetPairKey(face, other);
                    if (checkedPairs.Contains(pairKey))
                        continue;

                    checkedPairs.Add(pairKey);

                    // BB가 겹치는지 최종 확인 (tolerance 확장 적용)
                    BoundingBox3D expandedBB = face.BoundingBox.Expand(_tolerance);
                    if (expandedBB.Intersects(other.BoundingBox))
                    {
                        pairs.Add((face, other));
                    }
                }
            }

            Logger.Info("Octree", $"잠재적 접촉 쌍: {pairs.Count}개");
            Logger.MethodExit("Octree", "GetPotentialContactPairs", pairs.Count);

            return pairs;
        }

        /// <summary>
        /// 쌍 식별 키 생성
        /// </summary>
        private string GetPairKey(FaceData a, FaceData b)
        {
            // 정렬된 순서로 키 생성
            string keyA = $"{a.PartName}_{a.FaceIndex}";
            string keyB = $"{b.PartName}_{b.FaceIndex}";

            return string.Compare(keyA, keyB) < 0
                ? $"{keyA}|{keyB}"
                : $"{keyB}|{keyA}";
        }
    }
}
