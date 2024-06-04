using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Text;

namespace Colors.model
{
    /// <summary>
    /// A color in HTML format (a simple String)
    /// </summary>
    public class HTML : IColorMode
    {
        #region do not edit
        private string htmlCode;

        /// <summary>
        /// Initialize the color with HTML value like #FF80C0 (RRGGBB in hexa)
        /// </summary>
        /// <param name="value">value the html code of the color</param>
        /// <exception cref="BadColorValues">If string format is not correct</exception>
        public HTML(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new BadColorValues();
            try
            {
                if (value[0] != '#')
                    throw new BadColorValues();
                int test = Int32.Parse(value.Substring(1), System.Globalization.NumberStyles.HexNumber);
                // if not thrown, then the value is ok
				htmlCode = value;
            }
            catch
            {
                throw new BadColorValues();
            }

        }

        public override string ToString()
        {
            return htmlCode;
        }

        public override bool Equals(object obj)
        {
            return obj is HTML hTML &&
                   htmlCode == hTML.htmlCode;
        }
        #endregion

        #region code to do
        /// <summary>
        /// Convert the color in CMJN
        /// </summary>
        /// <returns>The same color with CMJN components</returns>
        /// <author>Olivier Mathis</author>
        public CMYB ToCMYB()
        {
            try
            {
                if (htmlCode[0] != '#' || htmlCode.Length != 7)
                {
                    throw new BadColorValues();
                }

                float red = Convert.ToInt32(htmlCode.Substring(1, 2), 16);
                float green = Convert.ToInt32(htmlCode.Substring(3, 2), 16);
                float blue = Convert.ToInt32(htmlCode.Substring(5, 2), 16);
                float r = 255 - red;
                float g = 255 - green;
                float b = 255 - blue;


                float x = Math.Min(r, Math.Min(g, b));
                float c = 100 * (r - x) / (255 - x);
                float m = 100 * (g - x) / (255 - x);
                float y = 100 * (b - x) / (255 - x);
                float k = 100 * x / 255;

                return new CMYB(c, m, y, k);
            }
            catch
            {
                throw new BadColorValues();

            }
        }
        /// <summary>
        /// Convert the color in HSL
        /// </summary>
        /// <returns>The color with HSL components</returns>
        /// <author>Olivier Mathis</author>
        public HSL ToHSL()
        {
            try
            {
                // Assurez-vous que le code hexadécimal est dans un format valide
                if (htmlCode[0] != '#' || htmlCode.Length != 7)
                {
                    throw new BadColorValues();
                }

                float red = Convert.ToInt32(htmlCode.Substring(1, 2), 16);
                float green = Convert.ToInt32(htmlCode.Substring(3, 2), 16);
                float blue = Convert.ToInt32(htmlCode.Substring(5, 2), 16);


                return new RGB(red, green, blue).ToHSL(); ;
            }
            catch
            {
                throw new BadColorValues();
            }
        }
        /// <summary>
        /// Convert the color in HTML
        /// </summary>
        /// <returns>the color in HTML string format</returns>
        /// <author>Olivier Mathis</author>
        public HTML ToHTML()
        {
            return this;
        }

        /// <summary>
        /// Convert the color in RGB
        /// </summary>
        /// <returns>the same color with RGB components</returns>
        /// <author>Olivier Mathis</author>
        public RGB ToRGB()
        {
            try
            {
                if (htmlCode[0] != '#' || htmlCode.Length != 7)
                {
                    throw new BadColorValues();
                }

                float red = Convert.ToInt32(htmlCode.Substring(1, 2), 16);
                float green = Convert.ToInt32(htmlCode.Substring(3, 2), 16);
                float blue = Convert.ToInt32(htmlCode.Substring(5, 2), 16);

                return new RGB(red, green, blue);
            }
            catch
            {
                throw new BadColorValues();
            }
        }

        /// <summary>
        /// Convert the color in standard WPF color format
        /// </summary>
        /// <returns>the color in standard WPF color format</returns>
        /// <author>Olivier Mathis</author>
        public Color ToColor()
        {
            try
            {
                if (htmlCode[0] != '#' || htmlCode.Length != 7)
                {
                    throw new BadColorValues();
                }

                float red = Convert.ToInt32(htmlCode.Substring(1, 2), 16);
                float green = Convert.ToInt32(htmlCode.Substring(3, 2), 16);
                float blue = Convert.ToInt32(htmlCode.Substring(5, 2), 16);

                return Color.FromRgb((byte)red, (byte)green, (byte)blue);
            }
            catch
            {
                throw new BadColorValues();
            }
        }

        #endregion

    }
}
