using Library.Context;
using Library.Dto;
using Library.Models;
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

        public IActionResult Create()
        {
            List<AuthorDto> authers = _db.Authors.Where(X => X.Status != Enums.DataStatus.Deleted).Select(x =>
            new AuthorDto()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            List<BookTypeDto> bookTypes = _db.BookTypes.Where(x => x.Status != Enums.DataStatus.Deleted).Select(X =>
            new BookTypeDto()
            {
                ID = X.ID,
                Name = X.Name
            }).ToList();

            return View((new Book(), authers, bookTypes));
        }

        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Item1")] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("BookList");
        }
    }
}
