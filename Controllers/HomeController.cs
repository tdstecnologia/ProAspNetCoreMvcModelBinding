using Microsoft.AspNetCore.Mvc;
using ProAspNetCoreMvcModelBinding.Models;
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

        public ViewResult Index(int id)
        {
         return View(repository[id] ?? repository.People.First());
        }
    }
}
