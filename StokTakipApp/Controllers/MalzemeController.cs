using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakipApp.Controllers
{
    public class MalzemeController : Controller
    {
        // GET: Malzeme
        public ActionResult Index()
        {
            return View();
        }

        StokTakipApp.Models.StokAppDbEntities db = new StokTakipApp.Models.StokAppDbEntities();

        [ValidateInput(false)]
        public ActionResult MalzemeGridView1Partial()
        {
            var model = db.Malzeme;
            return PartialView("_MalzemeGridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MalzemeGridView1PartialAddNew(StokTakipApp.Models.Malzeme item)
        {
            var model = db.Malzeme;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_MalzemeGridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MalzemeGridView1PartialUpdate(StokTakipApp.Models.Malzeme item)
        {
            var model = db.Malzeme;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_MalzemeGridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MalzemeGridView1PartialDelete(System.Int32 Id)
        {
            var model = db.Malzeme;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_MalzemeGridView1Partial", model.ToList());
        }
    }
}