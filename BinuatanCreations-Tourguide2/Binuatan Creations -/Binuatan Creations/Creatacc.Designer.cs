namespace Binuatan_Creations
{
    partial class Creatacc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creatacc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cse = new System.Windows.Forms.ComboBox();
            this.tpa = new System.Windows.Forms.TextBox();
            this.tre = new System.Windows.Forms.TextBox();
            this.tcon = new System.Windows.Forms.TextBox();
            this.tus = new System.Windows.Forms.TextBox();
            this.tlast = new System.Windows.Forms.TextBox();
            this.tname = new System.Windows.Forms.TextBox();
            this.tans = new System.Windows.Forms.TextBox();
            this.com1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.com1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cse);
            this.panel1.Controls.Add(this.tpa);
            this.panel1.Controls.Add(this.tre);
            this.panel1.Controls.Add(this.tcon);
            this.panel1.Controls.Add(this.tus);
            this.panel1.Controls.Add(this.tlast);
            this.panel1.Controls.Add(this.tname);
            this.panel1.Controls.Add(this.tans);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 550);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(277, 491);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 41);
            this.button2.TabIndex = 57;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(26, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 41);
            this.button1.TabIndex = 57;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cse
            // 
            this.cse.BackColor = System.Drawing.Color.White;
            this.cse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cse.ForeColor = System.Drawing.Color.Gray;
            this.cse.FormattingEnabled = true;
            this.cse.Items.AddRange(new object[] {
            "What city where you born in?",
            "What is your mother\'s maiden name?",
            "What was the name of your first pet?",
            "Who is your favorite author?",
            "What was the name of your favorite teacher?",
            "What was the name of the street on which you grew up?",
            "What is the name of your favorite sports team?",
            "Who is your all-time favorite movie character?"});
            this.cse.Location = new System.Drawing.Point(39, 343);
            this.cse.Name = "cse";
            this.cse.Size = new System.Drawing.Size(325, 24);
            this.cse.TabIndex = 55;
            this.cse.TabStop = false;
            this.cse.Text = "Security question ( choose one )";
            this.cse.Enter += new System.EventHandler(this.cse_Enter);
            this.cse.Leave += new System.EventHandler(this.cse_Leave);
            // 
            // tpa
            // 
            this.tpa.BackColor = System.Drawing.Color.White;
            this.tpa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpa.ForeColor = System.Drawing.Color.Gray;
            this.tpa.Location = new System.Drawing.Point(41, 234);
            this.tpa.Name = "tpa";
            this.tpa.Size = new System.Drawing.Size(323, 19);
            this.tpa.TabIndex = 52;
            this.tpa.TabStop = false;
            this.tpa.Text = "Choose a Password";
            this.tpa.Enter += new System.EventHandler(this.tpa_Enter);
            this.tpa.Leave += new System.EventHandler(this.tpa_Leave);
            // 
            // tre
            // 
            this.tre.BackColor = System.Drawing.Color.White;
            this.tre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tre.ForeColor = System.Drawing.Color.Gray;
            this.tre.Location = new System.Drawing.Point(42, 288);
            this.tre.Name = "tre";
            this.tre.Size = new System.Drawing.Size(322, 19);
            this.tre.TabIndex = 51;
            this.tre.TabStop = false;
            this.tre.Text = "Re-type Password";
            this.tre.Enter += new System.EventHandler(this.tre_Enter);
            this.tre.Leave += new System.EventHandler(this.tre_Leave);
            // 
            // tcon
            // 
            this.tcon.BackColor = System.Drawing.Color.White;
            this.tcon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcon.ForeColor = System.Drawing.Color.Gray;
            this.tcon.Location = new System.Drawing.Point(37, 454);
            this.tcon.Name = "tcon";
            this.tcon.Size = new System.Drawing.Size(173, 19);
            this.tcon.TabIndex = 49;
            this.tcon.TabStop = false;
            this.tcon.Text = "Contact number";
            this.tcon.Enter += new System.EventHandler(this.tcon_Enter);
            this.tcon.Leave += new System.EventHandler(this.tcon_Leave);
            // 
            // tus
            // 
            this.tus.BackColor = System.Drawing.Color.White;
            this.tus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tus.ForeColor = System.Drawing.Color.Gray;
            this.tus.Location = new System.Drawing.Point(37, 176);
            this.tus.Name = "tus";
            this.tus.Size = new System.Drawing.Size(327, 19);
            this.tus.TabIndex = 48;
            this.tus.TabStop = false;
            this.tus.Text = "Username";
            this.tus.Enter += new System.EventHandler(this.tus_Enter);
            this.tus.Leave += new System.EventHandler(this.tus_Leave);
            // 
            // tlast
            // 
            this.tlast.BackColor = System.Drawing.Color.White;
            this.tlast.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlast.ForeColor = System.Drawing.Color.Gray;
            this.tlast.Location = new System.Drawing.Point(37, 119);
            this.tlast.Name = "tlast";
            this.tlast.Size = new System.Drawing.Size(327, 19);
            this.tlast.TabIndex = 47;
            this.tlast.TabStop = false;
            this.tlast.Text = "Last name";
            this.tlast.Enter += new System.EventHandler(this.tlast_Enter);
            this.tlast.Leave += new System.EventHandler(this.tlast_Leave);
            // 
            // tname
            // 
            this.tname.BackColor = System.Drawing.Color.White;
            this.tname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tname.ForeColor = System.Drawing.Color.Gray;
            this.tname.Location = new System.Drawing.Point(38, 63);
            this.tname.Name = "tname";
            this.tname.Size = new System.Drawing.Size(326, 19);
            this.tname.TabIndex = 46;
            this.tname.TabStop = false;
            this.tname.Text = "First name";
            this.tname.Enter += new System.EventHandler(this.tname_Enter);
            this.tname.Leave += new System.EventHandler(this.tname_Leave);
            // 
            // tans
            // 
            this.tans.BackColor = System.Drawing.Color.White;
            this.tans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tans.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tans.ForeColor = System.Drawing.Color.Gray;
            this.tans.Location = new System.Drawing.Point(41, 401);
            this.tans.Name = "tans";
            this.tans.Size = new System.Drawing.Size(323, 19);
            this.tans.TabIndex = 56;
            this.tans.TabStop = false;
            this.tans.Text = "Your Answer";
            this.tans.Enter += new System.EventHandler(this.tans_Enter);
            this.tans.Leave += new System.EventHandler(this.tans_Leave);
            // 
            // com1
            // 
            this.com1.BackColor = System.Drawing.Color.White;
            this.com1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.com1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.com1.ForeColor = System.Drawing.Color.Gray;
            this.com1.FormattingEnabled = true;
            this.com1.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.com1.Location = new System.Drawing.Point(236, 451);
            this.com1.Name = "com1";
            this.com1.Size = new System.Drawing.Size(128, 24);
            this.com1.TabIndex = 59;
            this.com1.TabStop = false;
            this.com1.Text = "Status";
            // 
            // Creatacc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Creatacc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creatacc";
            this.Load += new System.EventHandler(this.Creatacc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tans;
        private System.Windows.Forms.ComboBox cse;
        private System.Windows.Forms.TextBox tpa;
        private System.Windows.Forms.TextBox tre;
        private System.Windows.Forms.TextBox tcon;
        private System.Windows.Forms.TextBox tus;
        private System.Windows.Forms.TextBox tlast;
        private System.Windows.Forms.TextBox tname;
        private System.Windows.Forms.ComboBox com1;
    }
}