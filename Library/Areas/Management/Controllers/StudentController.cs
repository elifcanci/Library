using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Management.Controllers
{
    [Area("Management")]
    public class StudentController : Controller
    {

        IRepository<Student> _repoStudent;

        public StudentController(IRepository<Student> repository)
        {
            _repoStudent = repository;
        }

        public IActionResult StudentList()
        {
            List<Student> studentList = _repoStudent.GetAll();
            return View(studentList);
        }

    }
}
