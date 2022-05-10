using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamMvcWeb.EmployeeService;

namespace ExamMvcWeb.Controllers
{
    public class EmployeeController : Controller
    {
        Service1Client service = new Service1Client();

        [HttpGet]
        public ActionResult Index(string keyword)
        {
            ViewBag.keyword = keyword;
            if (!string.IsNullOrEmpty(keyword))
            {
                var employees = service.SearchEmployee(keyword);
                return View(employees);
            }
            else
            {
                return View(service.FindAll());
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            bool result = service.AddEmployee(employee);
            if (result)
            {
                return Redirect("/Employee/Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}