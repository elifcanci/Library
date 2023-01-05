using Library.Context;
using Library.Dto;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        MyDbContext _db;

        public BookController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult BookList()
        {
            List<Book> books = _db.Books.Where(b => b.Status != Enums.DataStatus.Deleted).Include(x => x.Author).Include(x =>
            x.BookType).ToList();
            return View(books);
        }

    }
}
