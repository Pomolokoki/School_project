using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Text;

namespace Colors.model
{
    public interface IColorMode
    {
        /// <summary>
        /// Convert the color in RGB
        /// </summary>
        /// <returns>the same color with RGB components</returns>
        RGB ToRGB();

        /// <summary>
        /// Convert the color in CMJN
        /// </summary>
        /// <returns>The same color with CMJN components</returns>
        CMYB ToCMYB();

        /// <summary>
        /// Convert the color in HSL
        /// </summary>
        /// <returns>The color with HSL components</returns>
        HSL ToHSL();

        /// <summary>
        /// Convert the color in HTML
        /// </summary>
        /// <returns>the color in HTML string format</returns>
        HTML ToHTML();

        /// <summary>
        /// Convert the color in standard WPF color format
        /// </summary>
        /// <returns>the color in standard WPF color format</returns>
        Color ToColor();
    }
}
