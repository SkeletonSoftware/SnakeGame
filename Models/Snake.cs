using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Snake : ISnake
    {
        /* Třída had
         * Had je v podstatě shluk několika souřadic, které označují, kde se nachází jeho části.
         *  
         * Proměnné:
         * SNAKE_COLOR = barva hada
         * DIRECTION = enum pro zvolení směru pohybu hada
         * board = instance herního pole, ke kterému je had přiřazen
         * body = List souřadnic všech čtverečků hada
         * xSpeed, ySpeed = rychlost v ose x a y (o kolik čtverečků se had posune za 1 tick)
         * score = aktuální score (kolikrát se již ahd najedl)
         * 
         */

        public static readonly Color SNAKE_COLOR = Color.FromRgb(255, 0, 0);
        public enum DIRECTION { UP, DOWN, LEFT, RIGHT };

        public List<Tile> body;
        public int xSpeed;
        public int ySpeed;
        public int score;

        public Tile NextMove()
        {
            return new Tile(
                this.body.Last().x + this.xSpeed,
                this.body.Last().y + this.ySpeed,
                Board.BOARD_SIZE_W,
                SNAKE_COLOR
            );
        }

        public void MoveTo(Tile tile, bool isFood)
        {
            if(!isFood)
                this.body.RemoveAt(0);
            this.body.Add(tile);
        }
        public void ChangeDirection(DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.UP:
                    this.xSpeed = 0;
                    this.ySpeed = -1;
                    break;
                case DIRECTION.DOWN:
                    this.xSpeed = 0;
                    this.ySpeed = 1;
                    break;
                case DIRECTION.LEFT:
                    this.xSpeed = -1;
                    this.ySpeed = 0;
                    break;
                case DIRECTION.RIGHT:
                    this.xSpeed = 1;
                    this.ySpeed = 0;
                    break;
                default:
                    this.xSpeed = 0;
                    this.ySpeed = 0;
                    break;
            }
        }

        public Snake(int x, int y)
        {
            this.body = new List<Tile> { new Tile(x, y, Board.BOARD_SIZE_W, SNAKE_COLOR) };
            this.xSpeed = 1;
            this.ySpeed = 0;
            this.score = 0;
        }
    }
}
