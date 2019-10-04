using ChartInASPMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChartInASPMVC.Controllers
{

    public class HomeController : Controller
    {
        EmployeeEntities context = new EmployeeEntities();
        [HttpGet]
        public ActionResult GetData()
        {

            var male = context.HighChart_Employee.Where(x => x.Gender == "Male").Count();
            var female = context.HighChart_Employee.Where(x => x.Gender == "Female").Count();
            var other = context.HighChart_Employee.Where(x => x.Gender == "Other").Count();
            var xyz = context.HighChart_Employee.Where(x => x.Gender == "XYZ").Count();
            Ratio obj = new Ratio();
            obj.Male = male;
            obj.Female = female;
            obj.Other = other;
            obj.XYZ = xyz;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int Male { set; get; }
            public int Female { set; get; }
            public int Other { set; get; }
            public int XYZ { set; get; }
        }
        public ActionResult Index()
        {
            return View();
        }

       
    }
}