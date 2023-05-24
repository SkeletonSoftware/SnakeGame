using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    class Food : Tile
    {
        private static readonly Color FOOD_COLOR = Color.FromRgb(0, 255, 0);

        public Food(int x, int y) : base(x, y, Board.BOARD_SIZE_W, FOOD_COLOR)
        {

        }
    }
}
