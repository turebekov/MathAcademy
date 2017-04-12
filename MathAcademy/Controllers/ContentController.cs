using DataAccess;
using DataModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathAcademy.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Content
        public ActionResult Index()
        {
            int courseId = Convert.ToInt32(Request["courseId"]);
            DataManager mng = new DataManager();
            var course = mng.GetCourse(courseId);
            ViewBag.CourseId = courseId;
            return View(course);
        }
        
        public ActionResult Edit()
        {
            int ContentId = Convert.ToInt32(Request["contentId"]);
            DataManager mng = new DataManager();
            ViewBag.Content = mng.GetContent(ContentId);
            ViewBag.Id = ContentId;
            return View();
        }
        [HttpPost]
        public ActionResult Edit (Content content)
        {
            string Title = Request.Form["Title"];
            string Text = Request.Form["Text"];
            string Video = Request.Form["Video"];
            DataManager mng = new DataManager();
            mng.EditContent(content);
            return Redirect("/Course/Index");

        }
        public ActionResult GetContent()
        {
            int ContentId = Convert.ToInt32(Request["contentId"]);
            DataManager mng = new DataManager();

            ViewBag.Content = mng.GetContent(ContentId);
            int courseId = Convert.ToInt32(Request["courseId"]);
            ViewBag.Course = mng.GetCnt(courseId);
            return View();
        }
        [HttpGet]
        public ActionResult Create(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content content)
        {
            string Title = Request.Form["Title"];
            string Text = Request.Form["Text"];
            string Video = Request.Form["Video"];
            content.CourseId = Convert.ToInt32(Request.Form["courseId"]);
            //int OrderId = Convert.ToInt32(Request.Form["OrderId"]);
            content.Id = 0;
            content.CreateDate = DateTime.Now;
            DataManager manager = new DataManager();
            manager.CreateContent(content);
           return View("View", new { @courseId=content.CourseId });
        }
        public ActionResult Delete()
        {
            int ContentId = Convert.ToInt32(Request["ContentId"]);
            DataManager mng = new DataManager();
            mng.DeleteContent(ContentId);
            return Redirect("/Course/Index");
        }
    }
}