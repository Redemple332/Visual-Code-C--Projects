using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace ProSys_alpha
{
    public partial class frmAddPic : Form
    {
        public byte[] arrImage;
        public string sDetails, sLoadImg;
        public bool Loadpic = false;
        public string sql;
        MySqlCommand sql_cmd = new MySqlCommand();

        public frmAddPic()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
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

        public void Account_Image(string zid)
        {
            DataSet dS = new DataSet();
            sql = "SELECT img FROM tblimage WHERE id = " + zid;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(sql_cmd);
            
            DataAdapter.Fill(dS,"pics");

            Byte[] byteBLOBData = new Byte[0];
            picProfile.Image = ByteToImage((Byte[])(dS.Tables["pics"].Rows[0]["img"]));
        }

        private void SaveImage()
        {
            if (Loadpic == true)
            {
                arrImage = ImgConvert(picProfile.Image);
            }


            if (arrImage != null)
            {
                sql = "INSERT INTO tblimage VALUES (null, @File)";
            }
                
            
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);

            var withBlock = sql_cmd;
            withBlock.CommandText = sql;
            withBlock.Connection = clsMySQL.sql_con;
            withBlock.Parameters.AddWithValue("@File", arrImage);
            withBlock.ExecuteNonQuery();

            MessageBox.Show("Picture has been Added!", "Add Picture", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static byte[] ImgConvert(Image x)
        {
            MemoryStream ms = new MemoryStream();
            x.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        
        private void frmAddPic_Load(object sender, EventArgs e)
        {
            clsMySQL.sql_con.Open();
            picProfile.ContextMenuStrip = cmsMenu;
            Load_ComboData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage();
           // Load_ComboData();
        }

        private void Load_ComboData()
        {
           
            string sql = "SELECT id FROM tblimage ORDER BY id ASC";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            cmsView.Items.Clear(); //Clear the Combobox before populating
            while (rd.Read())
            {
                cmsView.Items.Add("View Picture Account " + rd["id"].ToString());
            }
            rd.Close();

        }

        private void cmsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account_Image((cmsView.SelectedIndex + 1).ToString());
        }

        private void cmsView_Click(object sender, EventArgs e)
        {

        }

        private void cmsClear_Click(object sender, EventArgs e)
        {
            Loadpic = false;
            picProfile.Image = null;
        }

    }
}
