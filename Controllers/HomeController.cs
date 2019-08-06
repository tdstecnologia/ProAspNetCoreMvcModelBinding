﻿using Microsoft.AspNetCore.Mvc;
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

        /*
        public ViewResult Index(int id)
        {
         return View(repository[id] ?? repository.People.First());
        }
        */

        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        //public ViewResult DisplaySummary(AddressSummary summary) => View(summary);

        //public ViewResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress))] AddressSummary summary) => View(summary);

        public ViewResult DisplaySummary([Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))] AddressSummary summary) => View(summary);

    }
}
