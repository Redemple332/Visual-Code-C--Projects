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
using Microsoft.Reporting.WinForms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace Binuatan_Creations
{
    public partial class User : Form
    {
        public string lastdateencode;
        public int counts = 1;
        public int c = 0;
        public string acc;
        public int counterprint = 0;
        public string SID = null;
        public string NACC = null;
        public double A = 0.06;
        public int B = 1;
        public int C = 2;
        public int D = 3;
        public int E = 4;
        public int F = 5;
        public string serch = null;
        public double gs = 0;
        public double gt = 0;
        public double gv = 0;
        bool isMenu1panelOpen = false;
        public string sam;
        Point lastpoint;
        public string occ;

        MySqlCommand sql_cmd = new MySqlCommand();
        public User()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            tsearch.Visible = false;
            s1.Visible = false;
            Load_lastencode();
            textBox1.Focus();
            lmale.Visible = false;
            lchild.Visible = false;
            lfemale.Visible = false;
            searname();
            sears();
            labeltitle.Text = "";
            panel2.Visible = false;
            ltag.Text = "Attendance";
            ttt.Visible = false;
            tt.Visible = false;
            b1.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.Gray;

            patent.Visible = true;
            patent.Dock = DockStyle.Fill;
            patent.BringToFront();
            tt.Visible = false;
        }
        private void searname()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM summary ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["fulln"].ToString());

            }
            textBox1.AutoCompleteCustomSource = serch;
            textBox2.AutoCompleteCustomSource = serch;
            textBox3.AutoCompleteCustomSource = serch;
            textBox4.AutoCompleteCustomSource = serch;
            textBox5.AutoCompleteCustomSource = serch;
            rd.Close();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            lmale.Visible = false;
            lchild.Visible = false;
            lfemale.Visible = false;
            printnames();
            labeltitle.Text = "View by Name";
            panel2.Visible = false;
            ttt.Text = "Total Amount : ₱";
            ltag.Text = "Summary";
            psum.ContextMenuStrip = list2;
            ttt.Visible = true;
            tt.Visible = true;
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b1.BackColor = Color.Gray;

            psum.Visible = true;
            psum.BringToFront();
            psum.Dock = DockStyle.Fill;
            tt.Visible = true;
            tt.Text = "0.00";
            ltag.Visible = true;
            s1.Visible = true;
            tsearch.Visible = true;

        }

        private void tsearch_Click(object sender, EventArgs e)
        {
            tsearch.ForeColor = Color.Black;
            tsearch.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Save" && textBox1.Text != "")
            {
                if (MessageBox.Show("Are you sure you want Enter this Amount?", "Attendance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    tPbar.Start();
                    last();

                    Pbar.Visible = true;
                }
            }

            if (tot.Text == "")
            {
                MessageBox.Show("Please enter Amount!");
                return;
            }


        }

        private void tot_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tot.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                tot.Text = tot.Text.Remove(tot.Text.Length - 1);
            }

            if (tot.Text != "")
            {
                label2.Text = (Convert.ToInt64(tot.Text) * (A)).ToString();

                if (label2.Text != "Total sale" && textBox1.Text != "")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (B)).ToString();
                }
                if (label2.Text != "Total sale" && textBox1.Text != "" && textBox2.Text != "")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (C)).ToString();
                }
                if (label2.Text != "Total sale" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (D)).ToString();
                }
                if (label2.Text != "Total sale" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (E)).ToString();
                }
                if (label2.Text != "Total sale" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (F)).ToString();
                }


            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact your Administrator to Update the Other Features ", " Redemple Marcelo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void viewsum_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = viewsum.FocusedItem.Text;
        }

        private void viewsums_DoubleClick(object sender, EventArgs e)
        {
            view();
        }

        private void viewsums_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = viewsums.FocusedItem.Text;
        }

        private void viewsum_DoubleClick(object sender, EventArgs e)
        {
            viee();

            if (ltag.Text != "Student List")
            {
                labeltitle.Text = "Personal Data";
                view();
                up();
                panel7.Visible = true;
                panel7.BringToFront();
                panel7.Dock = DockStyle.Fill;
            }
        }

        private void User_Load(object sender, EventArgs e)
        {

            timer2.Start();
            Load_lastencode();
            Picker1.Text = lastdateencode;
            searcountry();
            Pbar.Visible = false;
            printdelete();
            sear();
            nn();
            date.Text = DateTime.Now.ToShortDateString();
            time.Text = DateTime.Now.ToShortTimeString();
            b3.PerformClick();
            tt.Visible = false;
            label17.Text = clsMySQL.llnm;
            this.rptViewer.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void b6_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            b1.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.Gray;
            if (MessageBox.Show("Are you sure you want to Log-Out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = " UPDATE login SET  outime= now() WHERE user ='" + clsMySQL.sUN + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                Form b = new login();
                b.Show();
                this.Visible = false;
            }
        }

        private void viewsum_Click(object sender, EventArgs e)
        {
            viee();

            if (ltag.Text != "Select name")
            {

                float t = 0;
                string sql = "SELECT * FROM allSS WHERE fulln like '%" + ltag.Text + "%'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();

                while (rd.Read())
                {

                    t = t + float.Parse(rd["total"].ToString());

                }

                rd.Close();
                gt = t;
                tt.Text = "" + gt.ToString("#0.00");
                up();

            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            tsearch.Visible = false;
            s1.Visible = false;
            lmale.Visible = false;
            lchild.Visible = false;
            lfemale.Visible = false;
            labeltitle.Text = "";
            panel2.Visible = false;
            ttt.Visible = false;
            ltag.Text = "About";
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b1.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.Gray;
            tt.Visible = false;
            s1.Visible = false;
            tsearch.Visible = false;
            panel4.BringToFront();
            panel4.Visible = true;
            panel4.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (isMenu1panelOpen)
            {
                panel2.Height -= 15;
                if (panel2.Height == 0)
                {
                    timer1.Stop();
                    isMenu1panelOpen = false;
                }
            }
            else if (!isMenu1panelOpen)
            {
                panel2.Height += 15;
                if (panel2.Height == 135)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }

            LASTENCODE();
            ttt.Text = "    Total Sales: ₱";
            s1.Visible = true;
            tsearch.Visible = true;
            allss.ContextMenuStrip = list4;
            ltag.Text = "All records";
            pall.Visible = true;
            pall.BringToFront();
            pall.Dock = DockStyle.Fill;
            panel2.BringToFront();
            tt.Visible = true;
            ttt.Visible = true;

        }

        private void accview_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = accview.FocusedItem.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            if (isMenu1panelOpen)
            {
                panel2.Height -= 15;
                if (panel2.Height == 0)
                {
                    timer1.Stop();
                    isMenu1panelOpen = false;
                }
            }
            else if (!isMenu1panelOpen)
            {
                panel2.Height += 15;
                if (panel2.Height == 135)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }
        }

        private void searnames()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM summary ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["fulln"].ToString());

            }
            textBox1.AutoCompleteCustomSource = serch;
            textBox2.AutoCompleteCustomSource = serch;
            textBox3.AutoCompleteCustomSource = serch;
            textBox4.AutoCompleteCustomSource = serch;
            textBox5.AutoCompleteCustomSource = serch;
            rd.Close();
        }

        private void allss_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = allss.FocusedItem.Text;
        }

        private void jjj()
        {

            string sql = "SELECT * FROM login where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                acc = rd["lname"].ToString() + " ," + rd["fname"].ToString();

            }
            rd.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Update" && su.Text != "" && sp.Text != "")
            {
                {
                    if (MessageBox.Show("Are you sure you want to Update?", "Account ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sql = " UPDATE login SET fname='" + sf.Text + "', lname = '" + sl.Text + "' ,contact= '" + sc.Text + "', secq = '" + sq.Text + "', ans = '" + sa.Text + "', pass = '" + sp.Text + "', user = '" + su.Text + "' WHERE user ='" + clsMySQL.sUN + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account Successfully Update!", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        H5();
                        coo();
                        b1.PerformClick();
                    }
                    else return;
                }
            }
        }

        private void viewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SID != null)
            {
                labeltitle.Text = "Personal Data";
                view();
            }
            else MessageBox.Show("Please select you want to View ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

        }

        private void dELETEToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    alde();
                    H57();
                    string sql = "Delete from allss where id = " + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    ALL();


                    MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Please select you want to Delete", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            b1.PerformClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (t2.Text == "" || t4.Text == "" || t5.Text == "")
            {
                MessageBox.Show("Please complete all information needed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Update?", "Attendance ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = " UPDATE summary SET fulln='" + t2.Text + "', occ = '" + t4.Text + "' ,agency= '" + t5.Text + "', date = now()  WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                HD1();
                b1.PerformClick();
                t2.ForeColor = SystemColors.ControlDarkDark;
                t4.ForeColor = SystemColors.ControlDarkDark;
                t5.ForeColor = SystemColors.ControlDarkDark;
                MessageBox.Show("Profile Successfully Update!", "Update Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            b3.PerformClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (isMenu1panelOpen)
            {
                panel2.Height -= 15;
                if (panel2.Height == 0)
                {
                    timer1.Stop();
                    isMenu1panelOpen = false;
                }
            }
            else if (!isMenu1panelOpen)
            {
                panel2.Height += 15;
                if (panel2.Height == 135)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }
            Myacc_View();
            ltag.Text = "My Account";
            acccview.BringToFront();
            acccview.Dock = DockStyle.Fill;
        }

        private void lagen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                tot.Focus();
            }
        }

        private void tot_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.Up)
            {
                lagen.Focus();
            }
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labeltitle.Text = "View by Name";
            Load_Data();
        }

        private void byAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labeltitle.Text = "View by Amount";
            int i = 1;

            string sql = "SELECT * FROM summary order by amount *1 DESC where mods='" + clsMySQL.llnm + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsum.Items.Clear();
            while (rd.Read())
            {

                viewsum.Items.Add(rd["id"].ToString());

                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(i.ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["amount"].ToString());

                i++;
            }
            rd.Close();
            lb1.Text = "  Total records : " + viewsum.Items.Count;
            int x;
            for (x = 0; x <= viewsum.Items.Count - 2; x += 2) ;
        }

        private void viewAgencyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labeltitle.Text = "Agency List";
            tt.Visible = false;
            ttt.Visible = false;
            ltag.Text = "Agency List";
            listgen.ContextMenuStrip = listag;
            Load_agen();
            pang.Visible = true;
            pang.BringToFront();
            pang.Dock = DockStyle.Fill;
        }

        private void history_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    alde();
                    H57();
                    string sql = "Delete from allss where id = " + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    ALL();


                    MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Please select you want to Delete", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Load_agens();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_agen();
        }

        private void listgen_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = listgen.FocusedItem.Text;
        }

        private void addToPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SID != null)
            {
                labeltitle.Text = "Add Print";
                if (counterprint != 9)
                {
                    counterprint++;
                    printnames();
                }



                if (counterprint == 1)
                {
                    panel13.Visible = true;
                    COPRINT.Text = "" + counterprint + "/8";
                    print();
                    printinsert();
                    printnames();

                }
                if (counterprint == 2)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print2();
                    printinsert();
                    printnames();

                }
                if (counterprint == 3)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print3();
                    printinsert();
                    printnames();


                }
                if (counterprint == 4)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print4();
                    printinsert();
                    printnames();

                }

                if (counterprint == 5)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print5();
                    printinsert();
                    printnames();


                }
                if (counterprint == 6)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print6();
                    printinsert();
                    printnames();

                }
                if (counterprint == 7)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print7();
                    printinsert();
                    printnames();

                }
                if (counterprint == 8)
                {
                    COPRINT.Text = "" + counterprint + "/8";
                    print8();
                    printinsert();
                    printnames();
                    label39.Text = "Ready to Print";

                }
                if (counterprint == 9)
                {
                    MessageBox.Show("Paper is Already full / Maximum of 8 person", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else MessageBox.Show("Please select you want to add to Print ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void updategency()
        {
            clsMySQL.ttn = clsMySQL.ttn + "," + lagen.Text;
            string sql = "UPDATE summary SET agency='" + clsMySQL.ttn + "'WHERE  fulln ='" + textBox1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

        }
        private void updategency2()
        {
            clsMySQL.tt1 = clsMySQL.tt1 + "," + lagen.Text;
            string sql = "UPDATE summary SET agency='" + clsMySQL.tt1 + "'WHERE  fulln ='" + textBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

        }
        private void updategency3()
        {
            clsMySQL.tt22 = clsMySQL.tt22 + "," + lagen.Text;
            string sql = "UPDATE summary SET agency='" + clsMySQL.tt22 + "'WHERE  fulln ='" + textBox3.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

        }
        private void updategency4()
        {
            clsMySQL.tt3 = clsMySQL.tt3 + "," + lagen.Text;
            string sql = "UPDATE summary SET agency='" + clsMySQL.tt3 + "'WHERE  fulln ='" + textBox4.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

        }
        private void updategency5()
        {
            clsMySQL.tt4 = clsMySQL.tt4 + "," + lagen.Text;
            string sql = "UPDATE summary SET agency='" + clsMySQL.tt4 + "'WHERE  fulln ='" + textBox5.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

        }

        private void dded()
        {
            clsMySQL.f1 = null;
            clsMySQL.ttn = null;
            string sql = "SELECT * FROM summary where fulln='" + textBox1.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f1 = (rd["fulln"].ToString());
                clsMySQL.ttn = (rd["agency"].ToString());
            }
            rd.Close();


        }
        private void dded2()
        {
            clsMySQL.tt1 = null;
            clsMySQL.f2 = null;
            string sql = "SELECT * FROM summary where fulln=  '" + textBox2.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f2 = (rd["fulln"].ToString());
                clsMySQL.tt1 = (rd["agency"].ToString());
            }
            rd.Close();
        }
        private void dded3()
        {
            clsMySQL.tt22 = null;
            clsMySQL.f3 = null;
            string sql = "SELECT * FROM summary where fulln=  '" + textBox3.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f3 = (rd["fulln"].ToString());
                clsMySQL.tt22 = (rd["agency"].ToString());
            }
            rd.Close();
        }
        private void dded4()
        {
            clsMySQL.tt3 = null;
            clsMySQL.f4 = null;
            string sql = "SELECT * FROM summary where fulln=  '" + textBox4.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f4 = (rd["fulln"].ToString());
                clsMySQL.tt3 = (rd["agency"].ToString());
            }
            rd.Close();
        }
        private void dded5()
        {
            clsMySQL.ttn = null;
            clsMySQL.f4 = null;
            string sql = "SELECT * FROM summary where fulln=  '" + textBox5.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f5 = (rd["fulln"].ToString());
                clsMySQL.tt4 = (rd["agency"].ToString());
            }
            rd.Close();
        }
        private void H1()
        {
            if (textBox6.Text == "" && textBox7.Text == "" && textBox8.Text == "")
            {
                textBox6.Text = "1";
                textBox7.Text = "4";
                textBox8.Text = "1";
            }
            if (textBox9.Text == "")
            {
                textBox9.Text = "PHI";
            }
            if (lagen.Text == "")
            {
                lagen.Text = "Van rent";
            }

            string sql = "INSERT INTO visitors VALUES (null, '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + Picker1.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void last()
        {
            string sql = " UPDATE lastcode SET name='" + textBox1.Text + "', amount = '" + tot.Text + "' ,date= '" + Picker1.Text + "' WHERE id = 1";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void tPbar_Tick(object sender, EventArgs e)
        {

            if (button2.Text == "Save")
            {
                if (Pbar.Value <= 90)
                {
                    Pbar.Value += 50;
                }
                else if (Pbar.Value == 100)
                {

                    tPbar.Stop();
                    Pbar.Visible = false;

                    if (tot.Text != "" && button2.Text == "Save")
                    {

                        H1();
                        H2();
                        if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
                        {
                            dded();
                            if (textBox1.Text != (clsMySQL.f1) && textBox1.Text != "")
                            {
                                y1();
                                tr1();

                            }
                            if (textBox1.Text == clsMySQL.f1 && textBox1.Text != "")
                            {
                                tr1();

                                updategency();
                            }
                        }

                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
                        {
                            dded();
                            if (textBox1.Text != (clsMySQL.f1) && textBox1.Text != "")
                            {
                                y1();
                            }

                            dded2();
                            if (textBox2.Text != clsMySQL.f2 && textBox2.Text != "")
                            {
                                y2();
                                tr2();
                            }
                            if (textBox2.Text == clsMySQL.f2 && textBox2.Text != "")
                            {
                                tr2();

                            }
                            if (textBox2.Text == clsMySQL.f2 || textBox1.Text == clsMySQL.f1)
                            {
                                updategency();
                                updategency2();
                            }

                        }



                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "" && textBox5.Text == "")
                        {
                            dded();
                            if (textBox1.Text != (clsMySQL.f1) && textBox1.Text != "")
                            {
                                y1();
                            }

                            dded2();
                            if (textBox2.Text != clsMySQL.f2 && textBox2.Text != "")
                            {
                                y2();
                            }

                            dded3();
                            if (textBox3.Text != clsMySQL.f3 && textBox3.Text != "")
                            {
                                y3();
                                tr3();
                            }
                            if (textBox3.Text == clsMySQL.f3 && textBox3.Text != "")
                            {
                                tr3();
                            }
                            if (textBox2.Text == clsMySQL.f2 || textBox1.Text == clsMySQL.f1 || textBox3.Text == clsMySQL.f3)
                            {
                                updategency();
                                updategency2();
                                updategency3();
                            }
                        }

                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text == "")
                        {
                            dded();
                            if (textBox1.Text != (clsMySQL.f1) && textBox1.Text != "")
                            {
                                y1();
                            }

                            dded2();
                            if (textBox2.Text != clsMySQL.f2 && textBox2.Text != "")
                            {
                                y2();
                            }

                            dded3();
                            if (textBox3.Text != clsMySQL.f3 && textBox3.Text != "")
                            {
                                y3();

                            }
                            dded4();
                            if (textBox4.Text != clsMySQL.f4 && textBox4.Text != "")
                            {
                                y4();
                                tr4();
                            }
                            if (textBox4.Text == clsMySQL.f4 && textBox4.Text != "")
                            {
                                tr4();
                            }
                            if (textBox2.Text == clsMySQL.f2 || textBox1.Text == clsMySQL.f1 || textBox3.Text == clsMySQL.f3 || textBox3.Text == clsMySQL.f4)
                            {
                                updategency();
                                updategency2();
                                updategency3();
                                updategency4();
                            }

                        }

                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                        {
                            dded();
                            if (textBox1.Text != (clsMySQL.f1) && textBox1.Text != "")
                            {
                                y1();
                            }

                            dded2();
                            if (textBox2.Text != clsMySQL.f2 && textBox2.Text != "")
                            {
                                y2();
                            }

                            dded3();
                            if (textBox3.Text != clsMySQL.f3 && textBox3.Text != "")
                            {
                                y3();

                            }
                            dded4();
                            if (textBox4.Text != clsMySQL.f4 && textBox4.Text != "")
                            {
                                y4();

                            }
                            dded5();
                            if (textBox5.Text != clsMySQL.f5 && textBox5.Text != "")
                            {
                                y5();
                                tr5();
                            }
                            if (textBox5.Text == clsMySQL.f5 && textBox2.Text != "")
                            {
                                tr5();
                            }
                            if (textBox2.Text == clsMySQL.f2 || textBox1.Text == clsMySQL.f1 || textBox3.Text == clsMySQL.f3 || textBox3.Text == clsMySQL.f4 || textBox3.Text == clsMySQL.f5)
                            {
                                updategency();
                                updategency2();
                                updategency3();
                                updategency4();
                                updategency5();
                            }


                        }



                        if (lagen.Text != clsMySQL.namess)
                        {
                            agency();
                        }

                        if (lagen.Text == (clsMySQL.namess))
                        {


                            erras();
                            c = c + counts;
                            agenu();
                        }
                        button12.PerformClick();

                    }


                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (labeltitle.Text == "View by Name")
            {
                if (MessageBox.Show("Are you sure you want to Print this File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    totalp();
                    pprint.BringToFront();
                    pprint.Dock = DockStyle.Fill;

                    ReportParameter Title = new ReportParameter("Title", "" + "TOURGUIDES AND DRIVERS " + DateTime.Now.Year);
                    ReportParameter Date = new ReportParameter("Date", "" + "Date : " + DateTime.Now.ToLongDateString());
                    ReportParameter Total = new ReportParameter("Total", "" + "Total Amount : ₱ " + tt.Text);
                    DataSet DataSet1 = new DataSet();
                    DataTable DataTable1 = new DataTable();
                    DataRow dr;

                    DataColumn dc1 = new DataColumn("id", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("Name", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("Occupation", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("Agency", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("Amount", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);



                    int i = 1;
                    string sql = "SELECT * FROM summary order by fulln ASC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();
                        dr[0] = i;

                        dr[1] = rd["fulln"].ToString();
                        dr[2] = rd["occ"].ToString();
                        dr[3] = rd["agency"].ToString();
                        dr[4] = rd["amount"].ToString();

                        DataTable1.Rows.Add(dr);
                        i++;
                    }
                    rd.Close();
                    DataSet1.Tables.Add(DataTable1);

                    this.rptViewer.RefreshReport();
                    this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    this.rptViewer.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report1.rdlc";
                    this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

                    ReportDataSource rds = new ReportDataSource("summary", DataSet1.Tables[0]);
                    this.rptViewer.LocalReport.DataSources.Clear();
                    this.rptViewer.LocalReport.SetParameters(Title);
                    this.rptViewer.LocalReport.SetParameters(Total);
                    this.rptViewer.LocalReport.SetParameters(Date);
                    this.rptViewer.LocalReport.DataSources.Add(rds);
                    this.rptViewer.LocalReport.Refresh();
                    this.rptViewer.DocumentMapCollapsed = true;
                    this.rptViewer.RefreshReport();
                }
                else return;

            }

            if (labeltitle.Text == "View by Amount")
            {
                if (MessageBox.Show("Are you sure you want to Print this File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    totalp();
                    pprint.BringToFront();
                    pprint.Dock = DockStyle.Fill;


                    ReportParameter Title = new ReportParameter("Title", "" + "TOURGUIDES AND DRIVERS " + DateTime.Now.Year);
                    ReportParameter Date = new ReportParameter("Date", "" + "Date : " + DateTime.Now.ToLongDateString());
                    ReportParameter Total = new ReportParameter("Total", "" + "Total Amount : ₱ " + tt.Text);
                    DataSet DataSet1 = new DataSet();
                    DataTable DataTable1 = new DataTable();
                    DataRow dr;

                    DataColumn dc1 = new DataColumn("id", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("Name", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("Occupation", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("Agency", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("Amount", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);


                    int i = 1;
                    string sql = "SELECT * FROM summary order by amount *1 DESC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();
                        dr[0] = i;
                        dr[1] = rd["fulln"].ToString();
                        dr[2] = rd["occ"].ToString();
                        dr[3] = rd["agency"].ToString();
                        dr[4] = rd["amount"].ToString();

                        DataTable1.Rows.Add(dr);
                        i++;
                    }
                    rd.Close();
                    DataSet1.Tables.Add(DataTable1);

                    this.rptViewer.RefreshReport();
                    this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    this.rptViewer.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report1.rdlc";
                    this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

                    ReportDataSource rds = new ReportDataSource("summary", DataSet1.Tables[0]);
                    this.rptViewer.LocalReport.DataSources.Clear();
                    this.rptViewer.LocalReport.SetParameters(Title);
                    this.rptViewer.LocalReport.SetParameters(Total);
                    this.rptViewer.LocalReport.SetParameters(Date);
                    this.rptViewer.LocalReport.DataSources.Add(rds);
                    this.rptViewer.LocalReport.Refresh();
                    this.rptViewer.DocumentMapCollapsed = true;
                    this.rptViewer.RefreshReport();
                }
                else return;

            }

            if (ltag.Text == "All records")
            {
                if (MessageBox.Show("Are you sure you want to Print this File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    pprint.BringToFront();
                    pprint.Dock = DockStyle.Fill;

                    ReportParameter tit = new ReportParameter("tit", "" + "TOURGUIDES AND DRIVERS ATTENDANCE " + DateTime.Now.Year);
                    DataSet DataSet1 = new DataSet();
                    DataTable DataTable1 = new DataTable();
                    DataRow dr;

                    DataColumn dc1 = new DataColumn("id", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("name", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("date", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("agency", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("sales", Type.GetType("System.String"));
                    DataColumn dc6 = new DataColumn("share", Type.GetType("System.String"));
                    DataColumn dc7 = new DataColumn("indi", Type.GetType("System.String"));
                    DataColumn dc8 = new DataColumn("total", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);
                    DataTable1.Columns.Add(dc6);
                    DataTable1.Columns.Add(dc7);
                    DataTable1.Columns.Add(dc8);

                    int i = 1;
                    string sql = "SELECT * FROM allss";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();

                        dr[0] = i;
                        dr[1] = rd["fulln"].ToString();
                        dr[2] = rd["date"].ToString();
                        dr[3] = rd["agency"].ToString();
                        dr[4] = rd["amount"].ToString();
                        dr[5] = rd["share"].ToString();
                        dr[6] = rd["indi"].ToString();
                        dr[7] = rd["total"].ToString();

                        DataTable1.Rows.Add(dr);
                        i++;
                    }
                    rd.Close();
                    DataSet1.Tables.Add(DataTable1);

                    this.rptViewer.RefreshReport();
                    this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    this.rptViewer.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report3.rdlc";
                    this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
                    ReportDataSource rds = new ReportDataSource("attendance", DataSet1.Tables[0]);
                    this.rptViewer.LocalReport.DataSources.Clear();
                    this.rptViewer.LocalReport.SetParameters(tit);
                    this.rptViewer.LocalReport.DataSources.Add(rds);
                    this.rptViewer.LocalReport.Refresh();
                    this.rptViewer.DocumentMapCollapsed = true;
                    this.rptViewer.RefreshReport();
                }
                else return;

            }


            if (ltag.Text == "Agency List")
            {
                if (MessageBox.Show("Are you sure you want to Print this File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    pnlprint.BringToFront();
                    pnlprint.Dock = DockStyle.Fill;
                    DataSet DataSet1 = new DataSet();
                    DataTable DataTable1 = new DataTable();
                    DataRow dr;

                    DataColumn dc1 = new DataColumn("id", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("name", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("count", Type.GetType("System.String"));


                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);


                    int i = 1;
                    string sql = "SELECT * FROM agency order by count *1 DESC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();
                        dr[0] = i++;
                        dr[1] = rd["agency"].ToString();
                        dr[2] = rd["count"].ToString();

                        DataTable1.Rows.Add(dr);
                    }
                    rd.Close();
                    DataSet1.Tables.Add(DataTable1);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report4.rdlc";
                    this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

                    ReportDataSource rds = new ReportDataSource("agency", DataSet1.Tables[0]);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    //this.rptViewer.LocalReport.SetParameters(Title);
                    this.reportViewer1.LocalReport.DataSources.Add(rds);

                    this.reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.DocumentMapCollapsed = true;
                    this.reportViewer1.RefreshReport();
                }
                else return;

            }
            if (labeltitle.Text == "Personal Data")
            {
                if (MessageBox.Show("Are you sure you want to Print this File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pnlprint.BringToFront();
                    pnlprint.Dock = DockStyle.Fill;
                    ReportParameter names = new ReportParameter("names", "" + "NAME = " + ltag.Text);
                    ReportParameter name = new ReportParameter("name", "" + ltag.Text);
                    ReportParameter total = new ReportParameter("total", "" + tt.Text);
                    ReportParameter occupation = new ReportParameter("occupation", "" + "OCCUPATION : " + occ);
                    DataSet DataSet1 = new DataSet();
                    DataTable DataTable1 = new DataTable();
                    DataRow dr;
                    DataColumn dc1 = new DataColumn("date", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("name", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("agency", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("sales", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("share", Type.GetType("System.String"));
                    DataColumn dc6 = new DataColumn("individua", Type.GetType("System.String"));
                    DataColumn dc7 = new DataColumn("total", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);
                    DataTable1.Columns.Add(dc6);
                    DataTable1.Columns.Add(dc7);
                    string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();
                        dr[0] = rd["date"].ToString();
                        dr[1] = rd["fulln"].ToString();
                        dr[2] = rd["agency"].ToString();
                        dr[3] = rd["amount"].ToString();
                        dr[4] = rd["share"].ToString();
                        dr[5] = rd["indi"].ToString();
                        dr[6] = rd["total"].ToString();
                        DataTable1.Rows.Add(dr);
                    }
                    rd.Close();
                    DataSet1.Tables.Add(DataTable1);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report5.rdlc";
                    this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

                    ReportDataSource rds = new ReportDataSource("personaldata", DataSet1.Tables[0]);
                    //     ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    //this.rptViewer.LocalReport.SetParameters(Title);
                    this.reportViewer1.LocalReport.SetParameters(names);
                    this.reportViewer1.LocalReport.SetParameters(name);
                    this.reportViewer1.LocalReport.SetParameters(total);
                    this.reportViewer1.LocalReport.SetParameters(occupation);
                    this.reportViewer1.LocalReport.DataSources.Add(rds);
                    this.reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.DocumentMapCollapsed = true;
                    this.reportViewer1.RefreshReport();


                }
                else return;

            }

            if (labeltitle.Text != "View by Name" && labeltitle.Text != "View by Amount" && labeltitle.Text == "" && ltag.Text != "All records")
            {
                MessageBox.Show("This File can't Print", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {
            button5.Text = "Update";
            pshowacc.BringToFront();
            pshowacc.Visible = true;
            pshowacc.Dock = DockStyle.Fill;
            Myacc_Data();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (labeltitle.Text == "View by Name")
            {
                if (MessageBox.Show("Are you sure you want to Print this File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var excelApp = new Excel.Application();
                    // Make the object visible.
                    excelApp.Visible = true;
                    // Establish column headings in cells A1 and B1.

                    // Create a new, empty workbook and add it to the collection returned 
                    // by property Workbooks. The new workbook becomes the active workbook.
                    // Add has an optional parameter for specifying a praticular template. 
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This example uses a single workSheet. The explicit type casting is
                    // removed in a later procedure.
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    var row = 1;
                    int i = 1;

                    string sql = "SELECT * FROM summary order by fulln ASC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        row++;

                        workSheet.Cells[row, "A"] = i;
                        workSheet.Cells[row, "B"] = rd["fulln"].ToString();
                        workSheet.Cells[row, "C"] = rd["occ"].ToString();
                        workSheet.Cells[row, "D"] = rd["agency"].ToString();
                        workSheet.Cells[row, "E"] = rd["amount"].ToString();
                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "Name";
                    workSheet.Cells[1, "C"] = "Occupation";
                    workSheet.Cells[1, "D"] = "Agency";
                    workSheet.Cells[1, "E"] = "Amount";
                    workSheet.Columns[1].AutoFit();
                    workSheet.Columns[2].AutoFit();
                    workSheet.Columns[3].AutoFit();
                    workSheet.Columns[4].AutoFit();
                    workSheet.Columns[5].AutoFit();
                    ((Excel.Range)workSheet.Columns[1]).AutoFit();
                    ((Excel.Range)workSheet.Columns[2]).AutoFit();
                    ((Excel.Range)workSheet.Columns[3]).AutoFit();
                    ((Excel.Range)workSheet.Columns[4]).AutoFit();
                    ((Excel.Range)workSheet.Columns[5]).AutoFit();
                }
                else return;

            }
            if (labeltitle.Text == "View by Amount")
            {
                if (MessageBox.Show("Are you sure you want to Convert this into Exel File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var excelApp = new Excel.Application();
                    // Make the object visible.
                    excelApp.Visible = true;
                    // Establish column headings in cells A1 and B1.

                    // Create a new, empty workbook and add it to the collection returned 
                    // by property Workbooks. The new workbook becomes the active workbook.
                    // Add has an optional parameter for specifying a praticular template. 
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This example uses a single workSheet. The explicit type casting is
                    // removed in a later procedure.
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    var row = 1;
                    int i = 1;

                    string sql = "SELECT * FROM summary order by amount DESC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        row++;

                        workSheet.Cells[row, "A"] = i;
                        workSheet.Cells[row, "B"] = rd["fulln"].ToString();
                        workSheet.Cells[row, "C"] = rd["occ"].ToString();
                        workSheet.Cells[row, "D"] = rd["agency"].ToString();
                        workSheet.Cells[row, "E"] = rd["amount"].ToString();
                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "Name";
                    workSheet.Cells[1, "C"] = "Occupation";
                    workSheet.Cells[1, "D"] = "Agency";
                    workSheet.Cells[1, "E"] = "Amount";
                    workSheet.Columns[1].AutoFit();
                    workSheet.Columns[2].AutoFit();
                    workSheet.Columns[3].AutoFit();
                    workSheet.Columns[4].AutoFit();
                    workSheet.Columns[5].AutoFit();
                    workSheet.Columns[6].AutoFit();
                    ((Excel.Range)workSheet.Columns[1]).AutoFit();
                    ((Excel.Range)workSheet.Columns[2]).AutoFit();
                    ((Excel.Range)workSheet.Columns[3]).AutoFit();
                    ((Excel.Range)workSheet.Columns[4]).AutoFit();
                    ((Excel.Range)workSheet.Columns[5]).AutoFit();
                    ((Excel.Range)workSheet.Columns[6]).AutoFit();
                }
                else return;

            }
            if (ltag.Text == "All records")
            {
                if (MessageBox.Show("Are you sure you want to Convert this into Exel File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var excelApp = new Excel.Application();
                    // Make the object visible.
                    excelApp.Visible = true;
                    // Establish column headings in cells A1 and B1.

                    // Create a new, empty workbook and add it to the collection returned 
                    // by property Workbooks. The new workbook becomes the active workbook.
                    // Add has an optional parameter for specifying a praticular template. 
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This example uses a single workSheet. The explicit type casting is
                    // removed in a later procedure.
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    var row = 1;
                    int i = 1;

                    string sql = "SELECT * FROM allss";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        row++;
                        workSheet.Cells[row, "A"] = i;
                        workSheet.Cells[row, "B"] = rd["fulln"].ToString();
                        workSheet.Cells[row, "C"] = rd["date"].ToString();
                        workSheet.Cells[row, "D"] = rd["occ"].ToString();
                        workSheet.Cells[row, "E"] = rd["agency"].ToString();
                        workSheet.Cells[row, "F"] = rd["amount"].ToString();
                        workSheet.Cells[row, "G"] = rd["share"].ToString();
                        workSheet.Cells[row, "H"] = rd["indi"].ToString();
                        workSheet.Cells[row, "I"] = rd["total"].ToString();

                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "NAME";
                    workSheet.Cells[1, "C"] = "DATE";
                    workSheet.Cells[1, "D"] = "OCCUPATION";
                    workSheet.Cells[1, "E"] = "AGENCY";
                    workSheet.Cells[1, "F"] = "AMOUNT";
                    workSheet.Cells[1, "G"] = "6% SHARE";
                    workSheet.Cells[1, "H"] = "INDIVIDUAL SHARE";
                    workSheet.Cells[1, "I"] = "TOTAL";
                    workSheet.Columns[1].AutoFit();
                    workSheet.Columns[2].AutoFit();
                    workSheet.Columns[3].AutoFit();
                    workSheet.Columns[4].AutoFit();
                    workSheet.Columns[5].AutoFit();
                    workSheet.Columns[6].AutoFit();
                    workSheet.Columns[7].AutoFit();
                    workSheet.Columns[8].AutoFit();
                    workSheet.Columns[9].AutoFit();
                    ((Excel.Range)workSheet.Columns[1]).AutoFit();
                    ((Excel.Range)workSheet.Columns[2]).AutoFit();
                    ((Excel.Range)workSheet.Columns[3]).AutoFit();
                    ((Excel.Range)workSheet.Columns[4]).AutoFit();
                    ((Excel.Range)workSheet.Columns[5]).AutoFit();
                    ((Excel.Range)workSheet.Columns[6]).AutoFit();
                    ((Excel.Range)workSheet.Columns[7]).AutoFit();
                    ((Excel.Range)workSheet.Columns[8]).AutoFit();
                    ((Excel.Range)workSheet.Columns[9]).AutoFit();
                }
                else return;

            }


            if (labeltitle.Text == "Personal Data")
            {
                if (MessageBox.Show("Are you sure you want to Convert this into Exel File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var excelApp = new Excel.Application();
                    // Make the object visible.
                    excelApp.Visible = true;
                    // Establish column headings in cells A1 and B1.

                    // Create a new, empty workbook and add it to the collection returned 
                    // by property Workbooks. The new workbook becomes the active workbook.
                    // Add has an optional parameter for specifying a praticular template. 
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This example uses a single workSheet. The explicit type casting is
                    // removed in a later procedure.
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    var row = 1;
                    int i = 1;

                    string sql = "SELECT * FROM allss where fulln like '%" + ltag.Text + "%'";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        row++;
                        workSheet.Cells[row, "A"] = i;
                        workSheet.Cells[row, "B"] = rd["fulln"].ToString();
                        workSheet.Cells[row, "C"] = rd["date"].ToString();
                        workSheet.Cells[row, "D"] = rd["occ"].ToString();
                        workSheet.Cells[row, "E"] = rd["agency"].ToString();
                        workSheet.Cells[row, "F"] = rd["amount"].ToString();
                        workSheet.Cells[row, "G"] = rd["share"].ToString();
                        workSheet.Cells[row, "H"] = rd["indi"].ToString();
                        workSheet.Cells[row, "I"] = rd["total"].ToString();

                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "NAME";
                    workSheet.Cells[1, "C"] = "DATE";
                    workSheet.Cells[1, "D"] = "OCCUPATION";
                    workSheet.Cells[1, "E"] = "AGENCY";
                    workSheet.Cells[1, "F"] = "AMOUNT";
                    workSheet.Cells[1, "G"] = "6% SHARE";
                    workSheet.Cells[1, "H"] = "INDIVIDUAL SHARE";
                    workSheet.Cells[1, "I"] = "TOTAL";
                    workSheet.Columns[1].AutoFit();
                    workSheet.Columns[2].AutoFit();
                    workSheet.Columns[3].AutoFit();
                    workSheet.Columns[4].AutoFit();
                    workSheet.Columns[5].AutoFit();
                    workSheet.Columns[6].AutoFit();
                    workSheet.Columns[7].AutoFit();
                    workSheet.Columns[8].AutoFit();
                    workSheet.Columns[9].AutoFit();
                    ((Excel.Range)workSheet.Columns[1]).AutoFit();
                    ((Excel.Range)workSheet.Columns[2]).AutoFit();
                    ((Excel.Range)workSheet.Columns[3]).AutoFit();
                    ((Excel.Range)workSheet.Columns[4]).AutoFit();
                    ((Excel.Range)workSheet.Columns[5]).AutoFit();
                    ((Excel.Range)workSheet.Columns[6]).AutoFit();
                    ((Excel.Range)workSheet.Columns[7]).AutoFit();
                    ((Excel.Range)workSheet.Columns[8]).AutoFit();
                    ((Excel.Range)workSheet.Columns[9]).AutoFit();
                }
                else return;

            }
            if (ltag.Text == "Agency List")
            {
                if (MessageBox.Show("Are you sure you want to Convert this into Exel File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var excelApp = new Excel.Application();
                    // Make the object visible.
                    excelApp.Visible = true;
                    // Establish column headings in cells A1 and B1.

                    // Create a new, empty workbook and add it to the collection returned 
                    // by property Workbooks. The new workbook becomes the active workbook.
                    // Add has an optional parameter for specifying a praticular template. 
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This example uses a single workSheet. The explicit type casting is
                    // removed in a later procedure.
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    var row = 1;
                    int i = 1;

                    string sql = "SELECT * FROM agency";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        row++;

                        workSheet.Cells[row, "A"] = i;
                        workSheet.Cells[row, "B"] = rd["agency"].ToString();
                        workSheet.Cells[row, "C"] = rd["count"].ToString();

                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "NAME OF AGENCY";
                    workSheet.Cells[1, "C"] = "COUNT";
                    workSheet.Columns[1].AutoFit();
                    workSheet.Columns[2].AutoFit();
                    workSheet.Columns[3].AutoFit();
                    ((Excel.Range)workSheet.Columns[1]).AutoFit();
                    ((Excel.Range)workSheet.Columns[2]).AutoFit();
                    ((Excel.Range)workSheet.Columns[3]).AutoFit();

                }
                else return;

            }

            if (ltag.Text == "No. of visitors")
            {
                if (MessageBox.Show("Are you sure you want to Convert this into Exel File?", "Print Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var excelApp = new Excel.Application();
                    // Make the object visible.
                    excelApp.Visible = true;
                    // Establish column headings in cells A1 and B1.

                    // Create a new, empty workbook and add it to the collection returned 
                    // by property Workbooks. The new workbook becomes the active workbook.
                    // Add has an optional parameter for specifying a praticular template. 
                    // Because no argument is sent in this example, Add creates a new workbook. 
                    excelApp.Workbooks.Add();

                    // This example uses a single workSheet. The explicit type casting is
                    // removed in a later procedure.
                    Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                    var row = 1;
                    int i = 1;

                    string sql = "SELECT * FROM visitors";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        row++;

                        workSheet.Cells[row, "A"] = i;
                        workSheet.Cells[row, "B"] = rd["children"].ToString();
                        workSheet.Cells[row, "C"] = rd["female"].ToString();
                        workSheet.Cells[row, "D"] = rd["male"].ToString();
                        workSheet.Cells[row, "E"] = rd["country"].ToString();
                        workSheet.Cells[row, "F"] = rd["date"].ToString();

                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "Children below 13yo.";
                    workSheet.Cells[1, "C"] = "Female(adults)";
                    workSheet.Cells[1, "D"] = "Male(adults)";
                    workSheet.Cells[1, "E"] = "Country of origin";
                    workSheet.Cells[1, "F"] = "Date";
                    workSheet.Columns[1].AutoFit();
                    workSheet.Columns[2].AutoFit();
                    workSheet.Columns[3].AutoFit();
                    workSheet.Columns[4].AutoFit();
                    workSheet.Columns[5].AutoFit();
                    workSheet.Columns[6].AutoFit();
                    ((Excel.Range)workSheet.Columns[1]).AutoFit();
                    ((Excel.Range)workSheet.Columns[2]).AutoFit();
                    ((Excel.Range)workSheet.Columns[3]).AutoFit();
                    ((Excel.Range)workSheet.Columns[4]).AutoFit();
                    ((Excel.Range)workSheet.Columns[5]).AutoFit();
                    ((Excel.Range)workSheet.Columns[6]).AutoFit();

                }
                else return;

            }

            if (labeltitle.Text != "View by Name" && labeltitle.Text != "View by Amount" && labeltitle.Text == "" && ltag.Text != "All records" && ltag.Text != "Agency List" && ltag.Text != "No. of visitors")
            {
                MessageBox.Show("This File can't Convert into Exel File", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void nor_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            maxi.BringToFront();
            maxi.Visible = true;
            this.Location = new Point(100, 30);

        }

        private void clo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            mini.BringToFront();
            mini.Visible = true;
            maxi.SendToBack();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            printdelete();
            panel13.Visible = false;
            counterprint = 0;
            label39.Text = "Not ready to print";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            printdelete();
            counterprint = 0;
            printnames();
            label39.Text = "Not ready to print";
            COPRINT.Text = "0/8";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (counterprint == 8 || counterprint == 9)
            {
                pnlprint.BringToFront();
                pnlprint.Dock = DockStyle.Fill;
            }
            else MessageBox.Show("Please Select more person / minimum of 8 person [" + counterprint + "/8" + "]", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
     

        private void view()
        {
            viewsums.ContextMenuStrip = list3;
            panel7.Visible = true;
            panel7.BringToFront();
            panel7.Dock = DockStyle.Fill;
            oy();
        }

        private void sear()
        {
            lagen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            lagen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM Agency ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["agency"].ToString());

            }
            lagen.AutoCompleteCustomSource = serch;

            rd.Close();
        }

        private void searcountry()
        {
            textBox9.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox9.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM visitors ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["country"].ToString());

            }
            textBox9.AutoCompleteCustomSource = serch;

            rd.Close();
        }
        public void coo()
        {
            sf.ForeColor = SystemColors.ControlDarkDark;
            sl.ForeColor = SystemColors.ControlDarkDark;
            su.ForeColor = SystemColors.ControlDarkDark;
            sq.ForeColor = SystemColors.ControlDarkDark;
            sa.ForeColor = SystemColors.ControlDarkDark;
            sp.ForeColor = SystemColors.ControlDarkDark;
            sc.ForeColor = SystemColors.ControlDarkDark;

        }

        private void dels()
        {
            string sql = "Delete from allss where fulln =  '" + ltag.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }





        private void load_amount()
        {
            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Update?", "Attendance ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string sql = " UPDATE allss SET amount='" + tot.Text + "', share = '" + label2.Text + "' ,indi= '" + label3.Text + "', total = '" + label3.Text + "', agency = '" + lagen.Text + "' WHERE id =" + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    label3.Text = "0.00";
                    label2.Text = "0.00";
                    tot.Text = "";
                    lagen.Text = "";
                    SID = null;

                    oy();
                    ALL();
                    MessageBox.Show("Record Successfully Update!", "Update Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Please select you want to Update", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

        }

        private void Loads()
        {
            t2.Text = clsMySQL.f11;
            t4.Text = clsMySQL.f21;
            t5.Text = clsMySQL.f31;

        }



        private void H11()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "EDIT ATTENDANCE" + "', '" + aname.Text + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void HD()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "DELETE SUMMARY" + "', '" + ltag.Text + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void HD3()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "DELETE PERSONAL RECORD" + "', '" + ltag.Text + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void HD2()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "EDIT PERSONAL RECORD" + "', '" + ltag.Text + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void HD1()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "EDIT SUMMARY" + "', '" + ltag.Text + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void H2()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "ADD AMOUNT FROM ATTENDANCE" + "', '" + clsMySQL.tte + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void H3()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "ACTIVATE ACCOUNT" + "', '" + NACC + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void H4()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "DEACTIVATE ACCOUNT" + "', '" + NACC + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void H5()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "VIEW / EDIT ACCOUNT" + "', '" + NACC + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void H56()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "EDIT ALL RECORD " + "', '" + clsMySQL.tte + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void H57()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "DELETE ALL RECORD " + "', '" + clsMySQL.tte + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void alde()
        {

            string sql = "SELECT * FROM allss where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                clsMySQL.tte = (rd["fulln"].ToString());
            }
            rd.Close();

        }


        private void ShowAcc_Data()
        {

            string sql = "SELECT * FROM login where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                NACC = rd["fname"].ToString() + "," + rd["lname"].ToString();
                sf.Text = rd["fname"].ToString();
                sl.Text = rd["lname"].ToString();
                su.Text = rd["user"].ToString();
                sp.Text = rd["pass"].ToString();
                sc.Text = rd["contact"].ToString();
                sq.Text = rd["secq"].ToString();
                sa.Text = rd["ans"].ToString();
                si.Text = "Log-out time: " + rd["outime"].ToString();
                so.Text = "Log-in time: " + rd["intime"].ToString();
                ss.Text = rd["status"].ToString();

            }
            rd.Close();
        }
        private void accstat()
        {

            string sql = "SELECT * FROM login where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.AU = rd["Administrator"].ToString();
            }
            rd.Close();
        }
        private void all_Data()
        {
            int i = 1;
            string sql = "SELECT * FROM allss order by id desc";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            allss.Items.Clear();
            while (rd.Read())
            {

                allss.Items.Add(rd["id"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(i.ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["amount"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["share"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["indi"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["total"].ToString());
                i++;
            }

            rd.Close();
            lb1.Text = "  Total records : " + allss.Items.Count;
            int x;
            for (x = 0; x <= allss.Items.Count - 2; x += 2) ;


        }

        private void Load_Data()
        {
            int i = 1;
            string sql = "SELECT * FROM summary where mods='" + clsMySQL.llnm + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsum.Items.Clear();
            while (rd.Read())
            {

                viewsum.Items.Add(rd["id"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(i.ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["amount"].ToString());

                i++;

            }
            rd.Close();
            lb1.Text = "  Total records : " + viewsum.Items.Count;
            int x;
            for (x = 0; x <= viewsum.Items.Count - 2; x += 2) ;

        }






        private void y1()
        {
            string sql = "INSERT INTO summary VALUES (null,'" + textBox1.Text + "','" + "Driver" + "','" + lagen.Text + "','" + "0" + "',now(),'" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void y2()
        {
            string sql = "INSERT INTO summary VALUES (null,'" + textBox2.Text + "','" + "Tourguide" + "','" + lagen.Text + "','" + "0" + "',now(),'" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void y3()
        {
            string sql = "INSERT INTO summary VALUES (null,'" + textBox3.Text + "','" + "Tourguide" + "','" + lagen.Text + "','" + "0" + "',now(),'" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void y4()
        {
            string sql = "INSERT INTO summary VALUES (null,'" + textBox4.Text + "','" + "Tourguide" + "','" + lagen.Text + "','" + "0" + "',now(),'" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void y5()
        {
            string sql = "INSERT INTO summary VALUES (null,'" + textBox5.Text + "','" + "Tourguide" + "','" + lagen.Text + "','" + "0" + "',now(),'" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        public void tr1()
        {
            string na1 = textBox1.Text;
            string sql = "INSERT INTO allss VALUES (null,'" + na1 + "','" + lagen.Text + "','" + tot.Text + "','" + label2.Text + "','" + label3.Text + "','" + label3.Text + "','" + Picker1.Text + "','" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        public void tr2()
        {
            string na2 = textBox1.Text + "/" + textBox2.Text;
            string sql = "INSERT INTO allss VALUES (null,'" + na2 + "','" + lagen.Text + "','" + tot.Text + "','" + label2.Text + "','" + label3.Text + "','" + label3.Text + "','" + Picker1.Text + "','" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        public void tr3()
        {
            string na3 = textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text;
            string sql = "INSERT INTO allss VALUES (null,'" + na3 + "','" + lagen.Text + "','" + tot.Text + "','" + label2.Text + "','" + label3.Text + "','" + label3.Text + "','" + Picker1.Text + "','" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        public void tr4()
        {
            string na4 = textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text + "/" + textBox4.Text;
            string sql = "INSERT INTO allss VALUES (null,'" + na4 + "','" + lagen.Text + "','" + tot.Text + "','" + label2.Text + "','" + label3.Text + "','" + label3.Text + "','" + Picker1.Text + "','" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        public void tr5()
        {
            string na5 = textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text + "/" + textBox4.Text + "/" + textBox5.Text;
            string sql = "INSERT INTO allss VALUES (null,'" + na5 + "','" + lagen.Text + "','" + tot.Text + "','" + label2.Text + "','" + label3.Text + "','" + label3.Text + "','" + Picker1.Text + "','" + clsMySQL.llnm + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void sears()
        {
            lagen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            lagen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM Agency ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["agency"].ToString());

            }
            lagen.AutoCompleteCustomSource = serch;

            rd.Close();
        }

        private void erras()
        {
            int t = 0;
            string sql = "SELECT * FROM Agency where agency =  '" + lagen.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                t = t + int.Parse(rd["count"].ToString());

            }
            rd.Close();
            c = t;

        }
        private void agenu()
        {
            string sql = " UPDATE Agency SET count='" + c + "' WHERE agency ='" + lagen.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void agency()
        {
            string sql = "INSERT INTO Agency VALUES (null, '" + lagen.Text + "', '" + counts + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }


        public void up()
        {
            string sql = "UPDATE summary SET amount='" + tt.Text + "'WHERE fulln =  '" + ltag.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }


        private void viee()
        {
            string sql = "SELECT *  FROM summary where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsums.Items.Clear();
            while (rd.Read())
            {
                ltag.Text = (rd["fulln"].ToString());

                occ = (rd["occ"].ToString());
            }

            rd.Close();
        }
        private void oy()
        {
            float t = 0;

            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%' and  mods like '%" + clsMySQL.llnm +"%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsums.Items.Clear();
            while (rd.Read())
            {

                viewsums.Items.Add(rd["id"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["amount"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["share"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["indi"].ToString());
                viewsums.Items[viewsums.Items.Count - 1].SubItems.Add(rd["total"].ToString());
                t = t + float.Parse(rd["total"].ToString());
            }
            rd.Close();
            lb1.Text = "  Total records : " + viewsums.Items.Count;
            int x;
            for (x = 0; x <= viewsums.Items.Count - 2; x += 2) ;
        }



        private void nn()
        {
            string sql = "SELECT * FROM login WHERE user ='" + clsMySQL.sUN + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                clsMySQL.llnm = (rd["lname"].ToString()) + " ," + (rd["fname"].ToString());

            }
            rd.Close();

        }


        private void Myacc_Data()
        {

            string sql = "SELECT * FROM login where user ='" + clsMySQL.sUN + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                NACC = rd["fname"].ToString() + "," + rd["lname"].ToString();
                sf.Text = rd["fname"].ToString();
                sl.Text = rd["lname"].ToString();
                su.Text = rd["user"].ToString();
                sp.Text = rd["pass"].ToString();
                sc.Text = rd["contact"].ToString();
                sq.Text = rd["secq"].ToString();
                sa.Text = rd["ans"].ToString();
                si.Text = "Log-out time: " + rd["outime"].ToString();
                so.Text = "Log-in time: " + rd["intime"].ToString();
                ss.Text = rd["status"].ToString();

            }
            rd.Close();
        }

        private void Myacc_View()
        {

            string sql = "SELECT * FROM login where user ='" + clsMySQL.sUN + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                vf.Text = rd["fname"].ToString();
                vl.Text = rd["lname"].ToString();
                vu.Text = rd["user"].ToString();
                vp.Text = rd["pass"].ToString();
                vc.Text = rd["contact"].ToString();
                vq.Text = rd["secq"].ToString();
                vs.Text = rd["ans"].ToString();
                vo.Text = "Log-out time: " + rd["outime"].ToString();
                vi.Text = "Log-in time: " + rd["intime"].ToString();
                vss.Text = rd["status"].ToString();

            }
            rd.Close();
        }

        private void LASTENCODE()
        {

            float t = 0;
            int i = 1;
            string sql = "SELECT * FROM allss where mods='" + clsMySQL.llnm + "'";

            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            allss.Items.Clear();
            while (rd.Read())
            {

                allss.Items.Add(rd["id"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(i.ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["amount"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["share"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["indi"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["total"].ToString());
                t = t + float.Parse(rd["amount"].ToString());
                i++;
            }
            gt = t;
            tt.Text = "" + gt.ToString("#0.00");
            rd.Close();
            lb1.Text = "  Total records : " + allss.Items.Count;
            int x;
            for (x = 0; x <= allss.Items.Count - 2; x += 2) ;


        }



        private void ALL()
        {

            float t = 0;
            int i = 1;
            string sql = "SELECT * FROM allss order by id desc";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            allss.Items.Clear();
            while (rd.Read())
            {

                allss.Items.Add(rd["id"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(i.ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["amount"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["share"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["indi"].ToString());
                allss.Items[allss.Items.Count - 1].SubItems.Add(rd["total"].ToString());
                t = t + float.Parse(rd["amount"].ToString());
                i++;
            }
            gt = t;
            tt.Text = "" + gt.ToString("#0.00");
            rd.Close();
            lb1.Text = "  Total records : " + allss.Items.Count;
            int x;
            for (x = 0; x <= allss.Items.Count - 2; x += 2) ;


        }

        private void Load_agen()
        {
            int i = 1;
            string sql = "SELECT * FROM Agency order by count *1 DESC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listgen.Items.Clear();
            while (rd.Read())
            {

                listgen.Items.Add(rd["id"].ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(i.ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(rd["count"].ToString());
                i++;

            }
            rd.Close();
            lb1.Text = "  Total records : " + listgen.Items.Count;
            int x;
            for (x = 0; x <= listgen.Items.Count - 2; x += 2) ;

        }
        private void Load_lastencode()
        {

            string sql = "SELECT * FROM lastcode";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader(); ;
            while (rd.Read())
            {

                lastcode.Text = "Name: " + rd["name"].ToString() + "   Amount: " + rd["amount"].ToString() + "   Date: " + rd["date"].ToString();

                lastdateencode = rd["date"].ToString();
            }
            rd.Close();

        }
        private void Load_agens()
        {
            int i = 1;
            string sql = "SELECT * FROM Agency order by agency ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listgen.Items.Clear();
            while (rd.Read())
            {

                listgen.Items.Add(rd["id"].ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(i.ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(rd["count"].ToString());
                i++;

            }
            rd.Close();
            lb1.Text = "  Total records : " + listgen.Items.Count;
            int x;
            for (x = 0; x <= listgen.Items.Count - 2; x += 2) ;

        }

        private void totalp()
        {

            float t = 0;
            int i = 1;
            string sql = "SELECT * FROM summary";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                t = t + float.Parse(rd["amount"].ToString());
                i++;
            }
            gt = t;
            tt.Text = "" + gt.ToString("#0.00");
            rd.Close();


        }


        private void printinsert()
        {
            string sql = "INSERT INTO print  VALUES (null, '" + ltag.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void printdelete()
        {
            string sql = "Delete from print";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void printnames()
        {


            string sql = "SELECT * FROM print";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listprint.Items.Clear();
            while (rd.Read())
            {
                listprint.Items.Add(rd["id"].ToString());
                listprint.Items[listprint.Items.Count - 1].SubItems.Add(rd["name"].ToString());
            }

            rd.Close();


        }
        private void print()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter namess = new ReportParameter("namess", "" + "NAME = " + ltag.Text);
            ReportParameter name = new ReportParameter("name", "" + ltag.Text);
            ReportParameter total = new ReportParameter("total", "" + tt.Text);
            ReportParameter occupation = new ReportParameter("occupation", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();
            ReportDataSource pri2 = new ReportDataSource("pri2");
            ReportDataSource pri3 = new ReportDataSource("pri3");
            ReportDataSource pri4 = new ReportDataSource("pri4");
            ReportDataSource pri5 = new ReportDataSource("pri5");
            ReportDataSource pri6 = new ReportDataSource("pri6");
            ReportDataSource pri7 = new ReportDataSource("pri7");
            ReportDataSource pri8 = new ReportDataSource("pri8");
            ReportDataSource pri9 = new ReportDataSource("pri9");
            DataRow dr;
            DataColumn dc1 = new DataColumn("date", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("name", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("agency", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("sales", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("share", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("individua", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("total", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri1", DataSet1.Tables[0]);
            //     ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(namess);
            this.reportViewer1.LocalReport.SetParameters(name);
            this.reportViewer1.LocalReport.SetParameters(total);
            this.reportViewer1.LocalReport.SetParameters(occupation);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(pri2);
            this.reportViewer1.LocalReport.DataSources.Add(pri3);
            this.reportViewer1.LocalReport.DataSources.Add(pri4);
            this.reportViewer1.LocalReport.DataSources.Add(pri5);
            this.reportViewer1.LocalReport.DataSources.Add(pri6);
            this.reportViewer1.LocalReport.DataSources.Add(pri7);
            this.reportViewer1.LocalReport.DataSources.Add(pri8);
            this.reportViewer1.LocalReport.DataSources.Add(pri9);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();

        }
        private void print2()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter a = new ReportParameter("a", "" + "NAME = " + ltag.Text);
            ReportParameter c = new ReportParameter("c", "" + ltag.Text);
            ReportParameter d = new ReportParameter("d", "" + tt.Text);
            ReportParameter b = new ReportParameter("b", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("a", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("b", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("c", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("d", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("e", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("f", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("g", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri2", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(a);
            this.reportViewer1.LocalReport.SetParameters(b);
            this.reportViewer1.LocalReport.SetParameters(c);
            this.reportViewer1.LocalReport.SetParameters(d);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }

        private void print3()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter aa = new ReportParameter("aa", "" + "NAME = " + ltag.Text);
            ReportParameter cc = new ReportParameter("cc", "" + ltag.Text);
            ReportParameter dd = new ReportParameter("dd", "" + tt.Text);
            ReportParameter bb = new ReportParameter("bb", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("aa", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("bb", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("cc", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("dd", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("ee", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("ff", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("gg", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri3", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(aa);
            this.reportViewer1.LocalReport.SetParameters(bb);
            this.reportViewer1.LocalReport.SetParameters(cc);
            this.reportViewer1.LocalReport.SetParameters(dd);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }


        private void print4()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter aaa = new ReportParameter("aaa", "" + "NAME = " + ltag.Text);
            ReportParameter ccc = new ReportParameter("ccc", "" + ltag.Text);
            ReportParameter ddd = new ReportParameter("ddd", "" + tt.Text);
            ReportParameter bbb = new ReportParameter("bbb", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("aaa", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("bbb", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("ccc", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("ddd", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("eee", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("fff", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("ggg", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri4", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(aaa);
            this.reportViewer1.LocalReport.SetParameters(bbb);
            this.reportViewer1.LocalReport.SetParameters(ccc);
            this.reportViewer1.LocalReport.SetParameters(ddd);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }

        private void print5()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter aaaa = new ReportParameter("aaaa", "" + "NAME = " + ltag.Text);
            ReportParameter cccc = new ReportParameter("cccc", "" + ltag.Text);
            ReportParameter dddd = new ReportParameter("dddd", "" + tt.Text);
            ReportParameter bbbb = new ReportParameter("bbbb", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("aaaa", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("bbbb", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("cccc", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("dddd", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("eeee", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("ffff", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("gggg", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri5", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(aaaa);
            this.reportViewer1.LocalReport.SetParameters(bbbb);
            this.reportViewer1.LocalReport.SetParameters(cccc);
            this.reportViewer1.LocalReport.SetParameters(dddd);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }
        private void print6()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter aaaaa = new ReportParameter("aaaaa", "" + "NAME = " + ltag.Text);
            ReportParameter ccccc = new ReportParameter("ccccc", "" + ltag.Text);
            ReportParameter ddddd = new ReportParameter("ddddd", "" + tt.Text);
            ReportParameter bbbbb = new ReportParameter("bbbbb", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("aaaaa", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("bbbbb", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("ccccc", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("ddddd", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("eeeee", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("fffff", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("ggggg", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri6", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(aaaaa);
            this.reportViewer1.LocalReport.SetParameters(bbbbb);
            this.reportViewer1.LocalReport.SetParameters(ccccc);
            this.reportViewer1.LocalReport.SetParameters(ddddd);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }
        private void print7()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter aaaaaa = new ReportParameter("aaaaaa", "" + "NAME = " + ltag.Text);
            ReportParameter cccccc = new ReportParameter("cccccc", "" + ltag.Text);
            ReportParameter dddddd = new ReportParameter("dddddd", "" + tt.Text);
            ReportParameter bbbbbb = new ReportParameter("bbbbbb", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("aaaaaa", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("bbbbbb", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("cccccc", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("dddddd", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("eeeeee", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("ffffff", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("gggggg", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri7", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(aaaaaa);
            this.reportViewer1.LocalReport.SetParameters(bbbbbb);
            this.reportViewer1.LocalReport.SetParameters(cccccc);
            this.reportViewer1.LocalReport.SetParameters(dddddd);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }
        private void print8()
        {
            // ReportParameter Title = new ReportParameter("Title", "" + textBox1.Text);
            ReportParameter aaaaaaa = new ReportParameter("aaaaaaa", "" + "NAME = " + ltag.Text);
            ReportParameter ccccccc = new ReportParameter("ccccccc", "" + ltag.Text);
            ReportParameter ddddddd = new ReportParameter("ddddddd", "" + tt.Text);
            ReportParameter bbbbbbb = new ReportParameter("bbbbbbb", "" + "OCCUPATION : " + occ);
            DataSet DataSet1 = new DataSet();
            DataTable DataTable1 = new DataTable();

            DataRow dr;

            DataColumn dc1 = new DataColumn("aaaaaaa", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("bbbbbbb", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("ccccccc", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("ddddddd", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("eeeeeee", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("fffffff", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("ggggggg", Type.GetType("System.String"));

            DataTable1.Columns.Add(dc1);
            DataTable1.Columns.Add(dc2);
            DataTable1.Columns.Add(dc3);
            DataTable1.Columns.Add(dc4);
            DataTable1.Columns.Add(dc5);
            DataTable1.Columns.Add(dc6);
            DataTable1.Columns.Add(dc7);
            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = DataTable1.NewRow();
                dr[0] = rd["date"].ToString();
                dr[1] = rd["fulln"].ToString();
                dr[2] = rd["agency"].ToString();
                dr[3] = rd["amount"].ToString();
                dr[4] = rd["share"].ToString();
                dr[5] = rd["indi"].ToString();
                dr[6] = rd["total"].ToString();
                DataTable1.Rows.Add(dr);
            }
            rd.Close();
            DataSet1.Tables.Add(DataTable1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Environment.CurrentDirectory + "\\Report2.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("pri8", DataSet1.Tables[0]);
            //ReportDataSource rdss = new ReportDataSource("pri2", DataSet1.Tables[0]);

            //this.rptViewer.LocalReport.SetParameters(Title);
            this.reportViewer1.LocalReport.SetParameters(aaaaaaa);
            this.reportViewer1.LocalReport.SetParameters(bbbbbbb);
            this.reportViewer1.LocalReport.SetParameters(ccccccc);
            this.reportViewer1.LocalReport.SetParameters(ddddddd);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }









        private void mess()
        {
            if (tooo.Text == "")
            {
                string d;
                d = DateTime.Now.ToLongDateString();
                string bb = "Annoncesment";
                string sql = "UPDATE message SET froms='" + clsMySQL.llnm + "', tos = '" + bb + "', message = '" + messa.Text + "', date = '" + d + "'WHERE  id = " + 1;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Message Successfuly Send!", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                messas();
            }

            if (tooo.Text != "")
            {
                string d;
                d = DateTime.Now.ToLongDateString();
                string sql = "INSERT INTO message VALUES (null, '" + clsMySQL.llnm + "', '" + tooo.Text + "', '" + messa.Text + "', '" + d + "')";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Message Successfuly Send!", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }




        }



        private void messas()
        {
            string sql = "SELECT * FROM message where id= 1";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                messa.Text = (rd["message"].ToString());
            }

            rd.Close();
        }
        private void remind()
        {
            string sql = "SELECT * FROM reminder WHERE name like '%" + clsMySQL.llnm + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {

                rimind.Text = (rd["text"].ToString());
            }

            rd.Close();
        }







        private void mestlist()
        {

            string sql = "SELECT * FROM login ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            meslist.Items.Clear();
            while (rd.Read())
            {
                meslist.Items.Add(rd["id"].ToString());
                meslist.Items[meslist.Items.Count - 1].SubItems.Add(rd["lname"].ToString() + " ," + rd["fname"].ToString());
            }
            rd.Close();

        }



        private void meshis()
        {


            string sql = "SELECT * FROM message WHERE froms = '" + clsMySQL.llnm + "'" + "and tos='" + tooo.Text + "'" + "or froms='" + tooo.Text + "'" + "and tos='" + clsMySQL.llnm + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            messagelist.Items.Clear();
            while (rd.Read())
            {

                messagelist.Items.Add(rd["id"].ToString());
                messagelist.Items[messagelist.Items.Count - 1].SubItems.Add(rd["froms"].ToString());
                messagelist.Items[messagelist.Items.Count - 1].SubItems.Add(rd["message"].ToString());
                messagelist.Items[messagelist.Items.Count - 1].SubItems.Add(rd["date"].ToString());

            }
            rd.Close();




        }

        private void tot_Click(object sender, EventArgs e)
        {
            tot.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label2.Text = "0.00";
            label3.Text = "0.00";
            textBox1.Clear();
            textBox1.Focus();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            lagen.Clear();
            tot.Text = "0";
            Load_lastencode();
        }

        private void viewNoOfVisitorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ltag.Text = "No. of visitors";
            novistor();
            lmale.Visible = true;
            lchild.Visible = true;
            lfemale.Visible = true;
            panel20.BringToFront();
            panel20.Dock = DockStyle.Fill;
            labeltitle.Text = "";
        }
        private void novistor()
        {

            int chi = 0;
            int fel = 0;
            int mal = 0;
            int i = 1;
            string sql = "SELECT * FROM visitors";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listvisitor.Items.Clear();
            while (rd.Read())
            {
                listvisitor.Items.Add(rd["id"].ToString());
                listvisitor.Items[listvisitor.Items.Count - 1].SubItems.Add(i.ToString());
                listvisitor.Items[listvisitor.Items.Count - 1].SubItems.Add(rd["children"].ToString());
                listvisitor.Items[listvisitor.Items.Count - 1].SubItems.Add(rd["female"].ToString());
                listvisitor.Items[listvisitor.Items.Count - 1].SubItems.Add(rd["male"].ToString());
                listvisitor.Items[listvisitor.Items.Count - 1].SubItems.Add(rd["country"].ToString());
                listvisitor.Items[listvisitor.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                chi = chi + int.Parse(rd["children"].ToString());
                fel = fel + int.Parse(rd["female"].ToString());
                mal = mal + int.Parse(rd["male"].ToString());
                i++;
            }

            lchild.Text = "Children: " + chi;
            lfemale.Text = "Female: " + fel;
            lmale.Text = "Male: " + mal;
            rd.Close();
            lb1.Text = "  Total no. of visitors : " + ((Convert.ToInt64(chi)) + (Convert.ToInt64(fel)) + (Convert.ToInt64(mal)));


        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lagen.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tot.Focus();
            }

        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }


        private void s1_Click(object sender, EventArgs e)
        {
            

           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void tsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tsearch.Text != "" || tsearch.Text != "Search here...")
                {
                    Search(tsearch.Text);
                }

             

                if (tsearch.Text != "" || tsearch.Text != "Search here...")
                {
                    Searchss(tsearch.Text);
                }

                
            }

       
        }
        private void Searchss(string sSearch)
        {

            int i = 1;
            string sql = "SELECT * FROM Agency WHERE agency like '%" + sSearch + "%' or  count like '%" + sSearch + "%' order by agency ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listgen.Items.Clear();
            while (rd.Read())
            {

                listgen.Items.Add(rd["id"].ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(i.ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                listgen.Items[listgen.Items.Count - 1].SubItems.Add(rd["count"].ToString());
                i++;

            }
            rd.Close();
            lb1.Text = "  Total records : " + listgen.Items.Count;
            int x;
            for (x = 0; x <= listgen.Items.Count - 2; x += 2) ;


        }
        private void Search(string sSearch)
        {
            int i = 1;
            string sql = "SELECT * FROM summary  WHERE fulln like '%" + sSearch + "%' or  agency like '%" + sSearch + "%' or  occ like '%" + sSearch + "%' order by fulln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsumss.Items.Clear();
            while (rd.Read())
            {

                viewsumss.Items.Add(rd["id"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(i.ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["amount"].ToString());
                i++;
            }

            rd.Close();


        }
        
       
        private void button11_Click_1(object sender, EventArgs e)
        {
            string d;
            d = DateTime.Now.ToLongDateString();
            string sql = "UPDATE reminder SET text='" + rimind.Text + "', date = '" + d + "'WHERE name =  '" + clsMySQL.llnm + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reminder Successfuly Update!", " Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            remind();
        }

        private void meslist_Click(object sender, EventArgs e)
        {
            meshis();
            string sql = "SELECT * FROM login where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                tooo.Text = (rd["lname"].ToString() + " ," + rd["fname"].ToString());
            }
            rd.Close();
        }

        private void meslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = meslist.FocusedItem.Text;
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            panel21.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            remind();
            panel21.Location = new Point(308, 200);
            panel21.Height = 450;
            panel21.Width = 750;
            panel21.Visible = true;
            panel21.BringToFront();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel15.Visible = false;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

            mestlist();
            messas();
            panel15.Location = new Point(308, 200);
            panel15.Height = 450;
            panel15.Width = 750;
            panel15.Visible = true;
            panel15.BringToFront();
        }

        private void lisprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = listprint.FocusedItem.Text;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            lmale.Visible = false;
            lchild.Visible = false;
            lfemale.Visible = false;
            lmale.Visible = false;
            lchild.Visible = false;
            lfemale.Visible = false;
            panel2.Visible = true;
            labeltitle.Text = "";
            s1.Visible = false;
            tsearch.Visible = false;
            timer1.Start();
            panel2.BringToFront();
            b1.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.Gray;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            mess();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Delete from allss where id = " + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    view();
                    HD3();
                    MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                adate.ForeColor = SystemColors.ControlDarkDark;
                aname.ForeColor = SystemColors.ControlDarkDark;
                aagen.ForeColor = SystemColors.ControlDarkDark;
                aname.ForeColor = SystemColors.ControlDarkDark;
                panel3.Location = new Point(308, 200);
                panel3.Visible = true;
                panel3.Height = 450;
                panel3.Width = 750;
                viewsums.Items.Clear();
                panel3.BringToFront();
                button7.Text = "Update";
                atview();

            }
            else MessageBox.Show("Please select you want to Update ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
        }
        private void atview()
        {

            string sql = "SELECT * FROM allss where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                aname.Text = rd["fulln"].ToString();
                aagen.Text = rd["agency"].ToString();
                adate.Text = rd["date"].ToString();
            }
            rd.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Update?", "Attendance ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = " UPDATE allss SET fulln='" + aname.Text + "' ,agency= '" + aagen.Text + "', date = '" + adate.Text + "' WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendance Successfully Update!", "Update Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                H11();
                view();
                panel3.Visible = false;
            }
            else return;
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                t2.ForeColor = SystemColors.ControlDarkDark;

                t4.ForeColor = SystemColors.ControlDarkDark;
                t5.ForeColor = SystemColors.ControlDarkDark;
                panel9.Location = new Point(308, 200);
                panel9.Visible = true;
                panel9.Height = 450;
                panel9.Width = 750;
                viewsum.Items.Clear();
                panel9.BringToFront();
                string sql = "SELECT * FROM summary where id = " + SID;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();
                while (rd.Read())
                {

                    clsMySQL.f11 = (rd["fulln"].ToString());
                    clsMySQL.f21 = (rd["occ"].ToString());
                    clsMySQL.f31 = (rd["agency"].ToString());

                }
                rd.Close();
                Loads();
            }
            else MessageBox.Show("Please select you want to Edit ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Delete from summary where id = " + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    dels();
                    HD();
                    Load_Data();
                    MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Please select you want to Delete ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
      

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            printnames();
            labeltitle.Text = "View by Name";
            panel2.Visible = false;
            ttt.Text = "Total Amount : ₱";
            ltag.Text = "Summary";
            psum.ContextMenuStrip = list2;
            ttt.Visible = true;
            tt.Visible = true;
            panel23.Visible = true;
            panel23.BringToFront();
            panel23.Dock = DockStyle.Fill;
            tt.Visible = true;
            tt.Text = "0.00";
            ltag.Visible = true;
            s1.Visible = true;
            tsearch.Visible = true;
            timer1.Start();
            if (isMenu1panelOpen)
            {
                panel2.Height -= 15;
                if (panel2.Height == 0)
                {
                    timer1.Stop();
                    isMenu1panelOpen = false;
                }
            }
            else if (!isMenu1panelOpen)
            {
                panel2.Height += 15;
                if (panel2.Height == 135)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }

            int i = 1;
            string sql = "SELECT * FROM summary order by fulln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsumss.Items.Clear();
            while (rd.Read())
            {

                viewsumss.Items.Add(rd["id"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(i.ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewsumss.Items[viewsumss.Items.Count - 1].SubItems.Add(rd["amount"].ToString());

                i++;

            }
            rd.Close();
            lb1.Text = "  Total records : " + viewsum.Items.Count;
            int x;
            for (x = 0; x <= viewsum.Items.Count - 2; x += 2) ;






        }

    }
}
