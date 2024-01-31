using GozdeOzerBitirmeProjesi_.Entities;
using GozdeOzerBitirmeProjesi_.Enum;
using GozdeOzerBitirmeProjesi_.Extensions;
using GozdeOzerBitirmeProjesi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GozdeOzerBitirmeProjesi_.Controllers
{

    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(LoginViewModel login)
        {
            BlogDbContext db = new BlogDbContext();
            var admin = db.Admins.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);
            User user = db.Users.FirstOrDefault(x => x.Email == login.Username && x.Password == login.Password);
            if (admin != null || user != null)
            {
                ViewBag.Mesaj = new Alert("Giriş başarılı", AlertType.Success).Get();
                Session["Token"] = Guid.NewGuid().ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = new Alert("Kullanıcı Adı veya Parola Hatalı", AlertType.Danger).Get();
            }
            return View();
        }
        public ActionResult Exit()
        {
            Session.Remove("Token");
            return RedirectToAction("Index", "Home");
        }


    }

}