using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsb_sw
{
    class GestionDate
    {
        /// <summary>
        /// Retourne le mois en cours
        /// </summary>
        /// <returns>int</returns>
        public int moisCourrant()
        {
            return DateTime.Now.Month;
        }

        /// <summary>
        /// Retourne le mois d'avant le mois en cours
        /// </summary>
        /// <returns></returns>
        public string moisPrecedent()
        {
            string mois = (DateTime.Now.Month - 1).ToString();
            if (mois.Length == 1)
            {
                mois = "0" + mois;
            }

            if (DateTime.Now.Month - 1 == 0)
            {
                mois = "12";
            }

            return DateTime.Now.Year + mois;
        }
        /// <summary>
        /// 
        /// Retourne le numero du jour actuel
        /// </summary>
        /// <returns>int</returns>
        public int jourCourrant()
        {
            return DateTime.Now.Day;
        }
    }
}
