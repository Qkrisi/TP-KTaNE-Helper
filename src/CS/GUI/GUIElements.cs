using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Xceed.Wpf.Toolkit;
using static TPKtaneHelper.src.CS.GUI.ModuleWindow;

public class GuiElement { }
public class GuiRow : GuiElement { }

public class GuiDroppable : GuiRow { }
public class GuiDroppableRow : GuiDroppable { }

public static class ElementUtilities
{
    public static string GetDroppableType(GuiDroppable Element)
    {
        if (Element as GuiEmpty != null) return "Empty";
        if (Element as GuiImage != null) return "Image";
        if (Element as GuiText != null) return "Text";
        return "";
    }

    public static void Show(this GuiRow Element)
    {
        switch(getElementType(Element))
        {
            case "Button":
                (Element as GuiButton).GuiElement.Visibility = Visibility.Visible;
                break;
            case "Empty":
                (Element as GuiEmpty).GuiElement.Visibility = Visibility.Visible;
                break;
            case "Image":
                (Element as GuiImage).GuiElement.Visibility = Visibility.Visible;
                break;
            case "Dropdown":
                (Element as GuiDropdown).GuiElement.Visibility = Visibility.Visible;
                break;
            case "Text":
                (Element as GuiText).GuiElement.Visibility = Visibility.Visible;
                break;
            case "TextBox":
                (Element as GuiTextBox).GuiElement.Visibility = Visibility.Visible;
                break;
            case "Checkbox":
                (Element as GuiCheckbox).GuiElement.Visibility = Visibility.Visible;
                break;
            case "UpDown":
                (Element as GuiUpDown).GuiElement.Visibility = Visibility.Visible;
                break;
            default:break;
        }
    }

    public static void Hide(this GuiRow Element, bool Render)
    {
        Visibility toSet = Render ? Visibility.Hidden : Visibility.Collapsed;
        switch (getElementType(Element))
        {
            case "Button":
                (Element as GuiButton).GuiElement.Visibility = toSet;
                break;
            case "Empty":
                (Element as GuiEmpty).GuiElement.Visibility = toSet;
                break;
            case "Image":
                (Element as GuiImage).GuiElement.Visibility = toSet;
                break;
            case "Dropdown":
                (Element as GuiDropdown).GuiElement.Visibility = toSet;
                break;
            case "Text":
                (Element as GuiText).GuiElement.Visibility = toSet;
                break;
            case "TextBox":
                (Element as GuiTextBox).GuiElement.Visibility = toSet;
                break;
            case "Checkbox":
                (Element as GuiCheckbox).GuiElement.Visibility = toSet;
                break;
            case "UpDown":
                (Element as GuiUpDown).GuiElement.Visibility = toSet;
                break;
            default: break;
        }
    }
}

public enum ImageSource
{
    URL,
    File
}

public class GuiBackgroundImage
{
    public ImageBrush img { get; private set; }
    public GuiBackgroundImage(ImageSource imageType, string source)
    {
        Console.WriteLine("Creating new");
        var brush = new ImageBrush();
        brush.ImageSource = new BitmapImage(new Uri(imageType==ImageSource.File ? $@"../../../src/IMG/{source}" : source, imageType==ImageSource.File ? UriKind.Relative : UriKind.Absolute));
        img = brush;
    }
}

public class GuiEmpty : GuiDroppableRow
{
    public Image GuiElement { get; private set; }

    public GuiEmpty(double height, double width)
    {
        GuiElement = new GuiImage(ImageSource.File, "Misc/Empty.png", height, width).GuiElement;
    }
}

public class GuiImage : GuiDroppableRow
{
    public Image GuiElement { get; private set; }

    public GuiImage(ImageSource sType, string source, double? height = null, double? width = null)
    {
        GuiElement = new Image();
        GuiElement.Source = new GuiBackgroundImage(sType, source).img.ImageSource;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Height = height == null ? GuiElement.Height : (double)width;
    }
}

public class GuiText : GuiDroppableRow
{
    public TextBlock GuiElement { get; private set; }

    public GuiText(string text, double? fontSize = null, int[] textColor = null, double? height = null, double? width = null)
    {
        GuiElement = new TextBlock();
        GuiElement.Text = text;
        GuiElement.Foreground = textColor == null ? GuiElement.Foreground : new SolidColorBrush(Color.FromArgb(255, (byte)textColor[0], (byte)textColor[1], (byte)textColor[2]));
        GuiElement.FontSize = fontSize == null ? GuiElement.FontSize : (double)fontSize;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Height = height == null ? GuiElement.Height : (double)width;
    }
}

public class GuiTextBox : GuiRow
{
    public TextBox GuiElement { get; private set; }

