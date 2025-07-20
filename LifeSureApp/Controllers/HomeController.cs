using LifeSureApp.Models.DataModels;
using LifeSureApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class HomeController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();

        public async Task<ActionResult> Index()
        {

            var linkedInService = new LinkedinServices();
            var linkedInUser = await linkedInService.GetUserInfo("muratyucedag");

            return View(linkedInUser);
        }

        public PartialViewResult Feature()
        {
            var features = db.Tbl_Feature.ToList();
            return PartialView(features);
        }

        public PartialViewResult SubFeature()
        {
            var values = db.Tbl_SubFeature
                .OrderByDescending(x => x.SubFeatureId)
                .Take(4)
                .ToList();
            return PartialView(values);
        }

        public PartialViewResult About()
        {
            var about = db.Tbl_About.ToList();
            return PartialView(about);
        }


        public PartialViewResult Service()
        {
            var values = db.Tbl_Service
                .OrderByDescending(x => x.ServiceId) 
                .Take(4)
                .ToList();
            return PartialView(values);
        }
        public PartialViewResult Employee()
        {
            var employees = db.Tbl_Employee.ToList();
            return PartialView(employees);
        }

        public PartialViewResult Testimonial()
        {
            var testimonials = db.Tbl_Testimonial.ToList();
            return PartialView(testimonials);
        }
        public PartialViewResult Contact()
        {
            var contacts = db.Tbl_Contact.ToList();
            return PartialView(contacts);
        }
        public PartialViewResult Spinner()
        {
            return PartialView();
        }
        public PartialViewResult Navbar()
        {
            return PartialView();
        }
        public PartialViewResult Scripts()
        {
            return PartialView();
        }

        public PartialViewResult FAQ()
        {
            var faq = db.Tbl_Question.OrderByDescending(x => x.QuestionId)
                .Take(4)
                .ToList();
            return PartialView(faq);
        }
    }
}