using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using static profiles;

namespace TPKtaneHelper.src.CS
{
    /// <summary>
    /// Interaction logic for ProfileCreator.xaml
    /// </summary>
    public partial class ProfileCreator : Window
    {
        private TextBox nBox { get; set; }
        private TextBox tBox { get; set; }

        public ProfileCreator()
        {
            InitializeComponent();
            nBox = nameBox;
            tBox = tokenBox;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileManager p = new ProfileManager();
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (oauthKeys.ContainsKey(nBox.Text)) return;
                tBox.Text = tBox.Text.StartsWith("oauth:") ? tBox.Text : $"oauth:{tBox.Text}";
                oauthKeys.Add(nBox.Text, tBox.Text);
                Profiles.Add(new Dictionary<string, string>()
                {
                    {"Username", nBox.Text },
                    {"Oauth", tBox.Text }
                });
            });
            p.Show();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileManager p = new ProfileManager();
            p.Show();
            Close();
        }
    }
}
