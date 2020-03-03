using System;
using System.Windows;
using System.Windows.Controls;

public class GuiElement { }
public class GuiRow : GuiElement { }

public class FinalElement
{
    public GuiButton finalButton = null;

    public FinalElement(GuiElement Element, string eType)
    {
        switch(eType)
        {
            case "Button":
                finalButton = Element as GuiButton;
                break;
        };
    }
}

public class GuiButton : GuiRow
{

    private string Name;
    private string Text;
    private object ClickAction;
    public Button GuiElement { get; private set; }

    public GuiButton(string name, string text, Action ClickEvent)
    {
        SetValues(name, text, ClickEvent, null);
    }

    public GuiButton(string name, string text, Action<string> ClickEvent)
    {
        SetValues(name, text, null, ClickEvent);
    }

    private void SetValues(string name, string text, Action actionA, Action<string> actionB)
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
        CreateButton();
    }

    private void CreateButton()
    {
        GuiElement = new Button();
        GuiElement.Content = Text;
        GuiElement.Name = Name;
        GuiElement.Click += OnClick;
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