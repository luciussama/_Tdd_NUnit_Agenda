using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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
                string sqlCommand = String.Format("Insert into Contato (Id, Nome) values('{0}', '{1}');", contato.Id.ToString(), contato.Nome);

                con.Open();

                using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
                {
                    var rollsAfected = cmd.ExecuteNonQuery();
                }
            }

        }

        public Contato Obter(Guid id)
        {
            var resultado = new Contato();
            using (var con = new SqlConnection(_strCon))
            {
                var sqlCommand = String.Format("select * from contato where Id = '{0}';", id.ToString());

                con.Open();

                using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
                {
                    var sqlRead = cmd.ExecuteReader();
                    sqlRead.Read();


                    resultado = new Contato
                    {
                        Id = Guid.Parse(sqlRead["Id"].ToString()),
                        Nome = sqlRead["Nome"].ToString()
                    };
                }

                return resultado;
            }
        }

        public List<Contato> ObterTodos()
        {
            var sqlCommand = String.Format("select * from contato");
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
                {
                    var sqlRead = cmd.ExecuteReader();
                    while (sqlRead.Read())
                    {
                        contatos.Add(new Contato
                        {
                            Id = Guid.Parse(sqlRead["Id"].ToString()),
                            Nome = sqlRead["Nome"].ToString()
                        });
                    }
                }
            }
            return contatos;
        }
    }
}
