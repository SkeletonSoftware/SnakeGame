using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnakeGame.Components;

public partial class EndGameLabel : Label
{
	public EndGameLabel()
	{
		InitializeComponent();
    }

    private Color androidColor;
    public Color AndroidColor
    {
        get => androidColor;
        set
        {
            androidColor = value;
#if ANDROID
            this.TextColor = value;
#endif
        }
    }

    private Color windowsColor;
    public Color WindowsColor
    {
        get => windowsColor;
        set
        {
            windowsColor = value;
#if WINDOWS
            this.TextColor = value;
#endif
        }
    }
}