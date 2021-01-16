﻿using EmployeeModel.Models;
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
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
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
            string message = "LOGIN SUCCESS";
            var result = this.repoisitory.Login(employee.Email,employee.Password);
            if (result.Equals(message)) {
                return this.Ok(new { success = true, Message = "Get All Users successfully", Data = result });
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

        [HttpDelete]
        [Route("api/deletedEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = this.repoisitory.RemoveEmployee(id);
            if (result.Equals("Employee deleted")) {
                return this.Ok(result);
            }
            else {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/EmployeeDetails")]
        public IActionResult GetEmployee(int id)
        {
            var result = this.repoisitory.GetEmployee(id);
            if (result == true) {
                return this.Ok((new { success = true, Message = "Employee details fetched successfully", Data = result }));
            }
            else {
                return this.BadRequest();
            }
        }
    }
}
