using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Food : Tile
    {
        public Food(int x, int y) : base(x, y, TileType.Food)
        {

        }
    }
}
