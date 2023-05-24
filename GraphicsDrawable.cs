using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Text;
using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GraphicsDrawable : IDrawable
    {
        private List<Models.Tile> tiles;
        public const int DRAW_OFFSET_X = 30;
        public const int DRAW_OFFSET_Y = 30;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Color.FromRgb(200, 200, 200);
            canvas.StrokeSize = Board.BOARD_SIZE_W;
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.DrawRectangle(DRAW_OFFSET_X, DRAW_OFFSET_Y, (Board.BOARD_SIZE_X+1) * Board.BOARD_SIZE_W + DRAW_OFFSET_X/2, (Board.BOARD_SIZE_Y+1) * Board.BOARD_SIZE_W + DRAW_OFFSET_Y/2);

            //canvas.StrokeSize = Board.BOARD_SIZE_W;
            //canvas.FillColor = Color.FromRgb(255, 255, 255);
            //canvas.FontColor = Color.FromRgb(255, 255, 255);
            //canvas.StrokeColor = Color.FromRgb(255, 255, 255);
            foreach (Models.Tile tile in this.tiles)
            {
                canvas.StrokeSize = Board.BOARD_SIZE_W/2;
                canvas.StrokeColor = tile.color;
                canvas.FillColor = tile.color;
                canvas.DrawRectangle((tile.x*tile.w) + DRAW_OFFSET_X, (tile.y*tile.w) + DRAW_OFFSET_Y, tile.w/2, tile.w/2);
            }
        }

        public GraphicsDrawable(List<Models.Tile> tiles)
        {
            this.tiles = tiles;
        }
    }
}
