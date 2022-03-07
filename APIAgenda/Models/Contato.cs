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
    }
}
