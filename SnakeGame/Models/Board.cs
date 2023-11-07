using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace SnakeGame.Models
{
    public class Board : IBoard
    {
        /* Herní deska
         * 
         * Po jejím vytvoření se provolá metoda CreateBoard.
         * Tímto se vygeneruje herní pole
         * 
         * Proměnné:
         * BoardSize = rozměr herního pole - x a y v počtech políček
         * playing = bool označující, zda probíhá hra.
         * snake = instance hada, který je přiřazen tomut poli
         * food = List obsahující instance jídel přiřazených tomuto poli
         * 
         */
        public bool Playing
        {
            get => playing;
            set => playing = value;
        }

        private readonly int BoardSizeX;
        private readonly int BoardSizeY;
        private bool playing;
        private Snake snake;
        private List<Food> food;

        #region Constructor
        public Board(int x_size,  int y_size)
        {
            this.BoardSizeX = x_size;
            this.BoardSizeY = y_size;
        }
        #endregion

        #region Public methods
        public void InitBoard()
        {
            this.playing = true;
            this.snake = new Snake(5, 5);
            this.food = new List<Food> { };
            this.AddFood();
        }
        public void TestInitBoard(Snake snake, List<Food> food)
        {
            this.playing = true;
            this.snake = snake;
            this.food = food;
        }

        public int Tick()
        {
            var newTile = this.snake.NextMove();
            if (!IsSnake(newTile.x, newTile.y) &&
                newTile.x < this.BoardSizeX &&
                newTile.y < this.BoardSizeY &&
                newTile.x >= 0 &&
                newTile.y >= 0)
            {
                if (IsFood(newTile.x, newTile.y))
                {
                    RemoveFood(newTile.x, newTile.y);
                    this.snake.MoveTo(newTile, true);
                    AddFood();
                }
                else
                {
                    this.snake.MoveTo(newTile, false);
                }
                return 0;
            }
            return snake.Body.Count;
        }

        public List<Tile> DumpBoard()
        {
            List<Tile> output = new List<Tile>();
            foreach (Tile tile in this.snake.Body)
            {
                output.Add(tile);
            }
            foreach (Food food in this.food)
            {
                output.Add(food);
            }
            return output;
        }

        public void KeyPress(Snake.Direction direction)
        {
            this.snake.ChangeDirection(direction);
        }
        #endregion

        #region Private methods
        private void AddFood()
        {
            Random rnd = new Random(((int)DateTime.Now.Ticks));
            var randomX = (int)(rnd.Next(1, BoardSizeX));
            var randomY = (int)(rnd.Next(1, BoardSizeY));
            while (IsSnake(randomX, randomY))
            {
                randomX = (int)(rnd.Next(1, BoardSizeX));
                randomY = (int)(rnd.Next(1, BoardSizeY));
            }
            this.food.Add(new Food(randomX, randomY));
        }

        private void RemoveFood(int x, int y)
        {
            Food foodToRemove = null;
            foreach (Food food in this.food)
            {
                if (food.x == x && food.y == y)
                {
                    foodToRemove = food;
                    break;
                }
            }
            if (foodToRemove != null)
            {
                this.food.Remove(foodToRemove);
            }
        }
        private bool IsFood(int x, int y)
        {
            foreach (Food food in this.food)
            {
                if (food.x == x && food.y == y)
                    return true;
            }
            return false;
        }

        private bool IsSnake(int x, int y)
        {
            foreach (Tile snake in this.snake.Body)
            {
                if (snake.x == x && snake.y == y)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
