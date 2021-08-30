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
    public partial class USER : Form
    {
        public string SID;
        public string sName;
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        
        MySqlCommand sql_cmd = new MySqlCommand();

        private void USER_Load(object sender, EventArgs e)
        {
            b1.PerformClick();
            button3.Focus();
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            Load_Data();
            p0.Visible = true;
            p0.Dock = DockStyle.Fill;
            p0.BringToFront();
            pabout.Visible = false;
            picd.Visible = false;
            b1.Visible = true;
            stu.Visible = false;
            b3.Visible = false;
           
            b5.Visible = false;
            b6.Visible = false;
            picd.Visible = false;
            picu.Visible = false;
            date.Text = DateTime.Now.ToLongDateString();


        }

        public USER()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            p0.Visible = true;
            p0.Dock = DockStyle.Fill;
            p1.Visible = false;
            p2.Visible = false;
           
            panel6.Visible = false;
            pabout.Visible = false;
        }

        private void stu_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
            panel6.Visible = true;
            p1.Dock = DockStyle.Fill;
            p2.Visible = false;
        
            p0.Visible = false;
       
            lb1.Visible = true;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            p2.Visible = true;
            p2.Dock = DockStyle.Fill;
            p1.Visible = false;
            pabout.Visible = false;
            p0.Visible = false;
           
            if (SID == null) return;
        }

        private void Load_Data()
        {
            string sql = "SELECT * FROM prosted ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            view.Items.Clear();
            while (rd.Read())
            {
                view.Items.Add(rd["id"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["lname"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["grade"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["strand"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["gender"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["contact"].ToString());
                view.Items[view.Items.Count - 1].SubItems.Add(rd["date"].ToString());
            }
            rd.Close();
            lb1.Text = "  Total records : " + view.Items.Count;
            int x;
            for (x = 0; x <= view.Items.Count - 2; x += 2) ;
        }
        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
      
        private void Search(string sSearch)
        {
            string sql = "SELECT * FROM prosted WHERE fname like '%" + sSearch + "%' or lname like '%" + sSearch + "%' or gender like '%" + sSearch + "%' or  grade like '%" + sSearch + "%' or  strand like '%" + sSearch + "%' or contact like '%" + sSearch + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            view.Items.Clear();
            while (rd.Read())
            {
                view.Items.Add(rd["id"].ToString()); //id view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["fname"].ToString()); //fname view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["lname"].ToString()); //lname view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["grade"].ToString()); //gender view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["strand"].ToString()); //age view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["gender"].ToString()); //strand view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["contact"].ToString()); //school view
                view.Items[view.Items.Count - 1].SubItems.Add(rd["date"].ToString()); //modified 
            }

            rd.Close();

        }

        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (view.FocusedItem.Text != null)
            {
                b3.PerformClick();
                View(view.FocusedItem.Text);
                Account_Image(view.FocusedItem.Text);

            }
        }

        private void tsearch_TextChanged_1(object sender, EventArgs e)
        {
            if (tsearch.Text != "" || tsearch.Text != "Search here")
                Search(tsearch.Text);
        }

        private void view_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = view.FocusedItem.Text;
        }

        private void picu_Click(object sender, EventArgs e)
        {
            b1.Visible = false;
            stu.Visible = false;
            b3.Visible = false;
            
            b5.Visible = false;
            b6.Visible = false;
            picd.Visible = true;
            picu.Visible = false;
        }

        private void picd_Click(object sender, EventArgs e)
        {
            b1.Visible = true;
            stu.Visible = true;
            b3.Visible = true;
           
            b5.Visible = true;
            b6.Visible = true;
            picd.Visible = false;
            picu.Visible = true;
        }

        private void View(String id)
        {
            string sql = "SELECT * FROM prosted where id = " + id;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                full.Text = (rd["lname"].ToString() + "," + (rd["fname"].ToString()));
                lfirst.Text = "First name: " + (rd["fname"].ToString());
                llast.Text = "Last name: " + (rd["lname"].ToString());

                lgrade.Text = "Grade: " + (rd["grade"].ToString());

                lstrand.Text = "Strand: " + (rd["strand"].ToString());

                lgender.Text = "Gender: " + (rd["gender"].ToString());

                lcontact.Text = "Contact: " + (rd["contact"].ToString());
                lupdate.Text = "Last Modified: " + (rd["date"].ToString());

            }

            rd.Close();

        }

        private void b5_Click(object sender, EventArgs e)
        {
            pabout.Visible = true;
            pabout.Dock = DockStyle.Fill;
            pabout.BringToFront();
            panel3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b1.Visible = true;
            stu.Visible = true;
            b3.Visible = true;

            b5.Visible = true;
            b6.Visible = true;
            picd.Visible = false;
            picu.Visible = true;
            button3.Visible = false;
            pictureBox1.Visible = false;
            stu.PerformClick();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel the Data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form b = new Login();
                b.Show();
                this.Visible = false;
                sql = " UPDATE login SET outtime = now()  WHERE user='" + (clsMySQL.sUN) + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                return;
            }
            else return;
        }

        public void Account_Image(string id)
        {
            DataSet dS = new DataSet();
            sql = "SELECT pic FROM prosted WHERE id = " + id;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            vpic.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
        }
    }
}
