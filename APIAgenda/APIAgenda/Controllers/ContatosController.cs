using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace APIAgenda.Controllers
{
    [Route("contatos")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        [HttpGet]
        [Route("lista")]
        [Route("")]
        public List<Contato> Index()
        {
            return Contato.Todos();
        }

        [HttpPost]
        [Route("criar")]
        public Contato Criar ([FromBody]Contato contato)
        {
            return contato.Salvar();
        }

        [HttpPut]
        [Route("{id}")]
        public Contato Atualizar(int id, [FromBody] Contato contato)
        {
            contato.Id = id;
            return contato.Salvar();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Excluir(int id)
        {
            Contato.Excluir(id);
        }
    }
}
