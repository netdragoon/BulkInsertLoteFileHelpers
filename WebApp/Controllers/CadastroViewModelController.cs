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
            IQueryable<AddViewModel> query =
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
                        State = c.Address != null ? c.Address.State : null,
                        City = c.Address != null ? c.Address.City : null
                    },
                    PhoneViewModel = c.Phone.Select(a => new PhoneViewModel
                    {
                      Ddd  = a.Ddd, 
                      Number = a.Number,
                      PeopleId = a.PeopleId,
                      Id = a.Id
                    }).ToList()
                }).AsQueryable();
            IEnumerable<AddViewModel> items = query.ToList();
            return View(items);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            AddViewModel item = new AddViewModel();
            item.PhoneViewModel = GetPhoneViewModelDefault(0);
            return View(item);
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

                if (addViewModel?.PhoneViewModel.Count > 0)
                {
                    foreach (PhoneViewModel items in addViewModel.PhoneViewModel)
                    {
                        people.Phone.Add(new Phone
                        {
                            PeopleId = people.Id,
                            People = people,
                            Ddd = items.Ddd, 
                            Number = items.Number
                        });
                    }
                }

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
                    if (addViewModel.PhoneViewModel != null)
                    {
                        foreach (PhoneViewModel phoneViewModel in addViewModel.PhoneViewModel)
                        {
                            Phone phone = Db.Phone.Find(phoneViewModel.Id);
                            if (phone != null)
                            {
                                phone.Ddd = phoneViewModel.Ddd;
                                phone.Number = phoneViewModel.Number;
                                Db.SaveChanges();
                            }
                            else
                            {
                                phone = new Phone
                                {
                                    Ddd = phoneViewModel.Ddd,
                                    Number = phoneViewModel.Number,
                                    People = people,
                                    PeopleId = phoneViewModel.PeopleId
                                };
                                Db.Phone.Add(phone);
                                Db.SaveChanges();
                            }
                        }
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


        //metodo server para criar lista default ou padrão ou inicial
        protected ICollection<PhoneViewModel> GetPhoneViewModelDefault(int peopleid = 0)
        {
            ICollection<PhoneViewModel> phones = new List<PhoneViewModel>();
            phones.Add(new PhoneViewModel
            {
                Id = 0,
                PeopleId = peopleid,
                Number = string.Empty,
                Ddd = string.Empty
            });
            phones.Add(new PhoneViewModel
            {
                Id = 0,
                PeopleId = peopleid,
                Number = string.Empty,
                Ddd = string.Empty
            });
            phones.Add(new PhoneViewModel
            {
                Id = 0,
                PeopleId = peopleid,
                Number = string.Empty,
                Ddd = string.Empty
            });
            return phones;
        }

        //metodo server para recuperar
        protected AddViewModel GetById(int? id)
        {
            //
            People people = Db.People.Find(id);
            Address address = Db.Address.Find(id);
            IList<Phone> phones = Db.Phone.Where(c => c.PeopleId == id.Value).ToList();
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
            if (phones.Count > 0)
            {
                foreach (Phone phone in phones)
                {
                    item.PhoneViewModel.Add(new PhoneViewModel
                    {
                        Id = phone.Id,
                        PeopleId = phone.PeopleId,
                        Ddd = phone.Ddd,
                        Number = phone.Number
                    });
                }
            }
            else
            {
                item.PhoneViewModel = GetPhoneViewModelDefault(people.Id);
            }
            //
            return item;
        }
    }
}