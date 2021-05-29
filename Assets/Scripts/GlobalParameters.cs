using System;
public class GlobalParameters
{
    private static int heliID = 0;

    public static int HeliID
    {
        get { return heliID; }
        set { heliID = value; }
    }
}
