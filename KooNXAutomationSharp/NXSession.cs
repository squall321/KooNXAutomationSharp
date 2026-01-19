using NXOpen;
using NXOpen.UF;

namespace KooNXAutomationSharp
{
    /// <summary>
    /// NX 세션 관리 클래스
    /// </summary>
    public static class NXSession
    {
        private static Session _session;
        private static UFSession _ufSession;

        /// <summary>
        /// NX 세션 인스턴스
        /// </summary>
        public static Session Session
        {
            get
            {
                if (_session == null)
                    _session = Session.GetSession();
                return _session;
            }
        }

        /// <summary>
        /// UF 세션 인스턴스
        /// </summary>
        public static UFSession UFSession
        {
            get
            {
                if (_ufSession == null)
                    _ufSession = UFSession.GetUFSession();
                return _ufSession;
            }
        }

        /// <summary>
        /// 현재 작업 파트
        /// </summary>
        public static Part WorkPart
        {
            get { return Session.Parts.Work; }
        }

        /// <summary>
        /// 현재 표시 파트
        /// </summary>
        public static Part DisplayPart
        {
            get { return Session.Parts.Display; }
        }

        /// <summary>
        /// 리스팅 윈도우에 메시지 출력
        /// </summary>
        public static void Log(string message)
        {
            Session.ListingWindow.Open();
            Session.ListingWindow.WriteLine(message);
        }

        /// <summary>
        /// 정보 메시지 박스 표시
        /// </summary>
        public static void ShowInfo(string message)
        {
            UI.GetUI().NXMessageBox.Show("Information", NXMessageBox.DialogType.Information, message);
        }
    }
}
