using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam_Prep_Mock.Models.Section_B;

namespace Exam_Prep_Mock.Controllers
{
    public class SectionBController : Controller
    {
        /******Start Question 2 ********/
        public ActionResult Index()
        {
            if (playstations.Count == 0)
            {
                AddItems();
            }
            return View(playstations);
        }
        /** End Question 2 **/ /*** Total 5 MARKS ****/


        /*****Dont Touch This*******/
        public static List<Playstation> playstations = new List<Playstation>();

        private void AddItems()
        {
            playstations.Add(new Playstation(new Guid(), "Playstation 1", "2001_01PS1", 845.37, 10));
            playstations.Add(new Playstation(new Guid(), "Playstation 2", "2006_01PS2", 1000.50, 8));
        }
    }
}