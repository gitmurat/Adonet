using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Adonet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(str);

            string cmdtext = "select top 10 * from boo";
            SqlCommand cmd = new SqlCommand(cmdtext, con); //önce command sonra connection

            Console.WriteLine("DB State : " + con.State);

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                con.Open(); //when a connection is opend it has to be closed even if there is an error in the code and a try/catch block has to be implemented.

                Console.WriteLine("DB State : " + con.State);
                Console.WriteLine();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("An error occured");
                Console.WriteLine("DB State : " + con.State);
            }
            
            finally
            {
                dr.Close(); //closing data reader and disposing of command is optional but preferred.
                cmd.Dispose();
                con.Close(); //closing connection which was open until now is a must
                Console.WriteLine("Connection Closed");
                Console.WriteLine("DB State : " + con.State);
            }
            
        }
    }
}
