// corporate relationship that exists between a customer, employee and employee supervisor.

//select into a new object The customer’s Name and Surname as ‘Customer’, the Employees Name and Surname as ‘Employee’
//and the email address that the employee that’s linked to the customer reports to as ‘ReportsTo’.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam_Prep_Mock.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exam_Prep_Mock.Controllers
{
    public class SectionAController : Controller
    {//--- SQL example at bottom 
        public JsonResult CorrectExample()
        {
            var coporateRelationship = db.Customers.Include(e => e.Employee)
                                                   .Select(r => new
                                                   {
                                                       Customer = r.FirstName + "" + r.LastName,
                                                       Employee = r.Employee.FirstName + "" + r.Employee.LastName,
                                                       ReportsTo = db.Employees.Where(y => y.EmployeeId == r.Employee.ReportsTo).FirstOrDefault().Email

                                                   }).ToList();

             return new JsonResult { Data = new { relationship = coporateRelationship }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //---------------------------------------------------------------------My attempt Q1
        public JsonResult Question1()
        {           
            var coporateRelationship = db.Customers.GroupBy(c => c.CustomerId)
                .Select(r => new  
            {
                customer = r.Select(c => c.FirstName).FirstOrDefault() + r.Select(c => c.LastName),//.FirstOrDefault(), shouldn't have used these here
                employee = r.Select(e => e.Employee.FirstName).FirstOrDefault() + r.Select(e => e.Employee.LastName),//.FirstOrDefault(),
                ReportsTo = r.Select(e => e.Employee.Email).FirstOrDefault() 
            }).ToList();


            //should have selected top 100 rows of employeeID and customer to evaluate relationship
            //there was a ReportsTO FK

            return new JsonResult { Data = new { relationship = coporateRelationship }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //---------------------------------------------------------------------My attempt Q2
        public string Question2(string playlist)
        {
            bool Status = false;
            if (playlist != "" || playlist != null)
            {
                Status = true; //this is correct

                List<Playlist> playlists = new List<Playlist>();
                playlists.Add(playlist);

                //-----------Correct way -------------------------
                Playlist playlist1 = new Playlist();
                playlist1.Name = playlist;
                db.Playlists.Add(playlist1);
                db.SaveChanges();
            }

            string status = JsonSerializer.Serialize(Status);
            return (status);

            //return JsonConvert.SerializeObject(new {status = status})); --- how memo did it but i think above is just as good 
        }

        /*****Dont Touch This*******/

        private ChinookEntities db = new ChinookEntities();

        public ActionResult Q1Index()
        {
            return View("Question1");
        }

        public ActionResult Q2Index()
        {
            
            return View("Question2");
        }
    }
}