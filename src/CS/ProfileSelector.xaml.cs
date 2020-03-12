using System.Windows;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using System.IO;
using static profiles;

namespace TPKtaneHelper.src.CS
{
    /// <summary>
    /// Interaction logic for ProfileSelector.xaml
    /// </summary>
    public partial class ProfileSelector : Window
    {
        private Dictionary<string, string> Oauths { get; set; } = new Dictionary<string, string>();
        private ComboBox nameBox { get; set; }

        public ProfileSelector()
        {
            InitializeComponent();
            Profiles = JsonConvert.DeserializeObject<loaded>(File.ReadAllText(jsonPath))._profiles;
            nameBox = profileBox;
            doneBTN.Click += DoneBTNClick;
            if(Profiles.Count>0)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    (profileBox.SelectedItem as ComboBoxItem).Content = Profiles[0]["Username"];
                    Oauths.Add(Profiles[0]["Username"], Profiles[0]["Oauth"]);
                    for(int i = 1;i<Profiles.Count;i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = Profiles[i]["Username"];
                        item.IsSelected = false;
                        Oauths.Add(Profiles[i]["Username"], Profiles[i]["Oauth"]);
                        nameBox.Items.Add(item);
                    }
                    oauthKeys = Oauths;
                    doneBTN.Visibility = Visibility.Visible;
                });
            }
        }

        public void DoneBTNClick(object sender, RoutedEventArgs e)
        {
            uName = getName();
            Oauth = Oauths[uName];
            Start p = new Start();
            p.Show();
            Close();
        }

        private string getName()
        {
            string temp = "";
            Application.Current.Dispatcher.Invoke(() => temp = (nameBox.SelectedItem as ComboBoxItem).Content as string);
            return temp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProfileManager p = new ProfileManager();
            p.Show();
            Close();
        }
    }
}
