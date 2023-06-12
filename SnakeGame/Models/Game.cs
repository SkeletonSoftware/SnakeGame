using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    class Game
    {
        private Board board;
        private GraphicsView graphicsView;
        private readonly Layout gameView;

        private readonly int xSize;
        private readonly int ySize;
        private readonly int wSize;

        #region Constructor
        public Game(Layout gameView, int xSize, int ySize, int wSize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.wSize = wSize;
            this.gameView = gameView;
            this.board = new Board(xSize, ySize);

        }
        #endregion

        #region Public methods
        public void InitGame()
        {
            var graphicsDrawable = new GraphicsDrawable(new List<Tile>(), xSize, ySize, wSize);
            this.graphicsView = new GraphicsView();
            this.graphicsView.HeightRequest = (this.xSize + 3) * wSize;
            this.graphicsView.WidthRequest = (this.ySize + 3) * wSize;
            this.graphicsView.Drawable = graphicsDrawable;
            this.gameView.Children.Add(graphicsView);
            this.graphicsView.Invalidate();
            
            this.board.InitBoard();

            GameCycle();
        }

        public void KeyPress(Snake.DIRECTION direction)
        {
            this.board.KeyPress(direction);
        }

        public void GamePause()
        {
            this.board.playing = !this.board.playing;
            this.GameCycle();
        }
        #endregion

        #region Private methods
        private async void GameCycle()
        {
            while (board.playing)
            {
                var status = this.board.Tick();
                var tiles = this.board.DumpBoard();
                Render(tiles);
                if (!status)
                {
                    GamePause();
                }
                await Task.Delay(200);
            }
        }

        private void Render(List<Tile> tiles)
        {
            graphicsView.Drawable = new GraphicsDrawable(tiles, xSize, ySize, wSize);
            graphicsView.Invalidate();
        }
        #endregion
    }
}
