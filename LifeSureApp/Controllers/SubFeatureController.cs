using LifeSureApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class SubFeatureController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult SubFeatureList()
        {
            var SubFeatures = db.Tbl_SubFeature.ToList();
            return View(SubFeatures);
        }

        [HttpGet]
        public ActionResult AddSubFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubFeature(Tbl_SubFeature SubFeature)
        {
            db.Tbl_SubFeature.Add(SubFeature);
            db.SaveChanges();
            return RedirectToAction("SubFeatureList");
        }

        public ActionResult DeleteSubFeature(int id)
        {
            var SubFeature = db.Tbl_SubFeature.Find(id);
            db.Tbl_SubFeature.Remove(SubFeature);
            db.SaveChanges();
            return RedirectToAction("SubFeatureList");
        }

        [HttpGet]
        public ActionResult UpdateSubFeature(int id)
        {
            var SubFeature = db.Tbl_SubFeature.Find(id);
            return View(SubFeature);
        }

        [HttpPost]
        public ActionResult UpdateSubFeature(Tbl_SubFeature SubFeature)
        {
            var existingSubFeature = db.Tbl_SubFeature.Find(SubFeature.SubFeatureId);
            existingSubFeature.SubFeatureTitle = SubFeature.SubFeatureTitle;
            existingSubFeature.SubFeatureDescription = SubFeature.SubFeatureDescription;
            existingSubFeature.SubFeatureIcon = SubFeature.SubFeatureIcon;
            db.SaveChanges();
            return RedirectToAction("SubFeatureList");
        }

    }
}