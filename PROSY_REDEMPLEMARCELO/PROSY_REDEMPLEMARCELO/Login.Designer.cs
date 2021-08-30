namespace PROSY_REDEMPLEMARCELO
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lcreat = new System.Windows.Forms.Label();
            this.lforgot = new System.Windows.Forms.Label();
            this.tpass = new System.Windows.Forms.TextBox();
            this.tuser = new System.Windows.Forms.TextBox();
            this.pforget = new System.Windows.Forms.Panel();
            this.psec = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.psec3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tnewre = new System.Windows.Forms.TextBox();
            this.tnewpass = new System.Windows.Forms.TextBox();
            this.l3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.anser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tfind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcreat = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tans = new System.Windows.Forms.TextBox();
            this.cse = new System.Windows.Forms.ComboBox();
            this.tage = new System.Windows.Forms.TextBox();
            this.cge = new System.Windows.Forms.ComboBox();
            this.tpa = new System.Windows.Forms.TextBox();
            this.tre = new System.Windows.Forms.TextBox();
            this.tadd = new System.Windows.Forms.TextBox();
            this.tcon = new System.Windows.Forms.TextBox();
            this.tus = new System.Windows.Forms.TextBox();
            this.tlast = new System.Windows.Forms.TextBox();
            this.tname = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pforget.SuspendLayout();
            this.psec.SuspendLayout();
            this.psec3.SuspendLayout();
            this.pcreat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcreat
            // 
            this.lcreat.AutoSize = true;
            this.lcreat.BackColor = System.Drawing.Color.Transparent;
            this.lcreat.Font = new System.Drawing.Font("Californian FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcreat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lcreat.Location = new System.Drawing.Point(372, 333);
            this.lcreat.Name = "lcreat";
            this.lcreat.Size = new System.Drawing.Size(62, 22);
            this.lcreat.TabIndex = 8;
            this.lcreat.Text = "Create";
            this.lcreat.Click += new System.EventHandler(this.lcreat_Click_1);
            // 
            // lforgot
            // 
            this.lforgot.AutoSize = true;
            this.lforgot.BackColor = System.Drawing.Color.Transparent;
            this.lforgot.Font = new System.Drawing.Font("Californian FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lforgot.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lforgot.Location = new System.Drawing.Point(184, 332);
            this.lforgot.Name = "lforgot";
            this.lforgot.Size = new System.Drawing.Size(146, 22);
            this.lforgot.TabIndex = 7;
            this.lforgot.Text = "Forgot password?";
            this.lforgot.Click += new System.EventHandler(this.lforgot_Click);
            // 
            // tpass
            // 
            this.tpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpass.Location = new System.Drawing.Point(214, 287);
            this.tpass.Name = "tpass";
            this.tpass.Size = new System.Drawing.Size(201, 19);
            this.tpass.TabIndex = 6;
            this.tpass.TabStop = false;
            this.tpass.Text = "Password";
            this.tpass.Click += new System.EventHandler(this.tpass_Click);
            this.tpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tpass_KeyDown);
            this.tpass.Leave += new System.EventHandler(this.tpass_Leave);
            // 
            // tuser
            // 
            this.tuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuser.Location = new System.Drawing.Point(213, 205);
            this.tuser.Name = "tuser";
            this.tuser.Size = new System.Drawing.Size(220, 19);
            this.tuser.TabIndex = 5;
            this.tuser.TabStop = false;
            this.tuser.Text = "User name";
            this.tuser.Click += new System.EventHandler(this.tuser_Click);
            this.tuser.TextChanged += new System.EventHandler(this.tuser_TextChanged);
            this.tuser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuser_KeyDown);
            this.tuser.Leave += new System.EventHandler(this.tuser_Leave);
            // 
            // pforget
            // 
            this.pforget.BackColor = System.Drawing.Color.Transparent;
            this.pforget.BackgroundImage = global::PROSY_REDEMPLEMARCELO.Properties.Resources.zz;
            this.pforget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pforget.Controls.Add(this.psec);
            this.pforget.Controls.Add(this.label4);
            this.pforget.Controls.Add(this.label3);
            this.pforget.Controls.Add(this.label2);
            this.pforget.Controls.Add(this.tfind);
            this.pforget.Controls.Add(this.label1);
            this.pforget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pforget.Location = new System.Drawing.Point(0, 0);
            this.pforget.Name = "pforget";
            this.pforget.Size = new System.Drawing.Size(602, 549);
            this.pforget.TabIndex = 9;
            // 
            // psec
            // 
            this.psec.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.psec.BackgroundImage = global::PROSY_REDEMPLEMARCELO.Properties.Resources.zzzz;
            this.psec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.psec.Controls.Add(this.label8);
            this.psec.Controls.Add(this.psec3);
            this.psec.Controls.Add(this.label10);
            this.psec.Controls.Add(this.anser);
            this.psec.Controls.Add(this.label9);
            this.psec.Controls.Add(this.label7);
            this.psec.Location = new System.Drawing.Point(319, 91);
            this.psec.Name = "psec";
            this.psec.Size = new System.Drawing.Size(175, 165);
            this.psec.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 5;
            // 
            // psec3
            // 
            this.psec3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.psec3.BackgroundImage = global::PROSY_REDEMPLEMARCELO.Properties.Resources.xxx;
            this.psec3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.psec3.Controls.Add(this.label20);
            this.psec3.Controls.Add(this.label13);
            this.psec3.Controls.Add(this.label18);
            this.psec3.Controls.Add(this.tnewre);
            this.psec3.Controls.Add(this.tnewpass);
            this.psec3.Controls.Add(this.l3);
            this.psec3.Controls.Add(this.label12);
            this.psec3.Controls.Add(this.label11);
            this.psec3.Location = new System.Drawing.Point(58, 19);
            this.psec3.Name = "psec3";
            this.psec3.Size = new System.Drawing.Size(84, 44);
            this.psec3.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(56, 187);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(190, 25);
            this.label20.TabIndex = 13;
            this.label20.Text = "Your password is :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(212, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 25);
            this.label13.TabIndex = 12;
            this.label13.Text = "Hi! ";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(251, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 25);
            this.label18.TabIndex = 11;
            this.label18.Text = "name..";
            // 
            // tnewre
            // 
            this.tnewre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tnewre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tnewre.Location = new System.Drawing.Point(106, 360);
            this.tnewre.Name = "tnewre";
            this.tnewre.Size = new System.Drawing.Size(356, 22);
            this.tnewre.TabIndex = 10;
            this.tnewre.Text = "Re-type new Password";
            this.tnewre.Click += new System.EventHandler(this.tnewre_Click);
            // 
            // tnewpass
            // 
            this.tnewpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tnewpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tnewpass.Location = new System.Drawing.Point(100, 300);
            this.tnewpass.Name = "tnewpass";
            this.tnewpass.Size = new System.Drawing.Size(367, 22);
            this.tnewpass.TabIndex = 9;
            this.tnewpass.Text = "Enter new password";
            this.tnewpass.Click += new System.EventHandler(this.tnewpass_Click);
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.BackColor = System.Drawing.Color.Transparent;
            this.l3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l3.ForeColor = System.Drawing.Color.Orange;
            this.l3.Location = new System.Drawing.Point(391, 474);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(154, 20);
            this.l3.TabIndex = 8;
            this.l3.Text = "Recover yor account";
            this.l3.Click += new System.EventHandler(this.l3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(243, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(178, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Your password is";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(212, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "sample question?";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anser
            // 
            this.anser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.anser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anser.ForeColor = System.Drawing.SystemColors.InfoText;
            this.anser.Location = new System.Drawing.Point(99, 262);
            this.anser.Name = "anser";
            this.anser.Size = new System.Drawing.Size(384, 22);
            this.anser.TabIndex = 1;
            this.anser.Text = "Enter Your Answer";
            this.anser.Click += new System.EventHandler(this.anser_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(440, 471);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "Continue";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.label7.Location = new System.Drawing.Point(355, 470);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "Cancel";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.label4.Location = new System.Drawing.Point(342, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cancel";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(456, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Search ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 2;
            // 
            // tfind
            // 
            this.tfind.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tfind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tfind.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tfind.Location = new System.Drawing.Point(96, 262);
            this.tfind.Name = "tfind";
            this.tfind.Size = new System.Drawing.Size(398, 22);
            this.tfind.TabIndex = 1;
            this.tfind.Text = "Username or phone ";
            this.tfind.Click += new System.EventHandler(this.tfind_Click);
            this.tfind.Enter += new System.EventHandler(this.tfind_Enter);
            this.tfind.Leave += new System.EventHandler(this.tfind_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 0;
            // 
            // pcreat
            // 
            this.pcreat.BackColor = System.Drawing.Color.Transparent;
            this.pcreat.BackgroundImage = global::PROSY_REDEMPLEMARCELO.Properties.Resources.z;
            this.pcreat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcreat.Controls.Add(this.label16);
            this.pcreat.Controls.Add(this.label17);
            this.pcreat.Controls.Add(this.tans);
            this.pcreat.Controls.Add(this.cse);
            this.pcreat.Controls.Add(this.tage);
            this.pcreat.Controls.Add(this.cge);
            this.pcreat.Controls.Add(this.tpa);
            this.pcreat.Controls.Add(this.tre);
            this.pcreat.Controls.Add(this.tadd);
            this.pcreat.Controls.Add(this.tcon);
            this.pcreat.Controls.Add(this.tus);
            this.pcreat.Controls.Add(this.tlast);
            this.pcreat.Controls.Add(this.tname);
            this.pcreat.ForeColor = System.Drawing.Color.Orange;
            this.pcreat.Location = new System.Drawing.Point(489, 262);
            this.pcreat.Name = "pcreat";
            this.pcreat.Size = new System.Drawing.Size(79, 116);
            this.pcreat.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Orange;
            this.label16.Location = new System.Drawing.Point(378, 471);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 24);
            this.label16.TabIndex = 7;
            this.label16.Text = "Create my Account";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.label17.Location = new System.Drawing.Point(283, 471);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 24);
            this.label17.TabIndex = 12;
            this.label17.Text = "Cancel";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // tans
            // 
            this.tans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tans.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tans.Location = new System.Drawing.Point(68, 435);
            this.tans.Name = "tans";
            this.tans.Size = new System.Drawing.Size(455, 22);
            this.tans.TabIndex = 11;
            this.tans.Text = "Your Answer";
            this.tans.Enter += new System.EventHandler(this.tans_Enter);
            this.tans.Leave += new System.EventHandler(this.tans_Leave);
            // 
            // cse
            // 
            this.cse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cse.Location = new System.Drawing.Point(67, 381);
            this.cse.Name = "cse";
            this.cse.Size = new System.Drawing.Size(452, 30);
            this.cse.TabIndex = 10;
            this.cse.Text = "Security question ( choose one )";
            this.cse.Enter += new System.EventHandler(this.cse_Enter);
            this.cse.Leave += new System.EventHandler(this.cse_Leave);
            // 
            // tage
            // 
            this.tage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tage.Location = new System.Drawing.Point(234, 177);
            this.tage.Name = "tage";
            this.tage.Size = new System.Drawing.Size(132, 22);
            this.tage.TabIndex = 9;
            this.tage.Text = "Age";
            this.tage.Enter += new System.EventHandler(this.tage_Enter);
            this.tage.Leave += new System.EventHandler(this.tage_Leave);
            // 
            // cge
            // 
            this.cge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cge.FormattingEnabled = true;
            this.cge.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cge.Location = new System.Drawing.Point(388, 173);
            this.cge.Name = "cge";
            this.cge.Size = new System.Drawing.Size(149, 30);
            this.cge.TabIndex = 8;
            this.cge.Text = "Gender";
            this.cge.Enter += new System.EventHandler(this.cge_Enter);
            this.cge.Leave += new System.EventHandler(this.cge_Leave);
            // 
            // tpa
            // 
            this.tpa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpa.Location = new System.Drawing.Point(70, 337);
            this.tpa.Name = "tpa";
            this.tpa.Size = new System.Drawing.Size(206, 22);
            this.tpa.TabIndex = 7;
            this.tpa.Text = "Choose a Password";
            this.tpa.Enter += new System.EventHandler(this.tpa_Enter);
            this.tpa.Leave += new System.EventHandler(this.tpa_Leave);
            // 
            // tre
            // 
            this.tre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tre.Location = new System.Drawing.Point(317, 337);
            this.tre.Name = "tre";
            this.tre.Size = new System.Drawing.Size(206, 22);
            this.tre.TabIndex = 6;
            this.tre.Text = "Re-type Password";
            this.tre.Enter += new System.EventHandler(this.tre_Enter);
            this.tre.Leave += new System.EventHandler(this.tre_Leave);
            // 
            // tadd
            // 
            this.tadd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tadd.Location = new System.Drawing.Point(71, 229);
            this.tadd.Name = "tadd";
            this.tadd.Size = new System.Drawing.Size(455, 22);
            this.tadd.TabIndex = 5;
            this.tadd.Text = "Address";
            this.tadd.Enter += new System.EventHandler(this.tadd_Enter);
            this.tadd.Leave += new System.EventHandler(this.tadd_Leave);
            // 
            // tcon
            // 
            this.tcon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcon.Location = new System.Drawing.Point(69, 178);
            this.tcon.Name = "tcon";
            this.tcon.Size = new System.Drawing.Size(146, 22);
            this.tcon.TabIndex = 4;
            this.tcon.Text = "Contact number";
            this.tcon.Enter += new System.EventHandler(this.tcon_Enter);
            this.tcon.Leave += new System.EventHandler(this.tcon_Leave);
            // 
            // tus
            // 
            this.tus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tus.Location = new System.Drawing.Point(71, 283);
            this.tus.Name = "tus";
            this.tus.Size = new System.Drawing.Size(451, 22);
            this.tus.TabIndex = 3;
            this.tus.Text = "User name";
            this.tus.Enter += new System.EventHandler(this.tus_Enter);
            this.tus.Leave += new System.EventHandler(this.tus_Leave);
            // 
            // tlast
            // 
            this.tlast.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlast.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlast.Location = new System.Drawing.Point(315, 124);
            this.tlast.Name = "tlast";
            this.tlast.Size = new System.Drawing.Size(223, 22);
            this.tlast.TabIndex = 2;
            this.tlast.Text = "Last name";
            this.tlast.Enter += new System.EventHandler(this.tlast_Enter);
            this.tlast.Leave += new System.EventHandler(this.tlast_Leave);
            // 
            // tname
            // 
            this.tname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tname.Location = new System.Drawing.Point(70, 124);
            this.tname.Name = "tname";
            this.tname.Size = new System.Drawing.Size(209, 22);
            this.tname.TabIndex = 1;
            this.tname.Text = "First name";
            this.tname.Enter += new System.EventHandler(this.tname_Enter);
            this.tname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tname_KeyDown);
            this.tname.Leave += new System.EventHandler(this.tname_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(178, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PROSY_REDEMPLEMARCELO.Properties.Resources.key_512;
            this.pictureBox3.Location = new System.Drawing.Point(177, 281);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(255, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROSY_REDEMPLEMARCELO.Properties.Resources.logcin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.pcreat);
            this.Controls.Add(this.pforget);
            this.Controls.Add(this.lcreat);
            this.Controls.Add(this.lforgot);
            this.Controls.Add(this.tpass);
            this.Controls.Add(this.tuser);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.pforget.ResumeLayout(false);
            this.pforget.PerformLayout();
            this.psec.ResumeLayout(false);
            this.psec.PerformLayout();
            this.psec3.ResumeLayout(false);
            this.psec3.PerformLayout();
            this.pcreat.ResumeLayout(false);
            this.pcreat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lcreat;
        private System.Windows.Forms.Label lforgot;
        private System.Windows.Forms.TextBox tpass;
        private System.Windows.Forms.TextBox tuser;
        private System.Windows.Forms.Panel pforget;
        private System.Windows.Forms.Panel psec;
        private System.Windows.Forms.Panel psec3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tnewre;
        private System.Windows.Forms.TextBox tnewpass;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox anser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tfind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pcreat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tans;
        private System.Windows.Forms.ComboBox cse;
        private System.Windows.Forms.TextBox tage;
        private System.Windows.Forms.ComboBox cge;
        private System.Windows.Forms.TextBox tpa;
        private System.Windows.Forms.TextBox tre;
        private System.Windows.Forms.TextBox tadd;
        private System.Windows.Forms.TextBox tcon;
        private System.Windows.Forms.TextBox tus;
        private System.Windows.Forms.TextBox tlast;
        private System.Windows.Forms.TextBox tname;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button1;
    }
}