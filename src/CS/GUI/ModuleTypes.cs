using System;
using System.Collections.Generic;

public static class ModuleTypes
{
    public static Dictionary<string, Type> ModuleTypeDict = new Dictionary<string, Type>()          //Please keep this dictionary alphabetically sorted!
    {
        {"% Grey", typeof(PercentageGrey) },
        {"Capacitor Discharge", typeof(CapacitorDischarge) },
        {"Complicated Wires", typeof(ComplicatedWires) },
        {"Egg", typeof(Egg) },
        {"Forget Me Not", typeof(ForgetMeNot) },
        {"Keypad", typeof(Keypad) },
        {"Knob", typeof(Knob) },
        {"Maze", typeof(Maze) },
        {"Memory", typeof(Memory) },
        {"Morsematics", typeof(MorseMatics) },
        {"Morse Code", typeof(MorseCode) },
        {"Murder", typeof(Murder) },
        {"Password", typeof(Password) },
        {"Simon Says", typeof(SimonSays) },
        {"The Button", typeof(TheButton) },
        {"Two Bits", typeof(TwoBits) },
        {"Venting Gas", typeof(VentingGas) },
        {"Who’s on First", typeof(WhosOnFirst) },
        {"Wires", typeof(Wires) },
        {"Wire Sequence", typeof(WireSequence) }
    };
}