using System.Collections.Generic;

public static class NoteOverride
{
    public static Dictionary<string, string> BaseOverrides = new Dictionary<string, string>()           //Please keep this dictionary alphabetically sorted! (Except 1st one)
    {
        {"https://ktane.timwi.de", "Notes will show once the repo loads." },
        {"Egg", "EGG :O\nLast number on sticker: " },
        {"Mastermind Cruel", "White: \nMagenta: \nYellow: \nGreen: \nRed: \nBlue: "},
        {"Murder", "Suspects: \nWeapons: \nRoom: " },
        {"Passwod", "1st column letters: \n2nd column letters: \n3rd column letters: \n4th column letters: \n5th column letters: " },
        {"Ports", "Ports on bomb: " },
        {"Simon Says", "Pressed buttons: " },
        {"Wire Sequence", "Red wire occurrence: \nBlue wire occurrence: \nBlack wire occurrence: " }
    };

    public static Dictionary<string, string> UserOverrides = new Dictionary<string, string>();      //Do not modify!
}