using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programowanie_zaawansowane_zaliczenie.Models;
using System.Collections.Generic;
using System.Linq;

namespace Programowanie_zaawansowanie_zaliczenie2.Controllers
{
    public class ContactCategoriesController : Controller
    {
        private static List<ContactCategories> contactsCategories = new List<ContactCategories>()
        {
            new ContactCategories(){ Id=1,CategoryName="test" },
            new ContactCategories(){ Id=2,CategoryName="test2" },
            new ContactCategories(){Id=3,CategoryName="dom"}
        };
        // GET: ContactCategoriesController
        public ActionResult Index()
        {
            return View(contactsCategories);
        }

        // GET: ContactCategoriesController/Create
        public ActionResult Create()
        {
            return View(new ContactCategories());
        }

        // POST: ContactCategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCategories collection)
        {
            contactsCategories.Add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactCategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(contactsCategories.FirstOrDefault(x => x.Id == id));
        }

        // POST: ContactCategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactCategories collection)
        {
            ContactCategories contactCategory = contactsCategories.FirstOrDefault(x => x.Id == id);
            contactCategory.Id = contactCategory.Id;
            contactCategory.CategoryName = collection.CategoryName;
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactCategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(contactsCategories.FirstOrDefault(x => x.Id == id));
        }

        // POST: ContactCategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContactCategories collection)
        {
            ContactCategories contact = contactsCategories.FirstOrDefault(x => x.Id == id);
            contactsCategories.Remove(contact);
            return RedirectToAction(nameof(Index));
        }
    }
}
