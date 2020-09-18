using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaTech.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediaTech.ViewModel;
using MediaTech.Repo;

namespace MediaTech.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationDbContext db;


        public LoginController(ILogger<LoginController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult Index()
        {
            var model = new UserViewModel();
            return View(model);
        }
    }
}
