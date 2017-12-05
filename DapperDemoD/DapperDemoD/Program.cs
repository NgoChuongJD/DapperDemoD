using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperDemoD
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefautlConnection"].ConnectionString);
            string SqlString = "SELECT TOP 100 [CustomerID],[CustomerfName], [CustomerlName], [IsActive] FROM [Customer] ";
            var ourCustomer = (List<Customer>)db.Query<Customer>(SqlString);
            foreach (var Customer in ourCustomer)
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("\nCustomerID: " + Customer.CustomerID.ToString());
                Console.WriteLine("\nCustomerfName: " + Customer.CustomerfName);
                Console.WriteLine("\nCustomerlName: " + Customer.CustomerlName);
                Console.WriteLine("\nIsActive: " + Customer.IsActive+"\n");
                Console.WriteLine(new string('*',20));
            }
            Console.ReadKey(true);
        }
    }
}
