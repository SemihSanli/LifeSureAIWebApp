using LifeSureApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class TestimonialController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult TestimonialList()
        {
            var testimonials = db.Tbl_Testimonial.ToList();
            return View(testimonials);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Tbl_Testimonial testimonial)
        {
            db.Tbl_Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.Tbl_Testimonial.Find(id);
            db.Tbl_Testimonial.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.Tbl_Testimonial.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Tbl_Testimonial testimonial)
        {
            var existingTestimonial = db.Tbl_Testimonial.Find(testimonial.TestimonialId);
            existingTestimonial.TestimonialFullName = testimonial.TestimonialFullName;
            existingTestimonial.TestimonialTitle = testimonial.TestimonialTitle;
            existingTestimonial.TestimonialDescription = testimonial.TestimonialDescription;
            existingTestimonial.TestimonialPhotoURL = testimonial.TestimonialPhotoURL;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}