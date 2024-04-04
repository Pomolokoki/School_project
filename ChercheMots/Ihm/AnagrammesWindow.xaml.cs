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
    /// Logique d'interaction pour AnagrammesWindow.xaml
    /// </summary>
    public partial class AnagrammesWindow : Window
    {
        private Metier.Dictionnaire dico;
        public AnagrammesWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
        }

        private void Chercher(object sender, RoutedEventArgs e)
        {
            var list = dico.Anagrammes(mot.Text);
            mots.Items.Clear();
            foreach (var s in list)
                mots.Items.Add(s);
        }
    }
}
