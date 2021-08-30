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

namespace prosys_Marcelo
{
 
    public partial class LOGIN : Form
    {
        MySqlCommand sql_cmd = new MySqlCommand();
        public static int counter = 3;
        public LOGIN()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
           
        }

        private void tuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void tuser_Click(object sender, EventArgs e)
        {
            tuser.Clear();
        }

        private void tpass_Click(object sender, EventArgs e)
        {
            tpass.Clear();
        }
        private void Log()
        {
            string sql = "SELECT * FROM login where user='" + tuser.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.sUN = (rd["user"].ToString());
                clsMySQL.sPW = (rd["pass"].ToString());
                clsMySQL.ttb = (rd["Administrator"].ToString());
                clsMySQL.tty = (rd["status"].ToString());

            }
            rd.Close();
            if (tpass.Text == (clsMySQL.sPW) && tuser.Text != (clsMySQL.sUN))
            {
                MessageBox.Show("No Valid  Username!", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tuser.Focus();
                counter--;
                return;
            }

            if (tpass.Text == "")
            {
                tpass.Focus();
                tpass.Clear();
                return;
            }


            if (tuser.Text == "" || tuser.Text == "" && tpass.Text == "")
            {
                tuser.Focus();
                return;
            }




            if (tuser.Text == (clsMySQL.sUN) && tpass.Text != (clsMySQL.sPW))
            {
                {
                    MessageBox.Show("No Valid Password", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    counter--;
                    tpass.Focus();
                }


                if (counter == 1)
                {
                    MessageBox.Show("Find Account!", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form b = new LOGIN();
                    b.Show();
                    this.Visible = false;
                }
            }
            if ("Active" != (clsMySQL.tty))
            {

                MessageBox.Show("Your Account has been Deactivated", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




            if (tpass.Text == (clsMySQL.sPW) && tuser.Text == (clsMySQL.sUN) && "user" == (clsMySQL.ttb) && "Active" == (clsMySQL.tty))
            {
                Form b = new USER();
                b.Show();
                this.Visible = false;
                sql = " UPDATE login SET intime = now()  WHERE user='" + tuser.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                return;

            }
            if (tpass.Text == (clsMySQL.sPW) && tuser.Text == (clsMySQL.sUN) && "Admin" == (clsMySQL.ttb))
            {
                Form b = new ADMIN();
                b.Show();
                this.Visible = false;
                sql = " UPDATE login SET intime = now()  WHERE user='" + tuser.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                return;


            }

            if (tpass.Text != (clsMySQL.sPW) && tuser.Text != (clsMySQL.sUN))
            {
                MessageBox.Show("Invalid Username and  Password, Please Try Again! ", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tuser.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form b = new FORGOT();
            b.Show();
            this.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tpass.UseSystemPasswordChar = true;
            }
            else
            {
                tpass.UseSystemPasswordChar = false;
            }
        }
        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
