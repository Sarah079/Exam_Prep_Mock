using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_Prep_Mock.Models.Section_C
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public int TrackId { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}