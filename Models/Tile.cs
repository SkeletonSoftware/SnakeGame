using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Tile
    {
        public int x;
        public int y;
        public int w;
        public Color color;

        public Tile(int x, int y, int w, Color color)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.color = color;
        }
    }
}
