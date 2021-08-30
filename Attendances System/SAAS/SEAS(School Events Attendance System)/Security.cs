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

    public partial class Security : Form
    {

        MySqlCommand sql_cmd = new MySqlCommand();

       // string stepQ = "1";

        private string dbAnswer = null;

        public Security()
        {
            
            InitializeComponent();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            
           
        }
        private void Clear()
        {
            tSecUn.Clear();
            tSecEmail.Clear();
            tSecCon.Clear();
            
        }


        private void Security_Load(object sender, EventArgs e)
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();
            listtest.Text = "Username :";
            btnback.Enabled = false;
            tSecUn.Visible = true;
            tSecCon.Visible = false;
            tSecEmail.Visible = false;
            bSecOk.Visible = false;
            bSecClear.Visible = false;
            btnext.Enabled = false;
            // SearchUsername();
        }
        

        private void tSecCon_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            tSecUn.Clear();
            tSecEmail.Clear();
            tSecCon.Clear();
            listtest.Text = "Username :";
            btnback.Enabled = false;
            bSecOk.Visible = false;
            bSecClear.Visible = false;
            tSecUn.Visible = true;
            tSecCon.Visible = false;
            tSecEmail.Visible = false;
            btnext.Enabled = true;
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }
        private void btnext_Click(object sender, EventArgs e)
        {
            if (listtest.Text == "Username :")
            {
                tSecUn.Visible = false;
                tSecCon.Visible = true;
                tSecEmail.Visible = false;
                btnback.Enabled = true;
                btnext.Enabled = false;
                lPass.Visible = false;
                listtest.Text = "Contact :";
            }

           else if (listtest.Text == "Contact :")
            {
                btnback.Enabled = true;
                btnext.Enabled = false;
                tSecUn.Visible = false;
                tSecCon.Visible = false;
                tSecEmail.Visible = true;
                bSecOk.Visible = true;
                bSecClear.Visible = true;
                lPass.Visible = false;
                listtest.Text = "Email :";
                //SearchUsermail();
            }
            //else if (listtest.Text == "Email :")
            //{
            //    listtest.Text = "Email :";
            //    btnext.Enabled = false;
            //}
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (listtest.Text == "Email :")
            {
                tSecUn.Visible = false;
                tSecCon.Visible = true;
                tSecEmail.Visible = false;
                btnback.Enabled = true;
                btnext.Enabled = true;
                bSecOk.Visible = false;
                bSecClear.Visible = false;
                listtest.Text = "Contact :";
            }

            else if (listtest.Text == "Contact :")
            {
                btnback.Enabled = false;
                btnext.Enabled = true;
                tSecUn.Visible = true;
                tSecCon.Visible = false;
                tSecEmail.Visible = false;
                bSecOk.Visible = false;
                bSecClear.Visible = false;
                listtest.Text = "Username :";

            }
            else if (listtest.Text == "Username :")
            {
                listtest.Text = "Username :";
            }
        }

        //mga tester
        private void SearchUsercon()
        {
            string sql = "SELECT * FROM tbluser Where contact= '" + tSecCon.Text + "'  ";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                dbAnswer = rd["contact"].ToString();

            }

            rd.Close();

            if (dbAnswer == null)
            {
                tSecUn.Visible = false;
                tSecCon.Visible = true;
                tSecEmail.Visible = false;
                btnback.Enabled = true;
                btnext.Enabled = false;
                lPass.Visible = false;
                listtest.Text = "Contact :";
            }

            else
            {
                lPass.Visible = true;
                lPass.ForeColor = Color.Red;
                lPass.Text = "Your search did not return any results. Please try bagain!";
                tSecCon.Focus();
            }


        }

        private void SearchUsermail()
        {
            string sql = "SELECT * FROM tbluser Where email = '" + tSecEmail.Text + "'  ";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                dbAnswer = rd["email"].ToString();

            }

            rd.Close();

            if (dbAnswer != null)
            {
                btnback.Enabled = true;
                btnext.Enabled = false;
                tSecUn.Visible = false;
                tSecCon.Visible = false;
                tSecEmail.Visible = true;
                bSecOk.Visible = true;
                bSecClear.Visible = true;
                lPass.Visible = false;
                listtest.Text = "Email :";
            }

            else
            {
                lPass.Visible = true;
                lPass.ForeColor = Color.Red;
                lPass.Text = "Your search did not return any results. Please try bagain!";
                tSecCon.Focus();
            }


        }

       

        private void tSecUn_TextChanged(object sender, EventArgs e)
        {
            if(tSecUn.Text != null)
            {
                btnext.Enabled = true;
            }
          //  SearchUsername();
        }

        private void tSecCon_TextChanged_1(object sender, EventArgs e)
        {
            if (tSecCon.Text != null)
            {
                btnext.Enabled = true;
            }
        }

        private void bSecOk_Click(object sender, EventArgs e)
        {
           // int s = 0;

            string sql = "SELECT * FROM tbluser WHERE un = '" + tSecUn.Text + "' and  contact= '" + tSecCon.Text + "' and email ='" + tSecEmail.Text + "' ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
               // s = Convert.ToInt32(rd["id"].ToString());
                clsMySQL.sUn = (rd["un"].ToString());
                clsMySQL.sPw = (rd["pw"].ToString());
                clsMySQL.sContact = (rd["contact"].ToString());
                clsMySQL.sEmail = (rd["email"].ToString());
            }
            rd.Close();

            if (clsMySQL.sUn != null && clsMySQL.sContact != null && clsMySQL.sEmail != null)
            {
                lPass.Visible = true;
                lPass.Text = "Your Password is '" + clsMySQL.sPw + "' ";
                lPass.Location = new Point(-1, 221);
                lPass.Font = new Font("Segoe UI", 11);
                btnext.Enabled = false;
            }

            else
            {
                lPass.Visible = true;
                lPass.ForeColor = Color.Red;
                lPass.Text = "Incorrect input!";
                //Clear();
            }


        }

        private void bSecOk_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void Security_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
