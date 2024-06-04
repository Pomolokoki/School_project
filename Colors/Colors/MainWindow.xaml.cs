using Colors.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Colors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region do not edit
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Change color of the middle zone
        /// </summary>
        /// <param name="color"></param>
        private void ChangeColor(Color color)
        {
            panelColor.Background = new SolidColorBrush(color);
        }

        /// <summary>
        /// Change the values of RGB sliders
        /// </summary>
        /// <param name="value">the new RGB value</param>
        private void ChangeRGB(RGB value)
        {
            redSlider.Value = value.Red;
            greenSlider.Value = value.Green;
            blueSlider.Value = value.Blue;
        }

        /// <summary>
        /// THe user has pressed the validate button of RGB zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserChangeRGB(object sender, RoutedEventArgs e)
        {
            try
            {
                RGB rgb = new RGB(Int32.Parse(redText.Text), Int32.Parse(greenText.Text), Int32.Parse(blueText.Text));
                ChangeColor(rgb.ToColor());
                ChangeCMYB(rgb.ToCMYB());
                ChangeHSL(rgb.ToHSL());
                ChangeHTML(rgb.ToHTML());
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }
        /// <summary>
        /// Use has changed the red slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            redText.Text = e.NewValue.ToString("000");
        }

        private void blueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blueText.Text = e.NewValue.ToString("000");
        }

        private void greenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            greenText.Text = e.NewValue.ToString("000");
        }

        private void cyanSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            cyanText.Text = e.NewValue.ToString("000");
        }

        private void magentaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            magentaText.Text = e.NewValue.ToString("000");
        }

        private void yellowSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            yellowText.Text = e.NewValue.ToString("000");
        }

        private void blackSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blackText.Text = e.NewValue.ToString("000");
        }

        private void hueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hueText.Text = e.NewValue.ToString("000");
        }

        private void saturationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            saturationText.Text = e.NewValue.ToString("000");
        }

        private void luminanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            luminanceText.Text = e.NewValue.ToString("000");
        }
        #endregion


        #region code to edit
        /// <summary>
        /// Change the CMYB sliders
        /// </summary>
        /// <param name="value">the new color</param>
        /// <author>Hubert Tom</author>
        private void ChangeCMYB(CMYB value)
        {
            // todo : same thing as CHangeRGB
            cyanSlider.Value = value.Cyan;
            magentaSlider.Value = value.Magenta;
            yellowSlider.Value = value.Yellow;
            blackSlider.Value = value.Black;
        }

        /// <summary>
        /// Change the HSL sliders
        /// </summary>
        /// <param name="value">the new color</param>
        /// <author>Hubert Tom</author>
        private void ChangeHSL(HSL value)
        {
            // todo : same thing as CHangeRGB
            hueSlider.Value = value.Hue;
            saturationSlider.Value = value.Saturation;
            luminanceSlider.Value = value.Luminance;
        }

        /// <summary>
        /// Change the HTML text
        /// </summary>
        /// <param name="value">the new color</param>
        /// <author>Olivier Mathis</author>
        private void ChangeHTML(HTML value)
        {
            // todo : same thing as CHangeRGB
            htmlText.Text = value.ToString();
            
        }

        /// <summary>
        /// The user has pressed the validate button of CMYB zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Hubert Tom</author>
        private void UserChangeCMYB(object sender, RoutedEventArgs e)
        {
            // todo : same thing as UserCHangeRGB but, with CMYB and not RGB
            try
            {
                CMYB rgb = new CMYB(Int32.Parse(cyanText.Text), Int32.Parse(magentaText.Text), Int32.Parse(yellowText.Text), Int32.Parse(blackText.Text));
                ChangeColor(rgb.ToColor());
                ChangeRGB(rgb.ToRGB());
                ChangeHSL(rgb.ToHSL());
                ChangeHTML(rgb.ToHTML());
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// The user has pressed the validate button of HSL zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Hubert Tom</author>
        private void UserChangeHSL(object sender, RoutedEventArgs e)
        {
            // todo : same thing as UserCHangeCMYB but, with HSL and not RGB
            try
            {
                HSL hsl = new HSL(Int32.Parse(hueText.Text), Int32.Parse(saturationText.Text), Int32.Parse(luminanceText.Text));
                ChangeColor(hsl.ToColor());
                ChangeCMYB(hsl.ToCMYB());
                ChangeRGB(hsl.ToRGB());
                ChangeHTML(hsl.ToHTML());
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// The user has pressed the validate button of HTML zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Olivier Mathis</author>
        private void UserChangeHTML(object sender, RoutedEventArgs e)
        {
            // todo : same thing as UserCHangeRGB but, with HTML and not RGB
            try
            {
                HTML htmlColor = new HTML(htmlText.Text);
                ChangeColor(htmlColor.ToColor());
                ChangeCMYB(htmlColor.ToCMYB());
                ChangeHSL(htmlColor.ToHSL());
                ChangeHTML(htmlColor.ToHTML());
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }


        #endregion


    }
}
