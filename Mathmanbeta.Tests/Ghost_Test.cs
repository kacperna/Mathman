using System.Windows.Forms;
using Xunit;

namespace Mathmanbeta.Tests
{
    public class Ghost_Test
    {
        private Ghost ghost = new Ghost();
        
        [Fact]
        public void GhostTest()
        {
            ghost.CreateGhostImage(new Form());
            Assert.NotNull(ghost.GhostImage[0].Image);
        }
    }
    

}
