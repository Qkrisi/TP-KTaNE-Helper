using System.Collections.Generic;

public static class Keypad
{
    public static GuiElement[][] GuiElements = new GuiElement[][] 
    { 
        new GuiRow[] {new GuiButton("Button1", "1", OnClick, 20, 20, new int[] { 253,246,197 }), new GuiButton("Button2", "2", OnClick, 20, 20, new int[] { 253, 246, 197 }) },
        new GuiRow[] { new GuiButton("Button3", "3", OnClick, 20, 20, new int[] { 253, 246, 197 }), new GuiButton("Button4", "4", OnClick, 20, 20, new int[] { 253, 246, 197 }) },
    };

    public static string defaultMessage = "press ";

    public static void OnClick(string name)
    {
        name = name.Replace("Button", "");
        TP.Message = TP.Message + name + " ";
    }
}