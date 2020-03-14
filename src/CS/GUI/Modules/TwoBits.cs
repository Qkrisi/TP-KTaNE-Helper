public static class TwoBits
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] { new GuiButton("B", "B", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("C", "C", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("D", "D", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("E", "E", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("G", "G", OnButtonPress, 20, 15, 0) },
        new GuiRow[] { new GuiButton("K", "K", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("P", "P", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("T", "T", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("V", "V", OnButtonPress, 20, 15, 0), new GuiEmpty(20, 5), new GuiButton("Z", "Z", OnButtonPress, 20, 15, 0) },
        new GuiRow[] { new GuiButton ("Query", "Query", OnButtonPress, 20, 45), new GuiEmpty(20, 5), new GuiButton("Submit", "Submit", OnButtonPress, 20, 45) }
    };

    public static string defaultMessage = "press ";
 
    private static void OnButtonPress(string name)
    {
        if(name=="Submit" || name=="Query")
        {
            TP.Message = $"{TP.Message} {name}";
            TP.Done();
            return;
        }
        TP.Message = $"{TP.Message}{name}";
    }
}