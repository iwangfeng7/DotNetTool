using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRequest()
        {
            return View();
        }
        public ActionResult PostRequest()
        {
            return View();
        }
        public ActionResult PutRequest()
        {
            return View();
        }
        public ActionResult DeleteRequest()
        {
            return View();
        }
        public ActionResult MVCJump()
        {
            return View();
        }

        public ActionResult WebApiResult()
        {
            return View();
        }

        public ActionResult MVCHtmlhelper()
        {
            ViewBag.StudentList = new List<Student>()
            {
                new Student(){StudentId = 1001,StudentName = "学生1",Age = 10,CreateTime = Convert.ToDateTime("2019-08-08"),IsNormal = true,Password = "1001"},
                new Student(){StudentId = 1002,StudentName = "学生2",Age = 10,CreateTime = Convert.ToDateTime("2019-08-08"),IsNormal = true,Password = "1001"}
            };
            return View(new Student(){StudentId = 1001,StudentName = "学生1",Age = 10,CreateTime = Convert.ToDateTime("2019-08-08"),IsNormal = true,Password = "1001"});
        }

    }
}