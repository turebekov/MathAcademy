using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathAcademy.Controllers
{
    public class CourseController : BaseController
    {
        public ActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Cours course)
        {
            //Cours course = new Cours();
            string Name = Request.Form["Name"];
            course.CreateDate = DateTime.Now;
            DataManager manager = new DataManager();
            manager.CreateCourse(course);
            return Redirect("/course/Index");
        }
        public ActionResult Index()
        {

            DataManager mng = new DataManager();
            ViewBag.Courses = mng.GetCourses();

            return View();


        }
        public ActionResult Edit(int Id)
        {
            ViewBag.CourseId = Id;
            DataManager manager = new DataManager();
            ViewBag.Course = manager.GetCourse(Id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Cours course)
        {
            string Name = Request.Form["Name"];
            //course.CreateDate = DateTime.Now;
            DataManager manager = new DataManager();
            manager.EditCourse(course);
            return Redirect("/course/Index");
        }
        public ActionResult Delete(int Id)
        {
            DataManager manager = new DataManager();
            manager.DeleteCourse(Id);
            return Redirect("/course/index");
        }

        public ActionResult Details()
        {
            int courseId = Convert.ToInt32(Request["courseId"]);
            
            DataManager mng = new DataManager();
            var course = mng.GetCourse(courseId);
            int contentId = Convert.ToInt32(Request["contentId"]);
            ViewBag.Content = mng.GetContent(contentId);
            return View(course);
        }
       
    }
}