using Colors.model;
using System;
using Xunit;

namespace TestColors
{
    public class RGBTest
    {
        [Fact]
        public void TestToCMYB()
        {
            RGB test = new RGB(133, 101, 147);
            CMYB expResult = new CMYB(9, 31, 0, 42);
            CMYB result = test.ToCMYB();
            Assert.Equal(expResult, result);
        }

        [Fact]
        public void TestToHSL()
        {
            RGB rgb = new RGB(69, 158, 101);
            HSL hslExcepted = new HSL(141, 56, 49);
            HSL result = rgb.ToHSL();
            Assert.Equal(hslExcepted, result);
        }

        [Fact]
        public void TestToHTML()
        {
            RGB rgb = new RGB(0x13, 0xF0, 0x9B);
            HTML htmlExp = new HTML("#13F09B");
            HTML result = rgb.ToHTML();
            Assert.Equal(htmlExp, result);
        }

        [Fact]
        public void TestToColor()
        {
            RGB rgb = new RGB(255, 0, 0);
            System.Windows.Media.Color color = System.Windows.Media.Colors.Red;
            Assert.Equal(color, rgb.ToColor());
        }
    }
}
