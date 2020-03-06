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
        private BindingFlags mainFlags => BindingFlags.Public | BindingFlags.Static;
        public ModuleWindow(string Module, int ID)
        {
            InitializeComponent();
            Application.Current.Dispatcher.Invoke(() =>
            { 
                StackPanel ModulePanel = ModuleControls;
                Type ModuleType = ModuleTypeDict[Module];
                TP.MessageBox.Text = String.Format($"{0} {(string)ModuleType.GetField("defaultMessage", mainFlags).GetValue(null)}", ID);
                FieldInfo ElementField = ModuleType.GetField("GuiElements", mainFlags);
                GuiElement[][] Elements = (GuiElement[][])ElementField.GetValue(null);
                foreach (GuiElement[] Row in Elements)
                {
                    StackPanel Panel = new StackPanel();
                    Panel.Orientation = Orientation.Horizontal;
                    foreach (GuiElement Element in Row)
                    {
                        string finalString = getElementType(Element);
                        
                        switch(finalString)
                        {
                            case "Button":
                                try { Panel.Children.Add((Element as GuiButton).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiButton).GuiElement.Parent, (Element as GuiButton).GuiElement); Panel.Children.Add((Element as GuiButton).GuiElement); }
                                break;
                            case "Empty":
                                try { Panel.Children.Add((Element as GuiEmpty).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiEmpty).GuiElement.Parent, (Element as GuiEmpty).GuiElement); Panel.Children.Add((Element as GuiEmpty).GuiElement); }
                                break;
                            case "Image":
                                try { Panel.Children.Add((Element as GuiImage).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiImage).GuiElement.Parent, (Element as GuiImage).GuiElement); Panel.Children.Add((Element as GuiImage).GuiElement); }
                                break;
                            default:break;
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
        private string getElementType(GuiElement Element)
        {
            if (Element as GuiButton != null) return "Button";
            if (Element as GuiEmpty != null) return "Empty";
            if (Element as GuiImage != null) return "Image";
            return "";
        }

        private void DoneClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
