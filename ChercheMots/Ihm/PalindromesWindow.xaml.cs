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
    /// Logique d'interaction pour PalindromesWindow.xaml
    /// </summary>
    public partial class PalindromesWindow : Window
    {
        private Metier.Dictionnaire dico;
        public PalindromesWindow(Metier.Dictionnaire dico)
        {
            InitializeComponent();
            this.dico = dico;
            Chercher();
        }

        private void Chercher()
        {
            var list = dico.Palindromes();
            mots.Items.Clear();
            foreach (var s in list)
                mots.Items.Add(s);
        }
    }
}
