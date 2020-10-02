using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediaTech.Data;
using MediaTech.Model;
using MediaTech.Repo;
using MediaTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediaTech.Controllers
{
    public class SKPLUController : Controller
    {
        private readonly ILogger<SKPLUController> _logger;
        private readonly ApplicationDbContext _db;

        public SKPLUController(ILogger<SKPLUController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            long.TryParse(id.FromBase64(), out long ID);
            var spklu = new SKPLURepo(_db);
            var result = await spklu.GetByID(ID);
            if (result.SKPLUID == 0) return NotFound($"Data Not Found");
            return View();
        }
        [Produces("application/json")]
        [Route("api/SKPLU")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var spklu = new SKPLURepo(_db);
            var result = await spklu.GetAll();
            return Ok(result);
        }
        [Produces("application/json")]
        [Route("api/SKPLU/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(string id)
        {
            long.TryParse(id.FromBase64(), out long ID);
            var spklu = new SKPLURepo(_db);
            var result = await spklu.GetByID(ID);
            if (result.SKPLUID == 0) return NotFound($"Data Not Found");
            return Ok(result);
        }
        [Produces("application/json")]
        [Route("api/SKPLU/Insert/")]
        [HttpPost]
        public async Task<IActionResult> Insert(SKPLUViewModel model)
        {
            var repo = new SKPLURepo(_db);
            model.CreatedBy = 0; model.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await repo.Insert(model);
                if (result.Success) return Ok(result);
                return BadRequest(result);
            }
            return BadRequest();
        }
        [Produces("application/json")]
        [Route("api/SKPLU/Update/")]
        [HttpPost]
        public async Task<IActionResult> Update(SKPLUViewModel model)
        {
            var repo = new SKPLURepo(_db);
            model.ModifyBy = 1; model.ModifyDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await repo.Update(model);
                if (result.Success) return Ok(result);
                return BadRequest(result);
            }
            return BadRequest();
        }
        [Produces("application/json")]
        [Route("api/SKPLU/Delete/${id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            long.TryParse(id.FromBase64(), out long ID);
            var repo = new SKPLURepo(_db);
            var model = await repo.GetByID(ID);
            if (model.SKPLUID == 0) return NotFound($"Data Not Found");
            model.ModifyBy = 1; model.ModifyDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await repo.Delete(model);
                if (result.Success) return Ok(result);
                return BadRequest(result);
            }
            return BadRequest();
        }
    }
}
