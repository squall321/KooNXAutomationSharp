using System;
using NXOpen;

namespace KooNXAutomationSharp
{
    /// <summary>
    /// KooNXAutomationSharp 시작점 클래스
    /// NX에서 DLL 로드 시 자동으로 호출됨
    /// </summary>
    public class Startup
    {
        private static Session theSession;
        private static UI theUI;

        /// <summary>
        /// NX 진입점
        /// </summary>
        public static int Main(string[] args)
        {
            try
            {
                theSession = Session.GetSession();
                theUI = UI.GetUI();

                // 시작 메시지 출력
                theSession.ListingWindow.Open();
                theSession.ListingWindow.WriteLine("========================================");
                theSession.ListingWindow.WriteLine("  KooNX Automation Sharp Loaded!");
                theSession.ListingWindow.WriteLine("========================================");

                return 0;
            }
            catch (Exception ex)
            {
                try
                {
                    if (theUI == null) theUI = UI.GetUI();
                    theUI.NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.Message);
                }
                catch
                {
                    // ignore
                }
                return 1;
            }
        }

        /// <summary>
        /// NX 언로드 옵션
        /// </summary>
        public static int GetUnloadOption(string dummy)
        {
            return (int)Session.LibraryUnloadOption.Immediately;
        }
    }
}
