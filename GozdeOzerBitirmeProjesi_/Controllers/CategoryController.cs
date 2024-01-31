using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GozdeOzerBitirmeProjesi_.Entities;
using GozdeOzerBitirmeProjesi_.Enum;
using GozdeOzerBitirmeProjesi_.Extensions;

namespace GozdeOzerBitirmeProjesi_.Controllers
{
    public class CategoryController : Controller
    {
        BlogDbContext db = new BlogDbContext();

        public ActionResult Index()
        {
            var categories = db.Categories.Where(x => !x.Deleted);
            return View(categories);
        }

        public ActionResult Add()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {

            category.Createdate = DateTime.Now;
            category.Deleted = false;
            db.Categories.Add(category);
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = new Alert(category.Name + " kategorisi başarılı bir şekilde eklenmiştir.", AlertType.Success).Get();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["Mesaj"] = new Alert("Kategori eklenirken bir hata ile karşılaşıldı.", AlertType.Danger).Get();

            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]

        public ActionResult Edit(Category category)
        {
            var edit = db.Categories.Find(category.Id);

            edit.Name = category.Name;
            edit.Description = category.Description;
            edit.Status = category.Status;
            try
            {
                db.SaveChanges();
                TempData["Mesaj"] = new Alert("Güncelleme işlemi başarılı bir şekilde gerçekleşmiştir", AlertType.Success).Get();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = new Alert("Güncelleme işlemi sırasında bir hata oluştu.", AlertType.Danger).Get();

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            category.Deleted = true;
            try
            {

                db.SaveChanges();
                TempData["Mesaj"] = new Alert(category.Name + " kategorisi başarılı bir şekilde silinmiştir.", AlertType.Success).Get();

            }
            catch (Exception)
            {
                TempData["Mesaj"] = new Alert("Silme işlemi sırasında bir hata oluştu.", AlertType.Danger).Get();
            }
            return RedirectToAction("Index");
        }

    }
}