using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakipApp.Controllers
{
    public class OlcuBirimController : Controller
    {
        // GET: OlcuBirim
        public ActionResult Index()
        {
            return View();
        }

        StokTakipApp.Models.StokAppDbEntities db = new StokTakipApp.Models.StokAppDbEntities();

        [ValidateInput(false)]
        public ActionResult OlcuBirimGridViewPartial()
        {
            var model = db.OlcuBirim;
            return PartialView("_OlcuBirimGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult OlcuBirimGridViewPartialAddNew(StokTakipApp.Models.OlcuBirim item)
        {
            var model = db.OlcuBirim;
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
            return PartialView("_OlcuBirimGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OlcuBirimGridViewPartialUpdate(StokTakipApp.Models.OlcuBirim item)
        {
            var model = db.OlcuBirim;
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
            return PartialView("_OlcuBirimGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OlcuBirimGridViewPartialDelete(System.Int32 Id)
        {
            var model = db.OlcuBirim;
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
            return PartialView("_OlcuBirimGridViewPartial", model.ToList());
        }
    }
}