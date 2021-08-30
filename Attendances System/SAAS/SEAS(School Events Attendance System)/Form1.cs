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
    public partial class Form1 : Form
    {
        MySqlCommand sql_cmd = new MySqlCommand();
        private string sUn;
        private string sPw;

        public Form1()
        {
            
            InitializeComponent();
        }


        private void Clear()
        {
            tUn.Clear();
            tPass.Clear();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int s = 0;
            string sql = "SELECT * FROM tbluser WHERE un='" + tUn.Text + "' and pw= '" + tPass.Text + "' ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();


            while (rd.Read())
            {
                s = Convert.ToInt32(rd["id"].ToString());
                sUn= rd["un"].ToString();
                sPw = rd["pw"].ToString();
                clsMySQL.nameus = rd["fn"].ToString() + " " + rd["ln"].ToString();
            }

            rd.Close();

            if (!tUn.Text.Equals(sUn) && !tPass.Text.Equals(sPw))
            {
                lInvalid.Text = "You have entered invalid username or password!";
                Clear();
            }
            else
            {
                this.Hide();
                frmMENU fm = new frmMENU();
                fm.ShowDialog();

            }
           

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Security fm = new Security();
            fm.Show();
        }

        private void tUn_Enter(object sender, EventArgs e)
        {
            lInvalid.Text= "";
        }

        private void tPass_Enter(object sender, EventArgs e)
        {
            lInvalid.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();
        }

        private void tPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void tPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                int s = 0;
                string sql = "SELECT * FROM tbluser WHERE un='" + tUn.Text + "' and pw= '" + tPass.Text + "' ";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();


                while (rd.Read())
                {
                    s = Convert.ToInt32(rd["id"].ToString());
                    sUn = rd["un"].ToString();
                    sPw = rd["pw"].ToString();
                    clsMySQL.nameus = rd["fn"].ToString() + " " + rd["ln"].ToString();

                }

                rd.Close();

                if (!tUn.Text.Equals(sUn) && !tPass.Text.Equals(sPw))
                {
                    lInvalid.Text = "You have entered invalid username or password!";
                    Clear();
                }
                else
                {
                    this.Hide();
                    frmMENU fm = new frmMENU();
                    fm.ShowDialog();

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
