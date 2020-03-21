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
        {"Password", typeof(Password) },
        {"Simon Says", typeof(SimonSays) },
        {"Two Bits", typeof(TwoBits) },
        {"Venting Gas", typeof(VentingGas) },
        {"Who’s on First", typeof(WhosOnFirst) },
        {"Wires", typeof(Wires) },
        {"Wire Sequence", typeof(WireSequence) }
    };
}