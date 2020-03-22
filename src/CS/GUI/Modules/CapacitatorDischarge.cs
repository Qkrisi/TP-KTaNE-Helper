public static class CapacitorDischarge
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiUpDown("Seconds", OnChange, null, 1, watermark: "# of seconds to hold")
        }
    };

    public static string defaultMessage = "hold ";

    public static void DoneOverride()
    {
        if (!TP.Message.EndsWith("hold ")) TP.Done();
    }

    private static void OnChange(int value)
    {
        TP.Message = $"!{TP.moduleID} hold {value}";
    }
}