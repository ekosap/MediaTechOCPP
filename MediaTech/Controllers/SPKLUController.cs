using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaTech.Model;
using MediaTech.Repo;
using MediaTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediaTech.Controllers
{
    public class SPKLUController : Controller
    {
        private readonly ILogger<SPKLUController> _logger;
        private readonly ApplicationDbContext _db;

        public SPKLUController(ILogger<SPKLUController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var spklu = new SPKLURepo(_db);
            var result = await spklu.GetAll();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SPKLUViewModel model)
        {
            var repo = new SPKLURepo(_db);
            model.CreatedBy = 0; model.CreatedDate = DateTime.Now; model.ModifyBy = 1; model.ModifyDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await repo.Insert(model);
                if (result.Code == 200) return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
