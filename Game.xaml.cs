using SnakeGame.Models;
using SharpHook;

namespace SnakeGame;

public partial class Game : ContentPage
{
    Board board;
	public Game()
	{
		InitializeComponent();
        var hook = new TaskPoolGlobalHook();
        hook.KeyPressed += OnKeyPressed;
        Task.Run(async () =>
        {
            await hook.RunAsync();
        });
        var graphicsDrawable = new GraphicsDrawable(new List<Tile>());
        GraphicsView graphicsView = new GraphicsView();
        graphicsView.Drawable = graphicsDrawable;
        graphicsView.HeightRequest = (Board.BOARD_SIZE_X + 2) * Board.BOARD_SIZE_W + GraphicsDrawable.DRAW_OFFSET_X;
        graphicsView.WidthRequest = (Board.BOARD_SIZE_Y + 2) * Board.BOARD_SIZE_W + GraphicsDrawable.DRAW_OFFSET_Y;
        GameContent.Children.Add(graphicsView);
        graphicsView.Invalidate();


        this.board = new Board();
		this.board.CreateBoard(graphicsView);
	}

    private void OnKeyPressed(object sender, KeyboardHookEventArgs e)
    {
        switch(e.Data.KeyCode)
        {
            case SharpHook.Native.KeyCode.VcNumPadRight:
                this.board.KeyPress(Snake.DIRECTION.RIGHT);
                break;
            case SharpHook.Native.KeyCode.VcNumPadLeft:
                this.board.KeyPress(Snake.DIRECTION.LEFT);
                break;
            case SharpHook.Native.KeyCode.VcNumPadUp:
                this.board.KeyPress(Snake.DIRECTION.UP);
                break;
            case SharpHook.Native.KeyCode.VcNumPadDown:
                this.board.KeyPress(Snake.DIRECTION.DOWN);
                break;
            case SharpHook.Native.KeyCode.VcP:
                this.board.GamePause();
                break;
            default:
                break;
        }
    }
}