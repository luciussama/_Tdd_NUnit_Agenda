using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using Dapper;
using Agenda.Domain;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class BaseTest
    {
        private string _strCon;
        private string _script;
        private string _catalogTest;

        public BaseTest()
        {
            _strCon = ConfigurationManager
                .ConnectionStrings["connectionTest"]
                .ConnectionString;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            int qtdCampos;
            using (var con = new SqlConnection(_strCon))
            {
                qtdCampos = con.Query<Contato>("select * from contato").ToList().Count();
            }

            if (qtdCampos > 0)
            {
                DeleteDbData();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeleteDbData();
        }

       

        private void DeleteDbData()
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Open();

                using (var deleteCommand = new SqlCommand("Delete from Contato", con))
                {
                    deleteCommand.ExecuteNonQuery();
                }

            }
        }
    }
}

