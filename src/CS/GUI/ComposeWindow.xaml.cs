using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace TPKtaneHelper.src.CS.GUI
{
    /// <summary>
    /// Interaction logic for ComposeWindow.xaml
    /// </summary>
    public partial class ComposeWindow : Window
    {
        public ComposeWindow()
        {
            InitializeComponent();
            TP.MessageBox = Message;
            Message.TextChanged += TextChange;
            ModuleChooser.Click += ChooseClick;
            Send.Click += SendClick;
            new Thread(new ThreadStart(ChangeMessage)).Start();
        }

        private void ChangeMessage()
        {
            while (true) { try { Application.Current.Dispatcher.Invoke(() => Message.Text = TP.Message); Thread.Sleep(1); } catch { break; } }
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            TP.Message = (sender as TextBox).Text;
        }

        private void ChooseClick(object sender, RoutedEventArgs e)
        {
            ModuleChooser p = new ModuleChooser();
            p.Show();
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            Main.bot.SendMessage(TP.Message);
            TP.Message = "";
            Close();
        }
    }
}
