using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Registration_and_Record_System
{
    class DBServer
    {
        private MySqlConnection conn = new MySqlConnection("server = localhost; username = root; password = JEAton123; database = dbregistration_system");

        // Properties
        public MySqlConnection Connection
        {
            get { return conn; }
        }

        // Open Connnection
        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed) 
                conn.Open();
        }

        // Close Connection
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open) 
                conn.Close();
        }
    }
}
