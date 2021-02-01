using System.Windows.Forms;
using Xunit;

namespace Mathmanbeta.Tests
{
    public class Pacman_Test
    {
        private Pacman pacman = new Pacman();

        [Fact]
        public void CooridantesTest()
        {
            Assert.Equal(0, pacman.xCoordinate);
            Assert.Equal(0, pacman.yCoordinate);
            Assert.Equal(0, pacman.currentDirection);
            Assert.Equal(0, pacman.nextDirection);
        }
        
        [Fact]
        public void CreatePacmanTest()
        {
            pacman.CreatePacmanImage(new Form(), 0, 0);
            Assert.NotNull(pacman.PacmanImage.Image);
            Assert.Equal(-3, pacman.PacmanImage.Left);
            Assert.Equal(43, pacman.PacmanImage.Top);
            Assert.Equal("PacmanImage", pacman.PacmanImage.Name);
        }
    }
}
