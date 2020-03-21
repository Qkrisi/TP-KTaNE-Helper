using static System.Math;

public static class SimonSays
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiEmpty(HeightP, 40),
            new GuiButton("Blue", "", OnClick, 20, 20, 45, new int[] { 0,0,255 })
        },
        new GuiRow[]
        {
            new GuiEmpty(HeightP, 30-HeightP),
            new GuiButton("Red", "", OnClick, 20, 20, 45, new int[] { 255,0,0 }),
            new GuiEmpty(1, HeightP*1.5),
            new GuiButton("Yellow", "", OnClick, 20, 20, 45, new int[] { 255,255,0 })
        },
        new GuiRow[]
        {
            new GuiEmpty(HeightP, 40),
            new GuiButton("Green", "", OnClick, 20, 20, 45, new int[] { 0,255,0 })
        },
    };

    public static string defaultMessage = "press";

    private static double HeightP => Sqrt(200);

    private static void OnClick(string name)
    {
        TP.AppendToMessage($" {name}");
    }
}