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
using System.IO;
namespace TOURISTSPOT_DIRECTORY
{
    public partial class CREATE : Form
    {
        MySqlCommand sql_cmd = new MySqlCommand();
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        public CREATE()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
        }

        private void CREATE_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel1.BringToFront();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            username();
            if (tus.Text == (clsMySQL.ttt))
            {
                MessageBox.Show("Your Usernsme is already taken, try another Username ", "Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tus.Focus();
                return;
            }


            if (SaveNot())
            {
                tlast.Focus();
                return;
            }
            if (tpa.Text == tre.Text && tus.Text != (clsMySQL.ttt))
            {
                if (MessageBox.Show("Are you sure you want to Save new  account?", "Creat new account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("New account has been Create Succesfully!", "Creat new account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CREAT_Data();
                    Form b = new ADMIN();
                     b.Show();
                     this.Visible = false;

                    sql = "INSERT INTO history  VALUES (null, '" + "ADMIN" + "', '" + "DEACTIVATE ACCOUNT" + "', '" + clsMySQL.namess + "',now() )";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();

                }
                else return;
            }
            else MessageBox.Show(" Oppps ! Your password not match!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);


            tre.Clear();
            tre.Focus();
            return;
        
    }

        private void username()
        {
            string sql = "SELECT * FROM login where user='" + tus.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.sUN = (rd["user"].ToString());
            }
            rd.Close();
        }
      
        public static byte[] ImgConvert(Image x)
        {
            MemoryStream ms = new MemoryStream();
            x.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        private Boolean SaveNot()
        {
            Boolean err = false;

            if (tname.Text == "" || tname.Text == "First name")
            {
                tname.ForeColor = Color.Red;
                err = true;
            }
            if (tlast.Text == "" || tlast.Text == "Last name")
            {
                tlast.ForeColor = Color.Red;
                err = true;
            }

            if (cge.Text == "" || cge.Text == "Gender")
            {
                cge.ForeColor = Color.Red;
                err = true;
            }

            if (tage.Text == "" || tage.Text == "Age")
            {
                tage.ForeColor = Color.Red;
                err = true;
            }

            if (tcon.Text == "" || tcon.Text == "Contact number")
            {
                tcon.ForeColor = Color.Red;
                err = true;
            }

            if (tadd.Text == "" || tadd.Text == "Address")
            {
                tadd.ForeColor = Color.Red;
                err = true;
            }
            if (tus.Text == "" || tus.Text == "User name")
            {
                tus.ForeColor = Color.Red;
                err = true;
            }
            if (tpa.Text == "" || tpa.Text == "Choose a Password")
            {
                tpa.ForeColor = Color.Red;
                err = true;
            }
            if (tre.Text == "" || tre.Text == "Re-type Password")
            {
                tre.ForeColor = Color.Red;
                err = true;
            }
            if (cse.Text == "" || cse.Text == "Security question ( choose one )")
            {
                cse.ForeColor = Color.Red;
                err = true;
            }
            if (tans.Text == "" || tans.Text == "Your Answer")
            {
                tans.ForeColor = Color.Red;
                err = true;
            }

            if (err)
            {
                MessageBox.Show("Fill the Information first!!!", "Ooopss!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return err;
            }

            else
            {
                return err;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();

            odlg.FileName = null;
            odlg.DefaultExt = ".jpg";
            odlg.Filter = "Image (.jpg)|*.jpg";
            odlg.ShowDialog();
            if (odlg.FileName != null)
            {
                this.picb.ImageLocation = odlg.FileName;
                sLoadImg = odlg.FileName;
                Loadpic = true;
            }
        }

        private void tage_Enter(object sender, EventArgs e)
        {
            if (tage.Text == "Age")
            {
                tage.Clear();
                tage.ForeColor = Color.Black;
            }
        }

        private void tlast_Enter(object sender, EventArgs e)
        {
            if (tlast.Text == "Last name")
            {
                tlast.Clear();
                tlast.ForeColor = Color.Black;
            }
        }

        private void tname_Enter(object sender, EventArgs e)
        {
            if (tname.Text == "First name")
            {
                tname.Clear();
                tname.ForeColor = Color.Black;
            }
        }

        private void tcon_Enter(object sender, EventArgs e)
        {
            if (tcon.Text == "Contact number")
            {
                tcon.Clear();
                tcon.ForeColor = Color.Black;
            }
        }

        private void cge_Enter(object sender, EventArgs e)
        {
            cge.BackColor = Color.White;
            if (cge.Text == "Gender")
            {
                cge.Text = null;
                cge.ForeColor = Color.Black;
            }
        }

        private void tus_Enter(object sender, EventArgs e)
        {
            if (tus.Text == "Username")
            {
                tus.Clear();
                tus.ForeColor = Color.Black;
            }
        }

        private void tadd_Enter(object sender, EventArgs e)
        {

            if (tadd.Text == "Address")
            {
                tadd.Clear();
                tadd.ForeColor = Color.Black;
            }
        }

        private void tpa_Enter(object sender, EventArgs e)
        {
            if (tpa.Text == "Choose a Password")
            {
                tpa.Clear();
                tpa.ForeColor = Color.Black;
            }
        }

        private void tre_Enter(object sender, EventArgs e)
        {
            if (tre.Text == "Re-type Password")
            {
                tre.Clear();
                tre.ForeColor = Color.Black;
            }
        }

        private void cse_Enter(object sender, EventArgs e)
        {
            cse.BackColor = Color.White;
            if (cse.Text == "Security question ( choose one )")
            {
                cse.Text = null;
                cse.ForeColor = Color.Black;
            }
        }

        private void tans_Enter(object sender, EventArgs e)
        {
 if (tans.Text == "Your Answer")
            {
                tans.Clear();
                tans.ForeColor = Color.Black;
            }
        }

        private void tname_Leave(object sender, EventArgs e)
        {
            if (tname.Text == "")
            {
                tname.Text = "First name";
                tname.ForeColor = Color.Gray;
            }
        }

        private void tlast_Leave(object sender, EventArgs e)
        {
            if (tlast.Text == "")
            {
                tlast.Text = "Last name";
                tlast.ForeColor = Color.Gray;
            }
        }

        private void tcon_Leave(object sender, EventArgs e)
        {
            if (tcon.Text == "")
            {
                tcon.Text = "Contact number";
                tcon.ForeColor = Color.Gray;
            }
        }

        private void tage_Leave(object sender, EventArgs e)
        {

            if (tage.Text == "")
            {
                tage.Text = "Age";
                tage.ForeColor = Color.Gray;
            }
        }

        private void cge_Leave(object sender, EventArgs e)
        {
            if (cge.Text == "")
            {
                cge.Text = "Gender";
                cge.ForeColor = Color.Gray;
            }
        }

        private void tus_Leave(object sender, EventArgs e)
        {
            if (tus.Text == "")
            {
                tus.Text = "Username";
                tus.ForeColor = Color.Gray;
            }
        }

        private void tadd_Leave(object sender, EventArgs e)
        {
            if (tadd.Text == "")
            {
                tadd.Text = "Address";
                tadd.ForeColor = Color.Gray;
            }
        }

        private void tpa_Leave(object sender, EventArgs e)
        {
            if (tpa.Text == "")
            {
                tpa.Text = "Choose a Password";
                tpa.ForeColor = Color.Gray;
            }
        }

        private void tre_Leave(object sender, EventArgs e)
        {
            if (tre.Text == "")
            {
                tre.Text = "Re-type Password";
                tre.ForeColor = Color.Gray;
            }
        }

        private void cse_Leave(object sender, EventArgs e)
        {
            if (cse.Text == "")
            {
                cse.Text = "Security question ( choose one )";
                cse.ForeColor = Color.Gray;
            }
        }

        private void tans_Leave(object sender, EventArgs e)
        {
            if (tans.Text == "")
            {
                tans.Text = "Your Answer";
                tans.ForeColor = Color.Gray;
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Form b = new ADMIN();
            b.Show();
            this.Visible = false;
        }

        private void CREAT_Data()
        {
            string sql = "INSERT INTO login VALUES (null,'" + "user" + "','" + tpa.Text + "','" + tus.Text + "','" + tname.Text + "','" + tlast.Text + "','" + cge.Text + "','" + tage.Text + "','" + tadd.Text + "','" + cse.Text + "','" + tans.Text + "','" + tcon.Text + "','" + "No Log Out Found" + "', now() ,'" + "Active" + "',@File)";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            arrImage = ImgConvert(picb.Image);
            var withBlock = sql_cmd;
            withBlock.CommandText = sql;
            withBlock.Connection = clsMySQL.sql_con;
            withBlock.Parameters.AddWithValue("@File", arrImage);
            withBlock.ExecuteNonQuery();

        }
    }
}
