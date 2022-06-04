using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programowanie_zaawansowane_zaliczenie.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;

namespace Programowanie_zaawansowane_zaliczenie.Controllers
{
    public class ContactController : Controller
    {
        private readonly DatabaseContext _context;

        public ContactController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ContactController
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.List = _context.ContactCategories.ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            ViewBag.CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var contacts = from s in _context.ContactVievModel
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "lastName_desc":
                    contacts = contacts.OrderByDescending(s => s.LastName);
                    break;
                case "category_desc":
                    contacts = contacts.OrderByDescending(s => s.ContactCategory.CategoryName);
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(contacts.ToPagedList(pageNumber, pageSize));
        }

        // GET: ContactController/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            ViewBag.List = _context.ContactCategories.ToList();
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.ContactVievModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: ContactController/Create
        public IActionResult Create()
        {
            ContactCategoriesDropDownList();
            return View();
        }

        // POST: ContactController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email,FbLink,ContactCategoryID")] ContactVievModel contactVievModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(contactVievModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            ContactCategoriesDropDownList(contactVievModel.ContactCategoryID);
            return View(contactVievModel);
        }

        // GET: ContactController/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            ViewBag.List = _context.ContactCategories.ToList();
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.ContactVievModel.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ContactCategoriesDropDownList(contact.ContactCategoryID);
            return View(contact);
        }

        // POST: ContactController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,FirstName,LastName,Adress,PhoneNumber,Email,FbLink,ContactCategoryID")] ContactVievModel contactVievModel)
        {
            if (id != contactVievModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactVievModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(((uint)contactVievModel.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ContactCategoriesDropDownList(contactVievModel.ContactCategoryID);
            return View(contactVievModel);
        }

        // GET: ContactController/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactVievModel = await _context.ContactVievModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactVievModel == null)
            {
                return NotFound();
            }

            return View(contactVievModel);
        }

        // POST: ContactController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var contact = await _context.ContactVievModel.FindAsync(id);
            _context.ContactVievModel.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(uint id)
        {
            return _context.ContactVievModel.Any(e => e.Id == id);
        }
        private void ContactCategoriesDropDownList(object selectedCategory = null)
        {
            var categoriesQuery = from d in _context.ContactCategories
                                  orderby d.CategoryName
                                  select d;
            ViewBag.ContactCategoryID = new SelectList(categoriesQuery, "Id", "CategoryName", selectedCategory);
        }
        /*private readonly DatabaseContext _context;
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



        // GET: ContactController/Create
        public ActionResult Create()
        {
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
        }*/
    }
}
