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
    /// Logique d'interaction pour DefinitionsWindow.xaml
    /// </summary>
    public partial class DefinitionsWindow : Window
    {
        private Metier.Dictionnaire dico;
        public DefinitionsWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
        }

        private void Chercher(object sender, RoutedEventArgs e)
        {
            try
            {
                def.Text = dico.Definition(mot.Text);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
