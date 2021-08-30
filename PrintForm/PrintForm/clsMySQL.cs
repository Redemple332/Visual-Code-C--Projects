using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace PrintForm
{
    class clsMySQL
    {
        public static string Server = "localhost";
        public static string Database = "db_alfaro"; //Change this with your database name
        public static string User = "root";
        public static string Password = "";
        public static string Port = "3306";

        public static string constring = "Server=" + Server + ";" + "Database=" + Database + ";" + "Uid=" + User + ";"
            + "Password=" + Password + ";";
        public static MySqlConnection sql_con = new MySqlConnection(constring);

    }
}
