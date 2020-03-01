using System.Windows;
using System.Collections.Generic;

public sealed class Tab
{
    public string Address { get; private set; }
    public List<string> History { get; private set; }

    public void ChangeAddress(string address)
    {
        if(History[History.Count-1] != address) History.Add(address);
        Address = address;
    }

    public void GoBack()
    {
        if (History.Count > 1) History.RemoveAt(History.Count-1);
        Application.Current.Dispatcher.Invoke(() => { Main.Repository.Address = History[History.Count-1]; });
    }

    public Tab(string address)
    {
        Address = address;
        History = new List<string>() { address };
    }
}