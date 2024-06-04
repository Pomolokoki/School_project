using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Text;

namespace Colors.model
{
    /// <summary>
    /// A Cyan-Magenta-Yellow-Black color
    /// </summary>
    public class CMYB : IColorMode
    {
        #region do not edit
        private readonly float cyan;
        private readonly float magenta;
        private readonly float yellow;
        private readonly float black;

        /// <summary>
        /// Init the CMYB color
        /// </summary>
        /// <param name="c">the cyan value (0-100)</param>
        /// <param name="m">the magenta value (0-100)</param>
        /// <param name="y">the yellow value (0-100)</param>
        /// <param name="b">the black value (0-100)</param>
        /// <exception cref="BadColorValues">If values are not correct</exception>
        public CMYB(float c, float m, float y, float b)
        {
            if (c > 100 || c < 0 || m > 100 || m < 0 || y > 100 || y < 0 || b > 100 || b < 0)
                throw new BadColorValues();
            cyan = c;
            magenta = m;
            yellow = y;
            black = b;
        }

        /// <summary>
        /// Gets the cyan value
        /// </summary>
        public int Cyan
        {
            get { return (int)cyan; }
        }

        /// <summary>
        /// Gets the magenta value
        /// </summary>
        public int Magenta
        {
            get { return (int)magenta; }
        }

        /// <summary>
        /// Gets the yellow value
        /// </summary>
        public int Yellow
        {
            get { return (int)yellow; }
        }

        /// <summary>
        /// Gets the black value
        /// </summary>
        public int Black
        {
            get { return (int)black; }
        }

        public override bool Equals(object obj)
        {
            return obj is CMYB cMYB &&
                   Cyan == cMYB.Cyan &&
                   Magenta == cMYB.Magenta &&
                   Yellow == cMYB.Yellow &&
                   Black == cMYB.Black;
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
            return this;
        }
        /// <summary>
        /// Convert the color in HSL
        /// </summary>
        /// <returns>The color with HSL components</returns>
        /// <author>Hubert Tom</author>
        public HSL ToHSL()
        {
            return ToRGB().ToHSL();
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
            return new RGB(255 * (100 - cyan * (1 - black / 100) - black) / 100,
                            255 * (100 - magenta * (1 - black / 100) - black) / 100,
                            255 * (100 - yellow * (1 - black / 100) - black) / 100);
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
