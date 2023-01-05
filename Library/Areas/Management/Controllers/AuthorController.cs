using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Management.Controllers
{
    [Area("Management")]
    public class AuthorController : Controller
    {
        IRepository<Author> _repoAuthor;

        public AuthorController(IRepository<Author> repository)
        {
            _repoAuthor = repository;
        }

        public IActionResult AuthorList()
        {
            List<Author> authorList = _repoAuthor.GetActives();
            return View(authorList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repoAuthor.Add(author);
            return RedirectToAction("AuthorList","Author",new {area = "Management"});
        }

        public IActionResult Edit(int id)
        {
            Author author = _repoAuthor.GetById(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _repoAuthor.Update(author);
            return RedirectToAction("AuthorList", "Author", new { area = "Management" });
        }

        public IActionResult Delete(int id)
        {
            _repoAuthor.Delete(id);
            return RedirectToAction("AuthorList", "Author", new { area = "Management" });
        }
    }
}
