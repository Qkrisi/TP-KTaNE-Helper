public static class Maze
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiEmpty(20, 20),
            new GuiButton("u", "↑", OnClick, 20, 20)
        },
        new GuiRow[]
        {
            new GuiButton("l", "←", OnClick, 20, 20),
            new GuiEmpty(20, 20),
            new GuiButton("r", "→", OnClick, 20, 20),
        },
        new GuiRow[]
        {
            new GuiEmpty(20, 20),
            new GuiButton("d", "↓", OnClick, 20, 20),
        }
    };

    public static string defaultMessage = "move ";
    public static string DoneTextOverride = "Move";

    private static void OnClick(string name)
    {
        TP.AppendToMessage(name);
    }
}