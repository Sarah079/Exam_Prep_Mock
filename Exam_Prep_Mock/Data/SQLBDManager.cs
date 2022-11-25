using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam_Prep_Mock.Models.Section_C;
using System.Data.SqlClient;


namespace Exam_Prep_Mock.Data
{
    public class SQLDBManager
    {
        private SqlConnection Conn;

        public SqlConnection buildConnection()
        {
            SqlConnectionStringBuilder bob = new SqlConnectionStringBuilder();

            //Hint: if you have a different config. for your db, change your connection values below 
            bob["Data Source"] = ".";
            bob["Initial Catalog"] = "Chinook";
            bob["Integrated Security"] = "true";

            return new SqlConnection(bob.ConnectionString);
        }

        public void openConnection()
        {
            //bool status = true;
            try
            {
                String conString = buildConnection().ToString();
                Conn = new SqlConnection(conString);
                Conn.Open();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                closeConnection();
                //status = false;
            }
        }
        public bool closeConnection()
        {
            if (Conn != null)
            {
                Conn.Close();
            }
            return true;
        }

        public List<Customer> Customers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection Conn = buildConnection())
                {
                    openConnection();
                    using (SqlCommand command = new SqlCommand("select * from Customer", Conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Customer customer = new Customer()
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                City = reader["City"].ToString(),
                                Country = reader["Country"].ToString(),
                                Phone = reader["Phone"].ToString()
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return customers;
        }

        public List<Invoice> Invoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            try
            {
                using (SqlConnection Conn = buildConnection())
                {
                    openConnection();
                    using (SqlCommand command = new SqlCommand("select * from Customer", Conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice()
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                InvoiceId = Convert.ToInt32(reader["InvoiceId"]),
                                InvoiceDate = reader["InvoiceDate"].ToString(),
                                Total = (double)reader["Total"]
                            };
                            invoices.Add(invoice);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return invoices;
        }

        public List<InvoiceLine> InvoiceLines()
        {
            List<InvoiceLine> invoicelines = new List<InvoiceLine>();
            try
            {
                using (SqlConnection Conn = buildConnection())
                {
                    openConnection();
                    using (SqlCommand command = new SqlCommand("select * from Customer", Conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            InvoiceLine invoiceline = new InvoiceLine()
                            {
                                InvoiceLineId = Convert.ToInt32(reader["InvoiceLineId"]),
                                InvoiceId = Convert.ToInt32(reader["InvoiceId"]),
                                TrackId = Convert.ToInt32(reader["TrackId"]),
                                UnitPrice = (double)reader["UnitPrice"],
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };
                            invoicelines.Add(invoiceline);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return invoicelines;
        }


    }
}

