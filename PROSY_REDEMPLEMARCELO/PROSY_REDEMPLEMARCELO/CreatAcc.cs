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
namespace PROSY_REDEMPLEMARCELO
{
    public partial class CreatAcc : Form
    {
        public static string sid;
        MySqlCommand sql_cmd = new MySqlCommand();
        public static int counter = 3;
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        public CreatAcc()
        {
            InitializeComponent();
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
        }

        private void CreatAcc_Load(object sender, EventArgs e)
        {
            pcreate.Visible = true;
            pcreate.Dock = DockStyle.Fill;
            pcreate.BringToFront();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Form b = new log();
            b.Show();
            this.Visible = false;
        }
      private void CREAT_Data()
        {
            string sql = "INSERT INTO login VALUES (null,'" + "user" + "','" + tpa.Text + "','" + tus.Text + "','" + tname.Text + "','" + tlast.Text + "','" + cge.Text + "','" + tage.Text + "','" + tadd.Text + "','" + cse.Text + "','" + tans.Text + "','" + tcon.Text + "','" + "Not Log Out Found" + "', now() ,'" + "Active" + "','" + "Thank you for Creating Account her, Update Your Account always. Enjoy Your First Log-in...." + "', now(),@File)";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            arrImage = ImgConvert(picb.Image);
            var withBlock = sql_cmd;
            withBlock.CommandText = sql;
            withBlock.Connection = clsMySQL.sql_con;
            withBlock.Parameters.AddWithValue("@File", arrImage);
            withBlock.ExecuteNonQuery();

        }
        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void button2_Click(object sender, EventArgs e)
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
                   

                }
                else return;
            }
            else MessageBox.Show(" Oppps ! Your password not match!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);


            tre.Clear();
            tre.Focus();
            return;
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

        private void username()
        {



            string sql = "SELECT * FROM login where user='" + tus.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.ttt = (rd["user"].ToString());
            }
            rd.Close();
        }
    }

}
