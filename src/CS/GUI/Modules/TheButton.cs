public static class TheButton
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiDropdown("Mode", "Mode", new string[] { "Tap", "Hold", "Release" }, OnModeChange)
        },
        new GuiRow[]
        {
            new GuiDropdown("Seconds", "Seconds", new string[] {"1", "4", "5" }, OnSecondsChange)
        }
    };

    private static GuiDropdown ModeDropdown => GuiElements[0][0] as GuiDropdown;
    private static GuiDropdown SecondsDropdown => GuiElements[1][0] as GuiDropdown;

    public static void Init()
    {
        ModeDropdown.SetDefault();
        SecondsDropdown.Hide(false);
    }

    public static void DoneOverride()
    {
        if (TP.Message != $"!{TP.moduleID} " && ModeDropdown.Selected != "Release" ? true : SecondsDropdown.Selected != "Seconds") TP.Done();
    }

    private static void OnModeChange(string name, string value)
    {
        if (value == "Release") SecondsDropdown.Show();
        else { SecondsDropdown.Hide(false); }
        TP.Message = $"!{TP.moduleID} {value.ToLowerInvariant()}{(value == "Release" ? " " : "")}";
    }

    private static void OnSecondsChange(string name, string value)
    {
        TP.Message = $"!{TP.moduleID} release {value}";
    }
}