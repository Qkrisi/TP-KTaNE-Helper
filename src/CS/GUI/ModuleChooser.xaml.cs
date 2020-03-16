using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using static ModuleTypes;

namespace TPKtaneHelper.src.CS.GUI
{
    /// <summary>
    /// Interaction logic for ModuleChooser.xaml
    /// </summary>
    public partial class ModuleChooser : Window
    {
        private Dictionary<string, StackPanel> modulePanels { get; set; } = new Dictionary<string, StackPanel>();
        private Dictionary<string, string> moduleNames { get; set; } = new Dictionary<string, string>();

        private static int Count = 0;
        public ModuleChooser()
        {
            InitializeComponent();
            Count = 0;
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (KeyValuePair<string, Type> Pair in ModuleTypeDict)
                {
                    StackPanel Panel = new StackPanel();
                    Panel.Orientation = Orientation.Horizontal;
                    var fullFilePath = @$"https://ktane.timwi.de/icons/{Pair.Key.Replace(" ","%20")}.png";

                    try { Panel.Children.Add(new GuiImage(ImageSource.URL, fullFilePath).GuiElement); }
                    catch { Panel.Children.Add(new GuiImage(ImageSource.File, "Misc/ModuleNotFound.png").GuiElement); }

                    Button BTN = new Button();
                    moduleNames.Add($"Button{++Count}", Pair.Key);
                    BTN.Name = $"Button{Count}";
                    BTN.Content = Pair.Key;
                    BTN.Click += OnClick;

                    Panel.Children.Add(BTN);

                    ModulesPanel.Children.Add(Panel);
                    modulePanels.Add(Pair.Key, Panel);
                }
            });
        }
            
        private void OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    ModuleWindow p = new ModuleWindow(moduleNames[(sender as Button).Name], int.Parse(moduleID.Text));
                    p.Closing += (s, e) => Application.Current.Dispatcher.Invoke(() => TP.MessageBox.IsReadOnly = false);
                    TP.moduleID = int.Parse(moduleID.Text);
                    TP.doneAct = (s) => { p.Close(); Application.Current.Dispatcher.Invoke(() => TP.MessageBox.IsReadOnly = false); if (s) Main.SendMSG(); };
                    p.Show();
                    Close();
                }
                catch
                {
                    ModuleWindow p = new ModuleWindow(moduleNames[(sender as Button).Name], 1);
                    p.Closing += (s, e) => Application.Current.Dispatcher.Invoke(() => TP.MessageBox.IsReadOnly = false);
                    TP.moduleID = 1;
                    TP.doneAct = (s) => { p.Close(); Application.Current.Dispatcher.Invoke(() => TP.MessageBox.IsReadOnly = false); if (s) Main.SendMSG(); };
                    p.Show();
                    Close();
                }
                TP.MessageBox.IsReadOnly = true;
            });
        }

        private void moduleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Text = (sender as TextBox).Text;
            foreach(KeyValuePair<string, StackPanel> Pair in modulePanels)
            {
                if(Text=="" || Pair.Key.ToLowerInvariant().StartsWith(Text.ToLowerInvariant()))
                {
                    Pair.Value.Visibility = Visibility.Visible;
                    continue;
                }
                Pair.Value.Visibility = Visibility.Collapsed;
            }
        }
    }
}
