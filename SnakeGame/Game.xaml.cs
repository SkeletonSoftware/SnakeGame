using SnakeGame.Models;
using SharpHook;

namespace SnakeGame;

public partial class Game : ContentPage
{
    Models.Game game;
	public Game()
	{
		InitializeComponent();
        var hook = new TaskPoolGlobalHook();
        hook.KeyPressed += OnKeyPressed;
        Task.Run(async () =>
        {
            await hook.RunAsync();
        });

        var boardSizeX = 20;
        var boardSizeY = 20;
        var boardSizeW = 25;

        this.game = new Models.Game(GameContent, boardSizeX, boardSizeY, boardSizeW);
        this.game.InitGame();
	}

    private void OnKeyPressed(object sender, KeyboardHookEventArgs e)
    {
        switch(e.Data.KeyCode)
        {
            case SharpHook.Native.KeyCode.VcNumPadRight:
                this.game.KeyPress(Snake.DIRECTION.RIGHT);
                break;
            case SharpHook.Native.KeyCode.VcNumPadLeft:
                this.game.KeyPress(Snake.DIRECTION.LEFT);
                break;
            case SharpHook.Native.KeyCode.VcNumPadUp:
                this.game.KeyPress(Snake.DIRECTION.UP);
                break;
            case SharpHook.Native.KeyCode.VcNumPadDown:
                this.game.KeyPress(Snake.DIRECTION.DOWN);
                break;
            case SharpHook.Native.KeyCode.VcP:
                this.game.GamePause();
                break;
            default:
                break;
        }
    }
}