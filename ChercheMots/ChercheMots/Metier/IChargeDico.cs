using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChercheMots.Metier
{
    /// <summary>
    /// Interface sur un chargeur de dictionnaire
    /// </summary>
    public interface IChargeDico
    {
        /// <summary>
        /// Charge le dictionnaire
        /// </summary>
        /// <returns>le dictionnaire chargé</returns>
        Dictionnaire Charger();
    }
}
