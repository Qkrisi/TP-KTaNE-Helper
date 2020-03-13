using System;
using System.Windows.Controls;
using TPKtaneHelper.src.CS.GUI;

public static class TP
{
    public static string Message;
    public static TextBox MessageBox;

    public static readonly Action Done = () => doneAct(ModuleWindow.sendAfterDone);
    public static Action<bool> doneAct;     //Don't use in creators!
}