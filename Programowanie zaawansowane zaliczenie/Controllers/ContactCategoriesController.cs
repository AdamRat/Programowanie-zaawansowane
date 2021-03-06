using Microsoft.AspNetCore.Mvc;
using Programowanie_zaawansowane_zaliczenie.Models;
using Programowanie_zaawansowane_zaliczenie;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Programowanie_zaawansowane_zaliczenie.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Programowanie_zaawansowanie_zaliczenie.Controllers
{
    [Authorize]
    public class ContactCategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public ContactCategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ContactCategoriesController
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactCategories.ToListAsync());
        }

        // GET: ContactCategoriesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactCategoriesController/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] ContactCategories contactCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactCategories);
        }

        // GET: ContactCategoriesController/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactCategories = await _context.ContactCategories.FindAsync(id);
            if (contactCategories == null)
            {
                return NotFound();
            }
            return View(contactCategories);
        }

        // POST: ContactCategoriesController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,CategoryName")] ContactCategories contactCategories)
        {
            if (id != contactCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactCategoriesExists(((uint)contactCategories.Id)))
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
            return View(contactCategories);
        }


        private bool ContactCategoriesExists(uint id)
        {
            return _context.ContactCategories.Any(e => e.Id == id);
        }


        /*public List<string> Test()
        {
            List<string> test = new();
            for (int i = 0; i < _context.ContactCategories.ToList().Count; i++)
            {
                if (_context.ContactCategories.Find(i).CategoryName !=null)
                {
                    test.Add(_context.ContactCategories.Find(i).CategoryName);
                }
            }
            return test;
        }*/
        /*private static List<ContactCategories> contactsCategories = new List<ContactCategories>()
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
}*/
    }
}
