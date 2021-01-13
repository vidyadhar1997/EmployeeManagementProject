using EmployeeModel.Models;
using EmployeeRepoisitory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EmployeeManagement.Controllers
{
    /*[ApiController]*/
    public class EmployeeController : ControllerBase
    {
         private readonly IRepoisitory repoisitory;
        

        public EmployeeController(IRepoisitory repoisitory)
        {
            this.repoisitory = repoisitory;
        }

        [HttpPost]
        [Route("api/addedEmployee")]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            var result=this.repoisitory.CreateEmployee(employee);
            if (result.Equals("SUCCESS")) 
            {
                return this.Ok(result);

            }
            else 
            {
                return this.BadRequest();

            }
        }
       /* [HttpGet]
         public IActionResult GetEmployee(string id)
         {
             List<Employee> employeeList = new List<Employee>();
            employeeList = (List<Employee>)this.repoisitory.GetEmployee(id);
            return (IActionResult)employeeList;
         }*/
    }
}
