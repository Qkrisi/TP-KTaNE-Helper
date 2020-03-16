public static class PercentageGrey
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] {new GuiUpDown("Percentage", OnChange, null, 0, 100, UpDownFormats.General, 10, watermark:"Percentage")}
    };

    private static void OnChange(int value)
    {
        TP.Message = $"!{TP.moduleID} {value}%";
    }
}