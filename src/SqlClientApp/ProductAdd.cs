using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SqlClientApp
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductAdd
    {
        static string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db-tjApp-CustomerProduct;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void Set()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                try
                {
                    List<Product> parameters = new List<Product>{
                        new Product { Name = "Product-2", Price = 23, Quantity = 45 },
                        new Product { Name = "Product-3", Price = 56, Quantity = 78 },
                        new Product { Name = "Product-4", Price = 78, Quantity = 25 },
                        new Product { Name = "Product-5", Price = 21, Quantity = 14 },
                        new Product { Name = "Product-6", Price = 34, Quantity = 74 },
                        new Product { Name = "Product-7", Price = 65, Quantity = 7 }

                    };

                    connection.Open();
                    SqlCommand sqlCommander = new SqlCommand("", connection);
                    foreach (var x in parameters)
                    {
                        string command = "INSERT INTO [dbo].[Product] ([Name], [Price], [Quantity]) VALUES ('"
                                                            + x.Name + "', " + x.Price + ", " + x.Quantity + ")";
                        sqlCommander.CommandText = command;
                        sqlCommander.ExecuteNonQuery();
                    }

                }
                catch (SqlException se){ Console.WriteLine(se.Message); }
                catch (Exception se) { Console.WriteLine(se.Message); }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
