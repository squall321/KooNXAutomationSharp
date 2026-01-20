using System;
using NXOpen;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Features.StepExporter
{
    /// <summary>
    /// STEP Exporter 메뉴 명령어 진입점
    /// NX 메뉴에서 호출됨
    /// </summary>
    public class StepExporterCommand
    {
        private const string ClassName = "StepExporterCommand";

        /// <summary>
        /// STEP Exporter 대화창 열기
        /// 메뉴에서 호출되는 메인 진입점
        /// </summary>
        public static void ShowDialog()
        {
            Logger.MethodEntry(ClassName, "ShowDialog");

            try
            {
                Session session = Session.GetSession();

                // 파트 확인
                var parts = StepExportHelper.GetAllParts();
                if (parts.Count == 0)
                {
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine("STEP Exporter: No parts loaded in session.");
                    session.ListingWindow.WriteLine("Please open or load parts before using STEP Exporter.");
                    Logger.Warning(ClassName, "로드된 파트 없음");
                    return;
                }

                Logger.Info(ClassName, $"STEP Exporter 대화창 열기 - {parts.Count}개 파트 발견");

                // 대화창 생성 및 표시
                StepExporterDialog dialog = new StepExporterDialog();
                dialog.Show();
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "STEP Exporter 실행 오류", ex);

                try
                {
                    Session session = Session.GetSession();
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine($"STEP Exporter Error: {ex.Message}");
                }
                catch
                {
                    // 무시
                }
            }

            Logger.MethodExit(ClassName, "ShowDialog");
        }

        /// <summary>
        /// NX 언로드 옵션
        /// </summary>
        public static int GetUnloadOption(string arg)
        {
            return (int)Session.LibraryUnloadOption.Immediately;
        }
    }
}
