public static class WireSequence
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiText("Select wires to cut:")
        },
        new GuiRow[]
        {
            new GuiUpDown("FirstWire", OnChange, 1, 1, 9)
        },
        new GuiRow[]
        {
            new GuiUpDown("SecondWire", OnChange, 1, 1, 9)
        },
        new GuiRow[]
        {
            new GuiUpDown("ThirdWire", OnChange, 1, 1, 9)
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
            new GuiCheckbox("DownCheck", "Press down", true, OnCheckBox)
        },
        new GuiRow[]
        {
            new GuiButton("OnlyDown", "Down only", OnlyDown)
        }
    };

    private static GuiButton NewButton => (GuiElements[4] as GuiRow[])[0] as GuiButton;
    private static GuiButton RemoveButton => (GuiElements[5] as GuiRow[])[0] as GuiButton;
    private static GuiUpDown Wire1 => (GuiElements[1] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire2 => (GuiElements[2] as GuiRow[])[0] as GuiUpDown;
    private static GuiUpDown Wire3 => (GuiElements[3] as GuiRow[])[0] as GuiUpDown;
    private static GuiCheckbox pressDown => (GuiElements[6] as GuiRow[])[0] as GuiCheckbox;
    private static int maxWire = 1;

    public static string DoneTextOverride = "Down";
    public static string defaultMessage = "cut ";
    public static void Init()
    {
        maxWire = 1;
        Wire2.Hide(false);
        Wire3.Hide(false);
        NewButton.Show();
        RemoveButton.Hide(false);
    }

    public static void DoneOverride()
    {
        TP.Message = $"!{TP.moduleID} cut {Wire1.Value} {(maxWire>=2 ? $"{Wire2.Value} " : "")}{(maxWire == 3 ? $"{Wire3.Value} " : "")}{(pressDown.isChecked ? "d" : "")}";
        TP.Done();
    }

    private static void OnChange(string name, int value) { }
    private static void OnCheckBox(bool value) { }

    private static void OnlyDown()
    {
        TP.Message = $"!{TP.moduleID} down";
        TP.Done();
    }

    private static void NewWire()
    {
        if (maxWire == 1)
        {
            Wire2.Show();
            maxWire++;
        }
        else
        {
            Wire3.Show();
            maxWire++;
            NewButton.Hide(false);
        }
        RemoveButton.Show();
    }

    private static void RemoveWire()
    {
        if(maxWire==3)
        {
            Wire3.Hide(false);
            maxWire--;
        }
        else
        {
            Wire2.Hide(false);
            maxWire--;
            RemoveButton.Hide(false);
        }
        NewButton.Show();
    }
}