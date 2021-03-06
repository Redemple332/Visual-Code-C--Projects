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
namespace prosys_Marcelo
{
    public partial class ADMIN : Form
    {
        public string SID;
        public string sName;
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        MySqlCommand sql_cmd = new MySqlCommand();
        public ADMIN()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
        }

        private void view_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = view.FocusedItem.Text;
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            Pbar.Visible = false;
            Load_Data();
            p0.Visible = true;
            p0.Dock = DockStyle.Fill;
            p0.BringToFront();
            ptop.Visible = false;
            date.Text = DateTime.Now.ToLongDateString();
            oval();
            Profilepicture();
        }
        private void oval()
        {

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, picv.Width - 8, picv.Height - 2);
            Region rg = new Region(gp);
            picv.Region = rg;

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

            if (picProfile.Image == null)
            {
                string sql = "INSERT INTO prosted VALUES (null,'" + tf.Text + "','" + tl.Text + "','" + tgr.Text + "','" + tst.Text + "','" + tge.Text + "','" + td.Text + "','" + "no" + "', now() ,now())";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
            }
            if (picProfile.Image != null)
            {
                arrImage = ImgConvert(picProfile.Image);
                string sql = "INSERT INTO prosted VALUES (null,'" + tf.Text + "','" + tl.Text + "','" + tgr.Text + "','" + tst.Text + "','" + tge.Text + "','" + td.Text + "','" + "yes" + "', now() , @File)";
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
        private void Update_Data()
        {
            if (picProfile.Image == null)
            {
                string sql = "UPDATE prosted SET fname='" + tf.Text + "', lname = '" + tl.Text + "' ,grade = '" + tgr.Text + "' ,strand = '" + tst.Text + "' ,gender = '" + tge.Text + "', contact = '" + td.Text + "', ps = '" + "no" + "',date=now() ,pic = now() WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                Load_Data();
            }


            if (picProfile.Image != null)
            {
                arrImage = ImgConvert(picProfile.Image);
                string sql = "UPDATE prosted SET fname='" + tf.Text + "', lname = '" + tl.Text + "' ,grade = '" + tgr.Text + "' ,strand = '" + tst.Text + "' ,gender = '" + tge.Text + "', contact = '" + td.Text + "', ps = '" + "yes" + "',date=now() ,pic = @FILE WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();

            }



        }
        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
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
                clsMySQL.ttt = (rd["ps"].ToString());
                picProfile.Image = null;

            }

            rd.Close();

            if ((clsMySQL.ttt) == "yes")
            {
                DataSet dS = new DataSet();
                sql = "SELECT * FROM prosted WHERE id = " + id;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

                DataAdapter.Fill(dS, "pics");

                Byte[] byteBLOBData = new Byte[0];
                picProfile.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
            }


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
                clsMySQL.ttt = (rd["ps"].ToString());
                vpic.Image = null;

            }

            rd.Close();


            if ((clsMySQL.ttt) == "yes")
            {
                DataSet dS = new DataSet();
                sql = "SELECT * FROM prosted WHERE id = " + id;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

                DataAdapter.Fill(dS, "pics");

                Byte[] byteBLOBData = new Byte[0];
                vpic.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
            }

        }
        public void Profilepicture()
        {
            DataSet dS = new DataSet();
            sql = "SELECT profilepic FROM login WHERE user = '" + (clsMySQL.sUN) + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            picv.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["profilepic"]));
            {
                string sql = "SELECT * FROM login where user =  '" + (clsMySQL.sUN) + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();

                while (rd.Read())
                {
                    name.Text = (rd["fname"].ToString() + " " + (rd["lname"].ToString()));


                }
                rd.Close();
            }

        }

        private void ee_Click(object sender, EventArgs e)
        {

            ee.Visible = false;

            stu.PerformClick();
            pacc.Visible = true;
            ptop.Visible = true;
            lb1.Visible = true;
            tsearch.Visible = true;
        }

        private void stu_Click(object sender, EventArgs e)
        {
            ptop.Visible = true;
            p1.Visible = true;
            panel6.Visible = true;
            p1.Dock = DockStyle.Fill;
            p1.BringToFront();
            Pbar.Visible = false;
            lb1.Visible = true;
            tsearch.Visible = true;
            ltag.Text = "Student List";
            lb1.Visible = true;
            tsearch.Visible = true;
            view.ContextMenuStrip = cms;
        }

        private void pacc_Click(object sender, EventArgs e)
        {
            ltag.Text = "Account List";
            LoadAcc_Data();
            pac.Visible = true;
            pac.Dock = DockStyle.Fill;
            pac.BringToFront();
            accview.ContextMenuStrip = cmsacc;
            ptop.Visible = true;
            lb1.Visible = false;
            tsearch.Visible = false;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            enableF();
            ff.Text = "SAVE";
            ltag.Text = "Add Profile";
            p3.Dock = DockStyle.Fill;
            p3.BringToFront();
            p3.Visible = true;
            clear();
            ptop.Visible = true;
            lb1.Visible = false;
            tsearch.Visible = false;
        }
        private void clear()
        {
            tf.Clear();
            tl.Clear();
            tgr.Text = null;
            tge.Text = null; ;
            tst.Text = null;
            td.Clear();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            ltag.Text = "View Profile";
            ptop.Visible = true;
            p2.Visible = true;
            p2.Dock = DockStyle.Fill;
            p2.BringToFront();
            if (SID == null) return;
            lb1.Visible = false;
            tsearch.Visible = false;
        }

        private void b5_Click(object sender, EventArgs e)
        {

            ltag.Text = "About";
            pabout.Visible = true;
            pabout.Dock = DockStyle.Fill;
            pabout.BringToFront();
            ptop.Visible = true;
            lb1.Visible = false;
            tsearch.Visible = false;
            About();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            p0.Visible = true;
            p0.Dock = DockStyle.Fill;
            p0.BringToFront();
            ptop.Visible = false;
            lb1.Visible = false;
            tsearch.Visible = false;
        }
        private void About()
        {
            string sql = "SELECT * FROM about where id = " + 1;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                l6.Text = " " + (rd["name"].ToString());
                l2.Text = " " + (rd["con"].ToString());

                l3.Text = " " + (rd["fb"].ToString());

                l4.Text = " " + (rd["email"].ToString());

                l5.Text = " " + (rd["ins"].ToString());

                l1.Text = " " + (rd["text"].ToString());


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
        private void ff_Click(object sender, EventArgs e)
        {
            if (ff.Text == "UPDATE")
            {

                if (MessageBox.Show("Are you sure you want to Update the Data?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    enableT();
                    p1.Visible = true;
                    p1.Dock = DockStyle.Fill;
                    p1.BringToFront();
                    Pbar.Visible = true;
                    Pbar.Value = 0;
                    tPbar.Start();


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
                    enableT();
                    p1.Visible = true;
                    p1.Dock = DockStyle.Fill;
                    p1.BringToFront();
                    panel6.Visible = true;
                    Pbar.Visible = true;
                    Pbar.Value = 0;
                    tPbar.Start();

                }


            }
        }

        private void LoadAcc_Data()
        {
            string sql = "SELECT * FROM login WHERE Administrator like '%" + "user" + "%'";
            //  string sql = "SELECT * FROM login ";user only
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            accview.Items.Clear();
            while (rd.Read())
            {
                accview.Items.Add(rd["id"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["lname"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["user"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["pass"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["intime"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["outtime"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["status"].ToString());
            }
            rd.Close();

            int x;
            for (x = 0; x <= accview.Items.Count - 2; x += 2) ;
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
                if (ff.Text.Equals("UPDATE"))
                {
                    Update_Data();
                    Load_Data();
                    string sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "UPDATE RECORD" + "',now() )";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();



                }
                else if (ff.Text.Equals("SAVE"))
                {
                    Add_Data();

                    string sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "ADD RECORD" + "',now() )";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    Load_Data();
                }

            }
        }

        private void deletetoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete it?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (view.FocusedItem.Text != null)
                {
                    dEL_Data(view.FocusedItem.Text);

                    Load_Data();
                    MessageBox.Show("Record has been deleted Succesfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "DELETE RECORD" + "',now() )";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();

                }
            }
        }
        private void dEL_Data(String id)
        {

            string sql = "Delete from prosted where id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();


        }

        private void addtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            b4.PerformClick();
        }

        private void cc_Click(object sender, EventArgs e)
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
        private void enableF()
        {
            b1.Enabled = false;
            stu.Enabled = false;
            b3.Enabled = false;
            pacc.Enabled = false;
       
            b5.Enabled = false;
            bu.Enabled = false;
            b6.Enabled = false;


        }
        private void enableT()
        {
            b1.Enabled = true;
            stu.Enabled = true;
            b3.Enabled = true;
            pacc.Enabled = true;
          
            b5.Enabled = true;
            bu.Enabled = true;
            b6.Enabled = true;


        }

        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (view.FocusedItem.Text != null)
            {
                b3.PerformClick();
                View(view.FocusedItem.Text);


            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Activate this Account?", "Activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = " UPDATE login SET status = '" + "Active" + "'WHERE id=" + SID;
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

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button12.Text = "Save";
            Showacc_Data(SID);
            a.Visible = true;
            a.Dock = DockStyle.Fill;
            button12.Visible = false;
            a.BringToFront();
            if (accview.FocusedItem.Text != null)
            {
                ff.Text = "UPDATE";
                ltag.Text = "Edit Account";
                Showacc_Data(accview.FocusedItem.Text);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "Save")
            {
                asss();

                sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "UPDATE ACCOUNT" + "',now() )";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
            }
            if (button12.Text == "Update")
            {
                psss();

                sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "UPDATE ACCOUNT" + "',now() )";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
            }

        }
        private void psss()
        {
            arrImage = ImgConvert(picacc.Image);
            string sql = " UPDATE login SET pass = '" + c.Text + "', user = '" + b.Text + "', contact = '" + d.Text + "', gender = '" + g.Text + "', lname= '" + tas.Text + "', fname = '" + ter.Text + "', age = '" + h.Text + "', ans = '" + m.Text + "',profilepic=@FILE WHERE user='" + (clsMySQL.sUN) + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            var withBlock = sql_cmd;
            withBlock.CommandText = sql;
            withBlock.Connection = clsMySQL.sql_con;
            withBlock.Parameters.AddWithValue("@File", arrImage);
            withBlock.ExecuteNonQuery();
            pacc.PerformClick();
            MessageBox.Show("Account Successfully Update!", "Update account", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void asss()
        {
            arrImage = ImgConvert(picacc.Image);
            string sql = " UPDATE login SET pass = '" + c.Text + "', user = '" + b.Text + "', contact = '" + d.Text + "', gender = '" + g.Text + "', lname= '" + tas.Text + "', fname = '" + ter.Text + "', age = '" + h.Text + "', ans = '" + m.Text + "',profilepic=@FILE WHERE id =" + SID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            var withBlock = sql_cmd;
            withBlock.CommandText = sql;
            withBlock.Connection = clsMySQL.sql_con;
            withBlock.Parameters.AddWithValue("@File", arrImage);
            withBlock.ExecuteNonQuery();
            pacc.PerformClick();
            MessageBox.Show("Account Successfully Update!", "Update account", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dd_Click(object sender, EventArgs e)
        {
            enableT();
            stu.PerformClick();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text != "" || tsearch.Text != "Search here")
                Search(tsearch.Text);
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
        private Boolean SaveNot()
        {
            Boolean err = false;

            if (tf.Text == "")
            {
                tf.Focus();
                err = true;
            }
            if (tl.Text == "")
            {
                tl.Focus();
                err = true;
            }

            if (tgr.Text == "")
            {
                tgr.Focus();
                err = true;
            }

            if (tge.Text == "")
            {
                tge.Focus();
                err = true;
            }

            if (tst.Text == "")
            {
                tst.Focus();
                err = true;
            }

            if (td.Text == "")
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

        private void tsearch_Click(object sender, EventArgs e)
        {
            tsearch.Clear();
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log-Out the Data?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form b = new LOGIN();
                b.Show();
                this.Visible = false;
                sql = " UPDATE login SET outtime = now()  WHERE user='" + (clsMySQL.sUN) + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                return;
            }
            else return;
        }

        private void edittoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            enableF();
            Show_Data(SID);

            if (view.FocusedItem.Text != null)
            {
                ff.Text = "UPDATE";
                ltag.Text = "Edit Profile";

                Show_Data(view.FocusedItem.Text);
                p3.Visible = true;
                p3.Dock = DockStyle.Fill;
                p3.BringToFront();
                Pbar.Visible = false;
            }
        
    }

        private void picacc_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();

            odlg.FileName = null;
            odlg.DefaultExt = ".jpg";
            odlg.Filter = "Image (.jpg)|*.jpg";
            odlg.ShowDialog();
            if (odlg.FileName != null)
            {
                this.picacc.ImageLocation = odlg.FileName;




                sLoadImg = odlg.FileName;
                Loadpic = true;
            }
        }

        private void accview_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = accview.FocusedItem.Text;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sAbout();
            ab.Visible = true;
            ab.Dock = DockStyle.Fill;
            ab.BringToFront();
        }
        private void sAbout()
        {
            string sql = "SELECT * FROM about where id = " + 1;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                t1.Text = " " + (rd["name"].ToString());
                t2.Text = " " + (rd["con"].ToString());

                t3.Text = " " + (rd["fb"].ToString());

                t5.Text = " " + (rd["email"].ToString());

                t4.Text = " " + (rd["ins"].ToString());

                t6.Text = " " + (rd["text"].ToString());


            }

            rd.Close();
            DataSet dS = new DataSet();
            sql = "SELECT * FROM about where id = " + 1;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            t7.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["img"]));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            {
                arrImage = ImgConvert(t7.Image);


                string sql = " UPDATE about SET name='" + t1.Text + "',con='" + t2.Text + "',fb='" + t3.Text + "',ins='" + t4.Text + "',email='" + t5.Text + "',text='" + t6.Text + "',img=@File WHERE id =" + 1;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();

            }

            MessageBox.Show("About Information Sucessfully Change", "About Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            b5.PerformClick();
        }

        private void t7_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();

            odlg.FileName = null;
            odlg.DefaultExt = ".jpg";
            odlg.Filter = "Image (.jpg)|*.jpg";
            odlg.ShowDialog();
            if (odlg.FileName != null)
            {
                this.t7.ImageLocation = odlg.FileName;
                sLoadImg = odlg.FileName;
                Loadpic = true;
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form b = new CREATE();
            b.Show();
            this.Visible = false;
        }

        private void Showacc_Data(String id)
    {
        string sql = "SELECT * FROM login where id = " + id;
        sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
        MySqlDataReader rd = sql_cmd.ExecuteReader();

        while (rd.Read())
            {
                label2.Text = "" + (rd["lname"].ToString()) + "," + (rd["fname"].ToString());
                ltag.Text = "" + (rd["lname"].ToString()) + "," + (rd["fname"].ToString());
            ter.Text = "" + (rd["fname"].ToString());
                tas.Text = "" + (rd["lname"].ToString());
                f.Text = "" + (rd["status"].ToString());
            g.Text = "" + (rd["gender"].ToString());
            b.Text = "" + (rd["user"].ToString());
            c.Text = "" + (rd["pass"].ToString());
            o.Text = "" + (rd["add"].ToString());
            l.Text = "" + (rd["seq"].ToString());
            m.Text = "" + (rd["ans"].ToString());
            d.Text = "" + (rd["contact"].ToString());
            j.Text = "" + (rd["intime"].ToString());
            k.Text = "" + (rd["outtime"].ToString());
            h.Text = "" + (rd["age"].ToString());
        }

        rd.Close();

        DataSet dS = new DataSet();
        sql = "SELECT * FROM login where id = " + id;
        sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

        DataAdapter.Fill(dS, "pics");

        Byte[] byteBLOBData = new Byte[0];
        picacc.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["profilepic"]));
    }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sAbout();
            ab.Visible = true;
            ab.Dock = DockStyle.Fill;
            ab.BringToFront();
        }

        private void bu_Click(object sender, EventArgs e)
        {
            tsearch.Visible = true;
            ltag.Text = "History";
            lb1.Visible = true;
            History_Data();
            phis.BringToFront();
            phis.Visible = true;
            phis.Dock = DockStyle.Fill;
        }

        private void name_Click(object sender, EventArgs e)
        {
            button12.Text = "Update";
            ptop.Visible = true;
            string sql = "SELECT * FROM login where user =  '" + (clsMySQL.sUN) + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                tas.Text = "" + (rd["lname"].ToString());
                ter.Text = "" + (rd["fname"].ToString());
                label2.Text = "" + (rd["lname"].ToString()) + "," + (rd["fname"].ToString());
                ltag.Text = "" + (rd["lname"].ToString()) + "," + (rd["fname"].ToString());
                f.Text = "" + (rd["status"].ToString());
                g.Text = "" + (rd["gender"].ToString());
                b.Text = "" + (rd["user"].ToString());
                c.Text = "" + (rd["pass"].ToString());
                o.Text = "" + (rd["add"].ToString());
                l.Text = "" + (rd["seq"].ToString());
                m.Text = "" + (rd["ans"].ToString());
                d.Text = "" + (rd["contact"].ToString());
                j.Text = "" + (rd["intime"].ToString());
                k.Text = "" + (rd["outtime"].ToString());
                h.Text = "" + (rd["age"].ToString());
            }

            rd.Close();

            DataSet dS = new DataSet();
            sql = "SELECT * FROM login where user =  '" + (clsMySQL.sUN) + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            picacc.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["profilepic"]));

            a.Visible = true;
            a.Dock = DockStyle.Fill;
            button12.Visible = false;
            a.BringToFront();
            ff.Text = "UPDATE";



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button12.Visible = true;
        }

        private void History_Data()
        {
            string sql = "SELECT * FROM history ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            view1.Items.Clear();
            while (rd.Read())
            {
                view1.Items.Add(rd["id"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["event"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["date"].ToString());

            }
            rd.Close();
            lb1.Text = "  Total records : " + view1.Items.Count;
            int x;
            for (x = 0; x <= view1.Items.Count - 2; x += 2) ;


        }
    }
}
