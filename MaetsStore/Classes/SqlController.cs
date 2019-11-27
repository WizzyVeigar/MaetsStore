using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaetsStore.Classes
{
    public class SqlController
    {
        const string connectionstring = @"Server = RO-SKP-01838; Database=MaetsStore; Integrated Security=true";
        internal SqlConnection conn;

        public SqlController()
        {
            conn = new SqlConnection(connectionstring);
        }

        internal void OpenSqlConn()
        {
            if(conn != null && conn.State == System.Data.ConnectionState.Closed)
            conn.Open();
        }

        internal void CloseSqlConn()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }
}