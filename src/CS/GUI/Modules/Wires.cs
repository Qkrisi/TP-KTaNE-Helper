﻿public static class Wires
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[] { new GuiEmpty(20, 40), new GuiButton("Button1", "Wire 1", onClick, 20, 80, new int[] { 255, 0, 0 }) },
        new GuiRow[] { new GuiEmpty(20, 40), new GuiButton("Button2", "Wire 2", onClick, 20, 80, new int[] { 0, 0, 0 }, new int[] { 255, 255, 255 }) },
        new GuiRow[] { new GuiEmpty(20, 40), new GuiButton("Button3", "Wire 3", onClick, 20, 80, new int[] { 255, 255, 0 }) },
        new GuiRow[] { new GuiEmpty(20, 40), new GuiButton("Button4", "Wire 4", onClick, 20, 80, new int[] { 255, 0, 0 }) },
        new GuiRow[] { new GuiEmpty(20, 40), new GuiButton("Button5", "Wire 5", onClick, 20, 80, new int[] { 255, 255, 255 }) },
        new GuiRow[] { new GuiEmpty(20, 40), new GuiButton("Button6", "Wire 6", onClick, 20, 80, new int[] { 0, 0, 255 }) },
    };

    public static string defaultMessage = "cut ";

    private static void onClick(string name)
    {
        TP.Message = $"!{TP.moduleID} cut {name.Replace("Button", "")}";
        TP.Done();
    }
}