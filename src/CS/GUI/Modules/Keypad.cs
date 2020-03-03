public static class Keypad
{
    public static GuiElement[][] GuiElements = new GuiElement[][] 
    { 
        new GuiRow[] {new GuiButton("Button1", "1", OnClick), new GuiButton("Button2", "2", OnClick) },
        new GuiRow[] { new GuiButton("Button3", "3", OnClick), new GuiButton("Button4", "4", OnClick) } 
    };

    public static string defaultMessage = "!{0} press ";

    public static void OnClick(string name)
    {
        name = name.Replace("Button", "");
        TP.Message = TP.Message + name + " ";
    }
}