using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaTech.Data;
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
        public async Task<IActionResult> List()
        {
            var spklu = new SPKLURepo(_db);
            var result = await spklu.GetAll();
            return PartialView("_List",result);
        }
        public async Task<IActionResult> Details(string id)
        {
            SPKLUViewModel result = new SPKLUViewModel();
            if (string.IsNullOrWhiteSpace(id)) return View(result);

            var spklu = new SPKLURepo(_db); 
            string paramID = id.FromBase64();  if (long.TryParse(paramID, out long ID)) result = await spklu.GetByID(ID);
            return PartialView("_Details", result);
        }
        public IActionResult Add()
        {
            return PartialView("_Create");
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
                result.Success = true;
                return Json(result);
            }
            return PartialView("_Create",model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            SPKLUViewModel result = new SPKLUViewModel();
            if (string.IsNullOrWhiteSpace(id)) return View(result);

            var spklu = new SPKLURepo(_db);
            string paramID = id.FromBase64(); if (long.TryParse(paramID, out long ID)) result = await spklu.GetByID(ID);
            return PartialView("_Edit", result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SPKLUViewModel model)
        {
            var repo = new SPKLURepo(_db);
            model.CreatedBy = 0; model.CreatedDate = DateTime.Now; model.ModifyBy = 1; model.ModifyDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await repo.Update(model);
                result.Success = true;
                return Json(result);
            }
            return PartialView("_Edit", model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            SPKLUViewModel result = new SPKLUViewModel();
            if (string.IsNullOrWhiteSpace(id)) return View(result);

            var spklu = new SPKLURepo(_db);
            string paramID = id.FromBase64(); if (long.TryParse(paramID, out long ID)) result = await spklu.GetByID(ID);
            return PartialView("_Delete", result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SPKLUViewModel model)
        {
            var repo = new SPKLURepo(_db);
            model.CreatedBy = 0; model.CreatedDate = DateTime.Now; model.ModifyBy = 1; model.ModifyDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await repo.Delete(model);
                result.Success = true;
                return Json(result);
            }
            return PartialView("_Delete", model);
        }
    }
}
