using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_Adonet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BookCount();
            GetBooks(101);
        }

        private static void GetBooks(decimal minPrice)
        {
            string str = "select * from book where price<=@price";
            SqlCommand cmd = DBUtil.GetCommand(str);

            cmd.Parameters.AddWithValue("@price", minPrice);
            try
            {
                cmd.Connection.Open();
                var dr = cmd.ExecuteReader();
                int ndx = 1;
                while(dr.Read())
                {
                    string name = dr["Name"].ToString();
                    decimal price = Convert.ToDecimal(dr["price"]);
                    Console.WriteLine(ndx++ +" - "+ dr["Name"] + " - Fiyati: " + price);
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private static void BookCount()
        {
            string str = "select count(*) from book";
            SqlCommand cmd = DBUtil.GetCommand(str);

            try
            {
                cmd.Connection.Open();
                Console.WriteLine(cmd.ExecuteScalar()); //execute scaler sql'den tek satır tek kolon bir değer döndürür. bu değer object olarak döner.
            }
            finally
            {
                cmd.Connection.Close();
            }
            cmd.Connection.Close();
        }
    }
}
