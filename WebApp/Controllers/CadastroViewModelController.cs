using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class CadastroViewModelController : Controller
    {
        private WebAppEntities _db;
        public WebAppEntities Db
        {
            get
            {
                return _db;
            }

            set
            {
                _db = value;
            }
        }

        public CadastroViewModelController()
        {
            _db = new WebAppEntities();                
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<AddViewModel> items =
                Db.People.Select(c => new AddViewModel
                {
                    PeopleViewModel = new PeopleViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    },
                    AddressViewModel = new AddressViewModel()
                    {
                        Id = c.Id,
                        State = c.Address != null ? c.Address.State: null,
                        City = c.Address != null ? c.Address.City: null
                    }
                }).ToList();
            return View(items);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddViewModel addViewModel)
        {
            if (ModelState.IsValid)
            {
                People people = new People();
                Address address = new Address();

                people.Name = addViewModel.PeopleViewModel.Name;

                address.City = addViewModel.AddressViewModel.City;
                address.State = addViewModel.AddressViewModel.State;
                address.People = people;

                Db.People.Add(people);
                Db.Address.Add(address);

                Db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            AddViewModel item = GetById(id);
            return View("Create", item);
        }

        [HttpPost]
        public ActionResult Edit(AddViewModel addViewModel)
        {
            if (ModelState.IsValid)
            {
                People people = Db.People.Find(addViewModel.PeopleViewModel.Id);

                if (people != null)
                {
                    people.Name = addViewModel.PeopleViewModel.Name;
                    Db.SaveChanges();

                    if (addViewModel.AddressViewModel != null)
                    {
                        if (people.Address == null)
                        {
                            people.Address = new Address();
                            people.Address.Id = addViewModel.PeopleViewModel.Id;
                        }
                        people.Address.City = addViewModel.AddressViewModel.City;
                        people.Address.State = addViewModel.AddressViewModel.State;
                        people.Address.People = people;
                        Db.SaveChanges();
                    }

                }

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            AddViewModel item = GetById(id);
            return View(item);
        }

        //metodo server para recuperar
        protected AddViewModel GetById(int? id)
        {
            //
            People people = Db.People.Find(id);
            Address address = Db.Address.Find(id);
            //
            AddViewModel item = new AddViewModel();
            //
            if (people == null && address == null)
                throw new Exception("Error");

            if (people != null)
            {
                item.PeopleViewModel = new PeopleViewModel
                {
                    Id = people.Id,
                    Name = people.Name
                };
            }
            if (address != null)
            {
                item.AddressViewModel = new AddressViewModel
                {
                    Id = address.Id,
                    State = address.State,
                    City = address.City
                };
            }
            //
            return item;
        }
    }
}