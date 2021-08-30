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
    public partial class Form1 : Form
    {
        public string SID;
        public string sName;
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        Point lastpoint;

        MySqlCommand sql_cmd = new MySqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            b4.Visible = false;
            b5.Visible = false;
            b6.Visible = false;
            picd.Visible = false;
            picu.Visible = false;
            pacc.Visible = false;
            date.Text = DateTime.Now.ToLongDateString();
            view.ContextMenuStrip = cms;
            CTRL_Control(false);
            Pbar.Visible = false;

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

        private void Add_Data()
        {
           
            {
                arrImage = ImgConvert(picProfile.Image);
                string sql = "INSERT INTO prosted VALUES (null,'" + tf.Text + "','" + tl.Text + "','" + tgr.Text + "','" + tst.Text + "','" + tge.Text + "','" + td.Text + "', now() , @File)";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();
                Load_Data();
            }
 


        }

        public static byte[] ImgConvert(Image x)
        {
            MemoryStream ms = new MemoryStream();
            x.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            p0.Visible = true;
            p0.Dock = DockStyle.Fill;
            p0.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "UPDATE")
            {

                if (MessageBox.Show("Are you sure you want to Update the Data?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CTRL_Control(true);
                    b4.Text = "Add Profile";
                    p1.Visible = true;
                    p1.Dock = DockStyle.Fill;
                    p1.BringToFront();
                    Pbar.Visible = true;
                    Pbar.Value = 0;
                    tPbar.Start();
                    enable();
                }
            }
            else

            {
                if (SaveNot())
                {
                    return;
                }


                if (MessageBox.Show("Are you sure you want to Save the Data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   CTRL_Control(true);
                    enable();
                    p1.Visible = true;
                    p1.Dock = DockStyle.Fill;
                    p1.BringToFront();
                    panel6.Visible = true;
                    Pbar.Visible = true;

                    //        SaveImage();
                    Pbar.Value = 0;
                    tPbar.Start();
                    
                }


            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            p2.Visible = true;
            p2.Dock = DockStyle.Fill;
            p2.BringToFront();
            if (SID == null) return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();

            odlg.FileName = null;
            odlg.DefaultExt = ".jpg";
            odlg.Filter = "Image (.jpg)|*.jpg";
            odlg.ShowDialog();
            if (odlg.FileName != null)
            {
                this.picProfile.ImageLocation = odlg.FileName;
                sLoadImg = odlg.FileName;
                Loadpic = true;
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text != "" || tsearch.Text != "Search here")
                Search(tsearch.Text);
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
        private void CTRL_Control(Boolean x)
        {
            tf.Enabled = x;
            tl.Enabled = x;
            tgr.Enabled = x;
            tst.Enabled = x;
            tge.Enabled = x;
            td.Enabled = x;
        }

        private void deletetoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete it?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (view.FocusedItem.Text != null)
                {

                    CTRL_Control(true);
                    dEL_Data(view.FocusedItem.Text);

                    Load_Data();
                    MessageBox.Show("Record has been deleted Succesfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        }
        private void enable()
        {

            stu.Enabled = true;
            b3.Enabled = true;
            b4.Enabled = true;
            b5.Enabled = true;
            b6.Enabled = true;
            b1.Enabled = true;
            pacc.Enabled = true;
            
        }
        private void edittoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show_Data(SID);
            b4.Text = "Edit Profile";
            stu.Enabled = false;
            b3.Enabled = false;
            b1.Enabled = false;
            b5.Enabled = false;
            b6.Enabled = false;
            pacc.Enabled = false;
            if (view.FocusedItem.Text != null)
            {
                button8.Text = "UPDATE";
                button5.Text = "Edit Profile";
                CTRL_Control(true);
                Show_Data(view.FocusedItem.Text);
                Update_Image(view.FocusedItem.Text);
                p3.Visible = true;
                p3.Dock = DockStyle.Fill;
                p3.BringToFront();
                Pbar.Visible = false;
             


            }
        }

        private void dEL_Data(String id)
        {

            string sql = "Delete from prosted where id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();


        }
        private void Update_Data()
        {
            if (Loadpic == true)
            {
                arrImage = ImgConvert(picProfile.Image);
            }


            if (arrImage != null)
            {
                string sql = "UPDATE prosted SET fname='" + tf.Text + "', lname = '" + tl.Text + "' ,grade = '" + tgr.Text + "' ,strand = '" + tst.Text + "' ,gender = '" + tge.Text + "', contact = '" + td.Text + "',date=now() ,pic = @File WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();
                Load_Data();
            }



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

        public void Update_Image(string id)
        {
            DataSet dS = new DataSet();
            sql = "SELECT pic FROM prosted WHERE id = " + id;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            picProfile.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
        }



      

        private void tPbar_Tick(object sender, EventArgs e)
        {
            if (Pbar.Value <= 90)
            {
                Pbar.Value += 50;
            }
            else if (Pbar.Value == 100)
            {

                tPbar.Stop();
                Pbar.Visible = false;
                if (button8.Text.Equals("UPDATE"))
                {
                    Update_Data();

                }
                else if (button8.Text.Equals("SAVE"))
                {
                    Add_Data();
                    Load_Data();

                }

            }
        }

        private void Show_Data(String id)
        {

            string sql = "SELECT * FROM prosted where id = " + id;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                tf.Text = "" + (rd["fname"].ToString());

                tl.Text = "" + (rd["lname"].ToString());

                tgr.Text = "" + (rd["grade"].ToString());

                tst.Text = "" + (rd["strand"].ToString());

                tge.Text = "" + (rd["gender"].ToString());

                td.Text = "" + (rd["contact"].ToString());
            

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

        private void button3_Click(object sender, EventArgs e)
        {
            b1.Visible = true;
            stu.Visible = true;
            b3.Visible = true;
            b4.Visible = true;
            b5.Visible = true;
            b6.Visible = true;
            picd.Visible = false;
            picu.Visible = true;
            button3.Visible = false;
            pictureBox1.Visible = false;
            stu.PerformClick();
            pacc.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
            panel6.Visible = true;
            p1.Dock = DockStyle.Fill;
            p2.Visible = false;
            p3.Visible = false;
            p0.Visible = false;
            Pbar.Visible = false;
            lb1.Visible = true;
        }

        private void b5_Click(object sender, EventArgs e)
        {
            pabout.Visible = true;
            pabout.Dock = DockStyle.Fill;
            pabout.BringToFront();
            panel3.Visible = false;
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

        private void view_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = view.FocusedItem.Text;
        }

        private void picu_Click(object sender, EventArgs e)
        {
                   
            b1.Visible = false;
            stu.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b5.Visible = false;
            b6.Visible = false;
            picd.Visible = true;
            picu.Visible = false;
            pacc.Visible = false;
        }

        private void picd_Click(object sender, EventArgs e)
        {b1.Visible = true;
            stu.Visible = true;
            b3.Visible = true;
            b4.Visible = true;
            b5.Visible = true;
            b6.Visible = true;
            picd.Visible = false;
            picu.Visible = true;
            pacc.Visible = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            clear();
            button5.Text = "Add Profile";
            button8.Text = "SAVE";
            CTRL_Control(true);
            p3.Visible = true;
            p3.Dock = DockStyle.Fill;
            p3.BringToFront();
            panel6.Visible = true;
            stu.Enabled = false;
            b3.Enabled = false;
            b1.Enabled = false;
            b5.Enabled = false;
            b6.Enabled = false;
            pacc.Enabled = false;

        }

        private void stu_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
            panel6.Visible = true;
            p1.Dock = DockStyle.Fill;
            p1.BringToFront();     
            Pbar.Visible = false;
            lb1.Visible = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panel3.BringToFront();

        }

        private void label12_Leave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
                    
            
                if (MessageBox.Show("Are you sure you want to Cancel the Data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {enable();
                b4.Text = "Add Profile";
                stu.PerformClick(); }

            else return;

        }

        private Boolean SaveNot()
        {
            Boolean err = false;

            if (tf.Text == "" )
            {
                tf.Focus();
                err = true;
            }
            if (tl.Text == "")
            {
                tl.Focus();
                err = true;
            }

            if (tgr.Text == "" )
            {
                tgr.Focus();
                err = true;
            }

            if (tge.Text == "")
            {
                tge.Focus();
                err = true;
            }

            if (tst.Text == "" )
            {
                tst.Focus();
                err = true;
            }

            if (td.Text == "" )
            {
                td.Focus();
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

        private void addtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            b4.PerformClick();
        }

        private void tsearch_Click(object sender, EventArgs e)
        {
            tsearch.Clear();
        }

        private void tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tl.Focus();
            }
        }

        private void tl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void button10_Click(object sender, EventArgs e)
        {
            LoadAcc_Data();
            pac.Visible = true;
            pac.Dock = DockStyle.Fill;
            pac.BringToFront();
            accview.ContextMenuStrip = cmsacc;
        }

        private void clear()
        {
            tf.Clear();
            tl.Clear();
            tgr.Text=null;
            tge.Text = null; ;
            tst.Text = null;
            td.Clear();
        }

        private void LoadAcc_Data()
        {
            //string sql = "SELECT * FROM login WHERE Administrator like '%" + "user" + "%'"; user only
            string sql = "SELECT * FROM login ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            accview.Items.Clear();
            while (rd.Read())
            {
                accview.Items.Add(rd["id"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["Administrator"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["fname"].ToString());        
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["status"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["lname"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["intime"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["outtime"].ToString());
             
            }
            rd.Close();
            nacc.Text = "  Total records : " + accview.Items.Count;
            int x;
            for (x = 0; x <=accview.Items.Count - 2; x += 2) ;
        }

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Showacc_Data(SID);
            a.Visible = true;
            a.Dock = DockStyle.Fill;
            a.BringToFront();
            if (accview.FocusedItem.Text != null)
            {
                button8.Text = "UPDATE";
                button5.Text = "Edit Profile";
                CTRL_Control(true);
                Showacc_Data(accview.FocusedItem.Text);
             
            }
        }

        private void accview_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = accview.FocusedItem.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sql = " UPDATE login SET pass = '" + c.Text + "', user = '" + b.Text + "', status = '" + i.Text + "', contact = '" + d.Text + "', gender = '" + h.Text + "'WHERE id=" +SID;

            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            pacc.PerformClick();


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Activate this Account?", "Activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               string sql = " UPDATE login SET status = '" + "Active"+ "'WHERE id=" + SID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery(); LoadAcc_Data();
                MessageBox.Show("Account has been Deactivated Successfuly! ", " Account Deactivation", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                return;

            }
            else return;
            
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Deactivate this Account?", "Account Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               string sql = " UPDATE login SET status = '" + "Deactive" + "'WHERE id=" + SID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery(); LoadAcc_Data();
                MessageBox.Show("Account has been Activated Successfuly! ", " Account Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else return;
            
        }

        private void announcementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Text = "Announcement!";
            panel4.Visible = true;
            panel4.Dock = DockStyle.Fill;
            panel4.BringToFront();
           
        }

        private void privateMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button13.Text = "Private Massage!";
            panel7.Visible = true;
            panel7.Dock = DockStyle.Fill;
            panel7.BringToFront();
            string sql = "SELECT * FROM login where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                la.Text = "" + (rd["lname"].ToString()) + "," + (rd["fname"].ToString());    
            }

            rd.Close();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (pm.Text == "")
            {
                pacc.PerformClick();
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Send this Message?", "Private Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = " UPDATE login SET message =  '" + pm.Text + "'WHERE id=" + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    pacc.PerformClick();
                    LoadAcc_Data();
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (ano.Text == "")
            {
                pacc.PerformClick();
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Send this Message?", "Announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = " UPDATE login SET message =  '" + ano.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    pacc.PerformClick();
                    LoadAcc_Data();
                }
            }
        }

        private void Showacc_Data(String id)
        {  string sql = "SELECT * FROM login where id = " + id;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                bb.Text = "" + (rd["lname"].ToString())+"," + (rd["fname"].ToString());
                f.Text = "" + (rd["Administrator"].ToString());
                g.Text = "" + (rd["gender"].ToString());
                b.Text = "" + (rd["user"].ToString());
                c.Text = "" + (rd["pass"].ToString());
                e.Text = "" + (rd["add"].ToString());
                l.Text = "" + (rd["seq"].ToString());
                m.Text = "" + (rd["ans"].ToString());
                d.Text = "" + (rd["contact"].ToString());
                j.Text = "" + (rd["intime"].ToString());
                k.Text = "" + (rd["outtime"].ToString());
                i.Text = "" + (rd["status"].ToString());
                h.Text = "" + (rd["age"].ToString());
            }

            rd.Close();

        }

    }
}
