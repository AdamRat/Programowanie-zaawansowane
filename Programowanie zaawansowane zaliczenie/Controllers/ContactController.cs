using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Programowanie_zaawansowane_zaliczenie.Models;

namespace Programowanie_zaawansowane_zaliczenie.Controllers
{
    public class ContactController : Controller
    {
        private static IList<ContactVievModel> tasks = new List<ContactVievModel>()
        {
            new ContactVievModel(){ Id=1, FirstName= "Wizyta u lekarza", LastName= "Godzina 17:00", PhoneNumber=false },
            new ContactVievModel(){ TaskId=2, Name= "Zrobić obiad", Description= "Pierogi", Done=false },
        };
        // GET: ContactController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
