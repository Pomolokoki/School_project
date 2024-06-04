using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ChercheMots
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Metier.Dictionnaire dico ;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                // récupère le chemin du dictionnaire, relatif à l'exécutable
                string fichier = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\Ressources\dico.fr";
                // charge le dictionnaire
                Metier.IChargeDico chargeur = new Stockage.ChargeFichier(fichier);
                dico = chargeur.Charger();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Anagrammes(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre anagrammes
            Ihm.AnagrammesWindow win = new Ihm.AnagrammesWindow(dico);
            win.Show();
        }

        private void Definitions(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre définitions
            Ihm.DefinitionsWindow win = new Ihm.DefinitionsWindow(dico);
            win.Show();
        }

        /// <author>Hubert Tom</author>
        private void Prefixes(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre prefixes
            Ihm.PrefixesWindow win = new Ihm.PrefixesWindow(dico);
            win.Show();
        }

        /// <author>Hubert Tom</author>
        private void Palindromes(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre Palindromes
            Ihm.PalindromesWindow win = new Ihm.PalindromesWindow(dico);
            win.Show();
        }

        /// <author>Callerand Thibault</author>
        private void RechercheLettres(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre définitions
            Ihm.LettresWindow win = new Ihm.LettresWindow(dico);

            win.Show();
        }

        /// <author>Hubert Tom</author>
        private void MotsN(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre prefixes
            Ihm.MotsNWindow win = new Ihm.MotsNWindow(dico);
            win.Show();
        }

        /// <author>Evain Natan</author>
        private void Valeur(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre définitions
            Ihm.ValeurScrabbleWindow win = new Ihm.ValeurScrabbleWindow(dico);
            win.Show();
        }

        /// <author>Evain Natan</author>
        private void ValeurMot(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre définitions
            Ihm.ValeurMotWindow win = new Ihm.ValeurMotWindow(dico);
            win.Show();
        }
    }
}
