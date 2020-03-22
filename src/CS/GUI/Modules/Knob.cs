public static class Knob
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiUpDown("Turner", OnChange, null, 1, 3, watermark:"# of turns")
        }
    };

    public static string defaultMessage = "turn ";

    public static void DoneOverride()
    {
        if (!TP.Message.EndsWith("turn ")) TP.Done();
    }

    private static void OnChange(int value)
    {
        TP.Message = $"!{TP.moduleID} turn {value}";
    }
}