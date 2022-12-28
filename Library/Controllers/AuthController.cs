using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthController : Controller
    {
        IRepository<AppUser> _repoUser;

        public AuthController(IRepository<AppUser> repoUser)
        {
            _repoUser = repoUser;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AppUser user)
        {
            if (_repoUser.Any(x => x.UserName == user.UserName && x.Status != Enums.DataStatus.Deleted))
            {
                AppUser selectUser = _repoUser.Default(x => x.UserName == user.UserName && x.Status != Enums.DataStatus.Deleted);
                bool isValid = BCrypt.Net.BCrypt.Verify(user.Password,selectUser.Password);
                if (isValid)
                {
                    if (selectUser.Role == Enums.Role.admin)
                    {
                        return RedirectToAction("Index", "Home", new {area="Management"});
                    }else if (selectUser.Role == Enums.Role.user)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}
