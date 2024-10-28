using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vul
{
    internal class Program
    {
        static void Main(string[] args)
        {
 

            Console.WriteLine("Enter your Order ID:");
            string orderid = Console.ReadLine();

            // Vulnerable code: SQL Injection risk
            string query = $"SELECT * FROM Eshop WHERE order_id = '{orderid}'";

            using (SqlConnection connection = new SqlConnection("Server=.\\NEUROIT;User Id=sa;Password=Welcome@123;Initial Catalog=NeuroIT;TrustServerCertificate=True;"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
        }
    }
}
