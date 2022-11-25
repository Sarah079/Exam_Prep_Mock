using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_Prep_Mock.Models.Section_B
{

    /******Start Question 1 ********/
    public abstract class GamingConsole
    {
        //Data Members
        public Guid _ID { get; set; }
        public string _Model { get; set; }
        public string _Name { get; set; }
        public double _Price { get; set; }
        //Parameterless Constructor
        public GamingConsole()
        {

        }

        //Default Constructor
        public GamingConsole(Guid ID, string Model, string Name, double Price)
        {
            _ID = ID;
            _Model = Model;
            _Name = Name;
            _Price = Price;
        }

        //Methods 
        public abstract string Description();

        public abstract string ShippingDelay();

        /** Move To Playstation Class **/
    }
}