using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    public interface IBoard
    {
        /// <summary>
        /// Odchytávání stisků klávesnice
        /// </summary>
        /// <param name="direction">Enum definovaný pro všechny směry, kterými může had chodit</param>
        public void KeyPress(Snake.Direction direction);
        /// <summary>
        /// Inicializuje herní desku defaultními instancemi
        /// </summary>
        public void InitBoard();
        /// <summary>
        /// Inicializuje herní desku zadanými instancemi. Tato metoda je určena pro unit testy, nikoliv pro produkční použití.
        /// </summary>
        /// <param name="snake">Had, který se přidá hernímu poli</param>
        /// <param name="food">List jídel, který se přidá hernímu poli</param>
        public void TestInitBoard(Snake snake, List<Food> food);
        /// <summary>
        /// Hlavní smyčka hry. Provoláním metody se provede jeden herní cyklus (=tick).
        /// </summary>
        /// <returns>Zda tick proběhl bez chyb. Jinak také řečeno, zda hra dále pokračuje (true) nebo tímto tickem skončila (false)</returns>
        public bool Tick();
        /// <summary>
        /// Vrací všechny instance třídy Tile (políčka), které herní deska obsahuje.
        /// </summary>
        /// <returns></returns>
        public List<Tile> DumpBoard();
        /// <summary>
        /// Vrací informaci o stavu hry. Pokud se stále hraje, vrátí true, jinak false.
        /// </summary>
        public bool Playing { get; set; }
    }
}
