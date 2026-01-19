using System;
using NXOpen;

public class Program
{
    public static void Main()
    {
        Session theSession = Session.GetSession();
        theSession.ListingWindow.Open();
        theSession.ListingWindow.WriteLine("Hello from C# Journal!");
    }

    public static int GetUnloadOption(string arg)
    {
        return (int)Session.LibraryUnloadOption.Immediately;
    }
}
