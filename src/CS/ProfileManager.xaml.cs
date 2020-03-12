using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static profiles;

namespace TPKtaneHelper.src.CS
{
    /// <summary>
    /// Interaction logic for ProfileManager.xaml
    /// </summary>
    public partial class ProfileManager : Window
    {
        public ProfileManager()
        {
            InitializeComponent();
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (Dictionary<string, string> userDict in Profiles)
                {
                    StackPanel uPanel = new StackPanel();
                    uPanel.Orientation = Orientation.Horizontal;
                    Button removeBTN = new Button();
                    removeBTN.Content = "Remove";
                    removeBTN.Click += (s, e) => removeClick(userDict["Username"], uPanel);
                    uPanel.Children.Add(removeBTN);
                    Button editBTN = new Button();
                    editBTN.Content = "Edit";
                    editBTN.Click += (s, e) => editClick(userDict["Username"]);
                    uPanel.Children.Add(editBTN);
                    TextBlock nameText = new TextBlock();
                    nameText.Text = userDict["Username"];
                    uPanel.Children.Add(nameText);
                    profilePanel.Children.Add(uPanel);
                }
            });
        }

        private void removeClick(string user, StackPanel uPanel)
        {
            foreach(Dictionary<string, string> userDict in Profiles)
            {
                if(userDict["Username"]==user)
                {
                    Profiles.Remove(userDict);
                    Application.Current.Dispatcher.Invoke(() => (uPanel.Parent as StackPanel).Children.Remove(uPanel));
                    return;
                }
            }
        }

        private void editClick(string user)
        {
            ProfileEditor p = new ProfileEditor(user);
            p.Show();
            Close();
        }

        private void doneBTN_Click(object sender, RoutedEventArgs e)
        {
            loaded toSerialize = new loaded();
            toSerialize._profiles = Profiles;
            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(toSerialize));
            ProfileSelector p = new ProfileSelector();
            p.Show();
            Close();
        }

        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            ProfileSelector p = new ProfileSelector();
            p.Show();
            Close();
        }

        private void createBTN_Click(object sender, RoutedEventArgs e)
        {
            ProfileCreator p = new ProfileCreator();
            p.Show();
            Close();
        }
    }
}
