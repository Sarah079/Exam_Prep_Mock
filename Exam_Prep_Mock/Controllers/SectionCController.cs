using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam_Prep_Mock.Data;
using Exam_Prep_Mock.Models.Section_C;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Exam_Prep_Mock.Controllers
{
    public class SectionCController : Controller
    {
        SQLDBManager db = new SQLDBManager();
        //the total spend per order for each customer && the total number of orders placed by that customer
        public ActionResult Chart()
        {

            var CustomerOrders = db.Invoices()
                                   .Select(order => new ChartVM
                                   {
                                       Customer_Name = db.Customers().Where(x => x.CustomerId == order.CustomerId).FirstOrDefault().FirstName,
                                       Order_Total = order.Total,
                                       Back_Color = "#009c9e",
                                       Border_Color = "#009c9e"
                                   }).ToList();

            /**Required**/

            List<string> labels = new List<string>();
            List<double> Values = new List<double>();

            /**Optional**/

            List<string> backColors = new List<string>();
            List<string> borderColors = new List<string>();

            foreach (ChartVM order in CustomerOrders)
            {
                labels.Add(order.Customer_Name);
                Values.Add(order.Order_Total);
                backColors.Add("#27898b");
                borderColors.Add("#009c9e");
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();


            /*Required VB*/
            ViewBag.labels = serializer.Serialize(labels);
            ViewBag.data = serializer.Serialize(Values);

            /*Optional Viewbags*/
            ViewBag.backColors = serializer.Serialize(backColors);
            ViewBag.borderColors = serializer.Serialize(borderColors);


            return View();
        }


        public ActionResult Myanswer()
        {
            try
            {
                db.openConnection();
                List<Invoice> invoices = db.Invoices();
                List<InvoiceLine> invoiceLines = db.InvoiceLines();
                List<Customer> customers = db.Customers();

                List<ChartVM> customer = customers.Select(x => new ChartVM { CustomerId = x.CustomerId, CustomerName = x.FirstName + "" + x.LastName }).ToList();
                ViewBag.Regions = customer;

                List<ChartVM> chart = (from il in invoiceLines
                                       join i in invoices on il.InvoiceId equals i.InvoiceId
                                       join c in customers on i.CustomerId equals c.CustomerId
                                       group il by il.InvoiceId into g

                                       select new
                                       {
                                           invoiceamount = (int)g.Sum(il => il.UnitPrice * il.Quantity),
                                           invoicetotal = (int)g.Count(y => y.)
                                       })
                             .ToList();
                             

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                db.closeConnection();
            }
            return View();
        }


    }
}