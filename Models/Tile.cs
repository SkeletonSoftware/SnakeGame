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
        public TileType type;
        public enum TileType {
            Food,
            Snake,
        };

        #region Constructor
        public Tile(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }
        #endregion

    }
}
