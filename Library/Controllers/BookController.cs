using Library.Context;
using Library.Dto;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading;
using Microsoft.Extensions.Localization;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IStringLocalizer<BookController> _localizer;
        MyDbContext _db;

        public BookController(IStringLocalizer<BookController> localizer, MyDbContext db)
        {
            _localizer = localizer;
            _db = db;
        }

        [AllowAnonymous]
        public IActionResult BookList()
        {
            List<Book> books = _db.Books.Where(b => b.Status != Enums.DataStatus.Deleted).Include(x => x.Author).Include(x =>
            x.BookType).ToList();
            return View(books);
        }

    }
}
