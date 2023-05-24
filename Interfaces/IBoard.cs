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
        /// Přepíná stav hry mezi pauzou a hraním
        /// </summary>
        public void GamePause();
        /// <summary>
        /// Provolá se, když hra skončí. Vypne hru a znemožní její obnovení.
        /// </summary>
        /// <param name="score">Score, kterého had během svého života dosáhl</param>
        public void GameOver(int score);
        /// <summary>
        /// Odchytávání stisků klávesnice
        /// </summary>
        /// <param name="direction">Enum definovaný pro všechny směry, kterými může had chodit</param>
        public void KeyPress(Snake.DIRECTION direction);
        /// <summary>
        /// Hlavní smyčka. Zde probíhá update celého herního cyklu. Dokud je proměnná playing na stavená na true, smyčka běží.
        /// </summary>
        public void Update();
        /// <summary>
        /// Odstraní jídlo na zadaných souřadnicích
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RemoveFood(int x, int y);
        /// <summary>
        /// Zkontroluje, zda se na zadaných souřadnicích nachází jídlo
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Ano/Ne</returns>
        public bool IsFood(int x, int y);
        /// <summary>
        /// Zkontroluje, zda se na zadaných souřadnicích nachází had
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Ano/Ne</returns>
        public bool IsSnake(int x, int y);
        /// <summary>
        /// Přidá jídlo na náhodnou pozici na mapě
        /// </summary>
        public void AddFood();
        /// <summary>
        /// Vyrenderuje herní pole
        /// </summary>
        /// <param name="canvas">Instance GraphicsView, na které lze volat Invalidate() pro její překreslení</param>
        public void CreateBoard(GraphicsView canvas);

    }
}
