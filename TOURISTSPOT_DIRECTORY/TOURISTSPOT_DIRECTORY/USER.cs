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
    public partial class USER : Form
    {
        public string SID;
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        MySqlCommand sql_cmd = new MySqlCommand();

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            b4.Text = "Save";
            p1.Visible = false;
            p5.BringToFront();
            p5.Dock = DockStyle.Fill;
            b4.Visible = true;
            p3.Visible = false;
            p2.Visible = false;
            b4.Visible = true;
        }

        private void b1_Click(object sender, EventArgs e)
        {

            label4.Visible = true;
            tsearch.Visible = true;
            label5.Visible = true;
            csearch.Visible = true;
            labe.Visible = false;
            lb1.Visible = true;
            p1.Visible = true;
            p2.Visible = true;
            p2.BringToFront();
            p2.Dock = DockStyle.Left;
            p3.Visible = true;
            p3.BringToFront();
            p3.Dock = DockStyle.Fill;
            b4.Visible = true;
            v1.ContextMenuStrip = cmsadit;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            b4.Visible = true;
            b4.Text = "Update";
            p4.Visible = true;
            p4.Dock = DockStyle.Fill;
            p4.BringToFront();
            Show_Data();
            Load_Data();
            loadpersonel();
            viewpersonel();
        }

        private void USER_Load(object sender, EventArgs e)
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            b1.PerformClick();
            Load_Data();
            oval();
            Profilepicture();

        }
        public void Profilepicture()
        {
            DataSet dS = new DataSet();
            sql = "SELECT profilepic FROM login WHERE user = '" + (clsMySQL.sUN) + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);

            DataAdapter.Fill(dS, "pics");

            Byte[] byteBLOBData = new Byte[0];
            pict.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["profilepic"]));
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
        private void oval()
        {

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pict.Width - 8, pict.Height - 2);
            Region rg = new Region(gp);
            pict.Region = rg;

        }
        public USER()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
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
            lb1.Text = "  Total records : " + v1.Items.Count;
            int x;
            for (x = 0; x <= v1.Items.Count - 2; x += 2) ;
        }
        private void Add_Data()
        {
            if (picProfile.Image == null)
            {
                string sql = "INSERT INTO directory VALUES (null,'" + t1.Text + "','" + c1.Text + "','" + c2.Text + "','" + c3.Text + "','" + t4.Text + "','" + t2.Text + "','" + c5.Text + "','" + rich1.Text + "','" + "no" + "',now(), now() ,now() )";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                Load_Data();
                MessageBox.Show("New Tourist Attraction Succesfully Add!", "New Attraction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (picProfile.Image != null)
            {
                arrImage = ImgConvert(picProfile.Image);
                string sql = "INSERT INTO directory VALUES (null,'" + t1.Text + "','" + c1.Text + "','" + c2.Text + "','" + c3.Text + "','" + t4.Text + "','" + t2.Text + "','" + c5.Text + "','" + rich1.Text + "','" + "yes" + "', @File, now() ,now())";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();
                Load_Data();
                MessageBox.Show("New Tourist Attraction Succesfully Add!", "New Attraction", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void View()
        {
            string sql = "SELECT * FROM directory where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                label4.Text = (rd["name"].ToString());
                l1.Text = "Name of Attraction : " + (rd["name"].ToString());
                l2.Text = "Classification : " + (rd["cla"].ToString());
                l3.Text = " Categories : " + (rd["cate"].ToString());
                l4.Text = "Type :  " + (rd["type"].ToString());
                l5.Text = "Barangay : " + (rd["ba"].ToString());
                l6.Text = "Contact : " + (rd["con"].ToString());
                rich2.Text = (rd["de"].ToString());
                loce.Text = " Full Address : " + (rd["lo"].ToString());
                vhistory.Text = (rd["history"].ToString());
                clsMySQL.ttt = (rd["sign"].ToString());
                clsMySQL.ttp = (rd["name"].ToString());

                picv.Image = null;

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
                picv.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
            }


        }
        private void updatepersonel()

        {
            if (picper.Image == null)
            {
                string sql = "UPDATE personel SET atrac='" + la7.Text + "', fname = '" + pf.Text + "' ,lname = '" + pl.Text + "' ,mname = '" + pm.Text + "',address = '" + pa.Text + "', con = '" + pe.Text + "',mail = '" + pmail.Text + "',age = '" + page.Text + "',pro = '" + pp.Text + "',gen = '" + pgen.Text + "',stat = '" + pst.Text + "',de = '" + "no" + "', about = '" + rabout.Text + "',image=now()   WHERE atrac = '" + label4.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                Load_Data();
            }

            if (picper.Image != null)
            {
                arrImage = ImgConvert(picper.Image);
                sql = "UPDATE personel SET atrac='" + la7.Text + "', fname = '" + pf.Text + "' ,lname = '" + pl.Text + "' ,mname = '" + pm.Text + "',address = '" + pa.Text + "', con = '" + pe.Text + "',mail = '" + pmail.Text + "',age = '" + page.Text + "',pro = '" + pp.Text + "',gen = '" + pgen.Text + "',stat = '" + pst.Text + "',de = '" + "yes" + "', about = '" + rabout.Text + "',image=@FILE WHERE atrac = '" + label4.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();
                Load_Data();
            }
        }

        private void addpersonel()
        {

            string sql = "INSERT INTO personel VALUES (null,'" + t1.Text + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "None" + "','" + "no" + "','" + "None" + "','" + "None" + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            Load_Data();


        }
        private void viewpersonel()
        {

            string sql = "SELECT * FROM personel where atrac = '" + label4.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                lf.Text = "Firstname : " + (rd["lname"].ToString());
                ll.Text = "Lastname : " + (rd["fname"].ToString());
                lm.Text = "Middlename : " + (rd["mname"].ToString());
                la.Text = "Address :  " + (rd["address"].ToString());
                lc.Text = "Contact : " + (rd["con"].ToString());
                le.Text = "Email Address : " + (rd["mail"].ToString());
                lag.Text = "Age : " + (rd["age"].ToString());
                lp.Text = "Profession : " + (rd["pro"].ToString());
                lg.Text = "Gender : " + (rd["gen"].ToString());
                ls.Text = "Status : " + (rd["stat"].ToString());
                picperv.Image = null;
                clsMySQL.ttpp = (rd["de"].ToString());
            }
            rd.Close();

            if ((clsMySQL.ttpp) == "yes")
            {
                DataSet dS = new DataSet();
                sql = "SELECT * FROM personel where atrac = '" + label4.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);
                DataAdapter.Fill(dS, "pics");
                Byte[] byteBLOBData = new Byte[0];

                picperv.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["image"]));
            }




        }
        private void About()
        {
            string sql = "SELECT * FROM about where id = " + 1;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                labe6.Text = " " + (rd["name"].ToString());
                labe1.Text = " " + (rd["con"].ToString());

                labe2.Text = " " + (rd["fb"].ToString());

                labe3.Text = " " + (rd["email"].ToString());

                labe4.Text = " " + (rd["ins"].ToString());

                labe5.Text = " " + (rd["text"].ToString());


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
        private void loadpersonel()
        {
            string sql = "SELECT * FROM personel where atrac = '" + label4.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                pl.Text = (rd["lname"].ToString());
                pf.Text = (rd["fname"].ToString());
                pm.Text = (rd["mname"].ToString());
                pa.Text = (rd["address"].ToString());
                pe.Text = (rd["con"].ToString());
                pmail.Text = (rd["mail"].ToString());
                page.Text = (rd["age"].ToString());
                pp.Text = (rd["pro"].ToString());
                pgen.Text = (rd["gen"].ToString());
                pst.Text = (rd["stat"].ToString());
                picper.Image = null;
                clsMySQL.ttttt = (rd["de"].ToString());
                rabout.Text = (rd["about"].ToString());
            }

            rd.Close();

            if ((clsMySQL.ttttt) == "yes")
            {
                DataSet dS = new DataSet();
                sql = "SELECT * FROM personel WHERE atrac = '" + label4.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);
                DataAdapter.Fill(dS, "pics");
                Byte[] byteBLOBData = new Byte[0];
                picper.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["image"]));
            }
        }

        private void v1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = v1.FocusedItem.Text;
        }

        private void picProfile_Click(object sender, EventArgs e)
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

        private void b4_Click(object sender, EventArgs e)
        {
            if (b4.Text == "Save")
            {
                if (MessageBox.Show("Are you sure you want to Add new Attraction?", "Add Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    b1.PerformClick();
                    Add_Data();
                    addpersonel();
                    sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "ADD NEW TOURISPOT" + "', '" + label4.Text + "',now() )";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();

                }

            }
            if (b4.Text == "Update")
            {
                if (MessageBox.Show("Are you sure you want to Update this Attraction?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    b1.PerformClick();
                    UPDATE_Data();
                    updatepersonel();
                    sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "UPDATE TOURISPOT" + "', '" + label4.Text + "',now() )";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();

                }

            }
            if (b4.Text == "Logout")

                if (MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Form b = new LOGIN();
                    b.Show();
                    this.Visible = false;
                    sql = " UPDATE login SET outtime = now()  WHERE user='" + (clsMySQL.sUN) + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    return;
                }
        }

        private void Show_Data()
        {
            string sql = "SELECT * FROM directory where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                label4.Text = (rd["name"].ToString());
                la7.Text = (rd["name"].ToString());
                la9.Text = (rd["type"].ToString());
                la10.Text = (rd["cate"].ToString());
                la11.Text = (rd["cla"].ToString());
                la12.Text = (rd["ba"].ToString());
                la13.Text = (rd["con"].ToString());
                rich4.Text = (rd["de"].ToString());
                clsMySQL.ttt = (rd["sign"].ToString());
                rhistory.Text = (rd["history"].ToString());
                pedit.Image = null;
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
                pedit.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["pic"]));
            }
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

        private void v1_Click(object sender, EventArgs e)
        {
            sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "VIEW DETAILS" + "', '" + label4.Text + "',now() )";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            b4.Text = "Logout";
            View();
            Show_Data();
            viewpersonel();
        }
        private void personeldelete()
        {
            string sql = "Delete from personel where  atrac = '" + label4.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b1.PerformClick();
        }

        private void pedit_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();

            odlg.FileName = null;
            odlg.DefaultExt = ".jpg";
            odlg.Filter = "Image (.jpg)|*.jpg";
            odlg.ShowDialog();
            if (odlg.FileName != null)
            {
                this.pedit.ImageLocation = odlg.FileName;
                sLoadImg = odlg.FileName;
                Loadpic = true;
            }
        }

        private void UPDATE_Data()
        {
            if (pedit.Image == null)
            {
                string sql = "UPDATE directory SET name='" + la7.Text + "', type = '" + la9.Text + "' ,cate = '" + la10.Text + "' ,cla = '" + la11.Text + "',ba = '" + la12.Text + "', lo = '" + la14.Text + "',con = '" + la13.Text + "',sign = '" + "no" + "', de = '" + rich4.Text + "', history = '" + rhistory.Text + "',date=now() ,pic = now()WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                Load_Data();
                MessageBox.Show("Tourist Attraction Succesfully Update!", "UPDATE DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (pedit.Image != null)
            {
                arrImage = ImgConvert(pedit.Image);
                string sql = "UPDATE directory SET name='" + la7.Text + "', type = '" + la9.Text + "' ,cate = '" + la10.Text + "' ,cla = '" + la11.Text + "',ba = '" + la12.Text + "', lo = '" + la14.Text + "',con = '" + la13.Text + "',sign = '" + "yes" + "', de = '" + rich4.Text + "', history = '" + rhistory.Text + "',date=now() ,pic = @File WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                var withBlock = sql_cmd;
                withBlock.CommandText = sql;
                withBlock.Connection = clsMySQL.sql_con;
                withBlock.Parameters.AddWithValue("@File", arrImage);
                withBlock.ExecuteNonQuery();
                Load_Data();
                MessageBox.Show("Tourist Attraction Succesfully Update!", "UPDATE DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

        private void name_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            lb1.Visible = false;
            tsearch.Visible = false;
            label5.Visible = false;
            csearch.Visible = false;
            labe.Visible = true;
            labe.Text = "My Account";
            p2.Visible = false;
            button12.Text = "Update";

            string sql = "SELECT * FROM login where user =  '" + (clsMySQL.sUN) + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                tas.Text = "" + (rd["lname"].ToString());
                ter.Text = "" + (rd["fname"].ToString());
                label2.Text = "" + (rd["lname"].ToString()) + "," + (rd["fname"].ToString());
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
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if (button12.Text == "Update")
            {
                psss();

                sql = "INSERT INTO history  VALUES (null, '" + name.Text + "', '" + "UPDATE ACCOUNT" + "', '" + name.Text + "',now() )";
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

            MessageBox.Show("Account Successfully Update!", "Update account", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void picper_Click(object sender, EventArgs e)
        {
          
        }

        public static byte[] ImgConvert(Image x)
        {
            MemoryStream ms = new MemoryStream();
            x.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            About();
            p2.Visible = false;
            label4.Visible = false;
            lb1.Visible = false;
            tsearch.Visible = false;
            label5.Visible = false;
            csearch.Visible = false;
            pabout.Visible = true;
            pabout.BringToFront();
            pabout.Dock = DockStyle.Fill;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button12.Visible = true;
        }

        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
