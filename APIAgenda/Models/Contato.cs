using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Models
{
    [Table("agenda_contatos")]
    public class Contato
    {
        private static DBContexto db = new DBContexto();
        public Contato() { }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato Salvar()
        {
            if(this.Id > 0)
            {
               db.Contatos.Update(this);
            }
            else
            {
               db.Contatos.Add(this);
            }
            db.SaveChanges();
            return this;
        }

        public static List<Contato> Todos()
        {
            return db.Contatos.ToList();
        }

        public static void Excluir(int id)
        {
            db = new DBContexto();
            var cliente = db.Contatos.Where(c => c.Id == id).First();
            db.Contatos.Remove(cliente);
            db.SaveChanges();
        }












        
        public static List<Contato> Todos_Com_SqlConnection()
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

        public Contato Salvar_Com_SqlConnection()
        {
            SqlConnection conn = new SqlConnection(Conexao.Dados);
            conn.Open();
            SqlCommand cmd = new SqlCommand("CriarCliente @nome, @telefone, @email", conn);
            cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            cmd.Parameters["@nome"].Value = this.Nome;

            cmd.Parameters.Add("@telefone", SqlDbType.VarChar);
            cmd.Parameters["@telefone"].Value = this.Telefone;

            cmd.Parameters.Add("@email", SqlDbType.VarChar);
            cmd.Parameters["@email"].Value = this.Email;

            this.Id = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();
            return this;
        }
    }
}
