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
         * Had je zjednodušeně pouze pole několika souřadic, které označují, kde se nachází jeho jednotlivé části těla.
         *  
         * Proměnné:
         * Direction = enum pro zvolení směru pohybu hada
         * body = list souřadnic všech čtverečků hada
         * xSpeed, ySpeed = rychlost v ose x a y (o kolik čtverečků se had posune za 1 tick)
         * score = aktuální score (kolikrát se již had najedl)
         * 
         */
        public enum Direction { Up, Down, Left, Right };
        public List<Tile> Body 
        { 
            get => body; 
        }
        
        private List<Tile> body;
        private int xSpeed;
        private int ySpeed;
        private int score;

        #region Constructor

        public Snake(int x, int y)
        {
            this.body = new List<Tile> { new Tile(x, y, Tile.TileType.Snake) };
            this.xSpeed = 1;
            this.ySpeed = 0;
            this.score = 0;
        }

        #endregion

        #region Public methods

        public Tile NextMove()
        {
            return new Tile(
                this.body.Last().x + this.xSpeed,
                this.body.Last().y + this.ySpeed,
                Tile.TileType.Snake
            );
        }

        public void MoveTo(Tile tile, bool isFood)
        {
            if (!isFood)
                this.body.RemoveAt(0);
            this.body.Add(tile);
        }
        public void ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.xSpeed = 0;
                    this.ySpeed = -1;
                    break;
                case Direction.Down:
                    this.xSpeed = 0;
                    this.ySpeed = 1;
                    break;
                case Direction.Left:
                    this.xSpeed = -1;
                    this.ySpeed = 0;
                    break;
                case Direction.Right:
                    this.xSpeed = 1;
                    this.ySpeed = 0;
                    break;
                default:
                    this.xSpeed = 0;
                    this.ySpeed = 0;
                    break;
            }
        }
    }

    #endregion
}