    public string Text { get => GuiElement.Text; set { GuiElement.Text = value; } }

    private Action<string> changeActA { get; set; }
    private Action<string, string> changeActB { get; set; }

    public GuiTextBox(Action<string> changeAction, string text = "", double? fontSize = null, int[] backgroundColor = null, int[] textColor = null, double? height = null, double? width = null)
    {
        GuiElement = new TextBox();
        changeActA = changeAction;
        GuiElement.Text = text;
        GuiElement.FontSize = fontSize == null ? GuiElement.FontSize : (double)fontSize;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Height = height == null ? GuiElement.Height : (double)width;
        GuiElement.Background = backgroundColor == null ? GuiElement.Background : new SolidColorBrush(Color.FromArgb(255, (byte)backgroundColor[0], (byte)backgroundColor[1], (byte)backgroundColor[2]));
        GuiElement.Foreground = textColor == null ? GuiElement.Foreground : new SolidColorBrush(Color.FromArgb(255, (byte)textColor[0], (byte)textColor[1], (byte)textColor[2]));
        GuiElement.TextChanged += OnChange;
    }

    public GuiTextBox(string name, Action<string, string> changeAction, string text = "", double? fontSize = null, int[] backgroundColor = null, int[] textColor = null, double? height = null, double? width = null)
    {
        GuiElement = new TextBox();
        changeActB = changeAction;
        GuiElement.Text = text;
        GuiElement.FontSize = fontSize == null ? GuiElement.FontSize : (double)fontSize;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Height = height == null ? GuiElement.Height : (double)width;
        GuiElement.Background = backgroundColor == null ? GuiElement.Background : new SolidColorBrush(Color.FromArgb(255, (byte)backgroundColor[0], (byte)backgroundColor[1], (byte)backgroundColor[2]));
        GuiElement.Foreground = textColor == null ? GuiElement.Foreground : new SolidColorBrush(Color.FromArgb(255, (byte)textColor[0], (byte)textColor[1], (byte)textColor[2]));
        GuiElement.TextChanged += OnChange;
    }

    private void OnChange(object sender, TextChangedEventArgs e)
    {
       if(changeActA==null)
        {
            changeActB((sender as TextBox).Name, (sender as TextBox).Text);
            return;
        }
        changeActA((sender as TextBox).Text);
    }
}

public class GuiButton : GuiRow
{

    private string Name;
    private string Text;
    private object ClickAction;
    public Button GuiElement { get; private set; }

    public GuiButton(string name, string text, Action ClickEvent, double? height = null, double? width = null, double? rotation = null, int[] backgroundColor = null, int[] textColor = null,GuiBackgroundImage backgroundImage = null)
    {
        SetValues(name, text, ClickEvent, null, height, width, rotation, backgroundColor, textColor, backgroundImage);
    }

    public GuiButton(string name, string text, Action<string> ClickEvent, double? height = null, double? width = null, double? rotation = null, int[] backgroundColor = null, int[] textColor = null, GuiBackgroundImage backgroundImage = null)
    {
        SetValues(name, text, null, ClickEvent, height, width, rotation, backgroundColor, textColor, backgroundImage);
    }

    private void SetValues(string name, string text, Action actionA, Action<string> actionB, double? height, double? width, double? rotation, int[] backgroundColor, int[] textColor, GuiBackgroundImage backgroundImage)
    {
        Name = name.Replace(" ","_");
        Text = text;
        if(actionA==null)
        {
            ClickAction = actionB;
        }
        else
        {
            ClickAction = actionA;
        }
        CreateButton(height, width, rotation, backgroundColor, textColor, backgroundImage);
    }

    private void CreateButton(double? height, double? width, double? rotation, int[] backgroundColor, int[] textColor, GuiBackgroundImage backgroundImage)
    {
        GuiElement = new Button();
        GuiElement.Content = Text;
        GuiElement.Name = Name.Replace(" ", "_");
        GuiElement.Click += OnClick;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Width = width == null ? GuiElement.Width : (double)width;
        GuiElement.LayoutTransform = rotation == null ? GuiElement.LayoutTransform : new RotateTransform((double)rotation, 0.5, 0.5);
        GuiElement.Background = backgroundColor==null ? GuiElement.Background : new SolidColorBrush(Color.FromArgb(255, (byte)backgroundColor[0], (byte)backgroundColor[1], (byte)backgroundColor[2]));
        GuiElement.Foreground = textColor == null ? GuiElement.Foreground : new SolidColorBrush(Color.FromArgb(255, (byte)textColor[0], (byte)textColor[1], (byte)textColor[2]));
        GuiElement.Background = backgroundImage == null ? GuiElement.Background : backgroundImage.img;
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
        if(ClickAction.GetType()==typeof(Action))
        {
            ((Action)ClickAction)();
            return;
        }
        ((Action<string>)ClickAction)(Name);
    }
}

