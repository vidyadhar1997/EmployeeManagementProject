using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeModel.Models;
using System.Linq;

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
             /*Employee employee = new Employee();*/
            var login=this.employeeContext.Employees.Where(x => x.Email == Emial && x.Password == Password).SingleOrDefault();
            /* var login = this.employeeContext.Employees.Where(x => x.Email == employee.Email && x.Password ==employee.Password);*/
            /*this.employeeContext.Employees.Find(login);*/
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

        public IEnumerable<Employee> GetEmployee(string id)
        {
            List<Employee> employees = new List<Employee>();
            employees=employeeContext.Employees.ToList();
            return employees;
        }
    }
}