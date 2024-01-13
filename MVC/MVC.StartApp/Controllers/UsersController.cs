using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.StartApp.Models;
using MVC.StartApp.Models.Db;
using System.Threading.Tasks;

namespace MVC.StartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetUsers();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
