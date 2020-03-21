public static class Password
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiButton("Toggle", "Toggle", Toggle)
        },
        new GuiRow[]
        {
            new GuiTextBox("Answer word", OnChange)
        }
    };

    private static void OnChange(string text)
    {
        TP.Message = $"!{TP.moduleID} {text}";
    }

    private static void Toggle()
    {
        TP.Message = $"!{TP.moduleID} toggle";
        TP.Done();
    }
}