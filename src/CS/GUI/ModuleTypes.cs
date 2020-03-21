using System;
using System.Collections.Generic;

public static class ModuleTypes
{
    public static Dictionary<string, Type> ModuleTypeDict = new Dictionary<string, Type>()          //Please keep this dictionary alphabetically sorted!
    {
        {"% Grey", typeof(PercentageGrey) },
        {"Egg", typeof(Egg) },
        {"Forget Me Not", typeof(ForgetMeNot) },
        {"Keypad", typeof(Keypad) },
        {"Morsematics", typeof(MorseMatics) },
        {"Murder", typeof(Murder) },
        {"Two Bits", typeof(TwoBits) },
        {"Wires", typeof(Wires) },
        {"Wire Sequence", typeof(WireSequence) }
    };
}