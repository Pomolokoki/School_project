using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChercheMots.Metier
{
    public class DicoFactice : IChargeDico
    {
        public Dictionnaire Charger()
        {
            Dictionnaire tst = new Dictionnaire();
            tst.Ajouter("ordinateur", "machine machine pour faire des programmes");
            tst.Ajouter("prof", "super professionnel qui transforme des étudiants en informaticiens");
            tst.Ajouter("ropf", "truc qui n'existe pas mais qui permet de tester les anagrammes");
            tst.Ajouter("orpf", "truc qui n'existe pas non plus");
            tst.Ajouter("niche", "la où dort le chien");
            tst.Ajouter("chien", "ce qu'on trouve dans une niche");
            tst.Ajouter("chienne", "femelle du chien");
            return tst;
        }
    }
}
