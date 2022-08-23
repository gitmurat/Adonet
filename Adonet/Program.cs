using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Integrated Security=True;Initial Catalog=Bahar;Data Source=.";

            SqlCommand command = new SqlCommand();
            
            command.Connection = connection;
            command.CommandText = "select top 10 * from book";
            command.CommandType = CommandType.Text;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                 
            }
           
            

            connection.Close();
        }
    }
}
