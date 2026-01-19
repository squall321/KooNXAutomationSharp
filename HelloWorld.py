import NXOpen

def main():
    theSession = NXOpen.Session.GetSession()
    theSession.ListingWindow.Open()
    theSession.ListingWindow.WriteLine("Hello from Python!")

    workPart = theSession.Parts.Work
    if workPart:
        theSession.ListingWindow.WriteLine("Current Part: " + workPart.Name)
    else:
        theSession.ListingWindow.WriteLine("No part is currently open.")

if __name__ == "__main__":
    main()
