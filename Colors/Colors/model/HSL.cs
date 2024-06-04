using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Text;

namespace Colors.model
{
    /// <summary>
    /// A Hue saturation Luminance color
    /// </summary>
    public class HSL : IColorMode
    {
        #region do not edit
        private float hue;
        private float saturation;
        private float luminance;

        /// <summary>
        /// Init the HSL color
        /// </summary>
        /// <param name="h">the hue value (0-360)</param>
        /// <param name="s">the saturation value (0-100)</param>
        /// <param name="l">the luminance value (0-100)</param>
        /// <exception cref="BadColorValues">If a value is not correct</exception>
        public HSL(float h, float s, float l)
        {
            if (h > 360 || s > 100 || l > 100 || h < 0 || s < 0 || l < 0)
                throw new BadColorValues();
	    this.hue = h;
	this.saturation = s;
	this.luminance = l;
        }

        /// <summary>
        /// Gets the hue value
        /// </summary>
        public int Hue
        {
            get { return (int)hue; }
        }

        /// <summary>
        /// Gets the saturation value
        /// </summary>
        public int Saturation
        {
            get { return (int)saturation; }
        }

        /// <summary>
        /// Gets the luminance value
        /// </summary>
        public int Luminance
        {
            get { return (int)luminance; }
        }

        public override bool Equals(object obj)
        {
            return obj is HSL hSL &&
                   Hue == hSL.Hue &&
                   Saturation == hSL.Saturation &&
                   Luminance == hSL.Luminance;
        }
        #endregion

        #region code to do
        /// <summary>
        /// Convert the color in CMJN
        /// </summary>
        /// <returns>The same color with CMJN components</returns>
        /// <author>Hubert Tom</author>
        public CMYB ToCMYB()
        {
            return ToRGB().ToCMYB();
        }
        /// <summary>
        /// Convert the color in HSL
        /// </summary>
        /// <returns>The color with HSL components</returns
        /// <author>Hubert Tom</author>
        public HSL ToHSL()
        {
            return this;
        }
        /// <summary>
        /// Convert the color in HTML
        /// </summary>
        /// <returns>the color in HTML string format</returns>
        /// <author>Hubert Tom</author>
        public HTML ToHTML()
        { 
            return ToRGB().ToHTML();
        }

        /// <summary>
        /// Convert the color in RGB
        /// </summary>
        /// <returns>the same color with RGB components</returns>
        /// <author>Hubert Tom</author>
        public RGB ToRGB()
        {
            float M = luminance * 255 / 100;
            float m = (100 - saturation) * luminance * 255 / 10000;
            float C = M - m;
            float i = hue / 60;
            float X = C * (i % 2);
            if (i<1) {
                return new RGB(C + m, X + m, m);
            }
            else if (i>=1.0 && i<2.0) {
                return new RGB(X + m, C + m, m);
            }
            else if (i>=2.0 && i<3.0)
            {
                return new RGB(m, C + m, X + m);
            }
            else if (i>=3.0 && i<4.0) {
                return new RGB(m, X + m, C + m);
            }
            else if (i>=4.0 && i<5.0) {
                return new RGB(X + m, m, C + m);
            }
            else {
                return new RGB(C + m, m, X + m);
            }

        }

        /// <summary>
        /// Convert the color in standard WPF color format
        /// </summary>
        /// <returns>the color in standard WPF color format</returns>
        /// <author>Hubert Tom</author>
        public Color ToColor()
        {
            return ToRGB().ToColor();
        }

        #endregion

    }
}
