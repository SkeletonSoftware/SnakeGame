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
            var status = board.Tick();
            Assert.IsTrue(status);
            status = board.Tick();
            Assert.IsTrue(status);
            board.KeyPress(Snake.Direction.Left);
            status = board.Tick();
            Assert.IsFalse(status);
        }
        [TestMethod()]
        public void SnakeFoodTest()
        {
            var board = PrepareBoard(Snake.Direction.Right, food: new List<Food> { new Food(6, 5), new Food(7, 5) });
            var status = board.Tick();
            Assert.IsTrue(status);
            status = board.Tick();
            Assert.IsTrue(status);

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

        #region Private methods
        private void TestSnakeMovement(bool isPlaying, List<Tile> tiles, int snakeX, int snakeY, bool shouldBePlaying)
        {
            if(shouldBePlaying)
                Assert.IsTrue(isPlaying);
            else
                Assert.IsFalse(isPlaying);
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