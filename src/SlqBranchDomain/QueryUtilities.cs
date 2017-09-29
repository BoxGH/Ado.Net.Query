using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SlqBranchDomain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public static class QueryUtilities
    {
        public static void CustomerProductJacket(string connectionString, List<CustomerSbd> customers, List<ProductSbd> products)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Customer";
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CustomerSbd
                            {
                                Id = reader.GetInt32(0),
                                CustomerFullName = reader.GetString(1)
                            });
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Product";
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            products.Add(new ProductSbd
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Quantity = reader.GetInt32(3)
                            });
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static void CustomerOrderGroup(string connectionString, List<CustomerOrdersProducts> copGroup)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT customers.CustomerFullName, "
                                           + "orders.Id, orders.DateOperation, orders.Amount, "
                                           + "products.Name, products.Price, "
                                           + "prodotrder.Quantity "
                                     + "FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY Id) AS RowNum FROM[dbo].[Customer]) as customers "
                                          + "JOIN[dbo].[Order] as orders on customers.Id = orders.CustomerId "
                                          + "JOIN[dbo].[ProductOrder] as prodotrder on orders.Id = prodotrder.OrderId "
                                          + "JOIN[dbo].[Product] as products on prodotrder.ProductId = products.Id "
                                     + "WHERE customers.RowNum BETWEEN 1 AND 5";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        copGroup.Add(new CustomerOrdersProducts
                        {
                            CustorerName = reader.GetString(0),
                            OrderId = reader.GetInt32(1),
                            OrderDateOperation = reader.GetDateTime(2),
                            OrderAmount = reader.GetDecimal(3),
                            ProductName = reader.GetString(4),
                            ProductPrice = reader.GetDecimal(5),
                            ProductOrderQuantity = reader.GetInt32(6)
                        });
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static string CreateOrder(string connectionString, AddJsonOrder ajo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            { //string command = "INSERT INTO [dbo].[Order] ([Amount], [CustomerId], [CustomerName], [DateOperation], [OrderNumber]) VALUES ("+ajo.TotalPrice+", "+ajo.CustomerId+", N'"+ajo.CustomerName+"', N'"+dto+"', 0)";
                DateTime dto = new DateTime();
                dto = DateTime.Now;

                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.Transaction = transaction;
             try
                {
                    sqlCommand.CommandText =
                        "INSERT INTO [dbo].[Order] ([Amount], [CustomerId], [CustomerName], [DateOperation], [OrderNumber]) VALUES ("
                                        + ajo.TotalPrice + ", " + ajo.CustomerId + ", N'" + ajo.CustomerName + "', N'" + dto + "', 0)";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "SELECT * FROM [dbo].[Order] as corder WHERE corder.CustomerName = N'"
                                                      + ajo.CustomerName + "' AND corder.DateOperation = N'" + dto + "'";
                    int ID = (int)sqlCommand.ExecuteScalar();

                    foreach (var pd in ajo.ProductsDescript)
                    {
                        sqlCommand.CommandText =
                            "INSERT INTO [dbo].[ProductOrder] ([OrderId], [ProductId], [Quantity]) VALUES ("
                                                 + ID + ", " + pd.ProductId + ", " + pd.QuantityProduct + ")";
                        sqlCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    //transaction.Rollback();
                    return e.Message;
                }
                finally
                {
                    connection.Close();
                }
                return "Order created";
            }
        }

        public static void DeleteOrder(string connectionString, int? ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (null == ID) return;

                connection.Open();
                try
                {
                    new SqlCommand("DELETE FROM [dbo].[Order] WHERE Id = " + ID + "", connection).ExecuteNonQueryAsync();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void CustomerSetNotOrder(string connectionString, bool flag, List<CustomerSbd> customers)
        {
            //SELECT * FROM [dbo].[Customer] WHERE [dbo].[Customer].Id not in (SELECT CustomerId FROM [dbo].[Order]) 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    if (!flag)
                        command.CommandText = "SELECT * FROM [dbo].[Customer] WHERE [dbo].[Customer].Id not in (SELECT CustomerId FROM [dbo].[Order])";
                    else
                        command.CommandText = "SELECT * FROM [dbo].[Customer] WHERE [dbo].[Customer].Id in (SELECT CustomerId FROM [dbo].[Order])";
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CustomerSbd
                            {
                                Id = reader.GetInt32(0),
                                CustomerFullName = reader.GetString(1)
                            });
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

        }
    }
}
