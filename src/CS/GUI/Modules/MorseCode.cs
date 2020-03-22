public static class MorseCode
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiDropdown
            (
                "Frequency",
                "Frequency",
                new string[]
                {
                    "3.505 MHz",
                    "3.515 MHz",
                    "3.522 MHz",
                    "3.535 MHz",
                    "3.542 MHz",
                    "3.545 MHz",
                    "3.552 MHz",
                    "3.555 MHz",
                    "3.565 MHz",
                    "3.572 MHz",
                    "3.575 MHz",
                    "3.582 MHz",
                    "3.592 MHz",
                    "3.595 MHz",
                    "3.600 MHz"
                },
                OnChange
            )
        }
    };

    public static string defaultMessage = "tx ";
    public static string DoneTextOverride = "Transmit";
    public static string CheckboxOverride = "transmission";

    private static void OnChange(string name, string value)
    {
        TP.Message = $"!{TP.moduleID} tx {value.Replace("3.", "").Replace(" MHz", "")}";
    }

    public static void DoneOverride()
    {
        if (!TP.Message.EndsWith("tx ")) TP.Done();
    }

    public static void Init()
    {
        (GuiElements[0][0] as GuiDropdown).SetDefault();
    }
}