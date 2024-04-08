using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ChercheMots.Metier;

namespace ChercheMots.Stockage
{
    /// <summary>
    /// Chargeur de dictionnaire utilisant un fichier texte de type CSV : 1 ligne = 1 mot, définition suivant la virgule
    /// </summary>
    public class ChargeFichier : IChargeDico
    {
        private string chemin;

        /// <summary>
        /// Initialise le chargement du dico
        /// </summary>
        /// <param name="chemin">le chemin complet du fichier contenant le dictionnaire</param>
        public ChargeFichier(string chemin)
        {
            this.chemin = chemin;
        }

        public Dictionnaire Charger()
        {
            Dictionnaire dico = new Dictionnaire();
            using (StreamReader fichier = new StreamReader(chemin))
            {
                string ligne;
                while( (ligne=fichier.ReadLine()) != null)
                {
                    string[] morceaux = ligne.Split(',');
                    string mot = morceaux[0];
                    string def = "";
                    def = morceaux[1];
                    for(int i=1;i < morceaux.Length;i++)
                    {
                        if (i > 1) def += ",";
                        def += morceaux[i];                        
                    } 
                    try
                    {
                        dico.Ajouter(mot, def);
                    }
                    catch { }
                }
            }
            return dico;
        }
    }
}
