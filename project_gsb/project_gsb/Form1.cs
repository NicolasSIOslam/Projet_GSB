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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ConnexionSql.getInstance();
                dataGridView.DataSource = ConnexionSql.test();

                gDate = new GestionDate();

                time.Tick += new EventHandler(TimerEventProcessor);
                time.Interval = 30000;
                time.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            time.Stop();
            
            time.Enabled = true;
        }
    }
}