public class GuiDropdown : GuiRow
{
    public ComboBox GuiElement { get; private set; }

    public string Selected
    {
        get
        {
            if (!dType)
            {
                return new Regex(Regex.Escape("System.Windows.Controls.ComboBoxItem: ")).Replace(GuiElement.SelectedItem.ToString(), "", 1);
            }
            return ((GuiElement.SelectedItem as ComboBoxItem).Content as StackPanel).Name.Replace("_", " ");
        }
    }

    private Action<string, string> ChangeAction { get; set; }

    private string NoUse { get; set; }

    private bool dType { get; set; } = false;

    private StackPanel NoUsePanel { get; set; }

    public GuiDropdown(string Name, string defaultValue, string[] Values, Action<string, string> changeAction)
    {
        GuiElement = new ComboBox();
        GuiElement.Name = Name.Replace(" ", "_");
        GuiElement.SelectionChanged += OnChange;
        ChangeAction = changeAction;
        NoUse = defaultValue;
        ComboBoxItem Default = new ComboBoxItem();
        Default.IsSelected = true;
        Default.Content = defaultValue;
        GuiElement.Items.Add(Default);
        foreach(string value in Values)
        {
            ComboBoxItem item = new ComboBoxItem();
            item.IsSelected = false;
            item.Content = value;
            GuiElement.Items.Add(item);
        }
    }

    public GuiDropdown(string Name, GuiDroppableRow[] defaultValue, GuiDroppable[][] Values, string[] valueNames, Action<string, string> changeAction)
    {
        GuiElement = new ComboBox();
        GuiElement.Name = Name.Replace(" ", "_");
        GuiElement.SelectionChanged += OnChange;
        ChangeAction = changeAction;
        dType = true;

        NoUsePanel = new StackPanel();
        NoUsePanel.Name = Name;
        NoUsePanel.Orientation = Orientation.Horizontal;
        foreach(GuiDroppableRow RowElement in defaultValue)
        {
            switch(ElementUtilities.GetDroppableType(RowElement))
            {
                case "Empty":
                    NoUsePanel.Children.Add((RowElement as GuiEmpty).GuiElement);
                    break;
                case "Image":
                    NoUsePanel.Children.Add((RowElement as GuiImage).GuiElement);
                    break;
                case "Text":
                    NoUsePanel.Children.Add((RowElement as GuiText).GuiElement);
                    break;
                default:break;
            }
        }
        ComboBoxItem defaultItem = new ComboBoxItem();
        defaultItem.IsSelected = true;
        defaultItem.Content = NoUsePanel;
        GuiElement.Items.Add(defaultItem);

        if (Values.Length != valueNames.Length) throw new ArgumentException("Values and Names should be the same length");
        for(int i = 0; i<Values.Length;i++)
        {
            StackPanel itemPanel = new StackPanel();
            itemPanel.Orientation = Orientation.Horizontal;
            itemPanel.Name = valueNames[i].Replace(" ","_");
            foreach (GuiDroppable RowElement in Values[i])
            {
                switch (ElementUtilities.GetDroppableType(RowElement))
                {
                    case "Empty":
                        itemPanel.Children.Add((RowElement as GuiEmpty).GuiElement);
                        break;
                    case "Image":
                        itemPanel.Children.Add((RowElement as GuiImage).GuiElement);
                        break;
                    case "Text":
                        itemPanel.Children.Add((RowElement as GuiText).GuiElement);
                        break;
                    default: break;
                }
            }
            ComboBoxItem Item = new ComboBoxItem();
            Item.IsSelected = false;
            Item.Content = itemPanel;
            GuiElement.Items.Add(Item);
        }
    }

    private void OnChange(object sender, SelectionChangedEventArgs e)
    {
        if (!dType)
        {
            string text = new Regex(Regex.Escape("System.Windows.Controls.ComboBoxItem: ")).Replace((sender as ComboBox).SelectedItem.ToString(), "", 1);
            if (text != NoUse) ChangeAction((sender as ComboBox).Name, text);
            return;
        }
        if (((sender as ComboBox).SelectedItem as ComboBoxItem).Content as StackPanel != NoUsePanel) ChangeAction((sender as ComboBox).Name, (((sender as ComboBox).SelectedItem as ComboBoxItem).Content as StackPanel).Name.Replace("_"," "));
        return;
    }
}

public class GuiCheckbox : GuiRow
{
    public CheckBox GuiElement { get; private set; }

    public bool isChecked { get => (bool)GuiElement.IsChecked; set { GuiElement.IsChecked = value; } }

    private Action<string, bool> actionA { get; set; } = null;
    private Action<bool> actionB { get; set; } = null;

