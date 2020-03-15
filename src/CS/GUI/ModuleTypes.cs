using System;
using System.Collections.Generic;

public static class ModuleTypes
{
    public static Dictionary<string, Type> ModuleTypeDict = new Dictionary<string, Type>()          //Please keep this dictionary alphabetically sorted!
    {
        {"Egg", typeof(Egg) },
        {"Keypad", typeof(Keypad) },
        {"Morsematics", typeof(MorseMatics) },
        {"Two Bits", typeof(TwoBits) },
        {"Wires", typeof(Wires) }
    };
}