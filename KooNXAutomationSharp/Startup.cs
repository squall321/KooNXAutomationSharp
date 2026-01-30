using System;
using NXOpen;

/// <summary>
/// KooNXAutomationSharp 시작점 클래스
/// NX에서 DLL 로드 시 자동으로 호출됨
/// </summary>
public class Startup
{
    private static Session theSession = null;
    private static UI theUI = null;

    /// <summary>
    /// NX 진입점
    /// </summary>
    public static void Main()
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
        }
        catch (Exception ex)
        {
            try
            {
                if (theUI == null) theUI = UI.GetUI();
                theUI.NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.ToString());
            }
            catch
            {
                // ignore
            }
        }
    }

    /// <summary>
    /// NX 언로드 옵션
    /// </summary>
    public static int GetUnloadOption(string arg)
    {
        return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
    }

    /// <summary>
    /// DLL 언로드 시 호출
    /// </summary>
    public static void UnloadLibrary(string arg)
    {
        try
        {
            // cleanup
        }
        catch (Exception ex)
        {
            theUI.NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
}
