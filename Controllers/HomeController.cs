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
        //public ViewResult Index(int id) => View(repository[id]);

        /*
        public ViewResult Index(int id)
        {
         return View(repository[id] ?? repository.People.First());
        }
        */

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

        public ViewResult Create() => View(new Pessoa());

        [HttpPost]
        public ViewResult Create(Pessoa pessoa) => View("Index", pessoa);

        //public ViewResult DisplaySummary(AddressSummary summary) => View(summary);

        //public ViewResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress))] AddressSummary summary) => View(summary);

        public ViewResult DisplaySummary([Bind(nameof(EnderecoResumido.Cidade), Prefix = nameof(Pessoa.EnderecoCasa))] EnderecoResumido endereco) => View(endereco);

        //public ViewResult Names(string[] names) => View(names ?? new string[0]);

        public ViewResult Names(IList<string> nomes) => View(nomes ?? new List<string>());

        public ViewResult Address(IList<EnderecoResumido> addresses) => View(addresses ?? new List<EnderecoResumido>());

        //public string Header([FromHeader]string accept) => $"Header: {accept}";

        //public string Header([FromHeader(Name = "Accept-Language")] string accept) => $"Header: {accept}";

        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public Pessoa Body([FromBody]Pessoa pessoa)
        {
          Debug.WriteLine("Chamada do método ...");
          return  pessoa;
        }
    }
}
