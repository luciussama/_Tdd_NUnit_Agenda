using Agenda.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;

        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }


        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("Insert into Contato (Id, Nome) values(@Id, @Nome)", contato);
            }
        }

        public Contato Obter(Guid id)
        {
            var resultado = new Contato();
            using (var con = new SqlConnection(_strCon))
            {
                return con.QueryFirst<Contato>("select * from contato where Id = @Id", new { Id = id });
            }
        }

        public List<Contato> ObterTodos()
        {
            var sqlCommand = String.Format("select * from contato");
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                contatos = con.Query<Contato>(sqlCommand).ToList();
            }
            return contatos;
        }
    }
}
