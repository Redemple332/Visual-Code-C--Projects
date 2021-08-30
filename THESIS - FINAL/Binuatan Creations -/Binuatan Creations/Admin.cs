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
//using Word = Microsoft.Office.Interop.Word;
namespace Binuatan_Creations

{

    public partial class Admin : Form
    {
        public string acc;
        public  int counterprint = 0;
        public string SID = null;
        public string NACC =null;
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
        public Admin()
        {

            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            InitializeComponent();
            // Create a list of accounts.
       
        }


        private void b1_Click(object sender, EventArgs e)
        {
            
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
            Load_Data();
            psum.Visible = true;
            psum.BringToFront();
            psum.Dock = DockStyle.Fill;
            tt.Visible = true;
            tt.Text = "0.00";
            ltag.Visible = true;
            s1.Visible = true;
            tsearch.Visible = true;

        }


      

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text != "" || tsearch.Text != "Search here...")
            {
                Search(tsearch.Text);
            }

            if (tsearch.Text != "" || tsearch.Text != "Search here...")
            {
                Searchs(tsearch.Text);
            }

            if (tsearch.Text != "" || tsearch.Text != "Search here...")
            {
                Searchss(tsearch.Text);
            }

            if (tsearch.Text != "" || tsearch.Text != "Search here...")
            {
                Searhistory(tsearch.Text);
            }
            if (tsearch.Text != "" || tsearch.Text != "Search here...")
            {
                SearATEND(tsearch.Text);
            }
        }
        
        private void tsearch_Click(object sender, EventArgs e)
        {
            tsearch.ForeColor = Color.Black;
            tsearch.Clear();
        }

        private void b3_Click(object sender, EventArgs e)
        {          
            labeltitle.Text = "";
            panel2.Visible = false;
            ltag.Text = "Attendance";
            patent.ContextMenuStrip = list;
            ttt.Visible = false;
            tt.Visible = false;
            b1.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.Gray;
            Load_attend();
            patent.Visible = true;
            patent.Dock = DockStyle.Fill;
            patent.BringToFront();
            tt.Visible = false;
      
        }

       

        private void viewat_SelectedIndexChanged(object sender, EventArgs e)
        {
 SID = viewat.FocusedItem.Text;
           
        }

        private void viewat_DoubleClick(object sender, EventArgs e)
        {
            lagen.ForeColor = SystemColors.ControlDarkDark;
            Pbar.Value = 0;
            lagen.Focus();
            button2.Text = "Save";
            sum();
            newp();
            panel6.Visible = true;
            panel6.BringToFront();
            viewat.Items.Clear();
            tot.Clear();
            label3.Text = "0.00";
            label2.Text = "0.00";

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want Enter this Amount?", "Attendance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (button2.Text == "Save")
                {
                    tPbar.Start();
                    Pbar.Visible = true;
                }
            }
            if (tot.Text != "" && button2.Text == "Update")
            {
                if(ltag.Text=="All record")
                {
                    H56();
                    load_amount();
                }
                else {
                    HD2();
                    load_amount();
                }
               
             
            }

            if(tot.Text == "")
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

                if (label2.Text != "Total sale" && clsMySQL.tno == "1")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (B)).ToString();
                }
                if (label2.Text != "Total sale" && clsMySQL.tno == "2")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (C)).ToString();
                }
                if (label2.Text != "Total sale" && clsMySQL.tno == "3")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (D)).ToString();
                }
                if (label2.Text != "Total sale" && clsMySQL.tno == "4")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (E)).ToString();
                }
                if (label2.Text != "Total sale" && clsMySQL.tno == "5")
                {
                    label3.Text = (Convert.ToDouble(label2.Text) / (F)).ToString();
                }


            }
        }
     
        private void bu_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            ltag.Text = "Select name";
            b1.BackColor = Color.FromArgb(0, 189, 241);
            b6.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.FromArgb(0, 189, 241);
            b3.BackColor = Color.FromArgb(0, 189, 241);
            b4.BackColor = Color.FromArgb(0, 189, 241);
            b5.BackColor = Color.FromArgb(0, 189, 241);
            b2.BackColor = Color.Gray;

            if (MessageBox.Show("Are you sure you want to open attendance system?", "Attendance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                Form b = new LOADING();
                b.Show();
                this.Visible = false;
                clsMySQL.loadings = "Scanner";
            }
            else
                b2.BackColor = Color.FromArgb(0, 189, 241);
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
        
        private void Admin_Load(object sender, EventArgs e)
        {
            
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

        private void accview_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = accview.FocusedItem.Text;
        }
       
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Activate this Account?", "Activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = " UPDATE login SET status = '" + "Active" + "'WHERE id=" + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery(); LoadAcc_Data();
                    MessageBox.Show("Account has been Deactivated Successfuly! ", " Account Deactivation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAcc_Data();
                    H3();
                    return;

                }
            }
            else MessageBox.Show("Please select account you want to Activate ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accstat();

            if (SID != null && clsMySQL.AU != "Admin")
            {

            if (MessageBox.Show("Are you sure you want to Deactivate this Account?", "Account Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = " UPDATE login SET status = '" + "Deactive" + "'WHERE id=" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery(); LoadAcc_Data();
                MessageBox.Show("Account has been Activated Successfuly! ", " Account Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAcc_Data();
                H4();
            }
            }
            else MessageBox.Show("Please select account you want to Deactivate ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form b = new Creatacc();
            b.Show();
            this.Visible = false;
        }

        private void view1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = view1.FocusedItem.Text;
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
                if (panel2.Height == 165)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }
        }
      



        private void dELETEALLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Delete all ?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM history";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                History_Data();
                MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else return;

        }

        private void dELETEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Delete from history where id = " + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    History_Data();

                    MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Please select  you want to Delete", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      

        }

        private void button1_Click(object sender, EventArgs e)
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
                if (panel2.Height == 165)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }
            s1.Visible = true;
            tsearch.Visible = true;
            tt.Visible = false;
            ttt.Visible = false;
            ltag.Text = "Accounts";
            pac.Visible = true;
            pac.BringToFront();
            pac.Dock = DockStyle.Fill;
            LoadAcc_Data();
            panel2.BringToFront();
            accview.ContextMenuStrip = cmsacc;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Save")
            {
                SID = null;
                b3.PerformClick();
                tot.Clear();
                label3.Text = "0.00";
                label2.Text = "0.00";
            }
            if (button2.Text == "Update")
            {
                SID = null;
                panel6.Visible = false;
            }


        }

     
      
        private void button3_Click_1(object sender, EventArgs e)
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
                if (panel2.Height == 165)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }

            ALL();
            ttt.Text = "    Total Sales: ₱";

                s1.Visible = true;
            tsearch.Visible = true;
            allss.ContextMenuStrip = list4;
            ltag.Text = "All records";
            pall.Visible = true;
            pall.BringToFront();
            pall.Dock = DockStyle.Fill;
            all_Data();
            panel2.BringToFront();
                tt.Visible = true;
                ttt.Visible = true;
            
                
 
        }

        private void allss_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = allss.FocusedItem.Text;
        }



        private void button4_Click(object sender, EventArgs e)
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
                if (panel2.Height == 165)
                {
                    timer1.Stop();
                    isMenu1panelOpen = true;
                }
            }
            tsearch.Visible = true;
            s1.Visible = true;
            tt.Visible = false;
            ltag.Text = "History";
            ttt.Visible = false;
            phis.Visible = true;
            phis.Dock = DockStyle.Fill;
            phis.BringToFront();
            panel2.BringToFront();
            History_Data();
            view1.ContextMenuStrip = history;
        }

        private void Histo_Data()
        {
            int i = 1;
            string sql = "SELECT * FROM history where name=  '" + acc + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            view1.Items.Clear();
            while (rd.Read())
            {

                view1.Items.Add(rd["id"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(i.ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["event"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["who"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                i++;
            }
            rd.Close();
            lb1.Text = "  Total records : " + view1.Items.Count;
            int x;
            for (x = 0; x <= view1.Items.Count - 2; x += 2) ;


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
        private void accview_DoubleClick(object sender, EventArgs e)
        {
            jjj();
            Histo_Data();
            ltag.Text = "History";
            phis.Visible = true;
            phis.Dock = DockStyle.Fill;
            phis.BringToFront();
            panel2.BringToFront();
            view1.ContextMenuStrip = history;

        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            if( button5.Text == "Save" && su.Text != "" && sp.Text != "") 
            {
        if (MessageBox.Show("Are you sure you want to Update?", "Account ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = " UPDATE login SET fname='" + sf.Text + "', lname = '" + sl.Text + "' ,contact= '" + sc.Text + "', secq = '" + sq.Text + "', ans = '" + sa.Text + "', pass = '" + sp.Text + "', user = '" + su.Text + "' WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Successfully Update!", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                H5();
                ShowAcc_Data();
                button1.PerformClick();
                coo();
            }
            else return;
            }
          
            if (button5.Text == "Update" && su.Text!="" && sp.Text != "")
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

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                sf.ForeColor = SystemColors.ControlDarkDark;
                su.ForeColor = SystemColors.ControlDarkDark;
                button5.Text = "Save";
                pshowacc.Visible = true;
                pshowacc.BringToFront();
                pshowacc.Dock = DockStyle.Fill;
                ShowAcc_Data();
            }
            else MessageBox.Show("Please select account you want to View/Edit ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      

        }

      

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {

                if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Delete from new where id = " + SID;
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                    Load_attend();
                    H1();
                    MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Please select you want to Delete ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
                adate.ForeColor = SystemColors.ControlDarkDark;
                aoc.ForeColor = SystemColors.ControlDarkDark;
                aname.ForeColor = SystemColors.ControlDarkDark;
                aagen.ForeColor = SystemColors.ControlDarkDark;
                aname.ForeColor = SystemColors.ControlDarkDark;
                panel3.Location = new Point(308, 200);
                panel3.Visible = true;
                panel3.Height = 450;
                panel3.Width = 750;
                viewsum.Items.Clear();
                panel3.BringToFront();
                button7.Text = "Update";
                atview();
                viewat.Items.Clear();
            }
            else MessageBox.Show("Please select you want to Update ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
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

        private void viewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {
            labeltitle.Text = "Personal Data";
            view();
            }
            else MessageBox.Show("Please select you want to View ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
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
          else MessageBox.Show("Please select you want to View ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
        }

     
       

       

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
            if (SID != null)
            {
            
            alledi();
            button2.Text = "Update";
            panel6.Visible = true;
            panel6.BringToFront();
            tot.Text = clsMySQL.ttq;
             }
            else MessageBox.Show("Please select you want to Update ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
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

        private void toolStripMenuItem4_Click(object sender, EventArgs e)

        {if (SID != null)
            {
            alledi();
            button2.Text = "Update";
            panel6.Visible = true;
            panel6.BringToFront();
            tot.Text = clsMySQL.ttq;
            ALL();
                         }
            else MessageBox.Show("Please select you want to Update ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      

        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {if (SID != null)
            {
            t2.ForeColor = SystemColors.ControlDarkDark;
            t3.ForeColor = SystemColors.ControlDarkDark;
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
                clsMySQL.f51 = (rd["gender"].ToString());
                clsMySQL.f21 = (rd["occ"].ToString());
                clsMySQL.f31 = (rd["agency"].ToString());
                clsMySQL.f41 = (rd["qr"].ToString());

            }
            rd.Close();
            Loads();
            }
        else MessageBox.Show("Please select you want to Edit ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      


        }

     
        private void viewByToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
           
        }
       
       

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b1.PerformClick();
        }




        
        private void viewat_Click(object sender, EventArgs e)
        {
            newp();
        }
      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            b1.PerformClick();
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            if (t2.Text == "" || t3.Text == "" || t4.Text == "" || t5.Text == "" || tqr.Text == "")
            {
                MessageBox.Show("Please complete all information needed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Update?", "Attendance ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = " UPDATE summary SET fulln='" + t2.Text + "', occ = '" + t4.Text + "' ,agency= '" + t5.Text + "', gender = '" + t3.Text + "', date = now()  WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                HD1();
                b1.PerformClick();
                t2.ForeColor = SystemColors.ControlDarkDark;
                t3.ForeColor = SystemColors.ControlDarkDark;
                t4.ForeColor = SystemColors.ControlDarkDark;
                t5.ForeColor = SystemColors.ControlDarkDark;
                MessageBox.Show("Profile Successfully Update!", "Update Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update?", "Attendance ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = " UPDATE new SET fulln='" + aname.Text + "', occ = '" + aoc.Text + "' ,agency= '" + aagen.Text + "', Date = '" + adate.Text + "' WHERE id =" + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendance Successfully Update!", "Update Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                H11();
                b3.PerformClick();
            }
            else return;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            b3.PerformClick();
        }

        private void button6_Click_1(object sender, EventArgs e)
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
                if (panel2.Height == 165)
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
                tot.Focus();
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
            string sql = "SELECT * FROM summary order by amount *1 DESC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsum.Items.Clear();
            while (rd.Read())
            {

                viewsum.Items.Add(rd["id"].ToString());

                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(i.ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["qr"].ToString());
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

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (SID != null)
            {

            if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              
                string sql = "Delete from Agency where id = " + SID;
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                Load_agen();


                MessageBox.Show("DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             }
         else MessageBox.Show("Please select you want to Delete ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
      
        }
     
        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_agen();
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_agens();
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
                COPRINT.Text = ""+ counterprint +"/8";
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
            if (counterprint == 9 )
            {
                 MessageBox.Show("Paper is Already full / Maximum of 8 person", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information);     

            }
            }
        else MessageBox.Show("Please select you want to add to Print ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information); 
      
        }

       
        private void lisprint_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
       
       

        private void tPbar_Tick(object sender, EventArgs e)
        {
            if (button2.Text == "Save") {
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
                        H2();
                        tr();
                        del();
                        b3.PerformClick();
                        label3.Text = "0.00";
                        label2.Text = "0.00";

                    }
                }
            }
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (labeltitle.Text == "View by Name" )
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
                    DataColumn dc2 = new DataColumn("QR", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("Name", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("Occupation", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("Agency", Type.GetType("System.String"));
                    DataColumn dc6 = new DataColumn("Amount", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);
                    DataTable1.Columns.Add(dc6);


                    int i = 1;
                    string sql = "SELECT * FROM summary order by fulln ASC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();
                        dr[0] = i;
                        dr[1] = rd["qr"].ToString();
                        dr[2] = rd["fulln"].ToString();
                        dr[3] = rd["occ"].ToString();
                        dr[4] = rd["agency"].ToString();
                        dr[5] = rd["amount"].ToString();

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

            if(labeltitle.Text == "View by Amount" )
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
                    DataColumn dc2 = new DataColumn("QR", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("Name", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("Occupation", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("Agency", Type.GetType("System.String"));
                    DataColumn dc6 = new DataColumn("Amount", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);
                    DataTable1.Columns.Add(dc6);


                    int i = 1;
                    string sql = "SELECT * FROM summary order by amount *1 DESC";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    MySqlDataReader rd = sql_cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dr = DataTable1.NewRow();
                        dr[0] = i;
                        dr[1] = rd["qr"].ToString();
                        dr[2] = rd["fulln"].ToString();
                        dr[3] = rd["occ"].ToString();
                        dr[4] = rd["agency"].ToString();
                        dr[5] = rd["amount"].ToString();

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
                    DataColumn dc4 = new DataColumn("occ", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("agency", Type.GetType("System.String"));
                    DataColumn dc6 = new DataColumn("sales", Type.GetType("System.String"));
                    DataColumn dc7 = new DataColumn("share", Type.GetType("System.String"));
                    DataColumn dc8 = new DataColumn("indi", Type.GetType("System.String"));
                    DataColumn dc9 = new DataColumn("total", Type.GetType("System.String"));

                    DataTable1.Columns.Add(dc1);
                    DataTable1.Columns.Add(dc2);
                    DataTable1.Columns.Add(dc3);
                    DataTable1.Columns.Add(dc4);
                    DataTable1.Columns.Add(dc5);
                    DataTable1.Columns.Add(dc6);
                    DataTable1.Columns.Add(dc7);
                    DataTable1.Columns.Add(dc8);
                    DataTable1.Columns.Add(dc9);

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
                        dr[3] = rd["occ"].ToString();
                        dr[4] = rd["agency"].ToString();
                        dr[5] = rd["amount"].ToString();
                        dr[6] = rd["share"].ToString();
                        dr[7] = rd["indi"].ToString();
                        dr[8] = rd["total"].ToString();

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
                    string sql = "SELECT * FROM agency";
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

        private void time_MouseHover(object sender, EventArgs e)
        {
            
        }

       


        private void aagen_Click(object sender, EventArgs e)
        {
            aagen.ForeColor = Color.Black;
        }

        private void aoc_Click(object sender, EventArgs e)
        {
            aoc.ForeColor = Color.Black;
        }

        private void adate_Click(object sender, EventArgs e)
        {
            adate.ForeColor = Color.Black;
        }

        private void aname_Click(object sender, EventArgs e)
        {
            aname.ForeColor = Color.Black;
        }

        private void tsearch_Leave(object sender, EventArgs e)
        {
            if (tsearch.Text == "")
            {
                tsearch.Text = "Search here...";
                tsearch.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void time_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void date_Click(object sender, EventArgs e)
        {
            monthCalendar1.BringToFront();
            monthCalendar1.Visible = true;
        }

       


        private void sf_Click(object sender, EventArgs e)
        {
            sf.ForeColor = Color.Black;
        }

        private void sl_Click(object sender, EventArgs e)
        {
            sl.ForeColor = Color.Black;
        }

        private void su_Click(object sender, EventArgs e)
        {
            su.ForeColor = Color.Black;
        }

        private void sc_Click(object sender, EventArgs e)
        {
            sc.ForeColor = Color.Black;
        }

        private void sq_Click(object sender, EventArgs e)
        {
            sq.ForeColor = Color.Black;
        }

        private void sa_Click(object sender, EventArgs e)
        {
            sa.ForeColor = Color.Black;
        }

        private void sp_Click(object sender, EventArgs e)
        {
            sp.ForeColor = Color.Black;
        }

        private void label31_Click(object sender, EventArgs e)
        {
            button5.Text = "Update";
            pshowacc.BringToFront();
            pshowacc.Visible = true;
            pshowacc.Dock = DockStyle.Fill;
            Myacc_Data();
        }

        private void t2_Click(object sender, EventArgs e)
        {
            t2.ForeColor = Color.Black;
        }

        private void t5_Click(object sender, EventArgs e)
        {
            t5.ForeColor = Color.Black;
        }

        private void t3_Click(object sender, EventArgs e)
        {
            t3.ForeColor = Color.Black;
        }

        private void t4_Click(object sender, EventArgs e)
        {
            t4.ForeColor = Color.Black;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

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
                        workSheet.Cells[row, "B"] = rd["qr"].ToString();
                        workSheet.Cells[row, "C"] = rd["fulln"].ToString();
                        workSheet.Cells[row, "D"] = rd["occ"].ToString();
                        workSheet.Cells[row, "E"] = rd["agency"].ToString();
                        workSheet.Cells[row, "F"] = rd["amount"].ToString();
                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "QR";
                    workSheet.Cells[1, "C"] = "Name";
                    workSheet.Cells[1, "D"] = "Occupation";
                    workSheet.Cells[1, "E"] = "Agency";
                    workSheet.Cells[1, "F"] = "Amount";
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
                        workSheet.Cells[row, "B"] = rd["qr"].ToString();
                        workSheet.Cells[row, "C"] = rd["fulln"].ToString();
                        workSheet.Cells[row, "D"] = rd["occ"].ToString();
                        workSheet.Cells[row, "E"] = rd["agency"].ToString();
                        workSheet.Cells[row, "F"] = rd["amount"].ToString();
                        i++;

                    }
                    rd.Close();
                    workSheet.Cells[1, "A"] = "ID";
                    workSheet.Cells[1, "B"] = "QR";
                    workSheet.Cells[1, "C"] = "Name";
                    workSheet.Cells[1, "D"] = "Occupation";
                    workSheet.Cells[1, "E"] = "Agency";
                    workSheet.Cells[1, "F"] = "Amount";
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


            if (labeltitle.Text != "View by Name" && labeltitle.Text != "View by Amount" && labeltitle.Text == "" && ltag.Text != "All records" && ltag.Text != "Agency List")
            {
                MessageBox.Show("This File can't Convert into Exel File", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

    }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            maxi.BringToFront();
            maxi.Visible = true;
            this.Location = new Point(100, 30);
     
        }

        private void pictureBox14_Click(object sender, EventArgs e)
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

        private void lagen_TextChanged(object sender, EventArgs e)
        {
            lagen.ForeColor = Color.Black;
          
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

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            if (counterprint == 8 || counterprint == 9)
            {
                pnlprint.BringToFront();
                pnlprint.Dock = DockStyle.Fill;
            }
            else MessageBox.Show("Please Select more person / minimum of 8 person [" +counterprint +"/8" +"]", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            viewsum.Items.Clear();
            while (rd.Read())
            {

                viewsum.Items.Add(rd["id"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(i.ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["qr"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["amount"].ToString());
                i++;
            }

            rd.Close();


        }
        private void Searchs(string sSearchs)
        {

            int i = 1;
            string sql = "SELECT * FROM allss  WHERE fulln like '%" + sSearchs + "%' or  agency like '%" + sSearchs + "%' or  occ like '%" + sSearchs + "%' or  date like '%" + sSearchs + "%' order by fulln ASC";
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
        private void Searhistory(string sSearchs)
        {

            int i = 1;
            string sql = "SELECT * FROM history  WHERE name like '%" + sSearchs + "%' or  event like '%" + sSearchs + "%' or  who like '%" + sSearchs + "%' or  date like '%" + sSearchs + "%' order by name ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            view1.Items.Clear();
            while (rd.Read())
            {

                view1.Items.Add(rd["id"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(i.ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["event"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["who"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["date"].ToString());

                i++;
            }

            rd.Close();
            lb1.Text = "  Total records : " + view1.Items.Count;
            int x;
            for (x = 0; x <= view1.Items.Count - 2; x += 2) ;




        }
        private void SearATEND(string sSearchs)
        {


            int i = 1;
            string sql = "SELECT * FROM new  WHERE fulln like '%" + sSearchs + "%' or  occ like '%" + sSearchs + "%' or  agency like '%" + sSearchs + "%' or  Date like '%" + sSearchs + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewat.Items.Clear();
            while (rd.Read())
            {

                viewat.Items.Add(rd["id"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(i.ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["Date"].ToString());

                i++;
            }
            rd.Close();
            lb1.Text = "  Total records : " + viewat.Items.Count;
            int x;
            for (x = 0; x <= viewat.Items.Count - 2; x += 2) ;
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



        private void alledi()
        {

            clsMySQL.ttq = null;
            clsMySQL.ttw = null;
            clsMySQL.tte = null;
            clsMySQL.tno = null;
            string sql = "SELECT * FROM allss where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                lane.Text = "Name: " + (rd["fulln"].ToString());
                clsMySQL.ttq = (rd["amount"].ToString());
                clsMySQL.tno = (rd["no"].ToString());
                lagen.Text = (rd["agency"].ToString());
                clsMySQL.tte = (rd["fulln"].ToString());
            }
            rd.Close();

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
                    panel6.Visible = false;
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
            tqr.Text = clsMySQL.f41;
            t3.Text = clsMySQL.f51;
        }


        private void H1()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "DELETE ATTENDANCE" + "', '" + clsMySQL.tte + "', '" + date.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void H11()
        {
            string sql = "INSERT INTO history  VALUES (null, '" + clsMySQL.llnm + "', '" + "EDIT ATTENDANCE" + "', '" + clsMySQL.tte + "', '" + date.Text + "')";
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
        private void atview()
        {

            string sql = "SELECT * FROM new where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                aname.Text = rd["fulln"].ToString();
                aagen.Text = rd["agency"].ToString();
                aoc.Text = rd["occ"].ToString();
                adate.Text = rd["Date"].ToString();
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
            string sql = "SELECT * FROM allSS";
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
            string sql = "SELECT * FROM summary order by fulln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewsum.Items.Clear();
            while (rd.Read())
            {

                viewsum.Items.Add(rd["id"].ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(i.ToString());
                viewsum.Items[viewsum.Items.Count - 1].SubItems.Add(rd["qr"].ToString());
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



        private void Load_attend()
        {
            int i = 1;
            string sql = "SELECT * FROM new ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            viewat.Items.Clear();
            while (rd.Read())
            {

                viewat.Items.Add(rd["id"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(i.ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["fulln"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["occ"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["agency"].ToString());
                viewat.Items[viewat.Items.Count - 1].SubItems.Add(rd["Date"].ToString());

                i++;
            }
            rd.Close();
            lb1.Text = "  Total records : " + viewat.Items.Count;
            int x;
            for (x = 0; x <= viewat.Items.Count - 2; x += 2) ;
        }

        private void newp()
        {
            string sql = "SELECT * FROM new where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {
                lane.Text = "Name: " + (rd["fulln"].ToString());
                clsMySQL.ttq = (rd["occ"].ToString());
                lagen.Text = (rd["agency"].ToString());
                clsMySQL.tte = (rd["fulln"].ToString());
                clsMySQL.tno = (rd["no"].ToString());
                clsMySQL.dd = (rd["Date"].ToString());

            }

            rd.Close();

        }
        private void sum()
        {
            string sql = "SELECT * FROM allss where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            while (rd.Read())
            {


                clsMySQL.tooot = (rd["total"].ToString());
            }

            rd.Close();
        }

        public void del()
        {
            string sql = "DELETE  FROM new where id = " + SID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        public void tr()
        {
            string sql = "INSERT INTO allss VALUES (null,'" + clsMySQL.tte + "','" + clsMySQL.ttq + "','" + lagen.Text + "','" + tot.Text + "','" + label2.Text + "','" + label3.Text + "','" + label3.Text + "','" + clsMySQL.tno + "','" + clsMySQL.dd + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

        }
        public void up()
        {
            string sql = "UPDATE summary SET amount='" + tt.Text + "'WHERE fulln =  '" + ltag.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }
        private void History_Data()
        {
            int i = 1;
            string sql = "SELECT * FROM history order by id desc";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            view1.Items.Clear();
            while (rd.Read())
            {

                view1.Items.Add(rd["id"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(i.ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["event"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["who"].ToString());
                view1.Items[view1.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                i++;
            }
            rd.Close();
            lb1.Text = "  Total records : " + view1.Items.Count;
            int x;
            for (x = 0; x <= view1.Items.Count - 2; x += 2) ;


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

            string sql = "SELECT * FROM allss WHERE fulln like '%" + ltag.Text + "%'";
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

        private void LoadAcc_Data()
        {
            int i = 1;
            string sql = "SELECT * FROM login ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            accview.Items.Clear();
            while (rd.Read())
            {
                accview.Items.Add(rd["id"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(i.ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["lname"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["user"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["pass"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["intime"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["outime"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["status"].ToString());
                accview.Items[accview.Items.Count - 1].SubItems.Add(rd["Administrator"].ToString());
                acc = rd["lname"].ToString() + " ," + rd["fname"].ToString();
                i++;
            }
            rd.Close();
            lb1.Text = "  Total records : " + accview.Items.Count;
            int x;
            for (x = 0; x <= accview.Items.Count - 2; x += 2) ;
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


        private void deleteAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all records the in this table?", "Delete all record data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "Delete from allss ";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                ALL();

                MessageBox.Show("ALL FILE DELETED SUCCESSFULLY!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else return;
        }

        private void ALL()
        {

            float t = 0;
            int i = 1;
            string sql = "SELECT * FROM allss";
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
            string sql = "SELECT * FROM Agency order by agency *1 DESC";
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
        private void Load_agens()
        {
            int i = 1;
            string sql = "SELECT * FROM Agency order by count  DESC";
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

        private void listprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = listprint.FocusedItem.Text;
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            
            //    if (MessageBox.Show("Are you sure you want to Remove this name?", "Remove Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //       string sql = "DELETE  FROM print where id = " + SID;
            //MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            //cmd.ExecuteNonQuery();
            //if (counterprint != 9)
            //{
            //    this.reportViewer1.LocalReport.DataSources.Clear();  
            //    counterprint--;
            //    printnames();
            //    COPRINT.Text = "" + counterprint + "/8";
            //}
            //if (counterprint == 9)
            //{
            //    counterprint = counterprint - 2;
            //    printnames();
            //    COPRINT.Text = "" + counterprint + "/8";
            //}


            //    }    
        }

        private void panel13_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel13.Left += e.X - lastpoint.X;
                panel13.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel13_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel6.Left += e.X - lastpoint.X;
                panel6.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel15.Visible = false;
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
        private void pictureBox7_Click(object sender, EventArgs e)
        {

            remind();
            panel21.Location = new Point(308, 200);
            panel21.Height = 450;
            panel21.Width = 750;
            panel21.Visible = true;
            panel21.BringToFront();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            panel21.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string d;
            d = DateTime.Now.ToLongDateString();
            string sql = "UPDATE reminder SET text='" + rimind.Text + "', date = '" + d + "'WHERE name =  '" + clsMySQL.llnm + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reminder Successfuly Update!", " Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            remind();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mess();
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

        private void meslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            SID = meslist.FocusedItem.Text;
        }

        private void meslist_Click(object sender, EventArgs e)
        {
            meshis();
                 string sql = "SELECT * FROM login where id = " + SID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {               
            tooo.Text =  (rd["lname"].ToString() + " ," + rd["fname"].ToString());
            }
            rd.Close();
        }

        private void meshis()
        {

           
            string sql = "SELECT * FROM message WHERE froms = '" + clsMySQL.llnm + "'" + "and tos='" + tooo.Text + "'" + "or froms='" + tooo.Text + "'" + "and tos='" + clsMySQL.llnm +"'";
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

      
        ///////////////////////  END HERE //////////////////////////////////////////////////////////////////////

    }
} 

