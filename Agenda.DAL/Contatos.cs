using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        SqlConnection _con;

        public Contatos()
        {
            _strCon = @"Data Source=.\sqlexpress;Initial Catalog=Agenda;Integrated Security=true";
            _con = new SqlConnection(_strCon);
        }


        public void Adicionar(Contato contato)
        {
            string sqlCommand = String.Format("Insert into Contato (Id, Nome) values('{0}', '{1}');", contato.Id.ToString(), contato.Nome);

            _con.Open();

            using (SqlCommand cmd = new SqlCommand(sqlCommand, _con))
            {
                var rollsAfected = cmd.ExecuteNonQuery();
            }
            _con.Close();
        }

        public Contato Obter(Guid id)
        {
            var sqlCommand = String.Format("select * from contato where Id = '{0}';", id.ToString());

            _con.Open();

            using (SqlCommand cmd = new SqlCommand(sqlCommand, _con))
            {
                var sqlRead = cmd.ExecuteReader();
                sqlRead.Read();

                var resultado = new Contato
                {
                    Id = Guid.Parse(sqlRead["Id"].ToString()),
                    Nome = sqlRead["Nome"].ToString()
                };
                _con.Close();

                return resultado;
            }
        }

        public List<Contato> ObterTodos()
        {
            var sqlCommand = String.Format("select * from contato");
            var contatos = new List<Contato>();

            _con.Open();

            using (SqlCommand cmd = new SqlCommand(sqlCommand, _con))
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
            _con.Close();
            return contatos;
        }
    }
}
