using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookType bookType)
        {
            _repoBookType.Add(bookType);
            return RedirectToAction("BookTypeList");
        }

        public IActionResult Edit(int id)
        {
            BookType bookType = _repoBookType.GetById(id);
            return View(bookType);
        }

        [HttpPost]
        public IActionResult Edit(BookType bookType)
        {
            _repoBookType.Update(bookType);
            return RedirectToAction("BookTypeList");
        }

        public IActionResult Delete(int id)
        {
            _repoBookType.SpecialDelete(id);
            return RedirectToAction("BookTypeList");
        }
    }
}
