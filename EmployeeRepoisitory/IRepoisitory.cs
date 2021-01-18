using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeModel.Models;

namespace EmployeeRepoisitory
{
    public interface IRepoisitory
    {
        public string CreateEmployee(Employee employee);
        public string Login(string Emial, string Password);
        public IEnumerable<Employee> GetEmployee();
        public string RemoveEmployee(int Id);
        public IEnumerable<Employee> GetEmployee(int id);

        public string UpdateEmployeeDetails(Employee employee);
        public string ResetPassword(string oldPassword, string newPassword);
    }
}