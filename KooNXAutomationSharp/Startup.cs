using System;
using NXOpen;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp
{
    /// <summary>
    /// KooNXAutomationSharp 시작점 클래스
    /// NX에서 DLL 로드 시 자동으로 호출됨
    /// </summary>
    public class Startup
    {
        private const string ClassName = "Startup";
        private static bool _initialized = false;

        /// <summary>
        /// NX 진입점 - 파라미터 없는 버전 (일부 NX 버전용)
        /// </summary>
        public static int Main()
        {
            return Main(new string[0]);
        }

        /// <summary>
        /// NX 진입점 - 파라미터 있는 버전
        /// </summary>
        public static int Main(string[] args)
        {
            if (_initialized)
            {
                return 0;
            }

            try
            {
                // 로거 초기화
                Logger.Initialize();
                Logger.Info(ClassName, "KooNXAutomationSharp 시작");

                Session session = Session.GetSession();
                Logger.Info(ClassName, $"NX Session 획득 완료");

                // 시작 메시지 출력
                session.ListingWindow.Open();
                session.ListingWindow.WriteLine("========================================");
                session.ListingWindow.WriteLine("  KooNX Automation Sharp Loaded!");
                session.ListingWindow.WriteLine("========================================");
                session.ListingWindow.WriteLine("");
                session.ListingWindow.WriteLine("  Menu: Look for 'Koo NX Automation' in the menu bar");
                session.ListingWindow.WriteLine("  Tab:  'Koo Automation' tab in the ribbon");
                session.ListingWindow.WriteLine("");
                session.ListingWindow.WriteLine($"  Log file: {Logger.LogFilePath}");
                session.ListingWindow.WriteLine("");
                session.ListingWindow.WriteLine("========================================");

                _initialized = true;
                Logger.Info(ClassName, "초기화 완료");
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "초기화 중 오류 발생", ex);
                return 1;
            }
        }

        /// <summary>
        /// NX 언로드 옵션
        /// AtTermination: NX 종료 시까지 DLL 유지
        /// </summary>
        public static int GetUnloadOption(string arg)
        {
            Logger.Debug(ClassName, $"GetUnloadOption 호출: {arg}");
            return (int)Session.LibraryUnloadOption.AtTermination;
        }

        /// <summary>
        /// DLL 언로드 시 호출
        /// </summary>
        public static void UnloadLibrary()
        {
            Logger.Info(ClassName, "KooNXAutomationSharp 언로드");
            Logger.EndSession();
        }
    }
}
