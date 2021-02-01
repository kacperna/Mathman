using System;
using System.Windows.Forms;
using Xunit;

namespace Mathmanbeta.Tests
{
    public class GameBoard_Test
    {
        private GameBoard gameBoard = new GameBoard();

        [Fact]
        public void NewGameBoardTest()
        {
            gameBoard.CreateBoardImage(new Form());
            Assert.NotNull(gameBoard.BoardImage.Image);
            Assert.Equal(0, gameBoard.BoardImage.Left);
            Assert.Equal(50, gameBoard.BoardImage.Top);
            Assert.Equal("BoardImage", gameBoard.BoardImage.Name);
        }
        
        [Fact]
        public void GameBoardMatrixTest()
        {
            Assert.Equal(new Tuple<int, int>(31, 17), gameBoard.InitialiseBoardMatrix());
        }
    }
}
