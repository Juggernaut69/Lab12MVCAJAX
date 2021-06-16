using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab12MVCAJAX.Controllers;
using System.Web.Mvc;
using Lab12MVCAJAX.Models;
using System.Threading.Tasks;

namespace Lab12MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();
        // GET: STUDENT

        public async Task<ActionResult> IndexRazor()
        {
            var response = await Task.Run(()=>proxy.GetStudentAsync());
            System.Console.WriteLine("RESPUESTAAAAAAAAAAA");
            System.Console.WriteLine(response);
            //var listOfStrings = new List<StudentModel>();
            //var model = (from c in service.Get()
            //             select new StudentModel
            //             {
            //                 studentID = c.studentID,
            //                 studentName = c.studentName,
            //                 studentAddress = c.studentAddress
            //             }).ToList();
            return View(response.listado);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent( string id)
        {
            //return Json(service.Get(), JsonRequestBehavior.AllowGet);
            return null;
        }
        [HttpPost]
        public ActionResult createStudent( Models.StudentModel std )
        {
            //service.Insert(std);
            //string message = "SUCCESS";
            //return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            return null;
        }


    }
}