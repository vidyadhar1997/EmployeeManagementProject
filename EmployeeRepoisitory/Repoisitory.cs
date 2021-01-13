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

        public IEnumerable<Employee> GetEmployee(string id)
        {
            List<Employee> employees = new List<Employee>();
            employees=employeeContext.Employees.ToList();
            return employees;
        }
    }
}