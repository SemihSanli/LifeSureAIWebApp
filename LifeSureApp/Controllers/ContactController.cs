using LifeSureApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class ContactController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult ContactList()
        {
            var contacts = db.Tbl_Contact.ToList();
            return View(contacts);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Tbl_Contact contact)
        {
            db.Tbl_Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }

        public ActionResult DeleteContact(int id)
        {
            var contact = db.Tbl_Contact.Find(id);
            db.Tbl_Contact.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.Tbl_Contact.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(Tbl_Contact contact)
        {
            var existingContact = db.Tbl_Contact.Find(contact.ContactId);
            existingContact.ContactAddress = contact.ContactAddress;
            existingContact.ContactEmail = contact.ContactEmail;
            existingContact.ContactPhone = contact.ContactPhone;
            db.SaveChanges();
            return RedirectToAction("Contact");
        }
    }
}