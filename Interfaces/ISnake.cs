using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnakeGame.Models.Snake;

namespace SnakeGame.Interfaces
{
    public interface ISnake
    {
        public static readonly Color SNAKE_COLOR;
        /// <summary>
        /// Metoda, která provede všechny akce, které by se měly stát za jeden tick
        /// </summary>
        public void Update();
        /// <summary>
        /// Změna směru pohybu hada
        /// </summary>
        /// <param name="direction">Enum, který obsahuje slovně zadaný směr pohybu</param>
        public void ChangeDirection(DIRECTION direction);

    }
}
