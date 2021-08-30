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
using WMPLib;


using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;

namespace SEAS_School_Events_Attendance_System_
{
    public partial class frmMENU : Form
    {
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        

        MySqlCommand sql_cmd = new MySqlCommand();
        MySqlCommand sql_cmd_event = new MySqlCommand();

        public string SID;
        public string sName;
        public string EID;
        public string ENAME;
        string sql;

        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        private ComboBox cCamera = new ComboBox();

        public frmMENU()
        {
            InitializeComponent();

            Player.URL = "music.mp3";
            Player.controls.stop();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox2.Image = (Image)eventArgs.Frame.Clone();
        }

        private string ReadCode()
        {
            string decoded = null;
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pictureBox2.Image);
            try
            {
                decoded = result.ToString().Trim();
            }

            catch (Exception ex)
            {

            }

            return decoded;
        }


        private void Load_Data()
        {
            //Populate the Listview (lvStudentList) with information from the DataBase
           string sql = "SELECT * FROM tblstudentlist  ORDER BY ln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
        
            lvStudentList.Items.Clear(); //Clear the listview before populating
            while (rd.Read())
            {
                lvStudentList.Items.Add(rd["id"].ToString());
                lvStudentList.Items[lvStudentList.Items.Count - 1].SubItems.Add(rd["ln"].ToString() + " " + rd["fn"].ToString());
                lvStudentList.Items[lvStudentList.Items.Count - 1].SubItems.Add(rd["strand"].ToString());
                lvStudentList.Items[lvStudentList.Items.Count - 1].SubItems.Add(rd["qrcode"].ToString());
            }
            rd.Close();

            int x;
            for (x = 0; x <= lvStudentList.Items.Count - 2; x += 2)
            {
                lvStudentList.Items[x + 1].BackColor = lvStudentList.BackColor = Color.Gainsboro;
                lvStudentList.Items[x].BackColor = lvStudentList.BackColor = Color.White;
            }
        }

