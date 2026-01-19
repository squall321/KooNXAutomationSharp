import nxopen.*;

public class HelloWorld {
    public static void main(String[] args) throws Exception {
        Session theSession = (Session) SessionFactory.get("Session");
        theSession.listingWindow().open();
        theSession.listingWindow().writeLine("Hello from Java!");

        Part workPart = theSession.parts().work();
        if (workPart != null) {
            theSession.listingWindow().writeLine("Current Part: " + workPart.name());
        } else {
            theSession.listingWindow().writeLine("No part is currently open.");
        }
    }

    public static int getUnloadOption() {
        return Session.LibraryUnloadOption.IMMEDIATELY;
    }
}
