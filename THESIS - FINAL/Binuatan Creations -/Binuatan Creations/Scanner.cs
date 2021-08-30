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
namespace Binuatan_Creations
{
    public partial class Scanner : Form
    {
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        MySqlCommand sql_cmd = new MySqlCommand();
        MySqlCommand sql_cmd_event = new MySqlCommand();

        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        public string a;
        public string DATE;
        public string D;
        public int counts = 1;
        public int c = 0;
        private ComboBox cCamera = new ComboBox();
        public Scanner()
        {
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();
            
            Player.URL = "music.mp3";
            Player.controls.stop();
            InitializeComponent();
           
        }

        private string ReadCode()
        {
            
            string decoded = null;
            BarcodeReader Reader = new BarcodeReader();
            
            Result result = Reader.Decode((Bitmap)pbQRCode.Image);
            try
            {
                decoded = result.ToString().Trim();
            }

            catch (Exception ex)
            {

            }

            return decoded;
        }
        private void sears()
        {
            tt5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tt5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM Agency ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["agency"].ToString());

            }
            tt5.AutoCompleteCustomSource = serch;

            rd.Close();
        }
        private void err()
        {
            string sql = "SELECT * FROM summary where qr='" + tqr.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.qr1 = (rd["qr"].ToString());

            }
            rd.Close();
        }
        private void err1()
        {
            string sql = "SELECT * FROM summary";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                clsMySQL.nf = (rd["fulln"].ToString());
            }
            rd.Close();
        }
        private void y()
        {
            string sql = "INSERT INTO summary VALUES (null,'" + lb1.Text + "','" + tt4.Text + "','" + tt5.Text + "','" + "0" + "','" + tqr.Text + "','" + tt3.Text + "',now())";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void txtqr1()
        {
     
            string BCodeValue = ReadCode();
            string sql = "SELECT * FROM summary where qr='" + BCodeValue + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f1 = (rd["fulln"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
                clsMySQL.a1 = (rd["agency"].ToString());
                clsMySQL.n1 = (rd["qr"].ToString());
            }
            rd.Close();
        }
        private void txtqr2()
        {
            string BCodeValue = ReadCode();
            string sql = "SELECT * FROM summary where qr='" + BCodeValue + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f2 = (rd["fulln"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
                clsMySQL.a2 = (rd["agency"].ToString());
                clsMySQL.n2 = (rd["qr"].ToString());

            }
            rd.Close();
        }


        private void txtqr3()

        {
            string BCodeValue = ReadCode();
            string sql = "SELECT * FROM summary where qr='" + BCodeValue + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f3 = (rd["fulln"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
                clsMySQL.a3 = (rd["agency"].ToString());
                clsMySQL.n3 = (rd["qr"].ToString());

            }
            rd.Close();
        }

        private void txtqr4()

        {
            string BCodeValue = ReadCode();
            string sql = "SELECT * FROM summary where qr='" + BCodeValue + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f4= (rd["fulln"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
                clsMySQL.a4 = (rd["agency"].ToString());
                clsMySQL.n4 = (rd["qr"].ToString());

            }
            rd.Close();
        }
        private void txtqr5()

        {
            string BCodeValue = ReadCode();
            string sql = "SELECT * FROM summary where qr='" + BCodeValue + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.f5 = (rd["fulln"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
                clsMySQL.a5 = (rd["agency"].ToString());
                clsMySQL.n5 = (rd["qr"].ToString());

            }
            rd.Close();
        }


        private void qr1()
        {
            string sql = "SELECT * FROM summary where fulln='" + t1.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.t1 = (rd["fulln"].ToString());
                clsMySQL.tta = (rd["agency"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
            }
            rd.Close();
        }
        private void qr2()
        {
            string sql = "SELECT * FROM summary where fulln='" + t2.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.t2 = (rd["fulln"].ToString());
                clsMySQL.tta = (rd["agency"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());

            }
            rd.Close();
        }
        private void qr3()
        {
            string sql = "SELECT * FROM summary where fulln='" + t3.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.tto = (rd["occ"].ToString());
                clsMySQL.t3 = (rd["fulln"].ToString());
                clsMySQL.tta = (rd["agency"].ToString());

            }
            rd.Close();
        }
        private void qr4()
        {
            string sql = "SELECT * FROM summary where fulln='" + t4.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.t4 = (rd["fulln"].ToString());
                clsMySQL.tta = (rd["agency"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
            }
            rd.Close();
        }
        private void qr5()
        {
            string sql = "SELECT * FROM summary where fulln='" + t5.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.t5 = (rd["fulln"].ToString());
                clsMySQL.tta = (rd["agency"].ToString());
                clsMySQL.tto = (rd["occ"].ToString());
            }
            rd.Close();
        }


        private void hid()
        {
            b3.Visible = false;
            l1.Text = "Select";
            p3.Visible = true;
            p3.BringToFront();
            p3.Dock = DockStyle.Fill;
            p3.Visible = true;
        }
        private void clear()
        {
            if (t1.Text == t2.Text)
            {
                t2.Clear();
            }

            if (t1.Text == t2.Text)
            {
                t2.Clear();
            }
            if (t1.Text == t3.Text)
            {
                t3.Clear();
            }
            if (t2.Text == t3.Text)
            {
                t3.Clear();
            }

            if (t4.Text == t1.Text)
            {
                t4.Clear();
            }
            if (t4.Text == t2.Text)
            {
                t4.Clear();
            }

            if (t4.Text == t3.Text)
            {
                t4.Clear();
            }


            if (t5.Text == t1.Text)
            {
                t5.Clear();
            }

            if (t5.Text == t2.Text)
            {
                t4.Clear();
            }

            if (t5.Text == t3.Text)
            {
                t5.Clear();
            }

            if (t5.Text == t4.Text)
            {
                t5.Clear();
            }
        }



        public void loading() {
            panel1.BringToFront();
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            stop.Start();
            load.Start();
            name.Start();

        }
        private void b3_Click(object sender, EventArgs e)
        {

            clear();

            qr2();
            qr3();
            qr1();
            qr4();
            qr5();
            if ( t1.Text != "" && l1.Text == "1 Person" && t1.Text == (clsMySQL.t1) )
            {
                loading();
                string sql = "INSERT INTO new VALUES (null,'" + clsMySQL.t1 + "','" + clsMySQL.tto + "','" + clsMySQL.tta + "','" + DATE + "','" + "1" + "')";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();                   
                label1.Text = clsMySQL.t1;
                st(); 
                button1.Focus();
              

            }
         

                if (t1.Text == (clsMySQL.t1) && t1.Text != "" && t2.Text == (clsMySQL.t2) && t2.Text != "" && l1.Text == "2 Person" && t1.Text!=t2.Text)
                {
                    clsMySQL.ttn = t1.Text + " and " + t2.Text;
                string sql = "INSERT INTO new VALUES (null,'" + clsMySQL.ttn + "','" + "DRIVER / TOURGUIDE"+ "','" + clsMySQL.tta + "','" + DATE + "','" + "2" + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    cmd.ExecuteNonQuery();
                label1.Text = clsMySQL.ttn;
                loading();
                button1.Focus();
                st();
            }

                
            if (t1.Text == (clsMySQL.t1) && t1.Text != "" && t2.Text == (clsMySQL.t2) && t2.Text != "" && l1.Text == "3 Person" && t1.Text != t2.Text &&  t3.Text == (clsMySQL.t3) && t3.Text != "" && t3.Text != t2.Text && t1.Text!=t3.Text)
            {
                clsMySQL.ttn = t1.Text + " / " + t2.Text +" / "+t3.Text;
                string sql = "INSERT INTO new VALUES (null,'" + clsMySQL.ttn + "','" + "DRIVER / TOURGUIDE" + "','" + clsMySQL.tta + "','" + DATE + "','" + "3" + "')";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);              
                cmd.ExecuteNonQuery();
                label1.Text = clsMySQL.ttn;
                loading();
                button1.Focus();
                st();
            }

            if (t1.Text == (clsMySQL.t1) && t1.Text != "" && t2.Text == (clsMySQL.t2) && t2.Text != "" && l1.Text == "4 Person" && t1.Text != t2.Text && t3.Text == (clsMySQL.t3) && t3.Text != "" && t3.Text != t2.Text && t1.Text != t3.Text && t4.Text == (clsMySQL.t4) && t4.Text != "" && t4.Text != t1.Text && t4.Text != t2.Text && t4.Text != t3.Text)
            {
                clsMySQL.ttn = t1.Text + " / " + t2.Text + " / " + t3.Text + " / " + t4.Text;
                string sql = "INSERT INTO new VALUES (null,'" + clsMySQL.ttn + "','" + "DRIVER / TOURGUIDE" + "','" + clsMySQL.tta + "','" + DATE + "','" + "4" + "')";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                label1.Text = clsMySQL.ttn;
                loading();
                button1.Focus();
                st();
            }

            if (t1.Text == (clsMySQL.t1) && t1.Text != "" && t2.Text == (clsMySQL.t2) && t2.Text != "" && l1.Text == "5 Person" && t1.Text != t2.Text && t3.Text == (clsMySQL.t3) && t3.Text != "" && t3.Text != t2.Text && t1.Text != t3.Text && t4.Text == (clsMySQL.t4) && t4.Text != "" && t4.Text != t1.Text && t4.Text != t2.Text && t4.Text != t3.Text && t5.Text == (clsMySQL.t5) && t5.Text != "" && t5.Text != t1.Text && t5.Text != t2.Text && t5.Text != t3.Text && t5.Text != t4.Text)
            {
                clsMySQL.ttn = t1.Text + " / " + t2.Text + " / " + t3.Text + " / " + t4.Text + " / " + t5.Text;
                string sql = "INSERT INTO new VALUES (null,'" + clsMySQL.ttn + "','" + "DRIVER / TOURGUIDE" + "','" + clsMySQL.tta + "','" + DATE + "','" + "5" + "')";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                label1.Text = clsMySQL.ttn;
                loading();
                button1.Focus();
                st();
            }
            else return;

        }
        private void sear()
        {
            t1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            t1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            t2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            t2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            t3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            t3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            t4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            t4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            t5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            t5.AutoCompleteSource = AutoCompleteSource.CustomSource;
        
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            string sql = "SELECT * FROM summary ";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            AutoCompleteStringCollection serch = new AutoCompleteStringCollection();
            while (rd.Read())
            {
                serch.Add(rd["fulln"].ToString());

            }
            t1.AutoCompleteCustomSource = serch;
            t2.AutoCompleteCustomSource = serch;
            t3.AutoCompleteCustomSource = serch;
            t4.AutoCompleteCustomSource = serch;
            t5.AutoCompleteCustomSource = serch;
            rd.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Focus();
            stop.Stop();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            t3.Visible = false;
            t2.Visible = false;
            t4.Visible = false;
            t5.Visible = false;
            l1.Text = "1 Person";
            p1.Visible = true;
            p1.BringToFront();
            p1.Dock = DockStyle.Fill;
            b3.Visible = true;
            t1.Clear();
            t1.Enabled = false;
            label2.Text = "Press F11 no QR";
            none();
            sc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sc();
            label2.Focus();
            stop.Stop();
            string BCodeValue = ReadCode();
            BCodeValue = null;
            t1.Clear();
            t2.Clear();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            t1.Visible = true;
            b3.Visible = true;
            t4.Visible = false;
            t5.Visible = false;
            l1.Text = "2 Person";
            t2.Visible = true;
            p1.BringToFront();
            p1.Dock = DockStyle.Fill;
            b3.Visible = true;
            t3.Visible = false;
            none();
            t1.Enabled = false;
            t2.Enabled = false;
            tmScan.Start();
            label2.Text = "Press F11 no QR";
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
      
            pbQRCode.Image = (Image)eventArgs.Frame.Clone();

        }
            
        private void Scanner_Load(object sender, EventArgs e)
        {
          
            timer1.Start();
            p3.BringToFront();
            p3.Dock = DockStyle.Fill;
            label2.Text = "Press F11 no QR";
            sear();
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }

            clsMySQL.sql_con.Open();
            b3.Visible = false;
            sears();
            D = DateTime.Now.ToLongDateString();
            DATE = DateTime.Now.ToShortDateString();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cCamera.Items.Clear();
            foreach (FilterInfo Device in CaptureDevice)
            {
                cCamera.Items.Add(Device.Name);
            }
            cCamera.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
           
        }

  

        private void tname_TextChanged(object sender, EventArgs e)
        {
          
        }
        
    


        private void tmScan_Tick(object sender, EventArgs e)
        {

   //QR1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
            string BCodeValue = ReadCode();

            if (BCodeValue != null && l1.Text == "1 Person" && t1.Text == "")
            {
                txtqr1();
                t1.Text = clsMySQL.f1;
                BCodeValue = null;
                Player.controls.play();

                if (t1.Text != "" && t1.Text == (clsMySQL.f1) && BCodeValue != null)
                {
                    b3.PerformClick();
                   
                }
               
            }


///QR22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222


            if (BCodeValue != null && l1.Text == "2 Person" && t1.Text == "")
            {
                txtqr1();
                t1.Text = clsMySQL.f1;
                BCodeValue = null;
                Player.controls.play();
             
            }
            if (BCodeValue != null && l1.Text == "2 Person" && t1.Text != "" && t1.Text != t2.Text)
            {           
                slep.Start();
                if (t2.Text != "")
                {
                    Player.controls.play();
                    slep.Stop();

                }

                if (t2.Text != "" && t1.Text != "")
                {
                  
                    b3.PerformClick();
                }
              

            }


////////Qr3333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333


            if (BCodeValue != null && l1.Text == "3 Person" && t1.Text == "")
            {
                Player.controls.play();
                txtqr1();
                t1.Text = clsMySQL.f1;
                BCodeValue = null;
            }
            if (BCodeValue != null && l1.Text == "3 Person" && t1.Text != "" && t1.Text != t2.Text)
            {
                slep.Start();
                if (t2.Text != "")
                {
                    Player.controls.play();
                    slep.Stop();

                }
            }

            if (BCodeValue != null && l1.Text == "3 Person" && t1.Text != "" && t2.Text != "" && t1.Text != t2.Text && t2.Text != t3.Text)
            {
                slep1.Start();
                if (t3.Text != "")
                {
                    Player.controls.play();
                    slep1.Stop();
                    if (t2.Text != "" && t1.Text != "" && t3.Text != "")
                    {
                       
                        b3.PerformClick();
                    
                    }
                }

            
            }

            ////QR 444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444


            if (BCodeValue != null && l1.Text == "4 Person" && t1.Text == "")
            {
                Player.controls.play();
                txtqr1();
                t1.Text = clsMySQL.f1;
                BCodeValue = null;
            }
                if (BCodeValue != null && l1.Text == "4 Person" && t1.Text != "" && t1.Text != t2.Text)
                {
                    slep.Start();
                    if (t2.Text != "")
                {
                    Player.controls.play();
                    slep.Stop();

                    }

                }

            if (BCodeValue != null && l1.Text == "4 Person" && t1.Text != "" && t2.Text != "")
            {
                slep1.Start();
                if (t3.Text != "")
                {
                    Player.controls.play();
                    slep1.Stop();
                
                }
            }

                    if (BCodeValue != null && l1.Text == "4 Person" && t1.Text != "" && t2.Text != "" && t3.Text!="")
                    {
                        slep2.Start();
                        if (t4.Text != "")
                {
                    Player.controls.play();
                    slep2.Stop();

                        }
                    }
                    b3.PerformClick();
                
            
            ////QR55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555

            if (BCodeValue != null && l1.Text == "5 Person" && t1.Text == "")
            {
                Player.controls.play();
                txtqr1();
                t1.Text = clsMySQL.f1;
                BCodeValue = null;
            }
            if (BCodeValue != null && l1.Text == "5 Person" && t1.Text != "" && t1.Text != t2.Text)
            {
                slep.Start();
                if (t2.Text != "")
                {
                    Player.controls.play();
                    slep.Stop();

                }

              
            }

            if (BCodeValue != null && l1.Text == "5 Person" && t1.Text != "" && t2.Text != "")
            {
                slep1.Start();
                if (t3.Text != "")
                {
                    Player.controls.play();
                    slep1.Stop();

                }
            }
                
                if (BCodeValue != null && l1.Text == "5 Person" && t1.Text != "" && t2.Text != "" && t3.Text!="")
                {
                    slep2.Start();
                    if (t4.Text != "")
                {
                    Player.controls.play();
                    slep2.Stop();

                    }
                 
                }
                if (BCodeValue != null && l1.Text == "5 Person" && t1.Text != "" && t2.Text != "" && t3.Text!="" &&t4.Text!="")
                {
                    slep3.Start();
                    if (t5.Text != "")
                {
                    Player.controls.play();
                    slep3.Stop();

                    }
                          b3.PerformClick();
                }
            
        }
        
        private void slep_Tick(object sender, EventArgs e)
        {
            
            string BCodeValue = ReadCode();
            txtqr2();       
            t2.Text = clsMySQL.f2;
            BCodeValue = null;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sc();
            label2.Focus();
            stop.Stop();
            string BCodeValue = ReadCode();
            BCodeValue = null;
            t1.Clear();
            t2.Clear();
            t3.Clear();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            t1.Visible = true;
            b3.Visible = true;
            l1.Text = "3 Person";
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = false;
            t5.Visible = false;
            p1.BringToFront();
            p1.Dock = DockStyle.Fill;
            none();
            t1.Enabled = false;
            t2.Enabled = false;
            t3.Enabled = false;
            label2.Text = "Press F11 no QR";
        }

        private void none()
        {
            clsMySQL.f1 = null;
            clsMySQL.f2 = null;
            clsMySQL.f3 = null;
            clsMySQL.f5 = null;
            clsMySQL.f4 = null;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sc();
            label2.Focus();
            stop.Stop();
            none();
            string BCodeValue = ReadCode();
            BCodeValue = null;
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            t1.Visible = true;
            b3.Visible = true;
            t5.Visible = false;
            l1.Text = "4 Person";
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            p1.BringToFront();
            p1.Dock = DockStyle.Fill;
            t1.Enabled = false;
            t2.Enabled = false;
            t3.Enabled = false;
            t4.Enabled = false;
            label2.Text = "Press F11 no QR";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sc();
            label2.Focus();
            stop.Stop();
            string BCodeValue = ReadCode();
            BCodeValue = null;
            none();
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            t5.Clear();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            t1.Visible = true;
            b3.Visible = true;
            l1.Text = "5 Person";
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            p1.BringToFront();
            p1.Dock = DockStyle.Fill;
            t1.Enabled = false;
            t2.Enabled = false;
            t3.Enabled = false;
            t4.Enabled = false;
            t5.Enabled = false;
            label2.Text = "Press F11 no QR";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
                if ("User" == (clsMySQL.ttb))
                {
                    Form b = new USER();
                    b.Show();
                    this.Visible = false;
                   
                }
                if ("Admin" == (clsMySQL.ttb))
                {
                    Form b = new Admin();
                    b.Show();
                    this.Visible = false;
                   
                }
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            button1.Focus();
            p3.Visible = true;
            p3.BringToFront();
            p3.Dock = DockStyle.Fill;
            FinalFrame.Stop();
            stop.Stop();
        
        }

        private void slep1_Tick(object sender, EventArgs e)
        {

            string BCodeValue = ReadCode();
            txtqr3();
            t3.Text = clsMySQL.f3;
            BCodeValue = null;
        }

        private void slep2_Tick(object sender, EventArgs e)
        {
            string BCodeValue = ReadCode();
            txtqr4();
            t4.Text = clsMySQL.f4;
            BCodeValue = null;
        }

        private void slep3_Tick(object sender, EventArgs e)
        {
            string BCodeValue = ReadCode();
            txtqr5();
            t5.Text = clsMySQL.f5;
            BCodeValue = null;
        }

  
        private void Found_Tick(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FinalFrame.Stop();
        }

      
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            button9.PerformClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hid();
            load.Stop();
            name.Stop();
           
        }

        private void name_Tick(object sender, EventArgs e)
        {
            panel3.BringToFront();
            panel3.Dock = DockStyle.Fill;
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Focus();
            p3.Visible = true;
            p3.BringToFront();
            p3.Dock = DockStyle.Fill;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button6.PerformClick();
            }
            if (e.KeyCode == Keys.F1)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.F3)
            {
                button3.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {
                button4.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                button5.PerformClick();
            }
            if (e.KeyCode == Keys.F10)
            {
                tmScan.Start();
            
            }
            if (e.KeyCode == Keys.F10)
            {
                tmScan.Start();
                label2.Text = "Press F11 no QR";
            }
            if (e.KeyCode == Keys.F11)
            {
                tmScan.Stop();
                label2.Text = "Press F10 to Scan";

            }

        }

        private void t1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && l1.Text == "1 Person")
            {
                b3.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button8.PerformClick();
            }
            if (e.KeyCode == Keys.Enter && t1.Text != "")
            {
                t2.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                t2.Focus();
            }
            if (e.KeyCode == Keys.F10)
            {
                sc();
                eneble();
                label2.Text = "Press F11 no QR";
                label2.Focus();
            }
            if (e.KeyCode == Keys.F11)
            {
                tmScan.Stop();
                label2.Text = "Press F10 to Scan";
             
            }
        }
        private void t2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && l1.Text == "2 Person")
            {
                b3.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button8.PerformClick();
            }
            if (e.KeyCode == Keys.Enter && t2.Text != "")
            {
                t3.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                t1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                t3.Focus();
            }
            if (e.KeyCode == Keys.F10)
            {
                sc();
                eneble();
                label2.Focus();
                label2.Text = "Press F11 no QR";
            }
            if (e.KeyCode == Keys.F11)
            {
                label2.Text = "Press F10 to Scan";

            }
        }
        private void eneble()
        {
            t1.Enabled = false;
            t2.Enabled = false;
            t3.Enabled = false;
            t4.Enabled = false;
            t5.Enabled = false;
        }
        private void t3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && l1.Text =="3 Person")
            {
                b3.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button8.PerformClick();
            }
           
            if (e.KeyCode == Keys.Enter && t3.Text != "")
            {
                t4.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                t2.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                t4.Focus();
            }
            if (e.KeyCode == Keys.F10)
            {
                sc();
                eneble();
                label2.Focus();
                label2.Text = "Press F11 no QR";
            }
            if (e.KeyCode == Keys.F11)
            {
                label2.Text = "Press F10 to Scan";

            }

        }

        private void t4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && l1.Text == "4 Person")
            {
                b3.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button8.PerformClick();
            }
            if (e.KeyCode == Keys.Enter && t4.Text != "")
            {
                t5.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                t3.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                t5.Focus();
            }
            if (e.KeyCode == Keys.F10)
            {
                sc();
                eneble();
                label2.Focus();
                label2.Text = "Press F11 no QR";
            }
            if (e.KeyCode == Keys.F11)
            {
                label2.Text = "Press F10 to Scan";

            }
        }

        private void t5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && l1.Text == "5 Person" )
            {
                b3.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                button8.PerformClick();
            }
            if (e.KeyCode == Keys.Up)
            {
                t4.Focus();
            }
            if (e.KeyCode == Keys.F10)
            {
                sc();
                eneble();
                label2.Focus();
                label2.Text = "Press F11 no QR";
            }
            if (e.KeyCode == Keys.F11)
            {
                label2.Text = "Press F10 to Scan";
                
            }

        }
        private void sc()
        {
           tmScan.Start();
           slep3.Start();
            slep2.Start();
            slep1.Start();
            slep.Start();
        }
        private void st()
        {
            tmScan.Stop();
            slep3.Stop();
            slep2.Stop();
            slep1.Stop();
            slep.Stop();
        }
        private void label2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
               
                st();
                label2.Text = "Press F10 to Scan";
                t1.Enabled = true;
                t2.Enabled = true;
                t3.Enabled = true;
                t4.Enabled = true;
                t5.Enabled = true;
                t1.Focus();
            }
             if (e.KeyCode == Keys.Escape)
                {
                    button8.PerformClick();
                }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel4.Dock = DockStyle.Fill;
            panel4.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            lb1.Text = tt2.Text + "," + t11.Text;
            err();
            err1();
            if (t11.Text == "" || tt2.Text == "" || tt3.Text == "" || tt4.Text == "" || tt5.Text == "" || tqr.Text == "")
            {
                MessageBox.Show("Please complete all information needed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tqr.Text == (clsMySQL.qr1))
            {
                MessageBox.Show("QR CODE already registered.", "TRY ANOTHER QR no.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lb1.Text == (clsMySQL.nf))
            {
                MessageBox.Show("Name already registered", "RECORD FOUND", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tqr.Text != clsMySQL.qr1)
            {
                erra();
                erras();
                if (MessageBox.Show("Are you sure you want to register?", "REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (tt5.Text != clsMySQL.namess)
                    {
                        agency();
                    }

                    if (tt5.Text == clsMySQL.namess)
                    {
                        c = c + counts;
                        agenu();
                    }
                    MessageBox.Show(lb1.Text + " Successfully register", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    y();
                    newf();
                }

            }
        }
        public void newf()
        {
            t11.Clear();
            tt2.Clear();
            tt3.Text = null;
            tt4.Text = null;
            tt5.Clear();
            tqr.Clear();
            lb1.Text = "Registration";
        }

        private void agency()
        {
            string sql = "INSERT INTO Agency VALUES (null, '" + tt5.Text + "', '" + counts + "')";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void tqr_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tqr.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                tqr.Text = tqr.Text.Remove(tqr.Text.Length - 1);
            }

        }
        private void erra()
        {

            string sql = "SELECT * FROM Agency";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.namess = (rd["agency"].ToString());


            }
            rd.Close();


        }
        private void erras()
        {
            int t = 0;
            string sql = "SELECT * FROM Agency where agency =  '" + tt5.Text + "'";
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
            string sql = " UPDATE Agency SET count='" + c + "' WHERE agency ='" + tt5.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            p3.BringToFront();
            p3.Dock = DockStyle.Fill;

        }

    


        private void timer1_Tick_2(object sender, EventArgs e)
        {
            lada.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
