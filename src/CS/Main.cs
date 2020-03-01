using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using CefSharp.Wpf;
using Newtonsoft.Json;
using System.IO;
using static NoteOverride;


public static class Main
{
    public static Button RepoButton;
    public static ChromiumWebBrowser Repository;
    public static TextBox Notes;
    public static string _module = "https://ktane.timwi.de/";

    public static Bot bot = null;

    private static Tab[] Tabs = new Tab[5] { new Tab(_module), new Tab(_module), new Tab(_module), new Tab(_module), new Tab(_module) };
    private static int tabNum = 0;
    public static Tab currentTab => Tabs[tabNum];

    private static readonly string DataPath = @"../../../UserData.json";

    public static void CangeText()
    {
        currentTab.ChangeAddress(GetAddress());
        SaveNotes();
        _module = GetModuleNameByURL(GetAddress());
        LoadNotes();
    }

    #region VarGetters
    private static string GetText()
    {
        string temp = "";
        Application.Current.Dispatcher.Invoke(() => { temp = Notes.Text; });
        Console.WriteLine(temp);
        return temp;
    }

    private static string GetAddress()
    {
        string temp = "";
        Application.Current.Dispatcher.Invoke(() => { temp = Repository.Address; });
        return temp;
    }
    #endregion

    public static void ChangeTab(int num)
    {
        tabNum = num;
        Application.Current.Dispatcher.Invoke(() => { Repository.Address = currentTab.Address; });
    }

    #region Notes
    private static void SaveNotes()
    {
        try
        {
            UserOverrides[_module] = GetText();
        }
        catch
        {
            UserOverrides.Add(_module, GetText());
        }
    }

    private static void LoadNotes()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            try
            {
                Notes.Text = UserOverrides[_module];
            }
            catch
            {
                try
                {
                    Notes.Text = $"{(_module == "https://ktane.timwi.de" ? "" : $"{_module}\n\n")}{BaseOverrides[_module]}";
                }
                catch
                {
                    Notes.Text = $"{(_module == "https://ktane.timwi.de" ? "" : $"{_module}\n\n")}";
                }
                SaveNotes();
            }
        });
    }

    public static void ResetClick()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            try
            {
                Notes.Text = $"{(_module == "https://ktane.timwi.de" ? "" : $"{_module}\n\n")}{BaseOverrides[_module]}";
            }
            catch
            {
                Notes.Text = $"{(_module == "https://ktane.timwi.de" ? "" : $"{_module}\n\n")}";
            }
            if (Notes.Text == "https://ktane.timwi.de/\n\n") Notes.Text = "";
            SaveNotes();
        });
    }
    #endregion

    public static string GetModuleNameByURL(string URL)
    {
        return URL.Replace("http:ktane.timwi.de","https://ktane.timwi.de").Replace("https://ktane.timwi.de/HTML/", "").Replace("https://ktane.timwi.de/PDF/", "").Replace("%20", " ").Replace(".html","").Replace(".pdf","");
    }

    public static void StartBot(string Channel, bool announce)
    {
        Dictionary<string, string> UserData = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(DataPath));
        bot = new Bot(UserData["Username"], UserData["OAuthToken"], Channel, announce);
    }
}