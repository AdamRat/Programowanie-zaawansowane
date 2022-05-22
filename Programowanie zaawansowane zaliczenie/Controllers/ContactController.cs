using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Programowanie_zaawansowane_zaliczenie.Models;
using System.Linq;
using Programowanie_zaawansowanie_zaliczenie2.Controllers;

namespace Programowanie_zaawansowane_zaliczenie.Controllers
{
    public class ContactController : Controller
    {
        private static IList<ContactVievModel> Contacts = new List<ContactVievModel>()
        {
            new ContactVievModel(){ Id=1, FirstName= "Wizyta u lekarza", LastName= "Godzina 17:00", 
                Adress=new Adresses(){Id=1,Street="tarnowska",PostCode="61-323", City="poznan", Country="polsza" },
            PhoneNumber="722090231", ContactCategory=new ContactCategories(){Id=1,CategoryName="test" },FbLink="https://test.pl", Email="test@test.pl" },
            new ContactVievModel(){ Id=2, FirstName= "Wizyta u lekarza", LastName= "Godzina 17:00",
                Adress=new Adresses(){Id=2,Street="tarnowska2",PostCode="61-3232", City="poznan2", Country="polsza2" },
            PhoneNumber="722090231", ContactCategory=new ContactCategories(){Id=2,CategoryName="test2" },FbLink="https://test.pl", Email="test@test.pl" },
        };
        // GET: ContactController
        public ActionResult Index()
        {
            return View(Contacts);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View(Contacts.FirstOrDefault(x=>x.Id==id));
        }

        private ContactCategoriesController ContactCategoriesConoler = new ContactCategoriesController();


        // GET: ContactController/Create
        public ActionResult Create()
        {
            List<string> list = ContactCategoriesConoler.CategoriesGet();

            ViewBag.list = list;
            return View(new ContactVievModel());
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactVievModel collection)
        {
            Contacts.Add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Contacts.FirstOrDefault(x => x.Id == id));
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactVievModel collection)
        {
            ContactVievModel contact = Contacts.FirstOrDefault(x => x.Id == id);
            contact.Adress = collection.Adress;
            contact.ContactCategory = collection.ContactCategory;
            contact.Email = collection.Email;
            contact.FbLink = collection.FbLink;
            contact.FirstName = collection.FirstName;
            contact.LastName = collection.LastName;
            contact.PhoneNumber = collection.PhoneNumber;
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Contacts.FirstOrDefault(x => x.Id == id));
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContactVievModel collection)
        {
            ContactVievModel contact = Contacts.FirstOrDefault(x => x.Id == id);
            Contacts.Remove(contact);
            return RedirectToAction(nameof(Index));
        }
    }
}
