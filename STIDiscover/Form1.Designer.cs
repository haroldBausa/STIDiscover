namespace STIDiscover
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEventModule = new Guna.UI2.WinForms.Guna2Button();
            this.btnOpenMap = new Guna.UI2.WinForms.Guna2Button();
            this.btnSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.map1 = new STIDiscover.Map();
            this.scheduleControl2 = new STIDiscover.scheduleControl();
            this.eventSchedule1 = new STIDiscover.EventSchedule();
            this.scheduleControl1 = new STIDiscover.scheduleControl();
            this.homeControl1 = new STIDiscover.homeControl();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 60;
            this.guna2CustomGradientPanel1.Controls.Add(this.btnAdmin);
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnEventModule);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnOpenMap);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnSchedule);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnHome);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(88, 891);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1848, 171);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnAdmin.BorderRadius = 24;
            this.btnAdmin.BorderThickness = 1;
            this.btnAdmin.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAdmin.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnAdmin.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAdmin.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdmin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.Image")));
            this.btnAdmin.ImageSize = new System.Drawing.Size(70, 70);
            this.btnAdmin.Location = new System.Drawing.Point(1657, 16);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(135, 126);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::STIDiscover.Properties.Resources.KioskLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, -46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnEventModule
            // 
            this.btnEventModule.BackColor = System.Drawing.Color.Transparent;
            this.btnEventModule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnEventModule.BorderRadius = 24;
            this.btnEventModule.BorderThickness = 1;
            this.btnEventModule.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnEventModule.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnEventModule.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnEventModule.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnEventModule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEventModule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEventModule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEventModule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEventModule.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnEventModule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEventModule.ForeColor = System.Drawing.Color.White;
            this.btnEventModule.Image = ((System.Drawing.Image)(resources.GetObject("btnEventModule.Image")));
            this.btnEventModule.ImageSize = new System.Drawing.Size(70, 70);
            this.btnEventModule.Location = new System.Drawing.Point(1348, 16);
            this.btnEventModule.Name = "btnEventModule";
            this.btnEventModule.Size = new System.Drawing.Size(135, 126);
            this.btnEventModule.TabIndex = 4;
            this.btnEventModule.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnEventModule.Click += new System.EventHandler(this.btnEventModule_Click);
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenMap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnOpenMap.BorderRadius = 24;
            this.btnOpenMap.BorderThickness = 1;
            this.btnOpenMap.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnOpenMap.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnOpenMap.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnOpenMap.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnOpenMap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenMap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenMap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpenMap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpenMap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnOpenMap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOpenMap.ForeColor = System.Drawing.Color.White;
            this.btnOpenMap.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenMap.Image")));
            this.btnOpenMap.ImageSize = new System.Drawing.Size(70, 70);
            this.btnOpenMap.Location = new System.Drawing.Point(986, 16);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(135, 126);
            this.btnOpenMap.TabIndex = 3;
            this.btnOpenMap.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnSchedule.BorderRadius = 24;
            this.btnSchedule.BorderThickness = 1;
            this.btnSchedule.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSchedule.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnSchedule.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSchedule.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.btnSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSchedule.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.ImageSize = new System.Drawing.Size(70, 70);
            this.btnSchedule.Location = new System.Drawing.Point(635, 16);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(135, 126);
            this.btnSchedule.TabIndex = 2;
            this.btnSchedule.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnHome.BorderRadius = 24;
            this.btnHome.BorderThickness = 1;
            this.btnHome.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHome.Checked = true;
            this.btnHome.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnHome.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnHome.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageSize = new System.Drawing.Size(60, 60);
            this.btnHome.Location = new System.Drawing.Point(320, 16);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(135, 126);
            this.btnHome.TabIndex = 1;
            this.btnHome.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 50;
            this.guna2Elipse1.TargetControl = this.btnHome;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 50;
            this.guna2Elipse2.TargetControl = this.btnSchedule;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 50;
            this.guna2Elipse3.TargetControl = this.btnOpenMap;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 50;
            this.guna2Elipse4.TargetControl = this.btnEventModule;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.map1);
            this.panel2.Controls.Add(this.scheduleControl2);
            this.panel2.Controls.Add(this.eventSchedule1);
            this.panel2.Controls.Add(this.scheduleControl1);
            this.panel2.Controls.Add(this.homeControl1);
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2036, 875);
            this.panel2.TabIndex = 1;
            // 
            // map1
            // 
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(2036, 875);
            this.map1.TabIndex = 4;
            // 
            // scheduleControl2
            // 
            this.scheduleControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleControl2.Location = new System.Drawing.Point(0, 0);
            this.scheduleControl2.Name = "scheduleControl2";
            this.scheduleControl2.Size = new System.Drawing.Size(2036, 875);
            this.scheduleControl2.TabIndex = 3;
            this.scheduleControl2.Load += new System.EventHandler(this.scheduleControl2_Load);
            // 
            // eventSchedule1
            // 
            this.eventSchedule1.BackColor = System.Drawing.Color.White;
            this.eventSchedule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventSchedule1.Location = new System.Drawing.Point(0, 0);
            this.eventSchedule1.Name = "eventSchedule1";
            this.eventSchedule1.Size = new System.Drawing.Size(2036, 875);
            this.eventSchedule1.TabIndex = 2;
            // 
            // scheduleControl1
            // 
            this.scheduleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleControl1.Location = new System.Drawing.Point(0, 0);
            this.scheduleControl1.Name = "scheduleControl1";
            this.scheduleControl1.Size = new System.Drawing.Size(2036, 875);
            this.scheduleControl1.TabIndex = 1;
            // 
            // homeControl1
            // 
            this.homeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeControl1.Location = new System.Drawing.Point(0, 0);
            this.homeControl1.Name = "homeControl1";
            this.homeControl1.Size = new System.Drawing.Size(2036, 875);
            this.homeControl1.TabIndex = 0;
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2CustomGradientPanel1);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.Blue;
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.Blue;
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.Blue;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(1920, 1080);
            this.guna2CustomGradientPanel2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnSchedule;
        private Guna.UI2.WinForms.Guna2Button btnOpenMap;
        private Guna.UI2.WinForms.Guna2Button btnEventModule;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private System.Windows.Forms.Panel panel2;
        private homeControl homeControl1;
        private scheduleControl scheduleControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnAdmin;
        private EventSchedule eventSchedule1;
        private scheduleControl scheduleControl2;
        private Map map1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
    }
}

