using Colors.model;
using System;
using System.Windows.Media;
using Xunit;

namespace TestColors
{
    public class CMYBTest
    {
        [Fact]
        public void TestToRGB()
        {
            CMYB cmyb = new CMYB(33, 52, 49, 14);
            RGB rgbExp = new RGB(146, 105, 111);
            RGB result = cmyb.ToRGB();
            Assert.Equal(rgbExp, result);
        }

        [Fact]
        public void TestToHSL()
        {
            CMYB cmyb = new CMYB(50, 31, 78, 14);
            HSL exp = new HSL(84, 68, 50);
            HSL res = cmyb.ToHSL();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToHTML()
        {
            CMYB cmyb = new CMYB(33, 52, 49, 14);
            HTML exp = new HTML("#936970");
            HTML res = cmyb.ToHTML();
            Assert.Equal(exp, res);
        }

        [Fact]
        public void TestToColor()
        {
            CMYB cmyb = new CMYB(33, 52, 49, 14);
            Color exp = new Color() { R = 0x93, G = 0x69, B = 0x70 };
            Color res = cmyb.ToColor();
        }
    }
}
