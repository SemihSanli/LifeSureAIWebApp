using LifeSureApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class FeatureController : Controller
    {
       DayNightDbEntities db= new DayNightDbEntities();
        public ActionResult FeatureList()
        {
            var features = db.Tbl_Feature.ToList();
            return View(features);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(Tbl_Feature feature)
        {
            db.Tbl_Feature.Add(feature);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var feature = db.Tbl_Feature.Find(id);
            db.Tbl_Feature.Remove(feature);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }


    }
}