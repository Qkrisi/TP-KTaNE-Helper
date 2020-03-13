using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using static ModuleTypes;

namespace TPKtaneHelper.src.CS.GUI
{
    /// <summary>
    /// Interaction logic for ModuleChooser.xaml
    /// </summary>
    public partial class ModuleChooser : Window
    {
        public ModuleChooser()
        {
            InitializeComponent();
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
                    BTN.Name = Pair.Key;
                    BTN.Content = Pair.Key;
                    BTN.Click += OnClick;

                    Panel.Children.Add(BTN);

                    ModulesPanel.Children.Add(Panel);
                }
            });
        }
            
        private void OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    ModuleWindow p = new ModuleWindow((sender as Button).Name, int.Parse(moduleID.Text));
                    TP.doneAct = (s) => { p.Close(); Application.Current.Dispatcher.Invoke(() => TP.MessageBox.IsReadOnly = false); if (s) Main.SendMSG(); };
                    p.Show();
                    Close();
                }
                catch
                {
                    ModuleWindow p = new ModuleWindow((sender as Button).Name, 0);
                    TP.doneAct = (s) => { p.Close(); Application.Current.Dispatcher.Invoke(() => TP.MessageBox.IsReadOnly = false); if (s) Main.SendMSG(); };
                    p.Show();
                    Close();
                }
                TP.MessageBox.IsReadOnly = true;
            });
        }
    }
}
