using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataManager
    {
        public bool CreateCourse(Cours cours)
        {
            var ctx = new MATH_ACADEMY_DBEntities();
            ctx.Courses.Add(cours);
            try
            {
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool CreateContent(Content content)
        {
            var contx = new MATH_ACADEMY_DBEntities();
            contx.Contents.Add(content);
          contx.SaveChanges();
            return true;
            /*try
            {
                contx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }*/
        }
        public int EditCourse(Cours cours)
        {
            var ctx = new MATH_ACADEMY_DBEntities();
            var old = ctx.Courses.Where(x => x.Id == cours.Id).FirstOrDefault();
            if (old != null)
            {
                old.Name = cours.Name;
            }
            return ctx.SaveChanges();
        }
        public int EditContent(Content content)
        {
            var contx = new MATH_ACADEMY_DBEntities();
            var old = contx.Contents.Where(x => x.Id == content.Id).FirstOrDefault();
            if (old != null)
            {
                old.Title = content.Title;
                old.Text = content.Text;
                old.Video = content.Video;
            }
            return contx.SaveChanges();
        }

        public Cours[] GetCourses()
        {
            var ctx = new MATH_ACADEMY_DBEntities();
            return ctx.Courses.ToArray();
        }
        public Content[] GetContents()
        {
            var contx = new MATH_ACADEMY_DBEntities();
            return contx.Contents.ToArray();
        }
        public Cours GetCourse(int courseId)
        {
            var ctx = new MATH_ACADEMY_DBEntities();
            return ctx.Courses.Where(x => x.Id == courseId).FirstOrDefault();
        }
        public Content GetContent(int ContentId)
        {
            var contx = new MATH_ACADEMY_DBEntities();
            return contx.Contents.Where(x => x.Id == ContentId).FirstOrDefault();
        }
       public Content GetCnt(int courseId)
        {
            var contx = new MATH_ACADEMY_DBEntities();
            return contx.Contents.Where(x => x.CourseId == courseId).FirstOrDefault();
        }
        public int DeleteCourse(int courseId)
        {
            var ctx = new MATH_ACADEMY_DBEntities();
            var old = ctx.Courses.Where(x => x.Id == courseId).FirstOrDefault();
            ctx.Courses.Remove(old);
            return ctx.SaveChanges();
        }
        public int DeleteContent(int contentId)
        {
            var contx = new MATH_ACADEMY_DBEntities();
            var old = contx.Contents.Where(x => x.Id == contentId).FirstOrDefault();
            contx.Contents.Remove(old);
            return contx.SaveChanges();
        }

    }
}
