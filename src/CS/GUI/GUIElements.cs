using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

public class GuiElement { }
public class GuiRow : GuiElement { }

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

public class GuiEmpty : GuiRow
{
    public Image GuiElement { get; private set; }

    public GuiEmpty(double height, double width)
    {
        GuiElement = new GuiImage(ImageSource.File, "Misc/Empty.png", height, width).GuiElement;
    }
}

public class GuiImage : GuiRow
{
    public Image GuiElement { get; private set; }

    public GuiImage(ImageSource sType, string source, double? height = null, double? width = null)
    {
        Console.WriteLine("Creating");
        GuiElement = new Image();
        GuiElement.Source = new GuiBackgroundImage(sType, source).img.ImageSource;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Height = height == null ? GuiElement.Height : (double)width;
    }
}

public class GuiButton : GuiRow
{

    private string Name;
    private string Text;
    private object ClickAction;
    public Button GuiElement { get; private set; }

    public GuiButton(string name, string text, Action ClickEvent, double? height = null, double? width = null, int[] backgroundColor = null, GuiBackgroundImage backgroundImage = null)
    {
        SetValues(name, text, ClickEvent, null, height, width, backgroundColor, backgroundImage);
    }

    public GuiButton(string name, string text, Action<string> ClickEvent, double? height = null, double? width = null, int[] backgroundColor = null, GuiBackgroundImage backgroundImage = null)
    {
        SetValues(name, text, null, ClickEvent, height, width, backgroundColor, backgroundImage);
    }

    private void SetValues(string name, string text, Action actionA, Action<string> actionB, double? height, double? width, int[] backgroundColor, GuiBackgroundImage backgroundImage)
    {
        Name = name;
        Text = text;
        if(actionA==null)
        {
            ClickAction = actionB;
        }
        else
        {
            ClickAction = actionA;
        }
        CreateButton(height, width, backgroundColor, backgroundImage);
    }

    private void CreateButton(double? height, double? width, int[] backgroundColor, GuiBackgroundImage backgroundImage)
    {
        GuiElement = new Button();
        GuiElement.Content = Text;
        GuiElement.Name = Name;
        GuiElement.Click += OnClick;
        GuiElement.Height = height == null ? GuiElement.Height : (double)height;
        GuiElement.Width = width == null ? GuiElement.Width : (double)width;
        GuiElement.Background = backgroundColor==null ? GuiElement.Background : new SolidColorBrush(Color.FromArgb(255, (byte)backgroundColor[0], (byte)backgroundColor[1], (byte)backgroundColor[2]));
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