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

        public static bool sendAfterDone => (bool)sBox.IsChecked;

        private static CheckBox sBox;
        #pragma warning disable 8632
        public ModuleWindow(string Module, int ID)
        {
            InitializeComponent();
            Application.Current.Dispatcher.Invoke(() =>
            {
                StackPanel ModulePanel = ModuleControls;
                Type ModuleType = ModuleTypeDict[Module];
                try { TP.MessageBox.Text = String.Format($"!{"{0}"} {(string)ModuleType.GetField("defaultMessage", mainFlags).GetValue(null)}", ID); }
                catch { TP.MessageBox.Text = $"!{ID} "; }
                MethodInfo doneOverride = ModuleType.GetMethod("DoneOverride", mainFlags);
                FieldInfo ElementField = ModuleType.GetField("GuiElements", mainFlags);
                GuiElement[][] Elements = (GuiElement[][])ElementField.GetValue(null);
                foreach (GuiElement[] Row in Elements)
                {
                    StackPanel Panel = new StackPanel();
                    Panel.Orientation = Orientation.Horizontal;
                    foreach (GuiElement Element in Row)
                    {
                        string finalString = getElementType(Element);

                        switch (finalString)
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
                            case "Dropdown":
                                try { Panel.Children.Add((Element as GuiDropdown).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiDropdown).GuiElement.Parent, (Element as GuiDropdown).GuiElement); Panel.Children.Add((Element as GuiDropdown).GuiElement); }
                                break;
                            case "Text":
                                try { Panel.Children.Add((Element as GuiText).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiText).GuiElement.Parent, (Element as GuiText).GuiElement); Panel.Children.Add((Element as GuiText).GuiElement); }
                                break;
                            case "TextBox":
                                try { Panel.Children.Add((Element as GuiTextBox).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiTextBox).GuiElement.Parent, (Element as GuiTextBox).GuiElement); Panel.Children.Add((Element as GuiTextBox).GuiElement); }
                                break;
                            case "Checkbox":
                                try { Panel.Children.Add((Element as GuiCheckbox).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiCheckbox).GuiElement.Parent, (Element as GuiCheckbox).GuiElement); Panel.Children.Add((Element as GuiCheckbox).GuiElement); }
                                break;
                            case "UpDown":
                                try { Panel.Children.Add((Element as GuiUpDown).GuiElement); }
                                catch { RemoveChildHelper.RemoveChild((Element as GuiUpDown).GuiElement.Parent, (Element as GuiUpDown).GuiElement); Panel.Children.Add((Element as GuiUpDown).GuiElement); }
                                break;
                            default: break;
                        }
                        if (finalString != "Empty") (Element as GuiRow).Show();
                    }
                    ModulePanel.Children.Add(Panel);
                }
                MethodInfo initMethod = ModuleType.GetMethod("Init", mainFlags);
                if (initMethod != null) initMethod.Invoke(null, new object?[] { });
                FieldInfo TextOverride = ModuleType.GetField("DoneTextOverride", mainFlags);
                Button DoneBTN = new Button();
                DoneBTN.Content = TextOverride == null ? "Done" : (string)TextOverride.GetValue(null);
                if (doneOverride == null) { DoneBTN.Click += (s, e) => TP.Done(); }
                else { DoneBTN.Click += (s, e) => doneOverride.Invoke(null, new object?[] { }); }
                sPanel.Children.Add(DoneBTN);
                CheckBox sendBox = new CheckBox();
                FieldInfo CheckboxOverride = ModuleType.GetField("CheckboxOverride", mainFlags);
                sendBox.Content = $"Send after {(CheckboxOverride==null ? "done" : (string)CheckboxOverride.GetValue(null))}";
                sendBox.IsChecked = false;
                sBox = sendBox;
                sPanel.Children.Add(sBox);
            });
        }
        #pragma warning restore 8632
        public static string getElementType(GuiElement Element)
        {
            if (Element as GuiButton != null) return "Button";
            if (Element as GuiEmpty != null) return "Empty";
            if (Element as GuiImage != null) return "Image";
            if (Element as GuiDropdown != null) return "Dropdown";
            if (Element as GuiText != null) return "Text";
            if (Element as GuiTextBox != null) return "TextBox";
            if (Element as GuiCheckbox != null) return "Checkbox";
            if (Element as GuiUpDown != null) return "UpDown";
            return "";
        }
    }
}
