using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.IO;
using CefSharp.Wpf;
using CefSharp;

namespace TPKtaneHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly bool _DeveloperMode = true;

        public MainWindow(string channel)
        {
            InitializeComponent();
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
            StreamerSelect.Click += StreamerSelectClick;
            if (_DeveloperMode) ConsoleAllocator.ShowConsoleWindow();
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
            Main.Repository.Address = "https://ktane.timwi.de";
        }

        private static void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            Main.ResetClick();
        }

        private void TabClick(object sender, RoutedEventArgs e)
        {
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
