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
namespace PROSY_REDEMPLEMARCELO
{
    public partial class Login : Form
    {
        public static string sid;
        MySqlCommand sql_cmd = new MySqlCommand();
        public static int counter = 3;
      
        public Login()
        {
            InitializeComponent();
            if (clsMySQL.sql_con.State == ConnectionState.Open)
            {
                clsMySQL.sql_con.Close();
            }
            clsMySQL.sql_con.Open();

            pforget.Visible = false;
            pcreat.Visible = false;
         
        }

       

        private void lforgot_Click(object sender, EventArgs e)
        {
            tfind.Text = "Username or phone ";
            pforget.Visible = true;
            pforget.Dock = DockStyle.Fill;
            psec.Visible = false;
        }

        private void tuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            answer();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UP();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            pforget.Visible = true;
            pforget.Dock = DockStyle.Fill;
            psec.Visible = false;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel ?", "Forgot password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pforget.Visible = false;
                pcreat.Visible = false;
                anser.Clear();
            }
            else return;
        }

        private void label13_Click(object sender, EventArgs e)
        {
           
        
    }

        private void label16_Click(object sender, EventArgs e)
        {
            username();
            if (tus.Text == (clsMySQL.ttt))
            {
                MessageBox.Show("Your Usernsme is already taken, try another Username ", "Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tus.Focus();
                return;
            }


            if (SaveNot())
            {
                tlast.Focus();
                return;
            }
            if (tpa.Text == tre.Text && tus.Text != (clsMySQL.ttt))
            {
                if (MessageBox.Show("Are you sure you want to Save new  account?", "Creat new account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("New account has been Create Succesfully!", "Creat new account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CREAT_Data();
                    pforget.Visible = false;
                    pcreat.Visible = false;
           
                }
                else return;
            }
            else MessageBox.Show(" Oppps ! Your password not match!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);


            tre.Clear();
            tre.Focus();
            return;
        }

        private void  CREAT_Data()
        {
                 string sql = "INSERT INTO login VALUES (null,'" + "user" + "','" + tpa.Text + "','" + tus.Text + "','" + tname.Text + "','" + tlast.Text + "','" + cge.Text + "','" + tage.Text + "','" + tadd.Text + "','" + cse.Text + "','" + tans.Text + "','" + tcon.Text + "','" + "Not Log Out Found" + "', now() ,'"+ "Active" + "','"+ "Thank you for Creating Account her, Update Your Account always because if you are not Update your Account Regurlarly it can be Deactivate by the Admin " + "', now())";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();
     

        }


        private void answer()
        {

            if (anser.Text == "" || (clsMySQL.ttq) == "")
            {
                MessageBox.Show("Answer the question first before  continue.", "Forgot Password Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT * FROM login where ans='" + anser.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.tta = (rd["seq"].ToString());
                clsMySQL.ttq = (rd["ans"].ToString());
                label18.Text = "" + (rd["fname"].ToString()) + " " + (rd["lname"].ToString());
                label11.Text = (rd["pass"].ToString());
            }
            rd.Close();

            if (anser.Text == (clsMySQL.ttq))
            {
                psec3.Visible = true;
                psec3.Dock = DockStyle.Fill;
                l3.Focus();
            }

            else MessageBox.Show("Forgot Password is unavailable for this user, if you think this is an error, please go back and answer again.", "Forgot Password Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }
        private void UP()
        {

            if (tfind.Text == "" || (clsMySQL.ttt) == "")
            {
                MessageBox.Show("Insert your username or phone.", "No Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT * FROM login where user='" + tfind.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.ttt = (rd["user"].ToString());
                clsMySQL.ttl = (rd["contact"].ToString());
                label10.Text = " " + (rd["seq"].ToString());


            }
            rd.Close();

            if (tfind.Text == (clsMySQL.ttt) || tfind.Text == (clsMySQL.ttl))
            {
                psec3.Visible = false;
                psec.Visible = true;
                psec.Dock = DockStyle.Fill;
            }

            else MessageBox.Show("Your search did not return any results.Please try again with other information", "No Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }
        private void username()
        {



            string sql = "SELECT * FROM login where user='" + tus.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.ttt = (rd["user"].ToString());


            }
            rd.Close();





        }
        private void Update_Data()
        {
          
            string sql = " UPDATE login SET pass = '" + tnewre.Text  + "'WHERE user='" + tfind.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            cmd.ExecuteNonQuery();





        }
        private void Log()
        {
            string sql = "SELECT * FROM login where user='" + tuser.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                clsMySQL.sUN = (rd["user"].ToString());
                clsMySQL.sPW = (rd["pass"].ToString());
                clsMySQL.ttb = (rd["Administrator"].ToString());
                clsMySQL.tty = (rd["status"].ToString());

            }
            rd.Close();
            if (tpass.Text == (clsMySQL.sPW) && tuser.Text != (clsMySQL.sUN))
            {
                MessageBox.Show("No Valid  Username!", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tuser.Focus();
                return;
            }

            if (tpass.Text == "")
            {
                tpass.Focus();
                tpass.Clear();
                return;
            }


            if (tuser.Text == "" || tuser.Text == "" && tpass.Text == "")
            {
                tuser.Focus();
                return;
            }

         


            if (tuser.Text == (clsMySQL.sUN) && tpass.Text != (clsMySQL.sPW))
            {
                {  MessageBox.Show("No Valid Password", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                counter--;
                tpass.Focus();
                }
               

                if (counter == 1)
                {
                    MessageBox.Show("Find Account!", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tfind.Text = tuser.Text;
                    pforget.Visible = true;
                    pforget.Dock = DockStyle.Fill;
                    psec.Visible = false;

                }
            }
            if ("Active" != (clsMySQL.tty)){

                MessageBox.Show("Your Account has been Deactivated", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


           

            if (tpass.Text == (clsMySQL.sPW) && tuser.Text == (clsMySQL.sUN) && "user"== (clsMySQL.ttb) && "Active" == (clsMySQL.tty))
            {
                Form b = new USER();
                b.Show();
                this.Visible = false;
                sql = " UPDATE login SET intime = now()  WHERE user='" + tuser.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                return;

            }
            if (tpass.Text == (clsMySQL.sPW) && tuser.Text == (clsMySQL.sUN) && "Admin" == (clsMySQL.ttb))
            {
                Form b = new Form1();
                b.Show();
                this.Visible = false;
                sql = " UPDATE login SET intime = now()  WHERE user='" + tuser.Text +"'";
                MySqlCommand cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                cmd.ExecuteNonQuery();
                return;
             

            }

            if (tpass.Text != (clsMySQL.sPW) && tuser.Text != (clsMySQL.sUN))
            {
                MessageBox.Show("Invalid Username and  Password, Please Try Again! ", "Login Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   tuser.Focus();
            }



        }



        private Boolean SaveNot()
        {
            Boolean err = false;

            if (tname.Text == "" || tname.Text == "First name")
            {
                tname.ForeColor = Color.Red;
                err = true;
            }
            if (tlast.Text == "" || tlast.Text == "Last name")
            {
                tlast.ForeColor = Color.Red;
                err = true;
            }

            if (cge.Text == "" || cge.Text == "Gender")
            {
                cge.ForeColor = Color.Red;
                err = true;
            }

            if (tage.Text == "" || tage.Text == "Age")
            {
                tage.ForeColor = Color.Red;
                err = true;
            }

            if (tcon.Text == "" || tcon.Text == "Contact number")
            {
                tcon.ForeColor = Color.Red;
                err = true;
            }

            if (tadd.Text == "" || tadd.Text == "Address")
            {
                tadd.ForeColor = Color.Red;
                err = true;
            }
            if (tus.Text == "" || tus.Text == "User name")
            {
                tus.ForeColor = Color.Red;
                err = true;
            }
            if (tpa.Text == "" || tpa.Text == "Choose a Password")
            {
                tpa.ForeColor = Color.Red;
                err = true;
            }
            if (tre.Text == "" || tre.Text == "Re-type Password")
            {
                tre.ForeColor = Color.Red;
                err = true;
            }
            if (cse.Text == "" || cse.Text == "Security question ( choose one )")
            {
                cse.ForeColor = Color.Red;
                err = true;
            }
            if (tans.Text == "" || tans.Text == "Your Answer")
            {
                tans.ForeColor = Color.Red;
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

        private void tpass_Click(object sender, EventArgs e)
        {
            tpass.Clear();
        }

        private void tuser_Click(object sender, EventArgs e)
        {
            tuser.Clear();
        }



        private void tname_Enter(object sender, EventArgs e)
        {
            if (tname.Text == "First name")
            {
                tname.Clear();
               
                tname.ForeColor = Color.Black;
            }

        }

        private void lcreat_Click_1(object sender, EventArgs e)
        {
            pforget.Visible = false;
            pcreat.Visible = true;
            pcreat.Dock = DockStyle.Fill;
            tname.Clear();
            tname.Text = "First name";
            tname.ForeColor = Color.Black;


            tlast.Clear();
            tlast.Text = "Last name";
            tlast.ForeColor = Color.Black;


            cge.Text = null;
            cge.Text = "Gender";
            cge.ForeColor = Color.Black;


            cse.Text = null;
            cse.Text = "Security question ( choose one )";
            cse.ForeColor = Color.Black;



            tage.Clear();
            tage.Text = "Age";
            tage.ForeColor = Color.Black;



            tcon.Clear();
            tcon.Text = "Contact number";
            tcon.ForeColor = Color.Black;



            tadd.Clear();
            tadd.Text = "Address";
            tadd.ForeColor = Color.Black;


            tus.Clear();
            tus.Text = "User name";
            tus.ForeColor = Color.Black;


            tre.Clear();
            tre.Text = "Re-type Password";
            tre.ForeColor = Color.Black;


            tpa.Clear();
            tpa.Text = "Choose a Password";
            tpa.ForeColor = Color.Black;
            tpa.BackColor = Color.White;


            tans.Text = "Your Answer";
            tans.ForeColor = Color.Black;

        }

        private void tname_Leave(object sender, EventArgs e)
        {
            if (tname.Text == "")
            {
                tname.Text = "First name";
                tname.ForeColor = Color.Gray;
            }

        }

        private void tlast_Leave(object sender, EventArgs e)
        {
            if (tlast.Text == "")
            {
                tlast.Text = "Last name";
                tname.ForeColor = Color.Gray;
            }

        }

        private void tlast_Enter(object sender, EventArgs e)
        {
            if (tlast.Text == "Last name")
            {
                tlast.Clear();
                tlast.ForeColor = Color.Black;
            }
        }

        private void cge_Leave(object sender, EventArgs e)
        {
            if (cge.Text == "")
            {
                cge.Text = "Gender";
                cge.ForeColor = Color.Gray;
            }
        }

        private void cge_Enter(object sender, EventArgs e)
        {
            
            cge.BackColor = Color.White;
            if (cge.Text == "Gender")
            {
                cge.Text = null;
                cge.ForeColor = Color.Black;
            }
        }

        private void tage_Enter(object sender, EventArgs e)
        {
            if (tage.Text == "Age")
            {
                tage.Clear();
                
                tage.ForeColor = Color.Black;
            }
        }

        private void tage_Leave(object sender, EventArgs e)
        {
            if (tage.Text == "")
            {
                tage.Text = "Age";
                tage.ForeColor = Color.Gray;
            }
         
        }

        private void tcon_Leave(object sender, EventArgs e)
        {
            if (tcon.Text == "")
            {
                tcon.Text = "Contact number";
                tcon.ForeColor = Color.Gray;
            }
          
        }

        private void tcon_Enter(object sender, EventArgs e)
        {
            if (tcon.Text == "Contact number")
            {
                tcon.Clear();
                
                tcon.ForeColor = Color.Black;
            }
        }

        private void tadd_Enter(object sender, EventArgs e)
        {
            if (tadd.Text == "Address")
            {
                tadd.Clear();
              
                tadd.ForeColor = Color.Black;
            }
        }

        private void tadd_Leave(object sender, EventArgs e)
        {
            if (tadd.Text == "")
            {
                tadd.Text = "Address";
                tadd.ForeColor = Color.Gray;
            }
           
        }

        private void tus_Leave(object sender, EventArgs e)
        {

            if (tus.Text == "")
            {
                tus.Text = "User name";
                tus.ForeColor = Color.Gray;
            }
        

        }

        private void tus_Enter(object sender, EventArgs e)
        {
            if (tus.Text == "User name")
            {
                tus.Clear();
             
                tus.ForeColor = Color.Black;
            }
        }

        private void tpa_Enter(object sender, EventArgs e)
        {

            if (tpa.Text == "Choose a Password")
            {
                tpa.Clear();
                
                tpa.ForeColor = Color.Black;
            }
        }

        private void tpa_Leave(object sender, EventArgs e)
        {
            if (tpa.Text == "")
            {
                tpa.Text = "Choose a Password";
                tpa.ForeColor = Color.Gray;
            }
            
        }

        private void tre_Enter(object sender, EventArgs e)
        {
            if (tre.Text == "Re-type Password")
            {
                tre.Clear();
            
                tre.ForeColor = Color.Black;
            }
        }

        private void tre_Leave(object sender, EventArgs e)
        {
            if (tre.Text == "")
            {
                tre.Text = "Re-type Password";
                tre.ForeColor = Color.Gray;
            }
      
        }

        private void tans_Enter(object sender, EventArgs e)
        {
            if (tans.Text == "Your Answer")
            {
                tans.Clear();
               
                tans.ForeColor = Color.Black;
            }
        }

        private void tans_Leave(object sender, EventArgs e)
        {
            if (tans.Text == "")
            {
                tans.Text = "Your Answer";
                tans.ForeColor = Color.Gray;
            }
        
        }

        private void cse_Leave(object sender, EventArgs e)
        {
            if (cse.Text == "")
            {
                cse.Text = "Security question ( choose one )";
                cse.ForeColor = Color.Gray;
            }
           
        }

        private void cse_Enter(object sender, EventArgs e)
        {
            if (cse.Text == "Security question ( choose one )")
            {
                cse.Text = null;
            
                cse.ForeColor = Color.Black;
            }

        }

        private void tname_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tfind_Enter(object sender, EventArgs e)
        {
            tfind.Clear();
        }

        private void tfind_Leave(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            pforget.Visible = false;
            pcreat.Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            pforget.Visible = false;
            pcreat.Visible = false;
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            Log();
        }

        private void tuser_Leave(object sender, EventArgs e)
        {

        }

        private void tpass_Leave(object sender, EventArgs e)
        {

        }

      

        private void tpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void tuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tpass.Focus();
            }
        }

        private void anser_Click(object sender, EventArgs e)
        {
            anser.Clear();
        }

        private void tnewpass_Click(object sender, EventArgs e)
        {

            tnewpass.Clear();
        }

      

        private void tnewre_Click(object sender, EventArgs e)
        {
            tnewre.Clear();

        }

        private void l3_Click(object sender, EventArgs e)
        {
            if (tnewpass.Text == "Enter new password" && tnewre.Text == "Re-type new Password" || tnewpass.Text == "" && tnewre.Text == "Re-type new Password" || tnewre.Text == "" && tnewpass.Text == "Enter new password")

            {
                if (MessageBox.Show("Are you sure you want to Recover your Account ?", "Forgot password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Account has been Recovered Succesfully!", "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pforget.Visible = false;
                    pcreat.Visible = false;
                    tnewpass.Clear();
                    tnewre.Clear();
                    tnewpass.Text = "Enter new password";
                    tnewre.Text = "Re-type new Password";
                    anser.Clear();
                    return;
                }
            }

            if (tnewpass.Text == tnewre.Text)
            {


                if (MessageBox.Show("Are you sure you want to change  your Password ?", "Forgot password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Update_Data();
                    MessageBox.Show("Password has been Change Succesfully!", "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pforget.Visible = false;
                    pcreat.Visible = false;
                    tnewpass.Clear();
                    tnewre.Clear();
                    tnewpass.Text = "Enter new password";
                    tnewre.Text = "Re-type new Password";
                    anser.Clear();
                }
                tnewpass.Text = "Enter new password";
                tnewre.Text = "Re-type new Password";
                return;
            }
            else MessageBox.Show(" Oppps ! Your password not match!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tfind_Click(object sender, EventArgs e)
        {
            tfind.Clear();
        }
    }
}
