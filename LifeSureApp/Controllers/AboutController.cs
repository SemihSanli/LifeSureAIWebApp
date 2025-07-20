using LifeSureApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class AboutController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult AboutList()
        {
            var values = db.Tbl_About.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.Tbl_About.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(Tbl_About About)
        {
            var value = db.Tbl_About.Find(About.AboutId);

            value.AboutTitle = About.AboutTitle;
            value.AboutMinDescription = About.AboutMinDescription;
            value.AboutImageURL = About.AboutImageURL;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}