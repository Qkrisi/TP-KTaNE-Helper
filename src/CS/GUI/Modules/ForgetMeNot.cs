public static class ForgetMeNot
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] {new GuiButton("Button1", "1", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button2", "2", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button3", "3", OnClick, 20, 20), new GuiEmpty(20, 2.5) },
        new GuiRow[] {new GuiEmpty(2, 65)},
        new GuiRow[] {new GuiButton("Button4", "4", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button5", "5", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button6", "6", OnClick, 20, 20), new GuiEmpty(20, 2.5) },
        new GuiRow[] {new GuiEmpty(2, 65)},
        new GuiRow[] {new GuiButton("Button7", "1", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button8", "2", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button3", "9", OnClick, 20, 20), new GuiEmpty(20, 2.5), new GuiButton("Button0", "0", OnClick, 20, 20) }
    };

    public static string defaultMessage = "press ";

    private static void OnClick(string name)
    {
        TP.AppendToMessage(name.Replace("Button", ""));
    }
}