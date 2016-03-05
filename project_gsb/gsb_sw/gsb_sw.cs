using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsb_sw
{
    public partial class gsb_sw : ServiceBase
    {
        static Timer time = new Timer();
        static GestionDate gDate;

        public gsb_sw()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                // C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe "C:\Users\Nicolas\Documents\Visual Studio 2015\Projects\appli_gsb\appli_gsb\bin\Debug\appli_gsb.exe"
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

        protected override void OnStop()
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
