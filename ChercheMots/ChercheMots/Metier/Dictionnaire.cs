using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChercheMots.Metier
{
    /// <summary>
    /// Classe générale d'exception pour le dictionnaire
    /// </summary>
    public class DicoException : Exception { }

    public class DicoVide : DicoException 
    {
        public override string Message => "le dictionnaire est vide !"; 
    }

    /// <summary>
    /// Classe d'exception sur les soucis de mot
    /// </summary>
    public class MotException : Exception 
    {
        private string mot;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mot">le mot qui pose problème</param>
        public MotException(string mot)
        {
            this.mot = mot;
        }
        protected string Mot { get => mot; }
    }
    /// <summary>
    /// Exception levée quand un mot existe déjà dans le dico
    /// </summary>
    public class MotExisteException : MotException 
    {
        public MotExisteException(string mot) : base(mot)
        {            
        }
        public override string Message => "Le mot "+Mot+" existe déjà.";
    }

    /// <summary>
    /// Exception levée quand le mot n'existe pas dans le dico
    /// </summary>
    public class MotExistePasException : MotException
    {
        public MotExistePasException(string mot) : base(mot) { }
        public override string Message => "Le mot "+Mot+" n'existe pas dans le dico";
    }

    /// <summary>
    /// Représente un dictionnaire
    /// </summary>
    public class Dictionnaire
    {
        private Dictionary<string, string> mots;

        /// <summary>
        /// Initialise le dictionnaire
        /// </summary>
        public Dictionnaire()
        {
            mots = new Dictionary<string, string>();
        }

        /// <summary>
        /// Ajoute un mot au dictionnaire
        /// </summary>
        /// <param name="mot">le mot à ajouter</param>
        /// <param name="definition">la définition du mot à ajouter</param>
        /// <exception cref="MotExisteException">Si le mot existe déjà</exception>
        public void Ajouter(string mot, string definition)
        {
            if (mots.ContainsKey(mot)) throw new MotExisteException(mot);
            mots[mot] = definition;
        }

        /// <summary>
        /// Fournit la définition d'un mot
        /// </summary>
        /// <param name="mot">le mot dont on souhaite la définition</param>
        /// <returns>la définition du mot</returns>
        /// <exception cref="MotExistePasException">Si le mot n'existe pas dans le dico</exception>
        public string Definition(string mot)
        {
            if (!mots.ContainsKey(mot)) throw new MotExistePasException(mot);
            return mots[mot];
        }

        /// <summary>
        /// Indique si le dictionnaire contient le mot
        /// </summary>
        /// <param name="mot">le mot</param>
        /// <returns>true si le mot est contenu</returns>
        public bool Contient(string mot)
        {
            return mots.ContainsKey(mot);
        }

        /// <summary>
        /// Récupère un mot au hasard dans le dictionnaire
        /// </summary>
        /// <exception cref="DicoVide">Si aucun mot n'est présent</exception>
        public string MotAleatoire
        {
            get
            {
                if (mots.Count == 0) throw new DicoVide();
                Random r = new Random();
                int pos = r.Next(mots.Count);
                return mots.Keys.ToArray()[pos];
            }
        }

        /// <summary>
        /// Fournit le nombre de mots du dictionnaire
        /// </summary>
        public int NbMots
        {
            get => mots.Count;
        }

        /// <summary>
        /// Fournit les anagrammes d'un mot, issus du dictionnaire
        /// </summary>
        /// <param name="mot">le mot à chercher</param>
        /// <returns>la liste des mots contenant les mêmes lettres</returns>
        public List<string> Anagrammes(string mot)
        {
            List<string> retour = new List<string>();
            

            foreach(string m in mots.Keys)
            {
                if(m.Length==mot.Length && m!=mot)
                {
                    bool ok = true;
                    List<char> lettres = mot.ToList();
                    foreach (char c in m)
                    {
                        if(!lettres.Contains(c))
                        {
                            ok = false;
                            break;
                        }
                        else
                        {
                            lettres.Remove(c);
                        } 
                    }
                    if (ok)
                        retour.Add(m);
                }
            }
            return retour;
        }

        /// <summary>
        /// Renvoie une liste de mots commançant par le préfixe donné en paramètre
        /// </summary>
        /// <param name="prefix">le préfix avec lequel les mots doivent commençer</param>
        /// <author>Hubert Tom</author>
        public List<string> Prefixes(string prefix)
        {
            List<string> retour = new List<string>();


            foreach (string m in mots.Keys)
            {
                if (m.Length >= prefix.Length)
                {
                    bool ok = true;
                    for (int i = 0; i < prefix.Length; i++)
                    {
                        if (m[i] != prefix[i])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                        retour.Add(m);
                }
            }
            return retour;
        }

        /// <summary>
        /// Renvoie la liste des palindromes du ditionnaire
        /// </summary>
        /// <author>Hubert Tom</author>
        public List<string> Palindromes()
        {
            List<string> retour = new List<string>();


            foreach (string m in mots.Keys)
            {
                if (m.Length < 2) { continue; }
                bool ok = true;
                for (int i = 0; i < m.Length; i++)
                {
                    if (m[i] != m[m.Length - i - 1])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                    retour.Add(m);
            }

            return retour;
        }

        /// <summary>
        /// Renvoie la liste des mots du ditionnaire contenant les même lettre
        /// </summary>
        /// <author>Callerand Thibault</author>
        public List<string> MotsAvecLettres(string mot, bool chekOrNot)
        {
            List<string> retour = new List<string>();
            int sizeMot = mot.Length;
            if (chekOrNot)
            {
                foreach (string m in mots.Keys)
                {
                    bool ok = true;
                    List<char> lettresMots = mot.ToList();

                    foreach (char c in lettresMots)
                        if (!m.Contains(c))
                        {
                            ok = false;
                            break;
                        }

                    if (ok) retour.Add(m);
                }
            }
            else
            {
                foreach (string m in mots.Keys)
                {
                    bool ok = true;
                    List<char> lettresMots = m.ToList();
                    foreach (char c in mot)
                    {
                        if (!lettresMots.Contains(c))
                        {
                            ok = false;
                            break;
                        }
                        else
                        {
                            lettresMots.Remove(c);
                        }
                    }
                    if (ok) retour.Add(m);
                }
            }
            return retour;
        }

        /// <summary>
        /// Renvoie la liste des Mots de n lettres du ditionnaire
        /// </summary>
        /// <param name="nb">nombre de lettre dans le mot rechercher</param>
        /// <author>Hubert Tom</author>
        public List<string> MotsN(int nb)
        {
            List<string> retour = new List<string>();

            foreach (string m in mots.Keys)
            {
                if (m.Length == nb) { retour.Add(m); }
            }
            return retour;
        }
    }
}
