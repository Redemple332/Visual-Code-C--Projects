using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace PROSY_REDEMPLEMARCELO
{
    class clsMySQL
    {
        public static string Server = "localhost";
        public static string Database = "db_profiling";
        public static string User = "root";
        public static string Password = "";
        public static string Port = "3306";

        public static string constring = "Server=" + Server + ";" + "Database=" + Database + ";" + "Uid=" + User + ";" + "Password=" + Password + ";";
        public static MySqlConnection sql_con = new MySqlConnection(constring);


        public static string ttt;
                  public static string sUN;
        public static string ttl;
        public static string ttq;
        public static string tta;
        public static string sPW;
        public static string ttb;
   public static string tty;
    }
}
