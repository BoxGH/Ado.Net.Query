using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SqlClientApp
{
    public class CustomerAdd
    {
        static string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db-tjApp-CustomerProduct;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void Set()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                try
                {
                    List<string> parameters = new List<string>{ 
                        "Иванов Иван Иванович",
                        "Петров Петр Петрович",
                        "Сидоро Сидор Сидорович",
                        "Осипоп Осип Осипович",
                        "Охрипов Охрип Охрипович"
                    };
                    connection.Open();
                    foreach (var x in parameters)
                    {
                        string command = "INSERT INTO Customer (CustomerFullName) VALUES (@VALUE)";
                        SqlCommand sqlCommander = new SqlCommand(command, connection);
                        sqlCommander.Parameters.AddWithValue("@VALUE", x);
                        sqlCommander.ExecuteNonQuery();
                    }

                }
                catch (Exception se)
                {
                    Console.WriteLine(se.Message);
                }
                finally
                {
                    connection.Close();
                }

            }

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
