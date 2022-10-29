using Library.Context;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookTypeController : Controller
    {
        MyDbContext _db;

        public BookTypeController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult BookTypeList()
        {
            List<BookType> bookTypes = _db.BookTypes.Where(a => a.Status != Enums.DataStatus.Deleted).ToList();
            return View(bookTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookType bookType)
        {
            _db.BookTypes.Add(bookType);
            _db.SaveChanges();
            return RedirectToAction("BookTypeList");
        }

        public IActionResult Edit(int id)
        {
            BookType bookType = _db.BookTypes.Find(id);
            return View(bookType);
        }

        [HttpPost]
        public IActionResult Edit(BookType bookType)
        {
            bookType.Status = Enums.DataStatus.Updated;
            bookType.ModifiedDate = DateTime.Now;
            _db.BookTypes.Update(bookType);
            _db.SaveChanges();
            return RedirectToAction("BookTypeList");
        }

        public IActionResult Delete(int id)
        {
            BookType bookType = _db.BookTypes.Find(id);
            bookType.Status = Enums.DataStatus.Deleted;
            bookType.ModifiedDate = DateTime.Now;
            _db.BookTypes.Update(bookType);
            _db.SaveChanges();
            return RedirectToAction("BookTypeList");
        }
    }
}
