public static class Murder
{
    public static GuiElement[][] GuiElements = new GuiElement[][]
    {
        new GuiRow[]
        {
            new GuiButton("Cycle", "Cycle", Cycle)
        },
        new GuiRow[]
        {
            new GuiDropdown
            (
                "Suspects",
                new GuiDroppableRow[]
                {
                    new GuiText("Suspect", textColor:new int[] {109,109,109 })
                },
                "Suspect",
                new GuiDroppable[][]
                {
                    new GuiDroppableRow[]
                    {
                        new GuiImage(ImageSource.File, @"Murder\Red.png", 10, 10),
                        new GuiText(" Miss Scarlett", textColor: new int[] {255,0,0})
                    },
                    new GuiDroppableRow[]
                    {
                        new GuiImage(ImageSource.File, @"Murder\Purple.png", 10, 10),
                        new GuiText(" Professor Plum", textColor: new int[] {114,34,201})
                    },
                    new GuiDroppableRow[]
                    {
                        new GuiImage(ImageSource.File, @"Murder\Blue.png", 10, 10),
                        new GuiText(" Mrs Peacock", textColor: new int[] {0,0,255})
                    },
                    new GuiDroppableRow[]
                    {
                        new GuiImage(ImageSource.File, @"Murder\Green.png", 10, 10),
                        new GuiText(" Reverend Green", textColor: new int[] {0,255,0})
                    },
                    new GuiDroppableRow[]
                    {
                        new GuiImage(ImageSource.File, @"Murder\Yellow.png", 10, 10),
                        new GuiText(" Colonel Mustard", textColor: new int[] {255,200,0})
                    },
                    new GuiDroppableRow[]
                    {
                        new GuiEmpty(10, 10),
                        new GuiText(" Mrs White")
                    },
                },
                new string[]
                {
                    "Scarlett",
                    "Plum",
                    "Peacock",
                    "Green",
                    "Mustard",
                    "White"
                },
                (n, v) => { }
            ),
            new GuiDropdown
            (
                "Weapons",
                "Weapon",
                new string[]
                {
                    "Candlestick",
                    "Dagger",
                    "Lead pipe",
                    "Revolver",
                    "Rope",
                    "Spanner"
                },
                (n, v) => { }
            ),
            new GuiDropdown
            (
                "Rooms",
                "Room",
                new string[]
                {
                "Dining Room",
                "Study",
                "Kitchen", 
                "Lounge", 
                "Billiard Room", 
                "Conservatory", 
                "Ballroom", 
                "Hall", 
                "Library"
                },
                (n, v) => { }
            )
        }
    };

    public static string DoneTextOverride = "Accuse";
    public static string CheckboxOverride = "accusation";

    private static GuiDropdown Suspects => GuiElements[1][0] as GuiDropdown;
    private static GuiDropdown Weapons => GuiElements[1][1] as GuiDropdown;
    private static GuiDropdown Rooms => GuiElements[1][2] as GuiDropdown;

    public static void DoneOverride()
    {
        if (Suspects.Selected == "Suspect" || Weapons.Selected == "Weapon" || Rooms.Selected == "Room") return;
        TP.AppendToMessage($"It was {Suspects.Selected}, with the {Weapons.Selected}, in the {Rooms.Selected}");
        TP.Done();
    }

    private static void Cycle()
    {
        TP.AppendToMessage("cycle all");
        TP.Done();
    }
}