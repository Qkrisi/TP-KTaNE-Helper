public static class MorseMatics
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] { new GuiButton("Long", "-", OnClick, 20, 40 ), new GuiButton("Short", ".", OnClick, 20, 40) },
    };

    public static string defaultMessage = "transmit ";

    public static string DoneTextOverride = "TX";

    private static void OnClick(string name)
    {
        TP.AppendToMessage(name == "Long" ? "-" : ".");
    }
}