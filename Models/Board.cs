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
         * = nejnadřazenější objekt. Po jejím vytvoření se provolá metoda CreateBoard.
         * Tímto se vygeneruje herní pole
         * 
         * Proměnné:
         * BOARD_SIZE = rozměr herního pole - x a y v počtech políček, w = šířka jednoho políčka
         * playing = bool označující, zda probíhá hra.
         * snake = instance hada, který je přiřazen tomut poli
         * food = List obsahující instance jídel přiřazených tomuto poli
         * canvas = odkaz na instanci GraphicsView. Je zde pro provolání metody Invalidate (překreslení Canvasu)
         * 
         * Metody:
         * CreateBoard = vygeneruje herní pole
         * AddFood = přidá na náhodnou pozici jídlo
         * IsFood = prověří, jestli je na daných souřadnicích nachází jidlo
         * RemoveFood = odstraní jídlo z daných souřadnic
         * GameOver = ukončí hru
         * Update = Herní smyčka. Stará se o provolání posunu hada a následné překreslení celého pole.
         *          Toto překreslení provádí třída GraphicDrawable, Update smyčka jí pouze provolá.
         * 
         */

        public static readonly int BOARD_SIZE_X = 20;
        public static readonly int BOARD_SIZE_Y = 20;
        public static readonly int BOARD_SIZE_W = 30;

        private bool playing;
        private Snake snake;
        private List<Food> food;
        private GraphicsView canvas;

        public void CreateBoard(GraphicsView canvas)
        {
            this.playing = true;
            this.canvas = canvas;
            this.snake = new Snake(this,5,5);
            this.food = new List<Food> { };
            this.AddFood();

            this.Update();
        }

        public void AddFood()
        {
            Random rnd = new Random(((int)DateTime.Now.Ticks));
            var randomX = (int)(rnd.Next(1, BOARD_SIZE_X));
            var randomY = (int)(rnd.Next(1, BOARD_SIZE_Y));
            while(IsSnake(randomX, randomY))
            {
                randomX = (int)(rnd.Next(1, BOARD_SIZE_X));
                randomY = (int)(rnd.Next(1, BOARD_SIZE_Y));
            }
            this.food.Add(new Food(randomX, randomY));
        }
        public bool IsFood(int x, int y)
        {
            foreach(Food food in this.food)
            {
                if(food.x ==  x && food.y == y) 
                    return true;
            }
            return false;
        }

        public bool IsSnake(int x, int y)
        {
            foreach (Tile snake in this.snake.body)
            {
                if (snake.x == x && snake.y == y)
                    return true;
            }
            return false;
        }

        public void RemoveFood(int x, int y)
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
            if(foodToRemove != null)
            {
                this.food.Remove(foodToRemove);
                this.AddFood();
            }
        }
        public async void Update()
        {      
            while (playing)
            {
                this.snake.Update();
                
                List<Tile> output = new List<Tile>();
                foreach (Tile tile in this.snake.body)
                {
                    output.Add(tile);
                }
                foreach(Food food in this.food)
                {
                    output.Add(food);
                }
                canvas.Drawable = new GraphicsDrawable(output);
                canvas.Invalidate();
                await Task.Delay(200);
            }
            return;
        }

        public void KeyPress(Snake.DIRECTION direction)
        {
            this.snake.ChangeDirection(direction);
        }

        public void GameOver(int score)
        {
            playing = false;
            
        }

        public void GamePause()
        {
            playing = !playing;
            Update();
        }
    }
}
