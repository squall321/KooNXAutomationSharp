using NXOpen;

public class Program
{
    public static void Main()
    {
        Session.GetSession().ListingWindow.Open();
        Session.GetSession().ListingWindow.WriteLine("Hello NX!");
    }

    public static int GetUnloadOption(string arg)
    {
        return (int)Session.LibraryUnloadOption.Immediately;
    }
}
