using System;
using System.IO;
using System.Text;

namespace KooNXAutomationSharp.Utils
{
    /// <summary>
    /// 파일 기반 로깅 유틸리티 클래스
    /// NX 환경에서 디버깅을 위한 로그 출력 제공
    /// </summary>
    public static class Logger
    {
        private static readonly object _lock = new object();
        private static string _logFilePath;
        private static bool _initialized = false;

        /// <summary>
        /// 로그 레벨
        /// </summary>
        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error
        }

        /// <summary>
        /// 현재 로그 레벨 (이 레벨 이상만 기록)
        /// </summary>
        public static LogLevel CurrentLogLevel { get; set; } = LogLevel.Debug;

        /// <summary>
        /// 로그 파일 경로
        /// </summary>
        public static string LogFilePath
        {
            get
            {
                if (!_initialized)
                {
                    Initialize();
                }
                return _logFilePath;
            }
        }

        /// <summary>
        /// 로거 초기화 (기본 경로 사용)
        /// </summary>
        public static void Initialize()
        {
            string logDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "KooNXAutomationSharp",
                "Logs"
            );
            Initialize(logDir);
        }

        /// <summary>
        /// 로거 초기화 (지정된 디렉토리 사용)
        /// </summary>
        /// <param name="logDirectory">로그 파일 저장 디렉토리</param>
        public static void Initialize(string logDirectory)
        {
            lock (_lock)
            {
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                _logFilePath = Path.Combine(logDirectory, $"KooNX_{timestamp}.log");
                _initialized = true;

                // 초기화 메시지 기록
                WriteLog(LogLevel.Info, "Logger", "===== KooNXAutomationSharp 로거 초기화 =====");
                WriteLog(LogLevel.Info, "Logger", $"로그 파일: {_logFilePath}");
                WriteLog(LogLevel.Info, "Logger", $"시작 시간: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
        }

        /// <summary>
        /// Debug 레벨 로그 기록
        /// </summary>
        public static void Debug(string source, string message)
        {
            WriteLog(LogLevel.Debug, source, message);
        }

        /// <summary>
        /// Info 레벨 로그 기록
        /// </summary>
        public static void Info(string source, string message)
        {
            WriteLog(LogLevel.Info, source, message);
        }

        /// <summary>
        /// Warning 레벨 로그 기록
        /// </summary>
        public static void Warning(string source, string message)
        {
            WriteLog(LogLevel.Warning, source, message);
        }

        /// <summary>
        /// Error 레벨 로그 기록
        /// </summary>
        public static void Error(string source, string message)
        {
            WriteLog(LogLevel.Error, source, message);
        }

        /// <summary>
        /// Exception 정보와 함께 Error 레벨 로그 기록
        /// </summary>
        public static void Error(string source, string message, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine($"  Exception Type: {ex.GetType().FullName}");
            sb.AppendLine($"  Message: {ex.Message}");
            sb.AppendLine($"  StackTrace: {ex.StackTrace}");

            if (ex.InnerException != null)
            {
                sb.AppendLine($"  Inner Exception: {ex.InnerException.Message}");
            }

            WriteLog(LogLevel.Error, source, sb.ToString());
        }

        /// <summary>
        /// 메서드 시작 로깅 (디버깅용)
        /// </summary>
        public static void MethodEntry(string className, string methodName, params object[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($">>> {methodName}(");

            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    sb.Append(parameters[i]?.ToString() ?? "null");
                }
            }
            sb.Append(")");

            WriteLog(LogLevel.Debug, className, sb.ToString());
        }

        /// <summary>
        /// 메서드 종료 로깅 (디버깅용)
        /// </summary>
        public static void MethodExit(string className, string methodName, object result = null)
        {
            string resultStr = result != null ? $" => {result}" : "";
            WriteLog(LogLevel.Debug, className, $"<<< {methodName}{resultStr}");
        }

        /// <summary>
        /// 로그 기록 (내부 메서드)
        /// </summary>
        private static void WriteLog(LogLevel level, string source, string message)
        {
            if (level < CurrentLogLevel)
            {
                return;
            }

            if (!_initialized)
            {
                Initialize();
            }

            lock (_lock)
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
                    string levelStr = level.ToString().ToUpper().PadRight(7);
                    string logLine = $"[{timestamp}] [{levelStr}] [{source}] {message}";

                    using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(logLine);
                    }
                }
                catch
                {
                    // 로깅 실패는 무시 (무한 루프 방지)
                }
            }
        }

        /// <summary>
        /// 구분선 출력
        /// </summary>
        public static void Separator(string title = null)
        {
            if (!_initialized)
            {
                Initialize();
            }

            lock (_lock)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            writer.WriteLine(new string('-', 60));
                        }
                        else
                        {
                            writer.WriteLine($"===== {title} =====");
                        }
                    }
                }
                catch
                {
                    // 로깅 실패는 무시
                }
            }
        }

        /// <summary>
        /// 세션 종료 로깅
        /// </summary>
        public static void EndSession()
        {
            WriteLog(LogLevel.Info, "Logger", $"종료 시간: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            WriteLog(LogLevel.Info, "Logger", "===== KooNXAutomationSharp 세션 종료 =====");
        }
    }
}
