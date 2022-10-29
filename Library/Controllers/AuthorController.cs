using Library.Context;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        MyDbContext _db;

        public AuthorController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult AuthorList()
        {
            List<Author> authorList = _db.Authors.Where(a => a.Status != Enums.DataStatus.Deleted).ToList();
            return View(authorList);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
            return RedirectToAction("AuthorList");
        }

        public IActionResult Edit(int id)
        {
            Author author = _db.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            author.Status = Enums.DataStatus.Updated;
            author.ModifiedDate = DateTime.Now;
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("AuthorList");
        }

        public IActionResult Delete(int id)
        {
            Author author = _db.Authors.Find(id);
            author.Status = Enums.DataStatus.Deleted;
            author.ModifiedDate = DateTime.Now;
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("AuthorList");
        }
    }
}
