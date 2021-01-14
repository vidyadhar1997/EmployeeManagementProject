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
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
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

        [HttpPost]
        [Route("api/loginEmployee")]
        public IActionResult LoginEmployee([FromBody] Employee employee)
        {
            var result = this.repoisitory.Login(employee.Email,employee.Password);
            if (result.Equals("LOGIN SUCCESS")) {
                return this.Ok(result);
            }
            else {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/getEmployee")]
        public IActionResult GetEmployee()
         {
            try 
            {
                IEnumerable<Employee> list = this.repoisitory.GetEmployee();
                return this.Ok(list);
            }
            catch(Exception e) 
            {
                return this.BadRequest(e.Message);

            }
           
        }
    }
}
