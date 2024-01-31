using GozdeOzerBitirmeProjesi_.Entities;
using GozdeOzerBitirmeProjesi_.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GozdeOzerBitirmeProjesi_.Controllers
{
    public class BlogController : Controller
    {
        BlogDbContext db = new BlogDbContext();
        public ActionResult Index()
        {
            var bloglar = db.Blogs.Where(x => !x.Deleted);
            return View(bloglar.ToList());
        }
        public ActionResult Add()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories.Where(x => !x.Deleted), "Id", "Name");
            return View(new Blog());
        }
        [HttpPost]
        public ActionResult Add(Blog blog)
        {
            blog.Createdate = DateTime.Now;
            blog.Deleted = false;
            db.Blogs.Add(blog);
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = new Alert(blog.Caption + " tarifi başarılı bir şekilde eklenmiştir.", Enum.AlertType.Success).Get();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = new Alert("Kayıt işlemi sırasında bir hata meydana geldi.", Enum.AlertType.Danger).Get();
                ViewBag.CategoryId = new SelectList(db.Categories.Where(x => !x.Deleted), "Id", "Name");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ViewBag.CategoryID = new SelectList(db.Categories.Where(x => !x.Deleted), "Id", "Name");
            var blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            var edit = db.Blogs.Find(blog.Id);

            edit.Caption = blog.Caption;
            edit.Detail = blog.Detail;
            edit.Keyword = blog.Keyword;
            edit.CategoryId = blog.CategoryId;
            edit.Status = blog.Status;

            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = new Alert("Güncelleme işlemi başarılı bir şekilde gerçekleştirilmiştir.", Enum.AlertType.Success).Get();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = new Alert("Güncelleme işlemi sırasında bir hata oluştu.", Enum.AlertType.Danger).Get();
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            var blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        public ActionResult Delete(int id)
        {
            var blog = db.Blogs.Find(id);
            blog.Deleted = true;
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = new Alert(blog.Caption + " tarifi başarılı bir şekilde silinmiştir.", Enum.AlertType.Success).Get();
            }
            catch (Exception)
            {
                TempData["Mesaj"] = new Alert("Silme işlemi sırasında bir hata oluştu.", Enum.AlertType.Danger).Get();
            }
            return RedirectToAction("Index");
        }
    }
}