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
using System.Windows.Shapes;

namespace ChercheMots.Ihm
{
    /// <summary>
    /// Logique d'interaction pour LettresWindow.xaml
    /// </summary>
    /// <author>
    /// Thibault Callerand
    /// </author>
    public partial class LettresWindow : Window
    {
        private Metier.Dictionnaire dico;
        public LettresWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
        }

        private void Chercher(object sender, RoutedEventArgs e)
        {
            var list = dico.MotsAvecLettres(mot.Text, chekBool.IsChecked.GetValueOrDefault());
            mots.Items.Clear();
            foreach (var s in list)
                mots.Items.Add(s);
        }
    }
}
