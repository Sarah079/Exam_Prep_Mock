using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_Prep_Mock.Models.Section_B
{
    public class Playstation : GamingConsole
    {
        public int _dualShockRating { get; set; }

        public override string Description()
        {
            return "The following Console has a dualshock rating of " + " " + this._dualShockRating;
        }

        public override string ShippingDelay()
        {
            Random random = new Random();
            int Days = random.Next(1, 8);
            return "This Item will take " + Days + " " + "to deliver";

        }
        public Playstation()
        {

        }
        //correct version
        public Playstation (Guid ID, string Model, string Name, double Price,int dualShockRating) : base(ID, Model, Name, Price)
        {
            _dualShockRating = dualShockRating;
        }
        //public Playstation(int dualShockRating) : base(ID, Model, Name, Price) ----------my answer
        //{
        //    _dualShockRating = dualShockRating;
        //}

        /** End Question 1  - Move to HomeController For Question 2 **/ /*** Total 5 MARKS ****/
    }
}