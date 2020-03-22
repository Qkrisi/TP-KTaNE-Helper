public static class Memory
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiButton("p1", "P1", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 }),
            new GuiButton("p2", "P2", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 }),
            new GuiButton("p3", "P3", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 }),
            new GuiButton("p4", "P4", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 })
        },
        new GuiRow[]
        {
            new GuiButton("l1", "L1", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 }),
            new GuiButton("l2", "L2", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 }),
            new GuiButton("l3", "L3", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 }),
            new GuiButton("l4", "L4", OnClick, 20, 20, backgroundColor: new int[] { 189, 178, 152 })
        }
    };

    private static void OnClick(string name)
    {
        TP.Message = $"!{TP.moduleID} {name[0]} {name[1]}";
        TP.Done();
    }
}