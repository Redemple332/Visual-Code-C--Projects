using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace FINALPROSYS_REDEMPLEMARCELO
{
    public partial class FORGOT : Form
    {
        MySqlCommand sql_cmd = new MySqlCommand();
        public FORGOT()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
        }
        private void UP()
        {

            if (tfind.Text == "" || (clsMySQL.ttt) == "")
            {
                MessageBox.Show("Insert your username or phone.", "No Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT * FROM login where user='" + tfind.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.ttt = (rd["user"].ToString());
                clsMySQL.ttl = (rd["contact"].ToString());
                label10.Text = " " + (rd["seq"].ToString());
            }
            rd.Close();

            if (tfind.Text == (clsMySQL.ttt) || tfind.Text == (clsMySQL.ttl))
            {

                p2.Visible = true;
                p2.Dock = DockStyle.Fill;
                p2.BringToFront();
            }

            else MessageBox.Show("Your search did not return any results.Please try again with other information", "No Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }

        private void l3_Click(object sender, EventArgs e)
        {
           
            if (tnewpass.Text == "Enter new password" && tnewre.Text == "Re-type new Password" || tnewpass.Text == "" && tnewre.Text == "Re-type new Password" || tnewre.Text == "" && tnewpass.Text == "Enter new password")

            {
                if (MessageBox.Show("Are you sure you want to Recover your Account ?", "Forgot password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Account has been Recovered Succesfully!", "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tnewpass.Clear();
                    tnewre.Clear();
                    tnewpass.Text = "Enter new password";
                    tnewre.Text = "Re-type new Password";
                    anser.Clear();
                    Form b = new LOGIN();
                    b.Show();
                    this.Visible = false;

                }
            }

            if (tnewpass.Text == tnewre.Text)
            {
               

                if (MessageBox.Show("Are you sure you want to change  your Password ?", "Forgot password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Update_Data();
                    MessageBox.Show("Password has been Change Succesfully!", "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tnewpass.Clear();
                    tnewre.Clear();
                    tnewpass.Text = "Enter new password";
                    tnewre.Text = "Re-type new Password";
                    anser.Clear();
                    Form b = new LOGIN();
                    b.Show();
                    this.Visible = false;
                }
                else MessageBox.Show("Oppps ! Your password not match!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void answer()
        {

            if (anser.Text == "" || (clsMySQL.ttq) == "")
            {
                MessageBox.Show("Answer the question first before  continue.", "Forgot Password Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT * FROM login where ans='" + anser.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.tta = (rd["seq"].ToString());
                clsMySQL.ttq = (rd["ans"].ToString());
                label18.Text = "" + (rd["fname"].ToString()) + " " + (rd["lname"].ToString());
                label11.Text = (rd["pass"].ToString());
            }
            rd.Close();

            if (anser.Text == (clsMySQL.ttq))
            {
                p3.Visible = true;
                p3.Dock = DockStyle.Fill;
                p3.BringToFront();
                l3.Focus();
            }

            else MessageBox.Show("Forgot Password is unavailable for this user, if you think this is an error, please go back and answer again.", "Forgot Password Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
            UP();
        }
        private void Update_Data()
        {

            string sql = " UPDATE login SET pass = '" + tnewre.Text + "'WHERE user='" + tfind.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
       

        private void label9_Click(object sender, EventArgs e)
        {
            answer();
           
        }

        private void FORGOT_Load(object sender, EventArgs e)
        {
            p1.Visible = true;
            p1.Dock = DockStyle.Fill;
            p1.BringToFront();
        }

          
        private void tfind_Click(object sender, EventArgs e)
        {
 tfind.Clear();
        }

        private void tnewpass_Click(object sender, EventArgs e)
        {
tnewpass.Clear();
        }

        private void tnewre_Click(object sender, EventArgs e)
        {
 tnewre.Clear();
        }

        private void anser_Click(object sender, EventArgs e)
        {
            anser.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form b = new LOGIN();
            b.Show();
            this.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form b = new LOGIN();
            b.Show();
            this.Visible = false;
        }
    }



}
