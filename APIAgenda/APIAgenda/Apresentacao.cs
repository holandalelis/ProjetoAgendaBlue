using System.Collections.Generic;

namespace APIAgenda
{
    public class Apresentacao
    {
        public Apresentacao()
        {
            rotas = new List<string>();
            rotas.Add("/contatos");
        }
        private List<string> rotas { get; set; }
        public string Mensagem { get { return "Bem vindo(a) a API da Agenda da Blue Technology"; } }
        public List<string> Rotas { get { return this.rotas; } }
    }
}
