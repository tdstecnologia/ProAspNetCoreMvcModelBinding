using Microsoft.AspNetCore.Mvc;
using ProAspNetCoreMvcModelBinding.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProAspNetCoreMvcModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(int id)
        {
            return View("Index", repository[id]);
        }


        public ViewResult Index2(int id)
        {
            return View("Index", repository[id] ?? repository.Pessoa.First());
        }

        public IActionResult Index3(int? id)
        {
            Pessoa pessoa;
            if (id.HasValue && (pessoa = repository[id.Value]) != null)
            {
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }

        /*
        public IActionResult Index([FromQuery] int? id)
        {
            Pessoa pessoa;
            if (id.HasValue && (pessoa = repository[id.Value]) != null)
            {
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }
        */

        public ViewResult Cadastro()
        {
            return View("Cadastro", new Pessoa());
        }

        [HttpPost]
        public ViewResult Cadastro(Pessoa pessoa)
        {
            return View("Index", pessoa);
        }

        public ViewResult EnderecoBasico(EnderecoResumido endereco)
        {
            return View("EnderecoBasico", endereco);
        }

        public ViewResult EnderecoBasico2([Bind(Prefix = nameof(Pessoa.EnderecoCasa))] EnderecoResumido endereco)
        {
            return View("EnderecoBasico", endereco);
        }

        public ViewResult DisplaySummary([Bind(nameof(EnderecoResumido.Cidade), Prefix = nameof(Pessoa.EnderecoCasa))] EnderecoResumido endereco) => View(endereco);

        //public ViewResult Names(string[] names) => View(names ?? new string[0]);

        public ViewResult Nomes(IList<string> nomes) => View(nomes ?? new List<string>());

        public ViewResult Address(IList<EnderecoResumido> addresses) => View(addresses ?? new List<EnderecoResumido>());

        //public string Header([FromHeader]string accept) => $"Header: {accept}";

        //public string Header([FromHeader(Name = "Accept-Language")] string accept) => $"Header: {accept}";

        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public Pessoa Body([FromBody]Pessoa pessoa)
        {
            Debug.WriteLine("Chamada do método ...");
            return pessoa;
        }
    }
}
