using Colors.model;
using System;
using Xunit;

namespace TestColors
{
    public class HTMLTest
    {
        [Fact]
        public void TestToRGB()
        {
            HTML html = new HTML("#FF50AB");
            RGB exp = new RGB(0xFF, 0x50, 0xAB);
            RGB res = html.ToRGB();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToHSL()
        {
            HTML html = new HTML("#93BE3F");
            HSL exp = new HSL(80, 66, 64);
            HSL res = html.ToHSL();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToCMYB()
        {
            HTML html = new HTML("#323133");
            CMYB exp = new CMYB(1, 3, 0, 80);
            CMYB res = html.ToCMYB();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToColor()
        {
            HTML html = new HTML("#FF50AB");
            System.Windows.Media.Color color = new System.Windows.Media.Color() { R = 0xFF, G = 0x50, B = 0xAB };
            Assert.Equal(color, html.ToColor());
        }
    }
}
