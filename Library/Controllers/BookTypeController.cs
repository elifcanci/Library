using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookTypeController : Controller
    {
        IRepository<BookType> _repoBookType;

        public BookTypeController(IRepository<BookType> repository)
        {
            _repoBookType = repository;
        }

        public IActionResult BookTypeList()
        {
            List<BookType> bookTypes = _repoBookType.GetAll();
            return View(bookTypes);
        }

    }
}
