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
using MediaTech.Data;

namespace MediaTech.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext db;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new UserViewModel();
            var repo = new UserRepo(db);
            model = repo.GetUserAdmin();
            
            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var repo = new UserRepo(db);
            var result = repo.GetUserAdmin();
            return PartialView("_List", result);
        }

        public IActionResult Add()
        {
            UserViewModel model = new UserViewModel();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            var repo = new UserRepo(db);
            model.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            model.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = repo.Insert(model);
                if(result == true)
                {
                    var hasil = new
                    {
                        success = true,
                        strError = "Berhasil"
                    };
                    return Json(hasil);
                }
                else

                {
                    var hasil = new
                    {
                        success = false,
                        strError = "Gagal"
                    };
                    return Json(hasil);
                }
            }
            return PartialView(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            UserViewModel result = new UserViewModel();
            if (id == 0) return View(result);

            var repo = new UserRepo(db);
            result = repo.GetByID(id);
            return PartialView(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            UserViewModel result = new UserViewModel();
            if (id == 0) return View(result);

            var repo = new UserRepo(db);
            result = repo.GetByID(id);
            return PartialView(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var repo = new UserRepo(db);
            model.ModifyBy = model.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            model.ModifyDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = repo.Update(model);
                if (result == true)
                {
                    var hasil = new
                    {
                        success = true,
                        strError = "Berhasil"
                    };
                    return Json(hasil);
                }
                else

                {
                    var hasil = new
                    {
                        success = false,
                        strError = "Gagal"
                    };
                    return Json(hasil);
                }
            }
            return PartialView(model);
        }
    }
}
