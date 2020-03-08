using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.IO;
using CefSharp.Wpf;
using CefSharp;
using TPKtaneHelper.src.CS.GUI;
using Newtonsoft.Json;
using Vlc.DotNet.Wpf;
using System.Net;
using System.Collections.Generic;

namespace TPKtaneHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class Api
        {
            public Dictionary<string, string> urls { get; set; }
            public bool success { get; set; }
            public string error { get; set; }
        }

        private enum State
        {
            Stream,
            Repo
        }

        private static State currentState = State.Repo;

        private static readonly bool _DeveloperMode = true;

        private static VlcControl VlcViewer { get; set; }

        private string Channel { get; set; }

        private Button streamBTN { get; set; }

        public MainWindow(string channel)
        {
            InitializeComponent();
            Channel = channel;
            streamBTN = streamButton;
            Repository.LoadingStateChanged += OnLoad;
            Main.RepoButton = Repo;
            Main.Repository = Repository;
            Main.Notes = Notes;
            Main.RepoButton.Click += RepoButtonClick;
            Reset.Click += ResetButtonClick;
            Main.StartBot(channel, !_DeveloperMode);
            Back.Click += BackClick;
            Chat.Address = $"localhost:5000/chat/{channel}";
            Tab1.Click += TabClick;
            Tab2.Click += TabClick;
            Tab3.Click += TabClick;
            Tab4.Click += TabClick;
            Tab5.Click += TabClick;
            streamBTN.Click += StreamClick;
            StreamerSelect.Click += StreamerSelectClick;
            Composer.Click += ComposeMessage;
            if (_DeveloperMode) ConsoleAllocator.ShowConsoleWindow();


            var vlcLibDirectory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            var options = new string[]
            {
                "--network-caching=200"
            };
            VLCViewer.TabIndex = 1;
            VLCViewer.SourceProvider.CreatePlayer(vlcLibDirectory, options);
            VlcViewer = VLCViewer;
            StartStream();
        }

        private void StartStream()
        {
            Api gotDict = JsonConvert.DeserializeObject<Api>(new WebClient().DownloadString($"https://pwn.sh/tools/streamapi.py?url=twitch.tv%2F{Channel}"));
            if (!gotDict.success)
            {
                streamButton.Visibility = Visibility.Hidden;
                VlcViewer.Visibility = Visibility.Hidden;
                currentState = State.Repo;
                return;
            }
            VlcViewer.SourceProvider.MediaPlayer.Play(gotDict.urls["1080p60"], new[] { "--network-caching=300" });
        }

        private void StreamClick(object sender, RoutedEventArgs e)
        {
            if (currentState == State.Stream) return;
            VlcViewer.Visibility = Visibility.Visible;
            Main.Repository.Visibility = Visibility.Hidden;
            currentState = State.Stream;
        }

        private static void BackClick(object sender, RoutedEventArgs e)
        {
            Main.currentTab.GoBack();
        }
        private static void OnLoad(object sender, LoadingStateChangedEventArgs e)
        {
            Main.CangeText();
        }

        private static void RepoButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentState == State.Stream)
            {
                Main.Repository.Visibility = Visibility.Visible;
                VlcViewer.Visibility = Visibility.Hidden;
                currentState = State.Repo;
                return;
            }
            if (Main.currentTab.Address != "https://ktane.timwi.de/") Main.Repository.Address = "https://ktane.timwi.de/";
        }

        private static void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            Main.ResetClick();
        }

        private void TabClick(object sender, RoutedEventArgs e)
        {
            if (currentState != State.Repo) return;
            Button btn = sender as Button;
            Main.ChangeTab(int.Parse(btn.Name.Replace("Tab", ""))-1);
        }

        private void StreamerSelectClick(object sender, RoutedEventArgs e)
        {
            Main.bot.End();
            Start p = new Start();
            p.Show();
            Close();
        }

        private void ComposeMessage(object sender, RoutedEventArgs e)
        {
            ComposeWindow p = new ComposeWindow();
            p.Show();
        }
    }

    public partial class App : Application
    {
        public App()
        {
            //Add Custom assembly resolver
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            //Any CefSharp references have to be in another method with NonInlining
            // attribute so the assembly rolver has time to do it's thing.
            InitializeCefSharp();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InitializeCefSharp()
        {
            var settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitProcess ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");

            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        // Required by CefSharp to load the unmanaged dependencies when running using AnyCPU
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);

                return File.Exists(archSpecificPath)
                           ? Assembly.LoadFile(archSpecificPath)
                           : null;
            }

            return null;
        }
    }
}
