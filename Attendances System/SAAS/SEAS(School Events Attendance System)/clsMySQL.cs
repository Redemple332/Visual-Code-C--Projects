using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SEAS_School_Events_Attendance_System_
{
    class clsMySQL
    {
        public static string Server = "localhost";
        public static string Database = "db_seas"; //Change this with your database name
        public static string User = "root";
        public static string Password = "";
        public static string Port = "3306";

        public static string constring = "Server=" + Server + ";" + "Database=" + Database + ";" + "Uid=" + User + ";"
            + "Password=" + Password + ";";
        public static MySqlConnection sql_con = new MySqlConnection(constring);


        public static string fn;
        public static string ln;
        public static string id = null;
        public static string sid = null;
        public static string evnt = null;
        public static string studevnt = null;
        public static string evntname = null;
        public static string atevntnm = null;
        public static string datlog = null;
        public static string nameus = null;
        public static string eve = null;
        public static string det = null;
        public static string qrcode = null;
        public static string sUn = null;
        public static string sPw = null;
        public static string sContact = null;
        public static string sEmail = null;
        public static string eid = null;
        public static string evlistid = null;

    }
}
