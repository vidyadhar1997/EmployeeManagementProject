using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeModel.Models;
using System.Linq;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace EmployeeRepoisitory
{
    public class Repoisitory : IRepoisitory
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

        public string Login(string Emial, string Password)
        {
            string message;
            var login = this.employeeContext.Employees.Where(x => x.Email == Emial && x.Password == Password).SingleOrDefault();
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

        public string RemoveEmployee(int Id)
        {
            try
            {
                var login = this.employeeContext.Employees.Find(Id);
                this.employeeContext.Employees.Remove(login);
                this.employeeContext.SaveChangesAsync();
                return "Employee deleted";
            }
            catch (NullReferenceException e)
            {
                throw e;

            }
        }

        public IEnumerable<Employee> GetEmployee(int id)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(this.employeeContext.Employees.Find(id));
            return employees;
        }

        public string UpdateEmployeeDetails(Employee employee)
        {
            try
            {
                this.employeeContext.Entry(employee).State = EntityState.Modified;
                this.employeeContext.SaveChangesAsync();
                return "SUCCESS";
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public string ResetPassword(string oldPassword, string newPassword)
        {
            var Entries = this.employeeContext.Employees.FirstOrDefault(x => x.Password == oldPassword);
            if (Entries != null)
            {
                Entries.Password = newPassword;
                this.employeeContext.Entry(Entries).State = EntityState.Modified;
                this.employeeContext.SaveChanges();
                return "SUCCESS";
            }
            else
            {
                return "NOT FOUND";
            }
        }
        
        public string SendEmail(string emailAddress)
        {
            string body;
            string subject = "EmployeeManagements Credential";
            var entry = this.employeeContext.Employees.FirstOrDefault(x => x.Email == emailAddress);
            if (entry != null)
            {
                body = entry.Password;
            }
            else
            {
                return "Not Found";
            }
            using (MailMessage mailMessage = new MailMessage("vidyadharhudge1997@gmail.com", emailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("vidyadharhudge1997@gmail.com", "Dhiraj@123#");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "SUCCESS";
            }
        }
    }
}