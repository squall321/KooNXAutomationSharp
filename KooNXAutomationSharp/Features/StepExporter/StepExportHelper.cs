using System;
using System.Collections.Generic;
using System.IO;
using NXOpen;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Features.StepExporter
{
    /// <summary>
    /// STEP 파일 추출 결과
    /// </summary>
    public class ExportResult
    {
        public bool Success { get; set; }
        public string PartName { get; set; }
        public string FilePath { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// 일괄 추출 결과
    /// </summary>
    public class BatchExportResult
    {
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public List<ExportResult> Details { get; set; } = new List<ExportResult>();
    }

    /// <summary>
    /// STEP 파일 추출 유틸리티
    /// </summary>
    public static class StepExportHelper
    {
        private const string ClassName = "StepExportHelper";

        /// <summary>
        /// 단일 파트를 STEP 파일로 추출
        /// </summary>
        /// <param name="part">추출할 파트</param>
        /// <param name="outputPath">출력 STEP 파일 경로</param>
        /// <returns>추출 결과</returns>
        public static ExportResult ExportToStep(Part part, string outputPath)
        {
            Logger.MethodEntry(ClassName, "ExportToStep", part.Leaf, outputPath);

            ExportResult result = new ExportResult
            {
                PartName = part.Leaf,
                FilePath = outputPath
            };

            try
            {
                Session session = Session.GetSession();

                // StepCreator 생성
                StepCreator stepCreator = session.DexManager.CreateStepCreator();

                try
                {
                    // STEP 추출 설정
                    stepCreator.ExportAs = StepCreator.ExportAsOption.Ap214;
                    stepCreator.InputFile = part.FullPath;
                    stepCreator.OutputFile = outputPath;
                    stepCreator.FileSaveFlag = false;
                    stepCreator.LayerMask = "1-256";
                    stepCreator.ProcessHoldFlag = true;

                    // 추출 실행
                    NXObject exportResult = stepCreator.Commit();

                    if (exportResult != null || File.Exists(outputPath))
                    {
                        result.Success = true;
                        Logger.Info(ClassName, $"STEP 추출 성공: {part.Leaf} -> {outputPath}");
                    }
                    else
                    {
                        result.Success = false;
                        result.ErrorMessage = "Export completed but file not created";
                        Logger.Warning(ClassName, $"STEP 추출 실패: {part.Leaf} - 파일 생성되지 않음");
                    }
                }
                finally
                {
                    stepCreator.Destroy();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                Logger.Error(ClassName, $"STEP 추출 오류: {part.Leaf}", ex);
            }

            Logger.MethodExit(ClassName, "ExportToStep", result.Success);
            return result;
        }

        /// <summary>
        /// 중복되지 않는 고유한 파일 경로 생성
        /// </summary>
        /// <param name="folder">출력 폴더</param>
        /// <param name="baseName">기본 파일명 (확장자 제외)</param>
        /// <returns>고유한 파일 경로</returns>
        public static string GetUniqueFilePath(string folder, string baseName)
        {
            string extension = ".step";
            string filePath = Path.Combine(folder, baseName + extension);

            if (!File.Exists(filePath))
            {
                return filePath;
            }

            // 중복 시 숫자 추가
            int counter = 1;
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(folder, $"{baseName}_{counter}{extension}");
                counter++;
            }

            return filePath;
        }

        /// <summary>
        /// 여러 파트를 일괄적으로 STEP 파일로 추출
        /// </summary>
        /// <param name="parts">추출할 파트 목록</param>
        /// <param name="outputFolder">출력 폴더</param>
        /// <param name="progressCallback">진행률 콜백 (current, total)</param>
        /// <returns>일괄 추출 결과</returns>
        public static BatchExportResult ExportMultiple(
            List<Part> parts,
            string outputFolder,
            Action<int, int, string> progressCallback = null)
        {
            Logger.MethodEntry(ClassName, "ExportMultiple", parts.Count, outputFolder);
            Logger.Separator("STEP 일괄 추출 시작");

            BatchExportResult batchResult = new BatchExportResult
            {
                TotalCount = parts.Count
            };

            // 출력 폴더 생성
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
                Logger.Info(ClassName, $"출력 폴더 생성: {outputFolder}");
            }

            for (int i = 0; i < parts.Count; i++)
            {
                Part part = parts[i];
                string partName = part.Leaf;

                // 진행률 콜백 호출
                progressCallback?.Invoke(i + 1, parts.Count, partName);

                Logger.Info(ClassName, $"[{i + 1}/{parts.Count}] {partName} 추출 중...");

                // 파일 경로 생성 (중복 처리)
                string outputPath = GetUniqueFilePath(outputFolder, partName);

                // STEP 추출
                ExportResult result = ExportToStep(part, outputPath);
                batchResult.Details.Add(result);

                if (result.Success)
                {
                    batchResult.SuccessCount++;
                }
                else
                {
                    batchResult.FailureCount++;
                }
            }

            Logger.Separator("STEP 일괄 추출 완료");
            Logger.Info(ClassName, $"추출 결과 - 성공: {batchResult.SuccessCount}, 실패: {batchResult.FailureCount}");
            Logger.MethodExit(ClassName, "ExportMultiple");

            return batchResult;
        }

        /// <summary>
        /// 세션에서 모든 로드된 파트 목록 가져오기
        /// </summary>
        /// <returns>파트 목록</returns>
        public static List<Part> GetAllParts()
        {
            Logger.MethodEntry(ClassName, "GetAllParts");

            List<Part> parts = new List<Part>();
            Session session = Session.GetSession();

            foreach (Part part in session.Parts)
            {
                parts.Add(part);
                Logger.Debug(ClassName, $"파트 발견: {part.Leaf}");
            }

            Logger.Info(ClassName, $"총 {parts.Count}개 파트 로드됨");
            Logger.MethodExit(ClassName, "GetAllParts", parts.Count);

            return parts;
        }
    }
}
