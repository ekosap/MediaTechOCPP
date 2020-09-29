using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaTech.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediaTech.ViewModel;
using MediaTech.Repo;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MediaTech.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationDbContext _db;
        AuthenticationProperties props = new AuthenticationProperties();

        public LoginController(ILogger<LoginController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(UserViewModel model)
        {
            var repo = new LoginRepo(_db);
            var result = repo.Login(model.Email, model.Password);
            if (result == null)
            {
                var hasil = new
                {
                    success = false,
                    strError = "Password anda salah"
                };
                return Json(hasil);
            }
            else
            {

                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(result));
                var sessionuser = JsonConvert.DeserializeObject<LoginViewModel>(HttpContext.Session.GetString("SessionUser"));
                HttpContext.Session.SetString("UserId", sessionuser.UserId.ToString());
                HttpContext.Session.SetString("Name", sessionuser.Name);
                HttpContext.Session.SetString("Role", sessionuser.RoleId.ToString());
                HttpContext.Session.SetString("StringRole", sessionuser.StringRole);
                HttpContext.Session.SetString("Email", sessionuser.Email);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.Email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principcal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principcal, props).Wait();


                var hasil = new
                {
                    success = true,
                    strError = "Berhasil"
                };


                return Json(hasil);
            }
        }


        public ActionResult LogOut()
        {

            foreach (var cookie in Request.Cookies.Keys)
            {
                if (cookie == ".AspNetCore.Session" || cookie == "OCPPCookie")
                {
                    Response.Cookies.Delete(cookie);
                }

            }
            return RedirectToAction("Index");
        }




    }
}
