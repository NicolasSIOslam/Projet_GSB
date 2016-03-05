using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_gsb
{
    public partial class Form1 : Form
    {
        static Timer time = new Timer();
        static GestionDate gDate;

        public Form1()
        {
            InitializeComponent();
            
            try
            {
                ConnexionSql.getInstance();

                gDate = new GestionDate();

                time.Tick += new EventHandler(TimerEventProcessor);
                time.Interval = 5000;
                time.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            time.Stop();

            if (gDate.jourCourrant() == 1)
            {
                ConnexionSql.setCL(gDate.moisPrecedent());
            }
            else if (true)
            {
                ConnexionSql.setRB(gDate.moisPrecedent());
            }
            time.Enabled = true;
        }
    }
}
