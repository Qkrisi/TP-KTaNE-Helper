using System.Collections.Generic;

public static class NoteOverride
{
    public static Dictionary<string, string> BaseOverrides = new Dictionary<string, string>()           //Please keep this dictionary alphabetically sorted! (Except 1st one)
    {
        {"https://ktane.timwi.de", "Notes will show once the repo loads." },
        {"Egg", "EGG :O\nLast number on sticker: " },
        {"Mastermind Cruel", "White: \nMagenta: \nYellow: \nGreen: \nRed: \nBlue: "},
        {"Murder", "Suspects: \nWeapons: \nRoom: " },
    };

    public static Dictionary<string, string> UserOverrides = new Dictionary<string, string>();      //Do not modify!
}