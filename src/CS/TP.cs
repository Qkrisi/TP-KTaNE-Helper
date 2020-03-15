using System;
using System.Windows.Controls;
using TPKtaneHelper.src.CS.GUI;

public static class TP
{
    public static string Message;
    public static int moduleID;
    public static TextBox MessageBox;

    public static readonly Action Done = () => { try { doneAct(ModuleWindow.sendAfterDone); } catch { } };
    public static Action<bool> doneAct;     //Don not use in creators!
}