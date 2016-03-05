using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string moisPrecedent()
        {
            string mois = DateTime.Now.Month.ToString();
            if (DateTime.Now.Month - 1 == 0)
            {
                mois = "12";
            }
            MessageBox.Show(DateTime.Now.Year + mois);
            return DateTime.Now.Year+mois;
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
