namespace STIDiscover
{
    partial class FileMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileMaintenance));
            this.patnavBar = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEvent = new Guna.UI2.WinForms.Guna2Button();
            this.btnSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.eventManager1 = new STIDiscover.EventManager();
            this.scheduleControlManager1 = new STIDiscover.ScheduleControlManager();
            this.patnavBar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // patnavBar
            // 
            this.patnavBar.Controls.Add(this.panel3);
            this.patnavBar.Controls.Add(this.panel1);
            this.patnavBar.Controls.Add(this.panel2);
            this.patnavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.patnavBar.Location = new System.Drawing.Point(0, 0);
            this.patnavBar.Name = "patnavBar";
            this.patnavBar.Size = new System.Drawing.Size(348, 1080);
            this.patnavBar.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Location = new System.Drawing.Point(1, 960);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 118);
            this.panel3.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.CustomBorderColor = System.Drawing.Color.White;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::STIDiscover.Properties.Resources.right_from_bracket_solid;
            this.btnExit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExit.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.Location = new System.Drawing.Point(11, 42);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(253, 66);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Sign out";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEvent);
            this.panel1.Controls.Add(this.btnSchedule);
            this.panel1.Location = new System.Drawing.Point(0, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 749);
            this.panel1.TabIndex = 2;
            // 
            // btnEvent
            // 
            this.btnEvent.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnEvent.BorderThickness = 2;
            this.btnEvent.CustomBorderColor = System.Drawing.Color.White;
            this.btnEvent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEvent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEvent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEvent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEvent.FillColor = System.Drawing.Color.Transparent;
            this.btnEvent.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.ForeColor = System.Drawing.Color.White;
            this.btnEvent.Image = global::STIDiscover.Properties.Resources.calendar_check_regular;
            this.btnEvent.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEvent.Location = new System.Drawing.Point(7, 243);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(320, 57);
            this.btnEvent.TabIndex = 2;
            this.btnEvent.Text = "EVENT MANAGER";
            this.btnEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSchedule.BorderThickness = 2;
            this.btnSchedule.CustomBorderColor = System.Drawing.Color.White;
            this.btnSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSchedule.FillColor = System.Drawing.Color.Transparent;
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Image = global::STIDiscover.Properties.Resources.clock_regular;
            this.btnSchedule.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSchedule.Location = new System.Drawing.Point(7, 123);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(320, 55);
            this.btnSchedule.TabIndex = 1;
            this.btnSchedule.Text = "CONTROL SCHEDULE";
            this.btnSchedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 212);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // eventManager1
            // 
            this.eventManager1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.eventManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventManager1.Location = new System.Drawing.Point(348, 0);
            this.eventManager1.Name = "eventManager1";
            this.eventManager1.Size = new System.Drawing.Size(1572, 1080);
            this.eventManager1.TabIndex = 1;
            // 
            // scheduleControlManager1
            // 
            this.scheduleControlManager1.BackColor = System.Drawing.SystemColors.Control;
            this.scheduleControlManager1.Location = new System.Drawing.Point(348, 0);
            this.scheduleControlManager1.Name = "scheduleControlManager1";
            this.scheduleControlManager1.Size = new System.Drawing.Size(1920, 1080);
            this.scheduleControlManager1.TabIndex = 2;
            // 
            // FileMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(49)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.scheduleControlManager1);
            this.Controls.Add(this.eventManager1);
            this.Controls.Add(this.patnavBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileMaintenance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileMaintenance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.patnavBar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel patnavBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnEvent;
        private Guna.UI2.WinForms.Guna2Button btnSchedule;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private EventManager eventManager1;
        private ScheduleControlManager scheduleControlManager1;
    }
}