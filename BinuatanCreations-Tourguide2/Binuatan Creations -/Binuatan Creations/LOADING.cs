using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binuatan_Creations
{
    public partial class LOADING : Form
    {
        public LOADING()
        {
            InitializeComponent();
        }

      

        private void LOADING_Load(object sender, EventArgs e)
        {
            panel5.BringToFront();
            panel5.Dock = DockStyle.Fill;
            startload.Start();
        }

        private void startload_Tick(object sender, EventArgs e)
        {       
            
            if ((clsMySQL.loadings == "Home"))
            {
                if ("User" == (clsMySQL.ttb))
                {
                    Form b = new User();
                    b.Show();
                    this.Visible = false;
                    startload.Stop();
                }
                if ("Admin" == (clsMySQL.ttb))
                {
                    Form b = new Admin();
                    b.Show();
                    this.Visible = false;
                    startload.Stop();
                }


            }
           

        }
    }
}
