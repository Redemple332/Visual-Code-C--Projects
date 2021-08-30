using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
namespace PrintForm
{
    public partial class Form1 : Form
    {
        MySqlCommand sql_cmd = new MySqlCommand();
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
            
            this.rptViewer.RefreshReport();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string a = txName.Text;
            string b = txAdd.Text;

            ReportParameter rpName = new ReportParameter("pName", a.ToString());
          //  ReportParameter rpAdd = new ReportParameter("pAdd", b.ToString());


            this.rptViewer.RefreshReport();
            /*
            this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rptViewer.LocalReport.ReportPath = Environment.CurrentDirectory + "\\rptname.rdlc";
            this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            this.rptViewer.LocalReport.DataSources.Clear();

            this.rptViewer.LocalReport.SetParameters(rpName);
            this.rptViewer.LocalReport.SetParameters(rpAdd);*/

            this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rptViewer.LocalReport.ReportPath = Environment.CurrentDirectory + "\\rptName.rdlc";
            this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            this.rptViewer.LocalReport.DataSources.Clear();

            this.rptViewer.LocalReport.SetParameters(rpName);
            //this.rptViewer.LocalReport.Refresh();
            this.rptViewer.DocumentMapCollapsed = true;
             this.rptViewer.RefreshReport();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ReportParameter rpName = new ReportParameter("pName", "Printed by:" + txName.Text);
            DataSet dstud = new DataSet();
            DataTable dtStud = new DataTable();
            DataRow dr;

            DataColumn dc1 = new DataColumn("ln", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("fn", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("strand", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("grade", Type.GetType("System.String"));

            dtStud.Columns.Add(dc1);
            dtStud.Columns.Add(dc2);
            dtStud.Columns.Add(dc3);
            dtStud.Columns.Add(dc4);

            string sql = "SELECT * FROM tblstud";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                dr = dtStud.NewRow();
                dr[0] = rd["ln"].ToString();
                dr[1] = rd["fn"].ToString();
                dr[2] = rd["grade"].ToString();
                dr[3] = rd["strand"].ToString();
                dtStud.Rows.Add(dr);
               
            }
            rd.Close();
            dstud.Tables.Add(dtStud);

            this.rptViewer.RefreshReport();
            this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rptViewer.LocalReport.ReportPath = Environment.CurrentDirectory + "\\rptStud.rdlc";
            this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

            ReportDataSource rds = new ReportDataSource("dsStudlist", dstud.Tables[0]);
            this.rptViewer.LocalReport.DataSources.Clear();
            this.rptViewer.LocalReport.SetParameters(rpName);

            this.rptViewer.LocalReport.DataSources.Add(rds);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.DocumentMapCollapsed = true;
            this.rptViewer.RefreshReport();


        }
    }
}