        private void Load_Data_EventList()
        {
            //Populate the Listview (lvStudentList) with information from the DataBase
            string sql = "SELECT * FROM tbleventslist  ORDER BY name ASC";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();

            lvEventList.Items.Clear();
            while (rd.Read())
            {
                lvEventList.Items.Add(rd["id"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["datefrom"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["dtaeto"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["place"].ToString());
            }

            rd.Close();


        }
        private void button5_Click(object sender, EventArgs e)
        {
            frmAddUser fm = new frmAddUser();
            fm.Show();
        }

        private void ShowPanel(Panel z)
        {
            

            z.Visible = true;
            z.BringToFront();
            z.Dock = DockStyle.Fill;

  

        }
        private void MENU_Load(object sender, EventArgs e)
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();
            bHome.PerformClick();
            //ShowList();
            nameofuser.Text = clsMySQL.nameus;
            ShowPanel(pHomed);
            infolabel.Visible = false;
           pbsave.Visible = false;
            lblwn.Visible = false;
            lblsave.Visible = false;
            btaddstud.Enabled = false;
            tmTimeDate.Start();
            lvStudentList.ContextMenuStrip = cmsStudentListMenu;
            lvViewAttendance.ContextMenuStrip = cmsViewMenu;

            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cCamera.Items.Clear();
            foreach (FilterInfo Device in CaptureDevice)
            {
                cCamera.Items.Add(Device.Name);
            }
            cCamera.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
            wmp1.Visible = false;
            Select_ActiveEvent();
            Load_Data_EventList();
            pbsave.Visible = false;
            lblsave.Visible = false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPanel(pAttendance);
            pAttendance.Dock = DockStyle.Fill;
        }

      

        private void tmTimedate_Tick(object sender, EventArgs e)
        {
            lbTimeDate.Text = DateTime.Now.ToLongDateString() + System.Environment.NewLine + DateTime.Now.ToLongTimeString();
        }

       private void ColorTrans()
        {
            bHome.BackColor = Color.Transparent;
            bEventList.BackColor = Color.Transparent;
            bAttendance.BackColor = Color.Transparent;
            bViewAttendance.BackColor = Color.Transparent;
            bStudentList.BackColor = Color.Transparent;
            bAddUser.BackColor = Color.Transparent;
            bAbout.BackColor = Color.Transparent;
        }

        private void ColorRed(Button r)
        {
            bHome.BackColor = Color.Transparent;
            bEventList.BackColor = Color.Transparent;
            bAttendance.BackColor = Color.Transparent;
            bViewAttendance.BackColor = Color.Transparent;
            bStudentList.BackColor = Color.Transparent;
            bAddUser.BackColor = Color.Transparent;
            bAbout.BackColor = Color.Transparent;

            r.BackColor = Color.FromArgb(0, 54, 99);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ShowPanel(pEventsList);
            Load_Data_EventList();
          
 
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel(pStudentList);
        }

        private void bStudentList_Click(object sender, EventArgs e)
        {
            ShowPanel(pStudentList);
            Load_Data();
        }

        private void bViewAttendance_Click(object sender, EventArgs e)
        {
            ShowPanel(pViewAttendance);
            act();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowPanel(pAbout);
         
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowPanel(pAddStudent);
            ClearFields();

        }
        private Boolean CheckFields()
        {
            Boolean isEmpty = false;

            foreach (var z in this.pAddStudent.Controls)
            {
                if (z is TextBox)
                {
                    if (((TextBox)z).Text == "")
                    {
                        isEmpty = true;
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

        private Boolean CheckFieldsEvent()
        {
            Boolean isEmpty = false;

            foreach (var z in this.pAddEvent.Controls)
            {
                if (z is TextBox)
                {
                    if (((TextBox)z).Text == "")
                    {
                        isEmpty = true;
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
        private void AddRecord()
        {
            string sql = "INSERT INTO tblstudentlist( id, fn, ln, strand, qrcode,evnt_id ) VALUES (null, '" + tFNaddstudent.Text + "','" + tLNaddstudent.Text + "','" + cbSTRANDaddstudent.Text + "', '" + tQRCODEaddstudent.Text + "', '" + clsMySQL.evnt + "')";

            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Record has been Added Succesfully!", "Add Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SID = null;
            Load_Data();
        }



        private void UpdateRecord(string sSID)
        {
            string sql = "UPDATE tblstudentlist SET fn= '" + tFNaddstudent.Text + "',ln= '" + tLNaddstudent.Text + "' strand= '" + cbSTRANDaddstudent.Text + "' qrcode= '" + tQRCODEaddstudent.Text + "' WHERE id = " + sSID ;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record has been Updated Succesfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Load_Data();
            SID = null;
        }

        private void UpdateEvent(string sEID)
        {
            string sql = "update tbleventslist set name= '" + tAcname.Text + "', theme= '" + tActhyeme.Text + "', place= '" + tAcplace.Text + "', datefrom= '" + dtpdtae.Text + "', dtaeto= '" + dtpdateto.Text + "' where id = " + sEID;
            MySqlCommand cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd_event.ExecuteNonQuery();

            MessageBox.Show("event has been updated succesfully!", "update event", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFieldsEvent();
            Load_Data_EventList();
            EID = null;
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

        private void EditProfile(string sSID)
        {
            string sql = "SELECT * FROM tblstudentlist WHERE id = " + sSID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                tFNaddstudent.Text = (rd["fn"].ToString());
                tLNaddstudent.Text = (rd["ln"].ToString());
                tQRCODEaddstudent.Text = (rd["qrcode"].ToString());


            
               
            }
            rd.Close();
        }
        private void EditEvent(string sD)
        {
            string sql = "SELECT * FROM tbleventslist WHERE id = " + sD;
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                tAcname.Text = (rd["name"].ToString());
                tActhyeme.Text = (rd["theme"].ToString());
                tAcplace.Text = (rd["place"].ToString());
                dtpdtae.Text = (rd["datefrom"].ToString());
                dtpdateto.Text = (rd["dtaeto"].ToString());

            }
            rd.Close();
        }


        private void DeleteRecord(string sSID)
        {
            string sql = "DELETE FROM tblstudentlist WHERE id = " + sSID;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record has been Deleted Succesfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SID = null;
        }

        private void DeleteEvent(string sED)
        {
            string sql = "DELETE FROM tbleventslist WHERE id = " + sED;
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();

            Load_Data_EventList();
            MessageBox.Show("Event has been Deleted Succesfully!", "Delete Event", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SID = null;
        }

        private void Search_Data(string z)
        {

            string sql = "SELECT * FROM tblstudentlist WHERE fn LIKE '%" + z + "%' OR ln LIKE '%" + z + "%' OR strand LIKE '%" + z + "%'  ORDER BY ln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            lvStudentList.Items.Clear();
            while (rd.Read())
            {
                lvStudentList.Items.Add(rd["id"].ToString());
                lvStudentList.Items[lvStudentList.Items.Count - 1].SubItems.Add(rd["ln"].ToString() + " " + rd["fn"].ToString());
                lvStudentList.Items[lvStudentList.Items.Count - 1].SubItems.Add(rd["strand"].ToString());

            }
            rd.Close();
        }

        private void Search_Data_Event(string z)
        {

            string sql = "SELECT * FROM tbleventslist WHERE name LIKE '%" + z + "%' OR theme LIKE '%" + z + "%' OR place LIKE '%" + z + "%' OR date LIKE '%" + z + "%' OR time LIKE '%" + z + "%' OR class LIKE '%" + z + "%' OR about LIKE '%" + z + "%'   ORDER BY name ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            lvEventList.Items.Clear();
            while (rd.Read())
            {
                lvEventList.Items.Add(rd["id"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["theme"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["place"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["time"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["class"].ToString());
                lvEventList.Items[lvEventList.Items.Count - 1].SubItems.Add(rd["about"].ToString());

            }
            rd.Close();
        }

        private void ViewProfile(string sSID)
        {
            string sql = "SELECT * FROM tblstudentlist WHERE id = " + sSID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                lName.Text = (rd["fn"].ToString() + " " + rd["ln"].ToString());
                lLEVEL.Text = (rd["level"].ToString());
                lSTRAND.Text = (rd["strand"].ToString());
                lGENDER.Text = (rd["gender"].ToString());
                lCONTACT.Text = (rd["contact"].ToString());
                lAGE.Text = (rd["age"].ToString());
                lBDATE.Text = (rd["bdate"].ToString());
                lADDRESS.Text = (rd["address"].ToString());
                lQRCODE.Text = (rd["qrcode"].ToString());
            }
            rd.Close();

            SID = null;
        }

        private void ViewEvent(string sEID)
        {
            string sql = "SELECT * FROM tbleventslist WHERE id = " + sEID;
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                lEName.Text = (rd["name"].ToString());
                lETheme.Text = (rd["theme"].ToString());
                lEPlace.Text = (rd["place"].ToString());
                lEDate.Text = (rd["date"].ToString());
                lETime.Text = (rd["time"].ToString());
                lEClass.Text = (rd["class"].ToString());
                lEAbout.Text = (rd["about"].ToString());  
            }
            rd.Close();

            EID = null;
        }


        
        private void ClearFields()
        {
            foreach (var z in this.pAddStudent.Controls)
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

        private void button18_Click(object sender, EventArgs e)
        {
            if(bSaveaddstudent.Text == "Save")
            {
                if (CheckFields() == true)
                {
                    MessageBox.Show("Please Complete the Information!", "Add Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to Save this Record of " + tFNaddstudent.Text + " " + tLNaddstudent.Text +  " ? ", "Add Record",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AddRecord();
                        bStudentList.PerformClick();
                    }
                    else
                    {
                        SID = null;
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
                    if (MessageBox.Show("Are you sure you want to Update the Record of " + tFNaddstudent.Text + " " + tLNaddstudent.Text + " ? ", "Update Record",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdateRecord(SID);
                        bStudentList.PerformClick();
                       
                        
                    }

                    else
                    {
                        SID = null;
                    }
                }

            }
        }

        private void lvStudentList_Click(object sender, EventArgs e)
        {
            SID = lvStudentList.FocusedItem.Text;
            sName = lvStudentList.FocusedItem.SubItems[1].Text;
        }

       


        private void cmsEditStudent_Click(object sender, EventArgs e)
        {
            if (SID == null)
            {
                if (MessageBox.Show("Select student first! ", " Wrong Performance",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    bStudentList.PerformClick();
                }
              
            }
            else
            {
                EditProfile(SID);
                ShowPanel(pAddStudent);
                bSaveaddstudent.Text = "Update";
                lAdding.Text = "Editing Student Profile";

            }

        }

        private void cmsDeleteStudent_Click(object sender, EventArgs e)
        {

            if (SID == null)
            {
                if (MessageBox.Show("Select student first!", " Wrong Performance",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    bStudentList.PerformClick();
                }

            }
            else
            {

                if (MessageBox.Show("Are you sure you want to Delete Record of " + sName + "?", "Delete Record",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteRecord(SID);
                    Load_Data();
                }

                else
                {
                    SID = null;
                }

                

            }
        }

        private void cmsViewStudent_Click(object sender, EventArgs e)
        {
            if (SID == null)
            {
                if (MessageBox.Show("Select student first! ", " Wrong Performance",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    bStudentList.PerformClick();
                }

            }
            else
            {

                ShowPanel(pViewProfile);
                ViewProfile(SID);

            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            bStudentList.PerformClick();
            SID = null;
        }

      

        private void label43_Click(object sender, EventArgs e)
        {

        }

      

        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addevent_Form av = new Addevent_Form();
            av.Show();
        }

      

       
        private void cmsEditEvent_Click(object sender, EventArgs e)
        {
            
                ShowPanel(panel2);
                EditEvent(SID);
            
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            ShowPanel(pHomed);
          
           
        }

        private void bHome_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void menuAboutEvent_Click(object sender, EventArgs e)
        {
            if (EID == null)
            {
                if (MessageBox.Show("Select Event first! ", " Wrong Performance",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    bEventList.PerformClick();
                }

            }
            else
            {

                ShowPanel(pViewEvent);
                ViewEvent(EID);

            }
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {

            

            if (  MessageBox.Show("Are you sure you want to Delete " + tAcname.Text + "?", "Delete Record",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteEvent(SID);
            }
           
        }


        //   second process
        private void scanid()
        {
            string Dat = DateTime.Now.ToLongDateString();
            Boolean isEmpty = true;

            string sql = "SELECT * FROM tbleventattendance WHERE sid = '" + clsMySQL.id + "' AND event_id=" + clsMySQL.evnt + " AND Datelog ='" + Dat + "'";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                isEmpty = false;
                //clsMySQL.atevntnm = (rd["event_id"].ToString());
                //clsMySQL.datlog = (rd["Datelog"].ToString());
            }
            rd.Close();

            if (isEmpty)
            {
                loginsrt();
            }
            else //false
            {
                //if (clsMySQL.datlog != Dat)
                //{
                //    loginsrt();
                //}
                //else
                //{
                     logupdate();
                //}
            }

        }

        private void scan()
        {
            string sql = "SELECT * FROM tblstudentlist  WHERE qrcode = '" + txtscan.Text + "'";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.id = (rd["id"].ToString());
                clsMySQL.ln = (rd["ln"].ToString());
                clsMySQL.fn = (rd["fn"].ToString());
                clsMySQL.qrcode = (rd["qrcode"].ToString());
               
            }
            rd.Close();
 
            if (txtscan.Text != null)  //|| txtscan.Text == clsMySQL.ln || txtscan.Text == clsMySQL.fn )
            {
                lblwn.Visible = false;
                scanid();
                show();
            }
            else
            {
                lblwn.Visible = true;
                return;
            }

        }
        private void show()
        {
            string sql = "SELECT * FROM tblstudentlist WHERE '" + txtscan.Text + "' = qrcode";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                name.Text = (rd["ln"].ToString() + " , " + (rd["fn"].ToString()));
                sec.Text = (rd["strand"].ToString());
               // YL.Text = (rd["level"].ToString());
            }
            rd.Close();
            Player.controls.play();
            pbsave.Visible = true;
            timer1.Start();
            pbsave.Visible = true;
            lblsave.Visible = true;
        }

       
        private void ShowList()
        {
            string Dat = DateTime.Now.ToLongDateString();

            string sql = "SELECT tblstudentlist.id,tblstudentlist.fn,tblstudentlist.ln,tblstudentlist.strand,tbleventattendance.loginAM,tbleventattendance.logoutAM,tbleventattendance.loginPM,tbleventattendance.logoutPM from tblstudentlist inner join tbleventattendance on tblstudentlist.id = tbleventattendance.sid where (tbleventattendance.Datelog = '" + Dat + "' AND tbleventattendance.event_id =" + clsMySQL.eid + ") order by ln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            lvAttendance.Items.Clear();
            while (rd.Read())
            {
                label32.Text = clsMySQL.evntname + " " + "Activities";
                lvAttendance.Items.Add(rd[0].ToString());
                lvAttendance.Items[lvAttendance.Items.Count - 1].SubItems.Add(rd[2].ToString() + " , " + rd[1].ToString());
                lvAttendance.Items[lvAttendance.Items.Count - 1].SubItems.Add(rd[3].ToString());
                lvAttendance.Items[lvAttendance.Items.Count - 1].SubItems.Add(rd[4].ToString());
                lvAttendance.Items[lvAttendance.Items.Count - 1].SubItems.Add(rd[5].ToString());
                lvAttendance.Items[lvAttendance.Items.Count - 1].SubItems.Add(rd[6].ToString());
                lvAttendance.Items[lvAttendance.Items.Count - 1].SubItems.Add(rd[7].ToString());


            }
            rd.Close();

            int x;
            for (x = 0; x <= lvAttendance.Items.Count - 2; x += 2)
            {
                lvAttendance.Items[x + 1].BackColor = lvAttendance.BackColor = Color.Gainsboro;
                lvAttendance.Items[x].BackColor = lvAttendance.BackColor = Color.White;
            }
            
        }

       
        private void logupdate()
        {
            string time = DateTime.Now.ToLongTimeString();
            string sql = null;
            int hr = DateTime.Now.Hour;
            
            if (hr <= 10)
            {
                sql = "UPDATE tbleventattendance SET loginAM = '" + time + "' WHERE sid = " + clsMySQL.id;
            }
            else if (hr >= 10 && hr <= 11)
            {
                sql = "UPDATE tbleventattendance SET logoutAM = '" + time + "' WHERE sid = " + clsMySQL.id;
            }
            else if (hr >= 11 && hr <= 16)
            {
                sql = "UPDATE tbleventattendance SET loginPM = '" + time + "' WHERE sid = " + clsMySQL.id;
            }
            else if (hr >= 16)
            {
                sql = "UPDATE tbleventattendance SET logoutPM = '" + time + "' WHERE sid = " + clsMySQL.id;
            }

            if (sql != null)
            {
                if (clsMySQL.id != null)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void loginsrt()
        {
            string Date = DateTime.Now.ToLongDateString();
            string time = DateTime.Now.ToLongTimeString();
            string sql = null;

            if (DateTime.Now.Hour <= 10)
            {
                sql = "INSERT INTO tbleventattendance (sid, loginAM,event_id,Datelog) VALUES (" + clsMySQL.id + ", '" + time + "'," + clsMySQL.evnt + ", '" + Date + "')";
                
            }
            else if (DateTime.Now.Hour >= 10 && DateTime.Now.Hour <= 11)
            {
                sql = "INSERT INTO tbleventattendance (sid, logoutAM,event_id,Datelog) VALUES (" + clsMySQL.id + ", '" + time + "'," + clsMySQL.evnt + ", '" + Date + "')";
               
            }
            else if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour <= 16)
            {
                sql = "INSERT INTO tbleventattendance (sid, loginPM,event_id,Datelog) VALUES (" + clsMySQL.id + ", '" + time + "'," + clsMySQL.evnt + ", '" + Date + "')";
            }
            else if (DateTime.Now.Hour >= 16)
            {
                //sql = "INSERT INTO tblstudentlist(sid, logoutPM) VALUES (" + clsMySQL.id + ", '" + time + "' WHERE '" + clsMySQL.id + "' = sid)";
                // astig insert command my where clause ^_^
                sql = "INSERT INTO tbleventattendance (sid, logoutPM,event_id,Datelog) VALUES (" + clsMySQL.id + ", '" + time + "'," + clsMySQL.evnt + ", '" + Date + "')";
            }
            else
            {
                sql = null;
            }

            if (sql != null)
            {
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
            }
        }
       
        private void button10_Click(object sender, EventArgs e)
        {
            scan();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbsave.Value <= 90)
            {
                pbsave.Value += 10;
            }
            else
            {
                timer1.Stop();
                pbsave.Value = 0;
                pbsave.Visible = false;
                lblsave.Visible = true;
                ShowList();
            }
            
        }

        private void txtscan_Click(object sender, EventArgs e)
        {
            txtscan.Text = "";
             name.Text = "";
             sec.Text = "";
             YL.Text = "";
             lblsave.Visible = false;
             pbsave.Visible = false;
            
        }

        private void bAttendanceBack_Click_1(object sender, EventArgs e)
        {
            bHome.PerformClick();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Addevent_Form av = new Addevent_Form();
            av.ShowDialog();
        }

        private void bSaveUser_Click(object sender, EventArgs e)
        {
            UpdateEvent(SID);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bEventList.PerformClick();
        }

        private void lvEventList_DoubleClick(object sender, EventArgs e)
        {
            ldevt(SID);
            
        }
/*
        private void ev(string stid)
        {
            string sql = "SELECT * FROM tblstudentlist WHERE evnt_id = " + stid;
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.eid = (rd["evnt_id"].ToString());
            }
            rd.Close();
        }
  */
        private void ldevt(string stid)
        {
            string sql = "SELECT * FROM tbleventslist where id =" + stid;
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.evntname = (rd["name"].ToString());
            }
            rd.Close();

            if(clsMySQL.evntname != null)
            {
                lvAttendance.Items.Clear();
                ShowList();
                pAttendance.BringToFront();
                pAttendance.Dock = DockStyle.Fill;
            }              
        }
      

         private void lvEventList_Click(object sender, EventArgs e)
         {
             SID = lvEventList.FocusedItem.Text;
            clsMySQL.eid = SID;
        }

         private void btaddstud_Click(object sender, EventArgs e)
         {
             getevnt(SID);
         }
        
         private void getevnt(string evid)
         {
             string sql = "SELECT * FROM tbleventslist where id =" + evid;
             sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
             MySqlDataReader rd = sql_cmd_event.ExecuteReader();
             while (rd.Read())
             {
                 clsMySQL.evnt = (rd["id"].ToString());
             }
             rd.Close();
             ShowPanel(pAddStudent);
             ClearFields();
         }

        private void bHome_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bHome);
        }

        private void bEventList_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bEventList);
        }

        private void bAttendance_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bAttendance);
        }

        private void bViewAttendance_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bViewAttendance);
        }

        private void bStudentList_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bStudentList);
        }

        private void bAddUser_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bAddUser);
        }

        private void bAbout_MouseUp(object sender, MouseEventArgs e)
        {
            ColorTrans();
            ColorRed(bAbout);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPanel(pAbout);
            ColorRed(bAbout);
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            ShowPanel(pEventsList);
            ColorTrans();
            ColorRed(bEventList);
        }

        private void pSEASPIC_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button13_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            infolabel.Visible = true;
            infolabel.Text = "Press F10 to Scan";
        }
        



        private void frmMENU_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                tmScan.Start();
                infolabel.Text = "Press F11 to Stop";
            }
            else if (e.KeyCode == Keys.F11)
            {
                infolabel.Text = "Press F10 to Scan";
                tmScan.Stop();
            }
        }

        private void lvEventList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvEventList.FocusedItem.Bounds.Contains(e.Location))
                {
                    cmsEventsList.Show(Cursor.Position);
                    //btaddstud.Enabled = false;
                }
            }
            else
            {
                //btaddstud.Enabled = true;
            }
        }

        //button ng edit wala pang laman
        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            if (EID == null)
            {
                if (MessageBox.Show("Select Event first!", " Wrong Performance",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    bEventList.PerformClick();
                }

            }
            else
            {

                if (MessageBox.Show("Are you sure you want to Delete " + tAcname.Text + "?", "Delete Record",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteEvent(SID);
                    Load_Data_EventList();
                }

                else
                {
                    EID = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowPanel(pHomed);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Search_Data(textBox4.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ShowPanel(pHomed);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ShowPanel(pHomed);
        }

        private void act()
        {
            string sql = "SELECT distinct(name) FROM tbleventslist ";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            cbxslcact.Items.Clear();
            while (rd.Read())
            {
                cbxslcact.Items.Add(rd["name"].ToString());
              //  clsMySQL.eve = (rd["name"].ToString());
            }
            rd.Close();
            
                
            
        }
        private void secactivity()
        {
            string sql = "SELECT * FROM tbleventslist where name = '" + cbxslcact.Text + "'";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
          //  cbxslcact.Items.Clear();
            while (rd.Read())
            {
                // cbxslcact.Items.Add(rd["name"].ToString());
                clsMySQL.evlistid = (rd["id"].ToString());
                clsMySQL.eve = (rd["name"].ToString());
            }
            rd.Close();
            if (cbxslcact.Text == clsMySQL.eve)
            {
                cbxslcact.Focus();
                secact();
            }
        }



        private void secact()
        {
            string sql = "SELECT distinct(datelog) FROM tbleventattendance ";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            cbxsecdate.Items.Clear();
            while (rd.Read())
            {
                cbxsecdate.Items.Add(rd["Datelog"].ToString());
                clsMySQL.det = (rd["Datelog"].ToString());
            }
            rd.Close();
                
            
        }

        private void secdate()
        {
            string sql = "SELECT tblstudentlist.id,tblstudentlist.fn,tblstudentlist.ln,tblstudentlist.strand,tbleventattendance.loginAM,tbleventattendance.logoutAM,tbleventattendance.loginPM,tbleventattendance.logoutPM,tbleventattendance.event_id from tblstudentlist inner join tbleventattendance on tblstudentlist.id = tbleventattendance.sid where (tbleventattendance.Datelog = '" + cbxsecdate.Text + "' and tbleventattendance.event_id = '" + clsMySQL.evlistid + "' ) order by ln ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            lvAttendance.Items.Clear();
            while (rd.Read())
            {
                lvViewAttendance.Items.Add(rd[0].ToString());
                lvViewAttendance.Items[lvViewAttendance.Items.Count - 1].SubItems.Add(rd[2].ToString() + " , " + rd[1].ToString());
                lvViewAttendance.Items[lvViewAttendance.Items.Count - 1].SubItems.Add(rd[3].ToString());
                lvViewAttendance.Items[lvViewAttendance.Items.Count - 1].SubItems.Add(rd[4].ToString());
                lvViewAttendance.Items[lvViewAttendance.Items.Count - 1].SubItems.Add(rd[5].ToString());
                lvViewAttendance.Items[lvViewAttendance.Items.Count - 1].SubItems.Add(rd[6].ToString());
                lvViewAttendance.Items[lvViewAttendance.Items.Count - 1].SubItems.Add(rd[7].ToString());


            }
            rd.Close();

            int x;
            for (x = 0; x <= lvViewAttendance.Items.Count - 2; x += 2)
            {
                lvViewAttendance.Items[x + 1].BackColor = lvViewAttendance.BackColor = Color.Gainsboro;
                lvViewAttendance.Items[x].BackColor = lvViewAttendance.BackColor = Color.White;
            }
        }

        private void cbxslcact_SelectedIndexChanged(object sender, EventArgs e)
        {
           // lvViewAttendance.Items.Clear();
            secactivity();
        }

        private void cbxsecdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvViewAttendance.Items.Clear();
            secdate();
        }

        private void tmScan_Tick(object sender, EventArgs e)
        {
            string BCodeValue = ReadCode();
            if (BCodeValue != null)
            {
                txtscan.Text = BCodeValue;
                scan();
            }
            else
            {
                txtscan.Text = "No Record Found.";
            }
        }

        private void frmMENU_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout ?", "Logout",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 fm = new Form1();
                fm.Show();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void cmsActiveEvent_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Activate the selected Event?", "Event List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Deactivate all the Event 
                sql = "UPDATE tbleventslist SET active = 0";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();

                //Active the selected Event
                sql = "UPDATE tbleventslist SET active = 1 WHERE id = " + clsMySQL.eid;
                MySqlCommand cmd2 = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd2.ExecuteNonQuery();

                clsMySQL.evnt = clsMySQL.eid;
                clsMySQL.eid = null;
            }
        }

        private void Select_ActiveEvent()
        {
            string sql = "SELECT id FROM tbleventslist WHERE active = 1 ";
            sql_cmd_event = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd_event.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.evnt = (rd[0].ToString());
            }
            rd.Close();
        }

        private void txtscan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                scan();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void infolabel_Click(object sender, EventArgs e)
        {

        }
    }
}
