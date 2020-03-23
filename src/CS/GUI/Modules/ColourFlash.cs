public static class ColourFlash
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiDropdown("Answer", "Answer", new string[] { "Yes", "No" }, (n, v) => { })
        },
        new GuiRow[]
        {
            new GuiUpDown("Index", (v) => { }, null, 1, 8, watermark: "Index of word to press")
        }
    };

    public static string defaultMessage = "press ";

    public static void Init()
    {
        (GuiElements[0][0] as GuiDropdown).SetDefault();
    }

    public static void DoneOverride()
    {
        if((GuiElements[0][0] as GuiDropdown).Selected=="Answer" || (GuiElements[1][0] as GuiUpDown).Value==null) return;
        TP.AppendToMessage($"{(GuiElements[0][0] as GuiDropdown).Selected.ToLowerInvariant()} {(GuiElements[1][0] as GuiUpDown).Value}");
        TP.Done();
    }
}