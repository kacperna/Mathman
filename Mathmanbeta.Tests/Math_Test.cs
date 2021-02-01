using System.Windows.Forms;
using Xunit;

namespace Mathmanbeta.Tests
{
    public class Math_Test
    {
        private Math math = new Math();
        [Fact]
        public void CreateMathTest()
        {
            math.CreateMath(new Form());
            Assert.Equal(math.eq,math.Equation.Text);

        }
    }
}
