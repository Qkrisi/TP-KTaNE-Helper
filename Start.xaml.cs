using System.Windows;
using System.Windows.Controls;

namespace TPKtaneHelper
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
            MrPeanut1028.Click += OnButtonClick;
            derfer99.Click += OnButtonClick;
            Strike_Kaboom.Click += OnButtonClick;
            Jon123276.Click += OnButtonClick;
            MrMelon54.Click += OnButtonClick;
            Qkrisi.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            StartProgram(btn.Name);
        }

        private void StartProgram(string channel)
        {
            MainWindow Program = new MainWindow(channel);
            Program.Show();
            Close();
        }
    }
}
