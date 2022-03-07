using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAgenda.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    { 
        public Apresentacao Index()
        {
            return new Apresentacao();
        }
    }
}
