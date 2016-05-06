using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gsb_sw
{
    public partial class gsb_sw : ServiceBase
    {
         Timer time ;
         GestionDate gDate;

        //alt+ctrl+s pour accéder au log

        public gsb_sw()
        {
            InitializeComponent();
            time =new Timer(new TimerCallback(miseajour),null,0,5000);
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }
       /// <summary>
       /// Cette fonction est lancée au démarage
       /// </summary>
       /// <param name="args"></param>
       
        protected override void OnStart(string[] args)
        {
            try
            {
                ConnexionSql.getInstance();
                eventLog1.WriteEntry("In OnStart");
                gDate = new GestionDate();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry(ex.Message);
            }
        }

        protected override void OnStop()
        {
            
        }

        public void miseajour(object obj)
        {
            
           
            if (gDate.jourCourrant() < 11)
            {
                ConnexionSql.setCL(gDate.moisPrecedent());
            }
            else if (gDate.jourCourrant() > 19)
            {
                ConnexionSql.setRB(gDate.moisPrecedent());
            }
            
        }
    }
}
