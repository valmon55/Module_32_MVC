using Microsoft.AspNetCore.Mvc;
using MVC.StartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVC.StartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;
        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        { 
            var requests = await _repo.GetURLs();
            return View(requests);
        }
    }
}
