using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Media;

namespace Colors.model
{
    /// <summary>
    /// A color written with RGB components
    /// </summary>    
    public class RGB : IColorMode
    {
        #region code not to edit
        private readonly float red;
        private readonly float green;
        private readonly float blue;

        /// <summary>
        /// Create a RGB Color
        /// </summary>
        /// <param name="r">red value (0-255)</param>
        /// <param name="g">green value (0-255)</param>
        /// <param name="b">blue value (0-255)</param>
        /// <exception cref="BadColorValues">If values are not correct</exception>
        public RGB(float r, float g, float b)
        {
            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                throw new BadColorValues();
            red = r;
            green = g;
            blue = b;
        }

        /// <summary>
        /// Gets the red value
        /// </summary>
        public int Red
        {
            get { return (int)red; }
        }

        /// <summary>
        /// Return the green value
        /// </summary>
        public int Green
        {
            get { return (int)green; }
        }

        /// <summary>
        /// return the blue value
        /// </summary>
        public int Blue
        {
            get { return (int)blue; }
        }

        /// <summary>
        /// Gets the color in 32-bits value
        /// </summary>
        public Int32 Int
        {
            get
            {
                return (Red << 16) | (Green << 8) | Blue;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is RGB rGB &&
                   Int == rGB.Int;
        }
        #endregion

        #region code to do
        /// <summary>
        /// Convert the color in CMJN
        /// </summary>
        /// <returns>The same color with CMJN components</returns>
        /// <author>Callerand Thibault</author>
        public CMYB ToCMYB()
        {
            float R = 255 - this.Red;
            float G = 255 - this.Green;
            float B = 255 - this.Blue;

            float X = 0;
            if (R < G && R < B) { X = R; }
            else if (G < R && G < B) { X = G; }
            else { X = B; }

            float C = 100 * (R - X) / (255 - X);
            float M = 100 * (G - X) / (255 - X);
            float J = 100 * (B - X) / (255 - X);
            float N = 100 * X / 255;

            CMYB val = new CMYB(C, M, J, N);
            return val;
        }
        /// <summary>
        /// Convert the color in HSL
        /// </summary>
        /// <returns>The color with HSL components</returns>
        /// <author>Callerand Thibault</author>
        public HSL ToHSL()
        {
            float R = this.Red;
            float G = this.Green;
            float B = this.Blue;
            float m1 = 0, m2 = 0, C = 0;

            if (R > G && R > B) { m1 = R; }
            else if (G > R && G > B) { m1 = G; }
            else { m1 = B; };

            if (R < G && R < B) { m2 = R; }
            else if (G < R && G < B) { m2 = G; }
            else { m2 = B; };

            C = m1 - m2;
            float T = 0;
            if (m1 == R && C != 0) { T = 60 * (((G - B) / C) % 6); }
            else if (m1 == G && C != 0) { T = 60 * (((B - R) / C) + 2); }
            else if (C != 0) { T = 60 * (((R - G) / C) + 4); };

            if (T < 0) { T += 360; };
            float S = 100 * C / m1;
            float L = (float)(100 * (0.3 * R + 0.6 * G + 0.1 * B) / 255);

            HSL val = new HSL(T, S, L);
            return val;
        }
        /// <summary>
        /// Convert the color in HTML
        /// </summary>
        /// <returns>the color in HTML string format</returns>
        public HTML ToHTML()
        {
            string html = "#";
            string hex = this.Red.ToString("x");
            while (hex.Length < 2) { hex = "0" + hex; }
            html += hex;
            hex = this.Green.ToString("x");
            while (hex.Length < 2) { hex = "0" + hex; }
            html += hex;
            hex = this.Blue.ToString("x");
            while (hex.Length < 2) { hex = "0" + hex; }
            html += hex;
            Trace.WriteLine(html);
            return new HTML(html);
        }

        /// <summary>
        /// Convert the color in RGB
        /// </summary>
        /// <returns>the same color with RGB components</returns>
        public RGB ToRGB()
        {
            return this;
        }

        /// <summary>
        /// Convert the color in standard WPF color format
        /// </summary>
        /// <returns>the color in standard WPF color format</returns>
        /// <author>Callerand Thibault</author>
        public Color ToColor()
        {
            return Color.FromRgb((byte)red, (byte)green, (byte)blue);
        }

        #endregion
    }
}
