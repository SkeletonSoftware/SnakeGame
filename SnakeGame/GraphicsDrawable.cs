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
        //Config rendereru
        // --
        public readonly int DRAW_THICKNESS;
        public readonly Color SnakeColor = Color.FromHex("#a4c13b");
        public readonly Color FoodColor = Color.FromHex("#e31A5F");
        // --

        private List<Models.Tile> tiles;
        private int xSize = 0;
        private int ySize = 0;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            //Pozadí
            canvas.StrokeColor = Color.FromRgb(0, 00, 00);
            canvas.StrokeSize = DRAW_THICKNESS;
            canvas.FillColor = Color.FromRgb(200, 200, 200);
            canvas.DrawRectangle(DRAW_THICKNESS / 2, DRAW_THICKNESS / 2, (this.xSize + 1) * DRAW_THICKNESS + DRAW_THICKNESS / 2, (this.ySize + 1) * DRAW_THICKNESS + DRAW_THICKNESS / 2);
            canvas.FillRectangle(DRAW_THICKNESS * 1f, DRAW_THICKNESS * 1f, (this.xSize) * DRAW_THICKNESS + DRAW_THICKNESS / 2, (this.ySize) * DRAW_THICKNESS + DRAW_THICKNESS / 2);

            //Popředí
            foreach (Models.Tile tile in this.tiles)
            {
                canvas.StrokeSize = DRAW_THICKNESS/2;
                switch (tile.type)
                {
                    case Tile.TileType.Food:
                        canvas.StrokeColor = this.FoodColor;
                        canvas.FillColor = this.FoodColor;
                        break;
                    case Tile.TileType.Snake:
                        canvas.StrokeColor = this.SnakeColor;
                        canvas.FillColor = this.SnakeColor;
                        break;
                    default:
                        canvas.StrokeColor = Color.FromRgb(255, 255, 255);
                        canvas.FillColor = Color.FromRgb(255, 255, 255);
                        break;
                }
                canvas.DrawRectangle(((tile.x+1)*DRAW_THICKNESS) + DRAW_THICKNESS/2, ((tile.y+1)*DRAW_THICKNESS) + DRAW_THICKNESS/2, DRAW_THICKNESS/2, DRAW_THICKNESS/2);
            }
        }

        public GraphicsDrawable(List<Models.Tile> tiles, int xSize, int ySize, int wSize)
        {
            this.tiles = tiles;
            this.xSize = xSize;
            this.ySize = ySize;
            this.DRAW_THICKNESS = wSize;
        }
    }
}
