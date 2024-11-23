namespace STIDiscover
{
    partial class FrontPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontPage));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb7 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rb3 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rb6 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rb1 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rb5 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rb2 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.rb4 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.BtnNext = new Guna.UI2.WinForms.Guna2Button();
            this.BtnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.BtnStart = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSkipVideo = new Guna.UI2.WinForms.Guna2ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1920, 974);
            this.axWindowsMediaPlayer1.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 7000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb7);
            this.panel1.Controls.Add(this.rb3);
            this.panel1.Controls.Add(this.rb6);
            this.panel1.Controls.Add(this.rb1);
            this.panel1.Controls.Add(this.rb5);
            this.panel1.Controls.Add(this.rb2);
            this.panel1.Controls.Add(this.rb4);
            this.panel1.Location = new System.Drawing.Point(887, 1025);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 43);
            this.panel1.TabIndex = 10;
            // 
            // rb7
            // 
            this.rb7.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb7.CheckedState.BorderThickness = 0;
            this.rb7.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb7.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb7.Location = new System.Drawing.Point(203, 12);
            this.rb7.Name = "rb7";
            this.rb7.Size = new System.Drawing.Size(20, 20);
            this.rb7.TabIndex = 10;
            this.rb7.Text = "guna2CustomRadioButton7";
            this.rb7.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb7.UncheckedState.BorderThickness = 2;
            this.rb7.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb7.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb3
            // 
            this.rb3.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb3.CheckedState.BorderThickness = 0;
            this.rb3.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb3.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb3.Location = new System.Drawing.Point(99, 12);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(20, 20);
            this.rb3.TabIndex = 6;
            this.rb3.Text = "guna2CustomRadioButton3";
            this.rb3.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb3.UncheckedState.BorderThickness = 2;
            this.rb3.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb3.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb6
            // 
            this.rb6.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb6.CheckedState.BorderThickness = 0;
            this.rb6.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb6.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb6.Location = new System.Drawing.Point(177, 12);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(20, 20);
            this.rb6.TabIndex = 9;
            this.rb6.Text = "guna2CustomRadioButton6";
            this.rb6.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb6.UncheckedState.BorderThickness = 2;
            this.rb6.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb6.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb1
            // 
            this.rb1.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb1.CheckedState.BorderThickness = 0;
            this.rb1.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb1.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb1.Location = new System.Drawing.Point(47, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(20, 20);
            this.rb1.TabIndex = 4;
            this.rb1.Text = "guna2CustomRadioButton1";
            this.rb1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb1.UncheckedState.BorderThickness = 2;
            this.rb1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb1.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb5
            // 
            this.rb5.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb5.CheckedState.BorderThickness = 0;
            this.rb5.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb5.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb5.Location = new System.Drawing.Point(151, 12);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(20, 20);
            this.rb5.TabIndex = 8;
            this.rb5.Text = "guna2CustomRadioButton5";
            this.rb5.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb5.UncheckedState.BorderThickness = 2;
            this.rb5.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb5.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb2
            // 
            this.rb2.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb2.CheckedState.BorderThickness = 0;
            this.rb2.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb2.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb2.Location = new System.Drawing.Point(73, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(20, 20);
            this.rb2.TabIndex = 5;
            this.rb2.Text = "guna2CustomRadioButton2";
            this.rb2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb2.UncheckedState.BorderThickness = 2;
            this.rb2.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb2.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb4
            // 
            this.rb4.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.rb4.CheckedState.BorderThickness = 0;
            this.rb4.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.rb4.CheckedState.InnerColor = System.Drawing.Color.Blue;
            this.rb4.Location = new System.Drawing.Point(125, 12);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(20, 20);
            this.rb4.TabIndex = 7;
            this.rb4.Text = "guna2CustomRadioButton4";
            this.rb4.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb4.UncheckedState.BorderThickness = 2;
            this.rb4.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb4.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.Color.Transparent;
            this.BtnNext.BorderColor = System.Drawing.Color.Transparent;
            this.BtnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnNext.FillColor = System.Drawing.Color.Transparent;
            this.BtnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnNext.ForeColor = System.Drawing.Color.White;
            this.BtnNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnNext.Image")));
            this.BtnNext.ImageSize = new System.Drawing.Size(90, 90);
            this.BtnNext.Location = new System.Drawing.Point(1933, 442);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(121, 103);
            this.BtnNext.TabIndex = 15;
            this.BtnNext.UseTransparentBackground = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.BtnPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnPrevious.FillColor = System.Drawing.Color.Transparent;
            this.BtnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnPrevious.ForeColor = System.Drawing.Color.White;
            this.BtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.Image")));
            this.BtnPrevious.ImageSize = new System.Drawing.Size(90, 90);
            this.BtnPrevious.Location = new System.Drawing.Point(12, 442);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(121, 103);
            this.BtnPrevious.TabIndex = 14;
            this.BtnPrevious.UseTransparentBackground = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStart.FillColor = System.Drawing.Color.Transparent;
            this.BtnStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnStart.ForeColor = System.Drawing.Color.White;
            this.BtnStart.Image = ((System.Drawing.Image)(resources.GetObject("BtnStart.Image")));
            this.BtnStart.ImageSize = new System.Drawing.Size(800, 800);
            this.BtnStart.Location = new System.Drawing.Point(0, 974);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(1920, 106);
            this.BtnStart.TabIndex = 13;
            this.BtnStart.UseTransparentBackground = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnSkipVideo
            // 
            this.btnSkipVideo.BackColor = System.Drawing.Color.Black;
            this.btnSkipVideo.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSkipVideo.HoverState.ImageSize = new System.Drawing.Size(200, 200);
            this.btnSkipVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnSkipVideo.Image")));
            this.btnSkipVideo.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSkipVideo.ImageRotate = 0F;
            this.btnSkipVideo.ImageSize = new System.Drawing.Size(200, 200);
            this.btnSkipVideo.Location = new System.Drawing.Point(1930, 0);
            this.btnSkipVideo.Name = "btnSkipVideo";
            this.btnSkipVideo.PressedState.ImageSize = new System.Drawing.Size(200, 200);
            this.btnSkipVideo.Size = new System.Drawing.Size(117, 100);
            this.btnSkipVideo.TabIndex = 16;
            this.btnSkipVideo.Click += new System.EventHandler(this.btnSkipVideo_Click_1);
            // 
            // FrontPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnSkipVideo);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrevious);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrontPage";
            this.Text = "FrontPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrontPage_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb7;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb3;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb6;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb5;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb2;
        private Guna.UI2.WinForms.Guna2CustomRadioButton rb4;
        private Guna.UI2.WinForms.Guna2Button BtnNext;
        private Guna.UI2.WinForms.Guna2Button BtnPrevious;
        private Guna.UI2.WinForms.Guna2Button BtnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ImageButton btnSkipVideo;
    }
}