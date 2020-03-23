public static class NotWiresword
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiText("Select wires to cut:")
        },
        new GuiRow[]
        {
            new GuiUpDown("FirstWire", OnChange, 1, 1, 6)
        },
        new GuiRow[]
        {
            new GuiUpDown("SecondWire", OnChange, 1, 1, 6)
        },
        new GuiRow[]
        {
            new GuiUpDown("ThirdWire", OnChange, 1, 1, 6)
        },
        new GuiRow[]
        {
            new GuiUpDown("FourthWire", OnChange, 1, 1, 6)
        },
        new GuiRow[]
        {
            new GuiUpDown("FifthWire", OnChange, 1, 1, 6)
        },
        new GuiRow[]
        {
            new GuiUpDown("SixthWire", OnChange, 1, 1, 6)
        },
        new GuiRow[]
        {
            new GuiButton("NewWire", "New Wire", NewWire)
        },
        new GuiRow[]
        {
            new GuiButton("RemoveWire", "Remove Wire", RemoveWire)
        },
        new GuiRow[]
        {
            new GuiEmpty(5, 10)
        },
    };

    private static GuiButton NewButton => (GuiElements[7] as GuiRow[])[0] as GuiButton;
    private static GuiButton RemoveButton => (GuiElements[8] as GuiRow[])[0] as GuiButton;
    private static GuiUpDown Wire1 => (GuiElements[1] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire2 => (GuiElements[2] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire3 => (GuiElements[3] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire4 => (GuiElements[4] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire5 => (GuiElements[5] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire6 => (GuiElements[6] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown[] Wires => new GuiUpDown[] { Wire1, Wire2, Wire3, Wire4, Wire5, Wire6 };
    private static int wireDisplay = 0;
    private static int maxWire => wireDisplay + 1;

    public static string DoneTextOverride = "Done";
    public static string defaultMessage = "cut ";
    public static void Init()
    {
        wireDisplay = 5;
        NewButton.Hide(false);
        RemoveButton.Hide(false);
    }

    public static void DoneOverride()
    {
        TP.Message = $"!{TP.moduleID} cut {Wire1.Value} {(maxWire >= 2 ? $"{Wire2.Value} " : "")}{(maxWire >= 3 ? $"{Wire3.Value} " : "")}{(maxWire >= 4 ? $"{Wire4.Value} " : "")}{(maxWire >= 5 ? $"{Wire5.Value} " : "")}{(maxWire == 6 ? $"{Wire6.Value} " : "")}";
        TP.Done();
    }

    private static void OnChange(string name, int value) { }


    private static void NewWire()
    {
        Wires[++wireDisplay].Show();
        if (wireDisplay == 5)
        {
            NewButton.Hide(false);
        }
        RemoveButton.Show();
    }

    private static void RemoveWire()
    {
        Wires[wireDisplay--].Hide(false);
        if (wireDisplay == 0)
        {
            RemoveButton.Hide(false);
        }
        NewButton.Show();
    }
}