using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaTech.Model;
using MediaTech.ViewModel;
using MediaTech.Repo;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MediaTech.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext db;

        public UserController(ILogger<UserController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        [Authorize]
        public IActionResult AdminIndex()
        {

            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.StringRole = HttpContext.Session.GetString("StringRole");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            var model = new UserViewModel();
            var repo = new UserRepo(db);
            model = repo.GetUserAdmin();
            
            return View(model);
        }
    }
}