    public GuiCheckbox(string name, string text, bool _checked, Action<string, bool> changeAction, double? height = null, double? width = null, int[] textColor = null)
    {
        GuiElement = new CheckBox();
        GuiElement.Name = name.Replace(" ", "_");
        GuiElement.Content = text;
        GuiElement.IsChecked = _checked;
        actionA = changeAction;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Width = width == null ? GuiElement.Width : (double)width;
        GuiElement.Foreground = textColor == null ? GuiElement.Foreground : new SolidColorBrush(Color.FromArgb(255, (byte)textColor[0], (byte)textColor[1], (byte)textColor[2]));
        GuiElement.Checked += OnCheck;
        GuiElement.Unchecked += OnUncheck;
    }

    public GuiCheckbox(string name, string text, bool _checked, Action<bool> changeAction, double? height = null, double? width = null, int[] textColor = null)
    {
        GuiElement = new CheckBox();
        GuiElement.Name = name.Replace(" ", "_");
        GuiElement.Content = text;
        GuiElement.IsChecked = _checked;
        actionB = changeAction;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Width = width == null ? GuiElement.Width : (double)width;
        GuiElement.Foreground = textColor == null ? GuiElement.Foreground : new SolidColorBrush(Color.FromArgb(255, (byte)textColor[0], (byte)textColor[1], (byte)textColor[2]));
        GuiElement.Checked += OnCheck;
        GuiElement.Unchecked += OnUncheck;
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        if (actionA != null)
        {
            actionA((sender as CheckBox).Name, true);
            return;
        }
        else { actionB(true); }
    }

    private void OnUncheck(object sender, RoutedEventArgs e)
    {
        if (actionA != null)
        {
            actionA((sender as CheckBox).Name, false);
            return;
        }
        else { actionB(false); }
    }
}


public enum UpDownFormats
{
    Currency,
    FixedPoint,
    General,
    Number,
    Percent
}
public class GuiUpDown : GuiRow
{
    public IntegerUpDown GuiElement { get; private set; }

    public int? Value { get => GuiElement.Value; set { GuiElement.Value = value; } }

    private Action<string, int> actionA { get; set; } = null;
    private Action<int> actionB { get; set; } = null;

    private static readonly Dictionary<UpDownFormats, string> formatStrings = new Dictionary<UpDownFormats, string>()
    {
        {UpDownFormats.Currency, "C0" },
        {UpDownFormats.FixedPoint, "F0" },
        {UpDownFormats.General, "G0" },
        {UpDownFormats.Number, "N0" },
        {UpDownFormats.Percent, "P0" },
    };

    public GuiUpDown(string name, Action<string, int> changeAction, int? defaultValue = null, int? minimum = null, int? maximum = null, UpDownFormats format = UpDownFormats.General, int increment = 1, bool allowSpin = true, string watermark = "", double? height = null, double? width = null)
    {
        GuiElement = new IntegerUpDown();
        GuiElement.Name = name.Replace(" ", "_");
        GuiElement.Value = defaultValue;
        GuiElement.Minimum = minimum == null ? GuiElement.Minimum : minimum;
        GuiElement.Maximum = maximum == null ? GuiElement.Maximum : maximum;
        GuiElement.AllowSpin = allowSpin;
        GuiElement.Watermark = watermark;
        GuiElement.Increment = increment;
        GuiElement.FormatString = formatStrings[format];
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Width = width == null ? GuiElement.Width : (double)width;
        actionA = changeAction;
        GuiElement.ValueChanged += OnChange;
    }

    public GuiUpDown(string name, Action<int> changeAction, int? defaultValue = null, int? minimum = null, int? maximum = null, UpDownFormats format = UpDownFormats.General, int increment = 1, bool allowSpin = true, string watermark = "", double? height = null, double? width = null)
    {
        GuiElement = new IntegerUpDown();
        GuiElement.Name = name.Replace(" ","_");
        GuiElement.Value = defaultValue;
        GuiElement.Minimum = minimum == null ? GuiElement.Minimum : minimum;
        GuiElement.Maximum = maximum == null ? GuiElement.Maximum : maximum;
        GuiElement.AllowSpin = allowSpin;
        GuiElement.Watermark = watermark;
        GuiElement.Increment = increment;
        GuiElement.FormatString = formatStrings[format];
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Width = width == null ? GuiElement.Width : (double)width;
        actionB = changeAction;
        GuiElement.ValueChanged += OnChange;
    }

    private void OnChange(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if(actionA==null)
        {
            actionB((int)(sender as IntegerUpDown).Value);
            return;
        }
        actionA((sender as IntegerUpDown).Name, (int)(sender as IntegerUpDown).Value);
    }
}