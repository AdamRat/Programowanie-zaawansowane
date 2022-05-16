using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Programowanie_zaawansowanie_zaliczenie2.Controllers
{
    public class ContactCategoriesController : Controller
    {
        // GET: ContactCategoriesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactCategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactCategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactCategoriesController/Create
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

        // GET: ContactCategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactCategoriesController/Edit/5
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

        // GET: ContactCategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactCategoriesController/Delete/5
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
