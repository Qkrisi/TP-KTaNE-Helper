public static class Egg
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] { new GuiUpDown("Counter", OnChange, minimum:0, maximum:9, watermark:"Time to press egg on")}
    };

    public static string defaultMessage = "press ";
    private static void OnChange(int Value)
    {
        TP.Message = $"!{TP.moduleID} press {Value}";
    }
}