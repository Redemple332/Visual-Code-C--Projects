using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SEAS_School_Events_Attendance_System_
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }
    }
}
