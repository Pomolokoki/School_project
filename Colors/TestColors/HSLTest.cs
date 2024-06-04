using Colors.model;
using System;
using Xunit;

namespace TestColors
{
    public class HSLTest
    {
        [Fact]
        public void TestToRGB()
        {
            HSL hsl = new HSL(196, 68, 50);
            RGB exp = new RGB(40, 150, 127);// mofified values
            RGB res = hsl.ToRGB();

            Assert.Equal(exp,res);
        }

        [Fact]
        public void TestToCMYB()
        {
            HSL hsl = new HSL(196, 68, 50);
            CMYB exp = new CMYB(73, 0, 15, 41);
            CMYB res = hsl.ToCMYB();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToHTML()
        {
            HSL hsl = new HSL(196, 68, 50);
            HTML exp = new HTML("#299780");
            HTML res = hsl.ToHTML();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToColor()
        {
            HSL hsl = new HSL(196, 68, 50);
            System.Windows.Media.Color exp = new System.Windows.Media.Color() { R = 41, G = 151, B = 128 };
            Assert.Equal(exp, hsl.ToColor());
        }
    }
}
