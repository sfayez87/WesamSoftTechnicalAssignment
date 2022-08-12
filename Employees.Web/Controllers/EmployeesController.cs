using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.Domain;

namespace Employees.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController():this(new EmployeeService())
        {

        }
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchForEmployee(string searchBy, string firstName, DateTime? startBirthDate, DateTime? endBirthDate)
        {
            if (string.IsNullOrWhiteSpace(searchBy))
            {
                return PartialView("~/Views/Employees/_SearchForEmployee.cshtml", _employeeService.GetAllEmployees());
            }
            switch (searchBy)
            {
                case "FName":
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        return PartialView("~/Views/Employees/_SearchForEmployee.cshtml", _employeeService.GetAllEmployees());
                    }
                    return PartialView("~/Views/Employees/_SearchForEmployee.cshtml", _employeeService.GetEmployeesByFirstName(firstName));
                case "BDate":
                    if (startBirthDate == null || endBirthDate == null)
                    {
                        return PartialView("~/Views/Employees/_SearchForEmployee.cshtml", _employeeService.GetAllEmployees());
                    }
                    return PartialView("~/Views/Employees/_SearchForEmployee.cshtml", _employeeService.GetEmployeesByBirthdate(startBirthDate,endBirthDate));
                default:
                    return PartialView("~/Views/Employees/_SearchForEmployee.cshtml", _employeeService.GetAllEmployees());
            }

        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
              _employeeService.Add(employee);
              return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_employeeService.GetEmployeeById(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Edit(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            _employeeService.Delete(new Employee {Id=id }); 
             return RedirectToAction("Index");
        }
    }
}
