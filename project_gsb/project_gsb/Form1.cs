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
                dataGridView.DataMember = "Test";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            time.Stop();
            MessageBox.Show("Restart");
            time.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time.Tick += new EventHandler(TimerEventProcessor);

            time.Interval = 30000; 
            time.Start();
        }
    }
}
