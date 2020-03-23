using System.Collections.Generic;

public static class NoteOverride
{
    public static Dictionary<string, string> BaseOverrides = new Dictionary<string, string>()           //Please keep this dictionary alphabetically sorted! (Except 1st one)
    {
        {"https://ktane.timwi.de", "Notes will show once the repo loads." },
        {"Batteries", "Batteries: \nBattery holders: " },
        {"Colour Flash", "Flashing sequence: " },
        {"Complicated Wires", "Colors: \nLEDs: \nStars: " },
        {"Egg", "EGG :O\nLast number on sticker: " },
        {"Indicators", "Indicators on bomb: " },
        {"Knob", "First row: \nSecond row: " },
        {"Mastermind Cruel", "White: \nMagenta: \nYellow: \nGreen: \nRed: \nBlue: "},
        {"Maze", "Indicators: \nStart: \nFinish: \nMaze: " },
        {"Memory", "Stage 1\nPosition: \nLabel: \n\nStage 2\nPosition: \nLabel: \n\nStage 3\nPosition: \nLabel: \n\nStage 4\nPosition: \nLabel: " },
        {"Morse Code", "Signals: " },
        {"Murder", "Suspects: \nWeapons: \nRoom: " },
        {"Passwod", "1st column letters: \n2nd column letters: \n3rd column letters: \n4th column letters: \n5th column letters: " },
        {"Ports", "Ports on bomb: " },
        {"Simon Says", "Pressed buttons: " },
        {"The Button", "Color: \nText: " },
        {"Wire Sequence", "Red wire occurrence: \nBlue wire occurrence: \nBlack wire occurrence: " }
    };

    public static Dictionary<string, string> UserOverrides = new Dictionary<string, string>();      //Do not modify!
}