using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using static profiles;

namespace TPKtaneHelper.src.CS
{
    /// <summary>
    /// Interaction logic for ProfileEditor.xaml
    /// </summary>
    public partial class ProfileEditor : Window
    {
        private TextBlock nBlock { get; set; }
        private TextBox tBox { get; set; }

        public ProfileEditor(string user)
        {
            InitializeComponent();
            nBlock = nameBlock;
            tBox = tokenBox;
            Application.Current.Dispatcher.Invoke(() =>
            {
                nBlock.Text = user;
                tBox.Text = oauthKeys[user];
            });
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileManager p = new ProfileManager();
            Application.Current.Dispatcher.Invoke(() =>
            {
                tBox.Text = tBox.Text.StartsWith("oauth:") ? tBox.Text : $"oauth:{tBox.Text}";
                oauthKeys[nBlock.Text] = tBox.Text;
                for(int i = 0;i<Profiles.Count;i++)
                {
                    Dictionary<string, string> userDict = Profiles[i];
                    if(userDict["Username"]==nBlock.Text)
                    {
                        userDict["Oauth"] = tBox.Text;
                        Profiles[i] = userDict;
                        break;
                    }
                }
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
