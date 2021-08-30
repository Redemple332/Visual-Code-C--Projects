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

namespace SEAS_School_Events_Attendance_System_
{
    public partial class frmAddUser : Form
    {

        MySqlCommand sql_cmd = new MySqlCommand();
        public string UID;
        public string UNAME;

        private void Load_Data()
        {

            String Sql = "Select * from tbluser ORDER BY ln ASC";
            sql_cmd = new MySqlCommand(Sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();

            lvUsers.Items.Clear();

            while (rd.Read())
            {
                lvUsers.Items.Add(rd["id"].ToString());
                lvUsers.Items[lvUsers.Items.Count - 1].SubItems.Add(rd["ln"].ToString() + rd["fn"].ToString());
                lvUsers.Items[lvUsers.Items.Count - 1].SubItems.Add(rd["position"].ToString());
                lvUsers.Items[lvUsers.Items.Count - 1].SubItems.Add(rd["contact"].ToString());
                lvUsers.Items[lvUsers.Items.Count - 1].SubItems.Add(rd["status"].ToString());

            }

            rd.Close();


        }

        private void AddUser()
        {
            string sql = "INSERT INTO tbluser(id, fn, ln, un, pw, contact, email, position) VALUES(null, '"+ tAddFn.Text+ "','" + tAddLn.Text + "','" + tAddUn.Text + "','" + tAddPw.Text + "','" + tAddCon.Text + "','" + tAddEmail.Text + "','" + tAddPosition.Text + "'); ";

            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New User has been added successfully!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Load_Data();

        }

        private void UpdateUser(string sUID)
        {
            string sql = "UPDATE tbleventslist SET fn= '" + tAddFn.Text + "', ln= '" + tAddLn.Text + "', position= '" + tAddPosition.Text + "', un= '" + tAddUn.Text + "',pw= '" + tAddPw.Text + "', contact= '" + tAddCon.Text + "', email= '" + tAddEmail.Text + "',    WHERE id = " + sUID;
            MySqlCommand cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd_event.ExecuteNonQuery();

            MessageBox.Show("User has been Updated Succesfully!", "Update Event", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Load_Data();
            UID = null;
        }

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save " + tAddFn.Text + " " + tAddLn.Text + "?", "Add User", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {

                pUSER.Visible = true;
                pUSER.Dock = DockStyle.Fill;
                bBack.Visible = true;
                bClose.Visible = false;
                lAdduser.Text = "Users";
                lAdduser.Image = null;

                AddUser();
                Load_Data();

            }

        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

      if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();


            pUSER.Visible = false;
            bBack.Visible = false;
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pUSER.Visible = true;
            pUSER.Dock = DockStyle.Fill;
            Load_Data();
            bBack.Visible = true;
            lAdduser.Text = "USERS";
            lAdduser.Image = null;
            bClose.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pUSER.Visible = false;
            bBack.Visible = false;
            bClose.Visible = true;
            lAdduser.Text = "Add User";
            lAdduser.Image = Properties.Resources.add24;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
