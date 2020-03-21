public static class VentingGas
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiButton("yes", "Yes", OnPress, width:75, backgroundColor: new int[] { 192, 161, 130 }),
            new GuiButton("no", "No", OnPress, width:75, backgroundColor: new int[] { 192, 161, 130 })
        },
        new GuiRow[]
        {
            new GuiEmpty(5, 10)
        }
    };

    private static void OnPress(string name)
    {
        TP.AppendToMessage(name);
        TP.Done();
    }
}