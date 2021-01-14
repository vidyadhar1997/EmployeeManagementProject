using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeModel.Models;
using System.Linq;
using System.Collections;

namespace EmployeeRepoisitory
{
    public class Repoisitory:IRepoisitory
    {

        EmployeeContext employeeContext;

        public Repoisitory(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public string CreateEmployee(Employee employee)
        {
            this.employeeContext.Employees.Add(employee);
            this.employeeContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }
        public string Login(string Emial,string Password)
        {
            string message;
            var login=this.employeeContext.Employees.Where(x => x.Email == Emial && x.Password == Password).SingleOrDefault();
            if (login != null)
            {
                 message = "LOGIN SUCCESS";
            }
            else
            {
                 message = "LOGIN UNSUCCESSFUL";

            }
            return message;

        }

       public IEnumerable<Employee> GetEmployee()
       {
            IEnumerable<Employee> employeelist = this.employeeContext.Employees;
            return employeelist.ToList();
        }
    }
}