using LifeSureApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSureApp.Controllers
{
    public class EmployeeController : Controller
    {
        DayNightDbEntities db = new DayNightDbEntities();
        public ActionResult EmployeeList()
        {
            var employees = db.Tbl_Employee.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Tbl_Employee employee)
        {
            db.Tbl_Employee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.Tbl_Employee.Find(id);
            db.Tbl_Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = db.Tbl_Employee.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Tbl_Employee employee)
        {
            var existingEmployee = db.Tbl_Employee.Find(employee.EmployeeId);
            existingEmployee.EmployeeFullName = employee.EmployeeFullName;
            existingEmployee.EmployeeTitle = employee.EmployeeTitle;
            existingEmployee.EmployeePhotoURL = employee.EmployeePhotoURL;
            existingEmployee.EmployeeFacebook = employee.EmployeeFacebook;
            existingEmployee.EmployeeX = employee.EmployeeX;
            existingEmployee.EmployeeLinkedin = employee.EmployeeLinkedin;
            existingEmployee.EmployeeInstagram = employee.EmployeeInstagram;
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
    }
}