using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaTech.Model;
using MediaTech.ViewModel;
using MediaTech.Repo;
using Microsoft.Extensions.Logging;

namespace MediaTech.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext db;

        public UserController(ILogger<UserController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult AdminIndex()
        {
            var model = new UserViewModel();
            var repo = new UserRepo(db);
            model = repo.GetUserAdmin();
            return View(model);
        }
    }
}
