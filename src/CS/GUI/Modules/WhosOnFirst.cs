using System.Collections.Generic;

public static class WhosOnFirst
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiText("Select a button to press:")
        },
        new GuiRow[]
        {
            new GuiButton("TL", "Top left", OnPress, width:75, backgroundColor: new int[] { 204, 185, 151 }),
            new GuiButton("TR", "Top right", OnPress, width:75, backgroundColor: new int[] { 204, 185, 151 })
        },
        new GuiRow[]
        {
            new GuiButton("ML", "Middle left", OnPress, width:75, backgroundColor: new int[] { 204, 185, 151 }),
            new GuiButton("MR", "Middle right", OnPress, width:75, backgroundColor: new int[] { 204, 185, 151 })
        },
        new GuiRow[]
        {
            new GuiButton("BL", "Bottom left", OnPress, width:75, backgroundColor: new int[] { 204, 185, 151 }),
            new GuiButton("BR", "Bottom right", OnPress, width:75, backgroundColor: new int[] { 204, 185, 151 })
        },
        new GuiRow[]
        {
            new GuiEmpty(5, 150)
        },
        new GuiRow[]
        {
            new GuiTextBox("Or enter a word to press", OnChange)
        }
    };

    private static readonly Dictionary<string, string> Positions = new Dictionary<string, string>()
    {
        {"TL", "1" },
        {"TR", "2" },
        {"ML", "3" },
        {"MR", "4" },
        {"BL", "5" },
        {"BR", "6" }
    };

    public static string defaultMessage = "press ";

    private static void OnPress(string name)
    {
        TP.AppendToMessage(Positions[name]);
        TP.Done();
    }

    private static void OnChange(string text)
    {
        TP.Message = $"!{TP.moduleID} press {text}";
    }
}