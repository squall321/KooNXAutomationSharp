using System;
using NXOpen;

public class Program
{
    private static Session theSession;

    public Program()
    {
        theSession = Session.GetSession();

        theSession.ListingWindow.Open();
        theSession.ListingWindow.WriteLine("Hello from KooNXAutomationSharp!");
        theSession.ListingWindow.WriteLine("NX Version: " + theSession.GetEnvironmentVariableValue("UGII_VERSION"));

        Part workPart = theSession.Parts.Work;
        if (workPart != null)
        {
            theSession.ListingWindow.WriteLine("Current Part: " + workPart.Name);
        }
        else
        {
            theSession.ListingWindow.WriteLine("No part is currently open.");
        }
    }

    public static int Main(string[] args)
    {
        int retValue = 0;
        try
        {
            Program theProgram = new Program();
        }
        catch (NXOpen.NXException ex)
        {
            UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.Message);
        }
        return retValue;
    }

    public static int GetUnloadOption(string arg)
    {
        return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
    }
}
