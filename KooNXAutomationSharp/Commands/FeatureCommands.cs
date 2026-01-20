using System;
using NXOpen;
using NXOpen.Features;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Commands
{
    /// <summary>
    /// Feature 관련 메뉴 명령어 클래스
    /// NX 메뉴/리본에서 호출되는 피처 기능들
    /// </summary>
    public class FeatureCommands
    {
        private const string ClassName = "FeatureCommands";

        /// <summary>
        /// Extrude 명령 (선택된 스케치/커브 기반)
        /// </summary>
        public static void Extrude()
        {
            Logger.MethodEntry(ClassName, "Extrude");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    ShowMessage(session, "Error: No work part available.");
                    return;
                }

                Logger.Info(ClassName, $"Work Part: {workPart.Name}");

                // ExtrudeBuilder 생성
                ExtrudeBuilder extrudeBuilder = workPart.Features.CreateExtrudeBuilder(null);

                try
                {
                    // 사용자에게 섹션 선택 안내
                    ShowMessage(session, "Extrude Feature: Please select a sketch or curves, then use NX native Extrude dialog.");
                    ShowMessage(session, "Hint: Use Insert > Design Feature > Extrude in NX.");

                    Logger.Info(ClassName, "Extrude 기능 안내 메시지 출력");

                    // 참고: 실제 구현에서는 UI를 통한 선택 후 처리
                    // extrudeBuilder.Section - 섹션 설정
                    // extrudeBuilder.Limits.StartExtend.Value.RightHandSide = "0"
                    // extrudeBuilder.Limits.EndExtend.Value.RightHandSide = "50"
                }
                finally
                {
                    extrudeBuilder.Destroy();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "Extrude 기능 중 오류 발생", ex);
                ShowMessage(session, $"Error in Extrude: {ex.Message}");
            }

            Logger.MethodExit(ClassName, "Extrude");
        }

        /// <summary>
        /// Chamfer 명령 (선택된 엣지에 모따기)
        /// </summary>
        public static void Chamfer()
        {
            Logger.MethodEntry(ClassName, "Chamfer");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    ShowMessage(session, "Error: No work part available.");
                    return;
                }

                Logger.Info(ClassName, $"Work Part: {workPart.Name}");

                // ChamferBuilder 생성
                ChamferBuilder chamferBuilder = workPart.Features.CreateChamferBuilder(null);

                try
                {
                    // 기본 설정
                    chamferBuilder.Option = ChamferBuilder.ChamferOption.SymmetricOffsets;
                    chamferBuilder.FirstOffset = "5"; // 5mm 모따기

                    Logger.Debug(ClassName, "Chamfer 기본 설정: 5mm 대칭 모따기");

                    // 사용자에게 엣지 선택 안내
                    ShowMessage(session, "Chamfer Feature: Default 5mm symmetric chamfer configured.");
                    ShowMessage(session, "Please select edges to chamfer using NX selection tools.");

                    Logger.Info(ClassName, "Chamfer 기능 안내 메시지 출력");
                }
                finally
                {
                    chamferBuilder.Destroy();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "Chamfer 기능 중 오류 발생", ex);
                ShowMessage(session, $"Error in Chamfer: {ex.Message}");
            }

            Logger.MethodExit(ClassName, "Chamfer");
        }

        /// <summary>
        /// Fillet (Edge Blend) 명령
        /// </summary>
        public static void Fillet()
        {
            Logger.MethodEntry(ClassName, "Fillet");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    ShowMessage(session, "Error: No work part available.");
                    return;
                }

                Logger.Info(ClassName, $"Work Part: {workPart.Name}");

                // EdgeBlendBuilder 생성
                EdgeBlendBuilder blendBuilder = workPart.Features.CreateEdgeBlendBuilder(null);

                try
                {
                    Logger.Debug(ClassName, "Fillet 기본 설정 준비");

                    // 사용자에게 엣지 선택 안내
                    ShowMessage(session, "Fillet (Edge Blend) Feature: Ready to apply fillet.");
                    ShowMessage(session, "Please select edges to fillet using NX selection tools.");

                    Logger.Info(ClassName, "Fillet 기능 안내 메시지 출력");
                }
                finally
                {
                    blendBuilder.Destroy();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "Fillet 기능 중 오류 발생", ex);
                ShowMessage(session, $"Error in Fillet: {ex.Message}");
            }

            Logger.MethodExit(ClassName, "Fillet");
        }

        /// <summary>
        /// 메시지 출력 헬퍼
        /// </summary>
        private static void ShowMessage(Session session, string message)
        {
            if (session != null)
            {
                session.ListingWindow.Open();
                session.ListingWindow.WriteLine(message);
            }
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
