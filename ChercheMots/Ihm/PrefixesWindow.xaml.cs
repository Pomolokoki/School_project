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
    /// Logique d'interaction pour PrefixesWindow.xaml
    /// </summary>
    /// <author>Hubert Tom</author>
    public partial class PrefixesWindow : Window
    {
        private Metier.Dictionnaire dico;
        public PrefixesWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
        }

        private void Chercher(object sender, RoutedEventArgs e)
        {
            var list = dico.Prefixes(prefix.Text);
            mots.Items.Clear();
            foreach (var s in list)
                mots.Items.Add(s);
        }
    }
}
