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
            QueueName.TextChanged += QueueNameChanged;
            QueueBox.Checked += CheckBoxChanged;
            new Thread(new ThreadStart(ChangeMessage)).Start();
        }

        private void ChangeMessage()
        {
            while (true) { try { Application.Current.Dispatcher.Invoke(() => Message.Text = TP.Message); Thread.Sleep(1); } catch { break; } }
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (!(sender as TextBox).Text.StartsWith((bool)QueueBox.IsChecked ? "!q ":"!")) Message.Text = $"{((bool)QueueBox.IsChecked ? $"!q {QueueName.Text} ":"")}!{Message.Text}";
                TP.Message = (sender as TextBox).Text;
            });
        }

        private void QueueNameChanged(object sender, TextChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => TextChange(Message, null));
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

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                /*if (!(bool)(sender as CheckBox).IsChecked)
                {
                    if (TP.Message.StartsWith("!q "))
                    {
                        TP.Message = TP.Message.Substring(3+QueueName.Text.Length);
                    }
                    QueueName.Text = "";
                }
                else
                {
                    if(!TP.Message.StartsWith("!q "))
                    {
                        TP.Message = $"!q {TP.Message}";
                    }
                }*/
                TextChange(Message, null);
            });
        }
    }
}
