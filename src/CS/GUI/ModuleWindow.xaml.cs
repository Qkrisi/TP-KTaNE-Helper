using System;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using static ModuleTypes;

namespace TPKtaneHelper.src.CS.GUI
{
    /// <summary>
    /// Interaction logic for ModuleWindow.xaml
    /// </summary>
    public partial class ModuleWindow : Window
    {
        public ModuleWindow(string Module, int ID)
        {
            InitializeComponent();
            Application.Current.Dispatcher.Invoke(() =>
            { 
                StackPanel ModulePanel = ModuleControls;
                Type ModuleType = ModuleTypeDict[Module];
                TP.MessageBox.Text = String.Format((string)ModuleType.GetField("defaultMessage", BindingFlags.Public | BindingFlags.Static).GetValue(null), ID);
                FieldInfo ElementField = ModuleType.GetField("GuiElements", BindingFlags.Public | BindingFlags.Static);
                GuiElement[][] Elements = (GuiElement[][])ElementField.GetValue(null);
                foreach (GuiElement[] Row in Elements)
                {
                    StackPanel Panel = new StackPanel();
                    Panel.Orientation = Orientation.Horizontal;
                    foreach (GuiElement Element in Row)
                    {
                        FinalElement F = getElementType(Element);
                        if (F.finalButton != null)
                        {
                            try { Panel.Children.Add(F.finalButton.GuiElement); }
                            catch { RemoveChildHelper.RemoveChild(F.finalButton.GuiElement.Parent, F.finalButton.GuiElement); Panel.Children.Add(F.finalButton.GuiElement); }
                        }
                    }
                    ModulePanel.Children.Add(Panel);
                }
                Button DoneBTN = new Button();
                DoneBTN.Content = "Done";
                DoneBTN.Click += DoneClick;
                sPanel.Children.Add(DoneBTN);
            });
        }
        private FinalElement getElementType(GuiElement Element)
        {
            try
            {
                GuiButton temp = Element as GuiButton;
                return new FinalElement(Element, "Button");
            }
            catch
            {
                return new FinalElement(Element, "");
            }
        }

        private void DoneClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
