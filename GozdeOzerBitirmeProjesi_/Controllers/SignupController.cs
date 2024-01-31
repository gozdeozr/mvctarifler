using GozdeOzerBitirmeProjesi_.Entities;
using GozdeOzerBitirmeProjesi_.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GozdeOzerBitirmeProjesi_.Controllers
{
    public class SignupController : Controller
    {
        BlogDbContext dbContext = new BlogDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            user.Createdate = DateTime.Now;
            user.Status = true;
            user.Deleted = false;
            try
            {
                var existUser = dbContext.Users.ToList().Find(x => x.Email == user.Email);
                if (existUser != null)
                {
                    TempData["Mesaj"] = new Alert("Email sistemde kayıtlı.", Enum.AlertType.Danger).Get();
                    return RedirectToAction("Index");
                }
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Mesaj"] = new Alert("Kayıt işlemi sırasında bir hata meydana geldi.", Enum.AlertType.Danger).Get();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}