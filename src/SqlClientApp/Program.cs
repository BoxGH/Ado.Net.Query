using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SqlClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductAdd.Set();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
