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
        /// <summary>
        /// Změna směru pohybu hada
        /// </summary>
        /// <param name="direction">Enum, který obsahuje slovně zadaný směr pohybu</param>
        public void ChangeDirection(DIRECTION direction);
        /// <summary>
        /// Posune hada na další políčko
        /// </summary>
        /// <param name="tile">Políčko, na které se má had posunout</param>
        /// <param name="isFood">Informace o tom, zda u tohoto posunu snědl jídlo</param>
        public void MoveTo(Tile tile, bool isFood);
        /// <summary>
        /// Vypočte a následně vrátí, na jaké pole by se měl had posunout při příštím ticku
        /// </summary>
        public Tile NextMove();

    }
}
