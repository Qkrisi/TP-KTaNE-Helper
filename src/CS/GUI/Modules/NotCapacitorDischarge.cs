public static class NotCapacitorDischarge
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiUpDown("Hold", (n, v) => { }, null, 0, 9, watermark: "Digit to hold on")
        },
        new GuiRow[]
        {
            new GuiUpDown("Release", (n, v) => { }, null, 0, 9, watermark: "Digit to release on")
        }
    };

    public static string defaultMessage = "toggle ";

    private static GuiUpDown Hold => GuiElements[0][0] as GuiUpDown;
    private static GuiUpDown Release => GuiElements[1][0] as GuiUpDown;

    public static void DoneOverride()
    {
        if (Hold.Value == null || Release.Value == null) return;
        TP.AppendToMessage($"{Hold.Value} {Release.Value}");
        TP.Done();
    }
}