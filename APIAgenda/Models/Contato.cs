using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Models
{
    public class Contato
    {
        public Contato()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public static List<Contato> Todos()
        {
            var lista = new List<Contato>();

            SqlConnection conn = new SqlConnection(Conexao.Dados);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from agenda_contatos", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Contato
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nome = reader["nome"].ToString(),
                    Telefone = reader["telefone"].ToString(),
                    Email = reader["email"].ToString(),
                });
            }
            conn.Close();
            conn.Dispose();
            return lista;
        }










    }
}
