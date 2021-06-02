using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Service;
using Lab12MVCAJAX.Controllers;
using System.Web.Mvc;
using Lab12MVCAJAX.Models;

namespace Lab12MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();
        // GET: STUDENT

        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Name = c.studentName,
                             Address = c.studentAddress
                         }).ToList();
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent( string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent( Student std )
        {
            service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


    }
}