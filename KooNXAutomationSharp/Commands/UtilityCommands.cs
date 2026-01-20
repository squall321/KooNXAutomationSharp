using System;
using System.Text;
using NXOpen;
using NXOpen.UF;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Commands
{
    /// <summary>
    /// 유틸리티 관련 메뉴 명령어 클래스
    /// NX 메뉴/리본에서 호출되는 유틸리티 기능들
    /// </summary>
    public class UtilityCommands
    {
        private const string ClassName = "UtilityCommands";

        /// <summary>
        /// 현재 파트 정보 표시
        /// </summary>
        public static void ShowPartInfo()
        {
            Logger.MethodEntry(ClassName, "ShowPartInfo");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                session.ListingWindow.Open();

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    session.ListingWindow.WriteLine("No work part is currently open.");
                    return;
                }

                Logger.Info(ClassName, $"파트 정보 조회: {workPart.Name}");

                StringBuilder info = new StringBuilder();
                info.AppendLine("========================================");
                info.AppendLine("        KooNX Part Information          ");
                info.AppendLine("========================================");
                info.AppendLine();

                // 기본 정보
                info.AppendLine("[Basic Information]");
                info.AppendLine($"  Part Name: {workPart.Name}");
                info.AppendLine($"  Full Path: {workPart.FullPath}");
                info.AppendLine($"  Leaf Name: {workPart.Leaf}");
                info.AppendLine();

                // Feature 정보
                info.AppendLine("[Features]");
                int featureCount = 0;
                foreach (NXOpen.Features.Feature feature in workPart.Features)
                {
                    featureCount++;
                    if (featureCount <= 10)
                    {
                        info.AppendLine($"  {featureCount}. {feature.GetFeatureName()} ({feature.GetType().Name})");
                    }
                }
                if (featureCount > 10)
                {
                    info.AppendLine($"  ... and {featureCount - 10} more features");
                }
                info.AppendLine($"  Total Features: {featureCount}");
                info.AppendLine();

                // Body 정보
                info.AppendLine("[Bodies]");
                int bodyCount = 0;
                foreach (Body body in workPart.Bodies)
                {
                    bodyCount++;
                    if (bodyCount <= 5)
                    {
                        int faceCount = 0;
                        int edgeCount = 0;
                        foreach (Face face in body.GetFaces())
                        {
                            faceCount++;
                        }
                        foreach (Edge edge in body.GetEdges())
                        {
                            edgeCount++;
                        }
                        info.AppendLine($"  Body {bodyCount}: {faceCount} faces, {edgeCount} edges");
                    }
                }
                if (bodyCount > 5)
                {
                    info.AppendLine($"  ... and {bodyCount - 5} more bodies");
                }
                info.AppendLine($"  Total Bodies: {bodyCount}");
                info.AppendLine();

                // Expression 정보
                info.AppendLine("[Expressions]");
                int exprCount = 0;
                foreach (Expression expr in workPart.Expressions)
                {
                    exprCount++;
                    if (exprCount <= 5)
                    {
                        info.AppendLine($"  {expr.Name} = {expr.RightHandSide} ({expr.Units?.TypeName ?? "no unit"})");
                    }
                }
                if (exprCount > 5)
                {
                    info.AppendLine($"  ... and {exprCount - 5} more expressions");
                }
                info.AppendLine($"  Total Expressions: {exprCount}");
                info.AppendLine();

                info.AppendLine("========================================");

                // Listing Window에 출력
                session.ListingWindow.WriteLine(info.ToString());

                // 로그에도 기록
                Logger.Info(ClassName, $"파트 정보: Features={featureCount}, Bodies={bodyCount}, Expressions={exprCount}");
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "파트 정보 조회 중 오류 발생", ex);
                if (session != null)
                {
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine($"Error getting part info: {ex.Message}");
                }
            }

            Logger.MethodExit(ClassName, "ShowPartInfo");
        }

        /// <summary>
        /// 로그 파일 내보내기/열기
        /// </summary>
        public static void ExportLog()
        {
            Logger.MethodEntry(ClassName, "ExportLog");
            Session session = null;

            try
            {
                session = Session.GetSession();
                session.ListingWindow.Open();

                string logPath = Logger.LogFilePath;

                session.ListingWindow.WriteLine("========================================");
                session.ListingWindow.WriteLine("        KooNX Log Information           ");
                session.ListingWindow.WriteLine("========================================");
                session.ListingWindow.WriteLine("");
                session.ListingWindow.WriteLine($"Log file location:");
                session.ListingWindow.WriteLine($"  {logPath}");
                session.ListingWindow.WriteLine("");
                session.ListingWindow.WriteLine("To view the log, open this file in a text editor.");
                session.ListingWindow.WriteLine("");

                // 로그 파일이 존재하면 최근 내용 표시
                if (System.IO.File.Exists(logPath))
                {
                    session.ListingWindow.WriteLine("Last 20 lines of log:");
                    session.ListingWindow.WriteLine("----------------------------------------");

                    string[] lines = System.IO.File.ReadAllLines(logPath);
                    int startIndex = Math.Max(0, lines.Length - 20);

                    for (int i = startIndex; i < lines.Length; i++)
                    {
                        session.ListingWindow.WriteLine(lines[i]);
                    }
                    session.ListingWindow.WriteLine("----------------------------------------");
                }
                else
                {
                    session.ListingWindow.WriteLine("Log file not found or not yet created.");
                }

                session.ListingWindow.WriteLine("========================================");

                Logger.Info(ClassName, "로그 정보 출력 완료");
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "로그 내보내기 중 오류 발생", ex);
                if (session != null)
                {
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine($"Error exporting log: {ex.Message}");
                }
            }

            Logger.MethodExit(ClassName, "ExportLog");
        }

        /// <summary>
        /// About 정보 표시
        /// </summary>
        public static void About()
        {
            Logger.MethodEntry(ClassName, "About");
            Session session = null;

            try
            {
                session = Session.GetSession();
                session.ListingWindow.Open();

                StringBuilder about = new StringBuilder();
                about.AppendLine();
                about.AppendLine("╔════════════════════════════════════════════╗");
                about.AppendLine("║                                            ║");
                about.AppendLine("║       KooNX Automation Sharp               ║");
                about.AppendLine("║       Version 1.0.0                        ║");
                about.AppendLine("║                                            ║");
                about.AppendLine("╠════════════════════════════════════════════╣");
                about.AppendLine("║                                            ║");
                about.AppendLine("║  NX Open C# Automation Toolkit             ║");
                about.AppendLine("║                                            ║");
                about.AppendLine("║  Features:                                 ║");
                about.AppendLine("║  - Parametric modeling tools               ║");
                about.AppendLine("║  - Feature creation commands               ║");
                about.AppendLine("║  - Utility functions                       ║");
                about.AppendLine("║  - File-based logging system               ║");
                about.AppendLine("║                                            ║");
                about.AppendLine("║  GitHub:                                   ║");
                about.AppendLine("║  github.com/squall321/KooNXAutomationSharp ║");
                about.AppendLine("║                                            ║");
                about.AppendLine("╚════════════════════════════════════════════╝");
                about.AppendLine();

                session.ListingWindow.WriteLine(about.ToString());

                Logger.Info(ClassName, "About 정보 출력");
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "About 표시 중 오류 발생", ex);
            }

            Logger.MethodExit(ClassName, "About");
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
