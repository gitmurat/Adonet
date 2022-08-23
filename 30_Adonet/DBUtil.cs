using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_Adonet
{
    internal class DBUtil
    {
        private static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(GetConnectionString("con1"));
            return con;
        }

        public static SqlCommand GetCommand(string cmdtext)
        {
            SqlCommand cmd = new SqlCommand(cmdtext);
            cmd.Connection = GetConnection();
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
    }
}
