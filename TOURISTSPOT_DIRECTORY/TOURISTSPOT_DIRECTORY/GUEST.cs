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
    public partial class GUEST : Form
    {
        public string SID;
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        MySqlCommand sql_cmd = new MySqlCommand();
        public GUEST()
        {
            InitializeComponent();
        }
        public static byte[] ImgConvert(Image x)
        {
            MemoryStream ms = new MemoryStream();
            x.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void v1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = v1.FocusedItem.Text;
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {

            if (tsearch.Text != "")
                Search(tsearch.Text);
            if (tsearch.Text == "")
            {
                Load_Data();
            }
        }
        private void Search(string sSearch)
        {
            string sql = "SELECT * FROM directory WHERE name like '%" + sSearch + "%' or type like '%" + sSearch + "%' or ba like '%" + sSearch + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            v1.Items.Clear();
            while (rd.Read())
            {
                v1.Items.Add(rd["id"].ToString());
                v1.Items[v1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                v1.Items[v1.Items.Count - 1].SubItems.Add(rd["type"].ToString());
                v1.Items[v1.Items.Count - 1].SubItems.Add(rd["ba"].ToString());
            }
            rd.Close();

        }

        private void csearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (csearch.Text != "")
                Search(csearch.Text);
            if (csearch.Text == "" || csearch.Text == "ALL")
            {
                Load_Data();
            }

        }

        private void GUEST_Load(object sender, EventArgs e)
        {
            Load_Data();
            panel1.Visible = true;
            p2.Visible = true;
            p2.BringToFront();
            p2.Dock = DockStyle.Fill;
         
            panel1.Dock = DockStyle.Top;
        }

        private void v1_Click(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM directory where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                label1.Text = (rd["name"].ToString());
              

            }

            rd.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           Form b = new LOGIN();
            b.Show();
            this.Visible = false;
        }

        private void tsearch_KeyDown(object sender, KeyEventArgs e)
        {
            phome.Visible = true;
            phome.Dock = DockStyle.Fill;
        }

        private void v1_DoubleClick(object sender, EventArgs e)
        {
           
            View();
            panel1.Visible = false;
            p2.Visible = false;
            phome.Visible = true;
            phome.BringToFront();
            phome.Dock = DockStyle.Fill;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            p2.Visible = false;
            phome.Visible = true;
            phome.BringToFront();
            phome.Dock = DockStyle.Fill;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pdatails.Visible = true;
            pdatails.BringToFront();
            pdatails.Dock = DockStyle.Fill;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
          
            pdatails.Visible = true;
            pdatails.BringToFront();
            pdatails.Dock = DockStyle.Fill;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            p2.Visible = false;
            phome.Visible = true;
            phome.BringToFront();
            phome.Dock = DockStyle.Fill;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            viewpersonel();
            pcontact.Visible = true;
            pcontact.BringToFront();
            pcontact.Dock = DockStyle.Fill;
        }

        private void pcon_Click(object sender, EventArgs e)
        {
            viewpersonel();
            pcontact.Visible = true;
            pcontact.BringToFront();
            pcontact.Dock = DockStyle.Fill;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
           
            phome.Visible = true;
            phome.BringToFront();
            phome.Dock = DockStyle.Fill;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            viewpersonel();
            pcontact.Visible = true;
            pcontact.BringToFront();
            pcontact.Dock = DockStyle.Fill;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            pab.Visible = true;
            pab.BringToFront();
            pab.Dock = DockStyle.Fill;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            viewpersonel();
            pcontact.Visible = true;
            pcontact.BringToFront();
            pcontact.Dock = DockStyle.Fill;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            pdatails.Visible = true;
            pdatails.BringToFront();
            pdatails.Dock = DockStyle.Fill;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            phome.Visible = true;
            phome.BringToFront();
            phome.Dock = DockStyle.Fill;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pab.Visible = true;
            pab.BringToFront();
            pab.Dock = DockStyle.Fill;
            About();
        }

        private void pabout_Click(object sender, EventArgs e)
        {
            pab.Visible = true;
            pab.BringToFront();
            pab.Dock = DockStyle.Fill;
            About();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pab.Visible = true;
            pab.BringToFront();
            pab.Dock = DockStyle.Fill;
            About();
        }

        private void About()
        {
            string sql = "SELECT * FROM about where id = " + 1;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                la5.Text = " " + (rd["name"].ToString());
                la1.Text = " " + (rd["con"].ToString());

                la2.Text = " " + (rd["fb"].ToString());

                la3.Text = " " + (rd["email"].ToString());

                la4.Text = " " + (rd["ins"].ToString());

                la6.Text = " " + (rd["text"].ToString());


            }

            rd.Close();
            DataSet dS = new DataSet();
            sql = "SELECT * FROM about where id = " + 1;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            l7.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["img"]));
        }

        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Load_Data()
        {
            string sql = "SELECT * FROM directory ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            v1.Items.Clear();
            while (rd.Read())
            {
                v1.Items.Add(rd["id"].ToString());
                v1.Items[v1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                v1.Items[v1.Items.Count - 1].SubItems.Add(rd["type"].ToString());
                v1.Items[v1.Items.Count - 1].SubItems.Add(rd["ba"].ToString());
            }
            rd.Close();
          
        }
        private void viewpersonel()
        {

            string sql = "SELECT * FROM personel where atrac = '" + label1.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                lf.Text = "Firstname : " + (rd["lname"].ToString());
                ll.Text = "Lastname : " + (rd["fname"].ToString());
            
                la.Text = "Address :  " + (rd["address"].ToString());
                lc.Text = "Contact : " + (rd["con"].ToString());
                le.Text = "Email Address : " + (rd["mail"].ToString());
             
                lp.Text = "Profession : " + (rd["pro"].ToString());
                lg.Text = "Gender : " + (rd["gen"].ToString());
                ls.Text = "Status : " + (rd["stat"].ToString());
                label8.Text =  (rd["about"].ToString());
                picperv.Image = null;
                clsMySQL.ttpp = (rd["de"].ToString());
            }
            rd.Close();

            if ((clsMySQL.ttpp) == "yes")
            {
                DataSet dS = new DataSet();
                sql = "SELECT * FROM personel where atrac = '" + label1.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);
                DataAdapter.Fill(dS, "pics");
                Byte[] byteBLOBData = new Byte[0];
                picperv.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["image"]));
            }




        }

      

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            p2.Visible = true;
            p2.BringToFront();
            p2.Dock = DockStyle.Fill;

            panel1.Dock = DockStyle.Top;
        }

        private void View()
        {
            string sql = "SELECT * FROM directory where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                label6.Text = (rd["name"].ToString());
                l1.Text = "Name of Attraction : " + (rd["name"].ToString());
                l2.Text = "Classification : " + (rd["cla"].ToString());
                l3.Text = " Categories : " + (rd["cate"].ToString());
                l4.Text = "Type :  " + (rd["type"].ToString());
                l5.Text = "Barangay : " + (rd["ba"].ToString());
                l6.Text = "Contact : " + (rd["con"].ToString());
                label4.Text =  (rd["de"].ToString());
                la7.Text = " Full Address : " + (rd["lo"].ToString());
                label11.Text =  (rd["history"].ToString());
                clsMySQL.ttt = (rd["sign"].ToString());
                clsMySQL.ttp = (rd["name"].ToString());

                pict1.Image = null;

            }

            rd.Close();
            if ((clsMySQL.ttt) == "yes")
            {
                DataSet dS = new DataSet();
                sql = "SELECT pic FROM directory WHERE id = " + SID;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);
                DataAdapter.Fill(dS, "pics");
                Byte[] byteBLOBData = new Byte[0];
                pict1.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
            }


        }
    }
}
