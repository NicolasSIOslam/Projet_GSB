using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace gsb_sw
{
    class ConnexionSql
    {
        private static MySqlConnection connect = null;
        static DataSet ds;
        static MySqlDataAdapter adapter;

        public static MySqlConnection getInstance()
        {
            try
            {
                if (null == connect)
                {
                    ConnexionSql.Initialize();
                }
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }

            return connect;
        }

        private static void Initialize()
        {
            try
            {
                try
                {
                    connect = new MySqlConnection(ConfigurationManager.AppSettings["connexion"]);
                    ds = new DataSet("dsgestion");
                }
                catch (Exception emp)
                {
                    MessageBox.Show(emp.Message);
                }

            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }

        public static void OpenConnection()
        {
            try
            {
                connect.Open();
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                connect.Close();
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }
        /// <summary>
        /// update les lignes cr => cl
        /// du mois dernier
        /// </summary>
        /// <param name="mois"></param>
        /// <returns></returns>
        public static string setCL(string mois)
        {
            try
            {
                ConnexionSql.OpenConnection();
                adapter = new MySqlDataAdapter("UPDATE fichefrais SET idEtat = 'CL' WHERE idEtat = 'CR' and mois = " + mois, connect);
                adapter.Fill(ds, "Test");
                ConnexionSql.CloseConnection();
            }
            catch (Exception e)
            {
                return (e.Message);

            }

            return "UPDATE fichefrais SET idEtat = 'CL' WHERE idEtat = 'CR' and mois = " + mois;
        }
        /// <summary>
        /// update les lignes rb => va
        /// du mois dernier
        /// </summary>
        /// <param name="mois"></param>
        /// <returns></returns>
        public static string setRB(string mois)
        {
            try
            {
                ConnexionSql.OpenConnection();
                adapter = new MySqlDataAdapter("UPDATE fichefrais SET idEtat = 'RB' WHERE idEtat = 'VA' and mois = " + mois, connect);
                adapter.Fill(ds, "Test");
                ConnexionSql.CloseConnection();

            }
            catch (Exception e)
            {
                return(e.Message);
                
            }

            return "cool";
        }
    }
}
