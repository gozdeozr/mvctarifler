using GozdeOzerBitirmeProjesi_.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GozdeOzerBitirmeProjesi_.Controllers
{
    public class HomeController : Controller
    {
        BlogDbContext db = new BlogDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Receipt()
        {
            var bloglar = db.Blogs.Where(x => !x.Deleted);
            return View(bloglar.ToList());
        }
    }
}