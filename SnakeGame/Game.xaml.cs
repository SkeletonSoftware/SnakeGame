using SnakeGame.Models;
using SharpHook;
using static SnakeGame.Models.Game;

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
        this.game.GameEnded += GameEnded;
        this.game.InitGame();
	}

    private void GameEnded(object sender, GameOverEventArgs e)
    {
        App.Current.MainPage = new ScorePage(e.Score);
    }

    private void OnKeyPressed(object sender, KeyboardHookEventArgs e)
    {
        switch(e.Data.KeyCode)
        {
            case SharpHook.Native.KeyCode.VcNumPadRight:
                this.game.KeyPress(Snake.Direction.Right);
                break;
            case SharpHook.Native.KeyCode.VcNumPadLeft:
                this.game.KeyPress(Snake.Direction.Left);
                break;
            case SharpHook.Native.KeyCode.VcNumPadUp:
                this.game.KeyPress(Snake.Direction.Up);
                break;
            case SharpHook.Native.KeyCode.VcNumPadDown:
                this.game.KeyPress(Snake.Direction.Down);
                break;
            case SharpHook.Native.KeyCode.VcP:
                this.game.GamePause();
                break;
            default:
                break;
        }
    }
    private void SwipeUp(object sender, SwipedEventArgs e) => this.game.KeyPress(Snake.Direction.Up);
    private void SwipeDown(object sender, SwipedEventArgs e) => this.game.KeyPress(Snake.Direction.Down);
    private void SwipeRight(object sender, SwipedEventArgs e) => this.game.KeyPress(Snake.Direction.Right);
    private void SwipeLeft(object sender, SwipedEventArgs e) => this.game.KeyPress(Snake.Direction.Left);

}