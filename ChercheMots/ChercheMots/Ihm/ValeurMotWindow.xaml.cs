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

namespace ChercheMots.Ihm
{
    /// <summary>
    /// Logique d'interaction pour ValeurMot.xaml
    /// </summary>
    /// <author>Evain Natan</author>
    public partial class ValeurMotWindow : Window
    {
        private Metier.Dictionnaire dico;
        public ValeurMotWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
        }

        private void Calculer(object sender, RoutedEventArgs e)
        {
            try
            {
                val.Text = dico.ValMot(mot.Text).ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
