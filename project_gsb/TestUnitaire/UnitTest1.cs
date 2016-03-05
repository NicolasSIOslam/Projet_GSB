using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using project_gsb;
namespace TestUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Testjour()
        {
            project_gsb.GestionDate() gd = new project_gsb.GestionDate();

            Assert.AreSame(,DateTime.Now.Day);
        }
    }
}
