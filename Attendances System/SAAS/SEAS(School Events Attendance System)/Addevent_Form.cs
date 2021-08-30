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
    public partial class Addevent_Form : Form
    {
        public Addevent_Form()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tAddFn_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bSaveUser_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void ClearFieldsEvent()
        {
            foreach (var z in this.pAddEvent.Controls)
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
        private void AddEvent()
        {

            string sql = "INSERT INTO tbleventslist VALUES (null, '" + tAcname.Text + "','" + tActhyeme.Text + "','" + tAcplace.Text + "','" + dtpdtae.Text + "','" + dtpdateto.Text + "','0','1')";
            MySqlCommand cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd_event.ExecuteNonQuery();
            MessageBox.Show("New Event has been Added Succesfully!", "Add Event", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFieldsEvent();
        }

        private void pAddEvent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
