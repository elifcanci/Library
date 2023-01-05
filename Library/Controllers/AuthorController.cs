using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
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

    }
}
