public static class Keypad
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] {new GuiButton("Button1", "1", OnClick, 20, 20, backgroundColor: new int[] { 253,246,197 }), new GuiButton("Button2", "2", OnClick, 20, 20, backgroundColor: new int[] { 253, 246, 197 }) },
        new GuiRow[] { new GuiButton("Button3", "3", OnClick, 20, 20, backgroundColor: new int[] { 253, 246, 197 }), new GuiButton("Button4", "4", OnClick, 20, 20, backgroundColor: new int[] { 253, 246, 197 }) }
    };

    public static string defaultMessage = "press ";

    private static int Pressed = 0;

    public static void Init()
    {
        Pressed = 0;
    }

    private static void OnClick(string name)
    {
        name.HideElemenet(true);
        name = name.Replace("Button", "");
        TP.Message = TP.Message + name + " ";
        if (++Pressed == 4) TP.Done();
    }
}