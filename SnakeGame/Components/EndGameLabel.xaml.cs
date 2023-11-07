using System.ComponentModel;

namespace SnakeGame.Components;

public partial class EndGameLabel : Label
{
	public EndGameLabel()
	{
		InitializeComponent();
#if ANDROID
        this.TextColor = AndroidColor;
#elif WINDOWS
        this.TextColor =  WindowsColor;
#endif
    }

    public static readonly BindableProperty AndroidColorProperty = BindableProperty.Create(nameof(AndroidColor), typeof(Color), typeof(EndGameLabel), Colors.Green);

    #region BindableProps
    public Color AndroidColor
    {
        get => (Color)GetValue(AndroidColorProperty);
        set => SetValue(AndroidColorProperty, value);
    }

    public static readonly BindableProperty WindowsColorProperty = BindableProperty.Create(nameof(WindowsColor), typeof(Color), typeof(EndGameLabel), Colors.DeepSkyBlue);
    public Color WindowsColor
    {
        get => (Color)GetValue(WindowsColorProperty);
        set => SetValue(WindowsColorProperty, value);
    }
    #endregion
}