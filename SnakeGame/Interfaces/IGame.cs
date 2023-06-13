using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IGame
    {
        /// <summary>
        /// Inicializuje hru defaultními instancemi
        /// </summary>
        public void InitGame();
        /// <summary>
        /// Enum definovaný pro všechny směry, kterými může had chodit
        /// </summary>
        /// <param name="direction"></param>
        public void KeyPress(Snake.Direction direction);
        /// <summary>
        /// Dočasně přeruší hru
        /// </summary>
        public void GamePause();
    }
}
