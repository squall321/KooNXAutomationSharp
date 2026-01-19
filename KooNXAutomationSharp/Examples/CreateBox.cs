using System;
using NXOpen;
using NXOpen.Features;

namespace KooNXAutomationSharp.Examples
{
    public class CreateBox
    {
        public static void Main()
        {
            Session theSession = Session.GetSession();
            Part workPart = theSession.Parts.Work;

            if (workPart == null)
            {
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Error,
                    "Please open a part first.");
                return;
            }

            try
            {
                BlockFeatureBuilder blockBuilder = workPart.Features.CreateBlockFeatureBuilder(null);

                Point3d origin = new Point3d(0, 0, 0);
                blockBuilder.SetOriginAndLengths(origin, "100", "100", "100");

                NXObject block = blockBuilder.Commit();
                blockBuilder.Destroy();

                theSession.ListingWindow.Open();
                theSession.ListingWindow.WriteLine("100x100x100 box created.");
            }
            catch (Exception ex)
            {
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.Message);
            }
        }

        public static int GetUnloadOption(string dummy)
        {
            return (int)Session.LibraryUnloadOption.Immediately;
        }
    }
}
