using System;
using System.Windows.Forms;
using Xunit;

namespace Mathmanbeta.Tests
{
    public class Game_Test
    {
        private Game game = new Game();

        public Game_Test()
        {
            Form form = new Form();
            game.CreatePlayerDetails(form);
            game.CreateLives(form);
        }

        [Fact]
        public void CreateLIvesTest()
        {           
            Assert.Equal(0, game.Score);
            Assert.Equal(3, game.Lives);
            Assert.Equal(1, game.Level);
        }
        [Fact]
        public void CreateScoreLabelTest()
        {
            Assert.Equal("Score: 0", game.ScoreText.Text);
            Assert.Equal("High Score: "+ game.Highscore.ToString(), game.HighScore.Text);
        }
        [Fact]
        public void UpdateScoreTest()
        {
            game.UpdateScore(300);
            Assert.Equal(300, game.Score);
        }
        [Fact]
        public void CreateLivesTest()
        {
            Assert.NotNull(game.LifeImage[0]);
            Assert.False(game.LifeImage[3].Visible);
        }
    }
}
