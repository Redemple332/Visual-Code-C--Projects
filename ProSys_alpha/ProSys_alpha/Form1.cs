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

namespace ProSys_alpha
{
    public partial class Form1 : Form
    {
        MySqlCommand sql_cmd = new MySqlCommand();
        public string SID;
        public string sName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();

            ShowPanel(pHome);
            lvView.ContextMenuStrip = cmsMenu;
            tmTime.Start();
        }

        private void Load_Data(string sSql)
        {
            //Populate the Listview (lvView) with information from the DataBase
            //string sql = "SELECT * FROM tblstud ORDER BY ln ASC";
            sql_cmd = new MySqlCommand(sSql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            lvView.Items.Clear(); //Clear the listview before populating
            while (rd.Read())
            {
                lvView.Items.Add(rd["id"].ToString());
                lvView.Items[lvView.Items.Count - 1].SubItems.Add(rd["fn"].ToString() + " " + rd["ln"].ToString());
                lvView.Items[lvView.Items.Count - 1].SubItems.Add(rd["strand"].ToString());
                lvView.Items[lvView.Items.Count - 1].SubItems.Add(rd["mobile"].ToString());
            }
            rd.Close();
        }

        private void Search_Data(string z)
        {

            string sql = "SELECT * FROM tblstud WHERE fn LIKE '%" + z + "%' OR ln LIKE '%" + z + "%' OR strand LIKE '%" + z + "%' OR grade LIKE '%" + z + "%' ORDER BY ln ASC";
            Load_Data(sql);
        }

        private void ShowPanel(Panel z)
        {
            pHome.Visible = false;
            pStud.Visible = false;
            pAbout.Visible = false;
            pAERecord.Visible = false;
            pView.Visible = false;

            z.Visible = true;
            z.Dock = DockStyle.Fill;
        }

        private void ClearFields()
        {
            foreach (var z in this.pAERecord.Controls)
            {
                if (z is TextBox)
                {
                    ((TextBox)z).Clear();
                }
                if (z is ComboBox)
                {
                    ((ComboBox)z).Text = null;
                }
            }
        }

        private Boolean CheckFields() 
        {
            Boolean isEmpty = false;

            foreach (var z in this.pAERecord.Controls)
            {
                if (z is TextBox)
                {
                    if (((TextBox)z).Text == ""){
                        isEmpty = true;
                        ((TextBox)z).BackColor = Color.Maroon;

                    }
                }

                if (z is ComboBox)
                {
                    if (((ComboBox)z).Text == "")
                    {
                        isEmpty = true;
                    }
                }
            }

            return isEmpty;
        }

        private void ViewProfile(string sSID)
        {
            string sql = "SELECT * FROM tblstud WHERE id = " + sSID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                lbStudname.Text = (rd["fn"].ToString() + " " + rd["ln"].ToString());
                lbMotto.Text = (rd["motto"].ToString());
                lbGender.Text = (rd["gender"].ToString());
                lbStrand.Text = (rd["strand"].ToString());
                lbMobile.Text = (rd["mobile"].ToString());
                lbGrade.Text = (rd["grade"].ToString());
                lbAddress.Text = (rd["address"].ToString());
                lbEmail.Text = (rd["email"].ToString());
            }
            rd.Close();
        }

        private void EditProfile(string sSID)
        {
            string sql = "SELECT * FROM tblstud WHERE id = " + sSID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                tfn.Text = (rd["fn"].ToString());
                tln.Text = ( rd["ln"].ToString());
                tMotto.Text = (rd["motto"].ToString());
                cbGender.Text = (rd["gender"].ToString());
                cbStrand.Text = (rd["strand"].ToString());
                tMobile.Text = (rd["mobile"].ToString());
                cbGrade.Text = (rd["grade"].ToString());
                tAddress.Text = (rd["address"].ToString());
                tEmail.Text = (rd["email"].ToString());
            }
            rd.Close();
        }

        private void AddRecord()
        {
            string sql = "INSERT INTO tblstud (id, fn, ln, motto, gender, strand, mobile, grade, address, email) VALUES (null, '" + tfn.Text + "', '" + tln.Text + "', '" + tMotto.Text + "', '" + cbGender.Text + "', '" + cbStrand.Text + "', '" + tMobile.Text + "', '" + cbGrade.Text + "', '" + tAddress.Text + "', '" + tEmail.Text + "');";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("New Record has been Added Succesfully!", "Add Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateRecord(string sSID)
        {
            string sql = "UPDATE tblstud SET fn='" + tfn.Text + "', ln='" + tln.Text + "', motto='" + tMotto.Text + "', gender='" + cbGender.Text + "', strand='" + cbStrand.Text + "', mobile='" + tMobile.Text + "', grade='" + cbGrade.Text + "', address='" + tAddress.Text + "', email='" + tEmail.Text + "' WHERE id = " + sSID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record has been Updated Succesfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            ShowPanel(pHome);
        }

        private void bStud_Click(object sender, EventArgs e)
        {
            ShowPanel(pStud);
            Load_Data("SELECT * FROM tblstud ORDER BY ln ASC");
        }

        private void bView_Click(object sender, EventArgs e)
        {

            if (SID != null)
            {
                ShowPanel(pView);
                ViewProfile(SID);
            }
            else
            {
                MessageBox.Show("Please Select Record from the list.", "View Record",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowPanel(pStud);
            }

        }

        private void bAbout_Click(object sender, EventArgs e)
        {
            ShowPanel(pAbout);
        }

        private void lvView_Click(object sender, EventArgs e)
        {
            SID = lvView.FocusedItem.Text;
            sName = lvView.FocusedItem.SubItems[1].Text;
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete Record of " + sName  + "?", "Delete Record",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRecord(SID);
                Load_Data("SELECT * FROM tblstud ORDER BY ln ASC");
            }
        }

        private void DeleteRecord(string sSID)
        {
            string sql = "DELETE FROM tblstud WHERE id = " +sSID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record has been Deleted Succesfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmsView_Click(object sender, EventArgs e)
        {
            ShowPanel(pView);
            ViewProfile(SID);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (bSave.Text == "SAVE")
            {
                if (CheckFields() == true)
                {
                    MessageBox.Show("Please Complete the Information!", "Add Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to Save this Record of " + tfn.Text + " " + tln.Text + "?", "Add Record",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AddRecord();
                        bStud.PerformClick();
                    }
                }

                
            }
            else
            {

                if (CheckFields() == true)
                {
                    MessageBox.Show("Please Complete the Information!", "Add Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to Update the Record of " + tfn.Text + " " + tln.Text + "?", "Update Record",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdateRecord(SID);
                        bStud.PerformClick();
                    }
                }

            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            if (bSave.Text == "SAVE")
            {

                if (MessageBox.Show("Are you sure you want to Cancel?", "Cancel Add Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ShowPanel(pStud);
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Cancel Record Update of " + tfn.Text + " " + tln.Text + "?", "Cancel Update Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ShowPanel(pStud);
                }
            }
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            ShowPanel(pAERecord);
            bSave.Text = "UPDATE";
            EditProfile(SID);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void cmsAdd_Click(object sender, EventArgs e)
        {
            bSave.Text = "SAVE";
            ClearFields();
            ShowPanel(pAERecord);
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            Search_Data(tSearch.Text);
        }

        private void tmTime_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString();
        }

        private void pStud_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
