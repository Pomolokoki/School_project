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
    /// Logique d'interaction pour MotsNWindow.xaml
    /// </summary>
    public partial class MotsNWindow : Window
    {
        private Metier.Dictionnaire dico;
        public MotsNWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
        }

        private void Chercher(object sender, RoutedEventArgs e)
        {
            var list = dico.MotsN(Int32.Parse(nb.Text));
            mots.Items.Clear();
            foreach (var s in list)
                mots.Items.Add(s);
        }
    }
}