using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_gsb
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
        public int moisPrecedent()
        {
            int mois = DateTime.Now.Month;
            if (DateTime.Now.Month - 1 == 0)
            {
                mois = 12;
            }
            return mois;
        }
    }
}
