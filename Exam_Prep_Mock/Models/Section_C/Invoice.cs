using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_Prep_Mock.Models.Section_C
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public String InvoiceDate { get; set; }

        public String Number { get; set; }

        public int CustomerId { get; set; }

        public double Total { get; set; }
    }
}