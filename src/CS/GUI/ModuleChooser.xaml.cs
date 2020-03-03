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
                    var image = new Image();
                    var fullFilePath = $@"https://ktane.timwi.de/icons/{Pair.Key.Replace(" ", "%20")}.png";

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();

                    image.Source = bitmap;
                    Panel.Children.Add(image);

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
                    p.Show();
                    Close();
                }
                catch
                {
                    ModuleWindow p = new ModuleWindow((sender as Button).Name, 0);
                    p.Show();
                    Close();
                }
            });
        }
    }
}
