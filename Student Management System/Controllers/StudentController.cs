using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext db = new StudentDbContext();

        public ActionResult Index()
        {
            var studentList = (from s in db.Students
                               join c in db.Countries on s.CountryId equals c.CountryId
                               join st in db.States on s.StateId equals st.StateId
                               join ci in db.Cities on s.CityId equals ci.CityId
                               join d in db.Departments on s.DepartmentId equals d.DepartmentId
                               join co in db.Courses on s.CourseId equals co.CourseId
                               select new StudentViewModel
                               {
                                   StudentId = s.StudentId,
                                   StudentName = s.StudentName,
                                   Email = s.Email,
                                   CountryName = c.CountryName,
                                   StateName = st.StateName,
                                   CityName = ci.CityName,
                                   DepartmentName = d.DepartmentName,
                                   CourseName = co.CourseName
                               }).ToList();

            ViewBag.StudentList = studentList;
            return View();
        }

        public ActionResult AddStudent(int id = 0)
        {
            ViewBag.CountryList = db.Countries.ToList();
            ViewBag.DepartmentList = db.Departments.ToList(); // New Dropdown

            tblStudent obj = new tblStudent();

            if (id > 0)
            {
                var data = (from s in db.Students where s.StudentId == id select s).FirstOrDefault();
                if (data != null)
                {
                    obj = data;
                }
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddStudent(tblStudent obj)
        {
            if (obj.StudentId > 0)
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.Students.Add(obj);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var data = db.Students.Find(id);
            if (data != null)
            {
                db.Students.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetStates(int countryId)
        {
            var states = db.States.Where(s => s.CountryId == countryId).ToList();
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCities(int stateId)
        {
            var cities = db.Cities.Where(c => c.StateId == stateId).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        // --- NEW AJAX METHOD FOR COURSE DROPDOWN ---
        [HttpPost]
        public JsonResult GetCourses(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }

    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
    }
}