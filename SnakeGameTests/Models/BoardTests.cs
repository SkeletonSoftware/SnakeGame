using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace SnakeGame.Models.Tests
{
    [TestClass()]
    public class BoardTests
    {
        
        [TestMethod()]
        public void SnakeMovementTest()
        {
            //volný pohyb
            var board = PrepareBoard(Snake.Direction.Right);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 6, 5, true);
            board = PrepareBoard(Snake.Direction.Left);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 4, 5, true);
            board = PrepareBoard(Snake.Direction.Up);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 5, 4, true);
            board = PrepareBoard(Snake.Direction.Down);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 5, 6, true);

            //kolize se zdí
            board = PrepareBoard(Snake.Direction.Up, 0, 0);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 0, 0, false);
            board = PrepareBoard(Snake.Direction.Left, 0, 0);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 0, 0, false);
            board = PrepareBoard(Snake.Direction.Down, 19, 19);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 19, 19, false);
            board = PrepareBoard(Snake.Direction.Right, 19, 19);
            TestSnakeMovement(board.Tick(), board.DumpBoard(), 19, 19, false);

            //Kolize hada s hadem
            board = PrepareBoard(Snake.Direction.Right, food: new List<Food> { new Food(6, 5), new Food(7, 5) });
            var score = board.Tick();
            Assert.AreEqual(score, 0);
            score = board.Tick();
            Assert.AreEqual(score, 0);
            board.KeyPress(Snake.Direction.Left);
            score = board.Tick();
            Assert.AreNotEqual(score, 0);
        }
        [TestMethod()]
        public void SnakeFoodTest()
        {
            var board = PrepareBoard(Snake.Direction.Right, food: new List<Food> { new Food(6, 5), new Food(7, 5) });
            var score = board.Tick();
            Assert.AreEqual(score, 0);
            score = board.Tick();
            Assert.AreEqual(score, 0);

            var tiles = board.DumpBoard();
            var snakeCounter = 0;
            var foodCounter = 0;
            foreach(Tile t in tiles)
            {
                switch(t.type)
                {
                    case Tile.TileType.Snake:
                        snakeCounter++; 
                        break;
                    case Tile.TileType.Food:
                        foodCounter++;
                        break;
                    default:
                        break;
                }
            }
            Assert.AreEqual(snakeCounter, 3);
            Assert.AreEqual(foodCounter, 2);
        }

        [TestMethod()]
        public void Board_TickTest()
        {
            var board = PrepareBoard(Snake.Direction.Right, 17, 5, new List<Food> { new Food(19,5) });
            
            //Po prvním kroku bude existovat pouze had a jídlo, hra pokračuje
            var score = board.Tick();
            Assert.AreEqual(score, 0);
            var tiles = board.DumpBoard();
            Assert.IsInstanceOfType(tiles[0], typeof(Tile));
            Assert.IsInstanceOfType(tiles[1], typeof(Food));

            //Po druhém roku bude had najedený, existují tedy dvě políčka hada, jídlo a hra pokračuje
            score = board.Tick();
            Assert.AreEqual(score, 0);
            tiles = board.DumpBoard();
            var qe = tiles[0].Equals(new Tile(18, 5, Tile.TileType.Snake));
            var rov = tiles[0] == new Tile(18, 5, Tile.TileType.Snake);
            Assert.IsInstanceOfType(tiles[0], typeof(Tile));
            Assert.IsInstanceOfType(tiles[1], typeof(Tile));
            Assert.IsInstanceOfType(tiles[2], typeof(Food));
            
            //Po třetím kroku had narazí do zdi. Stav je tedy stejný jako minule, ale hra nepokračuje
            score = board.Tick();
            Assert.AreEqual(score, 2);
            var tilesAfterCollision = board.DumpBoard();
            Assert.IsInstanceOfType(tilesAfterCollision[0], typeof(Tile));
            Assert.IsInstanceOfType(tilesAfterCollision[1], typeof(Tile));
            Assert.IsInstanceOfType(tilesAfterCollision[2], typeof(Food));
        }

        [TestMethod()]
        public void Board_KeyPressTest()
        {
            var board = PrepareBoard(Snake.Direction.Right, 5, 5, new List<Food> { });

            //Změna směru nahoru
            board.KeyPress(Snake.Direction.Up);
            board.Tick();
            var tiles = board.DumpBoard();
            Assert.AreEqual(tiles[0].x, 5);
            Assert.AreEqual(tiles[0].y, 4);

            //Změna směru vpravo
            board.KeyPress(Snake.Direction.Right);
            board.Tick();
            tiles = board.DumpBoard();
            Assert.AreEqual(tiles[0].x, 6);
            Assert.AreEqual(tiles[0].y, 4);

            //Změna směru dolů
            board.KeyPress(Snake.Direction.Down);
            board.Tick();
            tiles = board.DumpBoard();
            Assert.AreEqual(tiles[0].x, 6);
            Assert.AreEqual(tiles[0].y, 5);

            //Změna směru vlevo
            board.KeyPress(Snake.Direction.Left);
            board.Tick();
            tiles = board.DumpBoard();
            Assert.AreEqual(tiles[0].x, 5);
            Assert.AreEqual(tiles[0].y, 5);
        }

        [TestMethod()]
        public void Board_InitBoard_Test()
        {
            var board = new Board(20, 20);
            board.InitBoard();
            
            //Hra běží
            Assert.IsTrue(board.Playing);

            var Tiles = board.DumpBoard();
            var snakeCounter = 0;
            var foodCounter = 0;
            foreach(Tile t in Tiles)
            {
                if(t.type == Tile.TileType.Food)
                    foodCounter++;
                else if(t.type == Tile.TileType.Snake)
                    snakeCounter++;
            }
            //Na herním poli se nachází had
            Assert.AreNotEqual(snakeCounter, 0);
            
            //Na herním poli se nachází jídlo
            Assert.AreNotEqual(foodCounter, 0);
        }

        #region Private methods
        private void TestSnakeMovement(int score, List<Tile> tiles, int snakeX, int snakeY, bool shouldBePlaying)
        {
            if (shouldBePlaying)
                Assert.AreEqual(score, 0);
            else
                Assert.AreNotEqual(score, 0);
            CoordinatesAreEqual(tiles.First(), snakeX, snakeY);
        }

        private void CoordinatesAreEqual(Tile tile, int x, int y)
        {
            Assert.AreEqual(tile.x, x);
            Assert.AreEqual(tile.y, y);
        }

        private Board PrepareBoard(Snake.Direction direction, int snakeX = 5, int snakeY = 5, List<Food> food = null) 
        {
            var board = new Board(20, 20);
            board.TestInitBoard(new Snake(snakeX, snakeY), food==null?new List<Food>():food);
            board.KeyPress(direction);
            return board;
        }
        #endregion
    }
}