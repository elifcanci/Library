using Library.Context;
using Library.Dto;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public IActionResult Create()
        {
            List<AuthorDto> authers = _db.Authors.Where(X => X.Status != Enums.DataStatus.Deleted).Select(x => 
            new AuthorDto(){
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

    }
}
