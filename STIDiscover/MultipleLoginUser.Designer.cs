namespace STIDiscover
{
    partial class MultipleLoginUser
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnToMap = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnToAsk = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(311, 655);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 66);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Faculty/Employee";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("MS Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(148, 47);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "BACK";
            this.btnBack.UseTransparentBackground = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(329, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1396, 69);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome to STI-Discover, please select if you are:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1262, 655);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 66);
            this.label3.TabIndex = 9;
            this.label3.Text = "Visitor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.btnToMap);
            this.guna2GradientPanel1.Controls.Add(this.btnToAsk);
            this.guna2GradientPanel1.Controls.Add(this.label3);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(70)))), ((int)(((byte)(135)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(70)))), ((int)(((byte)(135)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1920, 1080);
            this.guna2GradientPanel1.TabIndex = 8;
            // 
            // btnToMap
            // 
            this.btnToMap.BackColor = System.Drawing.Color.Transparent;
            this.btnToMap.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnToMap.HoverState.ImageSize = new System.Drawing.Size(400, 400);
            this.btnToMap.Image = global::STIDiscover.Properties.Resources.@__1;
            this.btnToMap.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnToMap.ImageRotate = 0F;
            this.btnToMap.ImageSize = new System.Drawing.Size(350, 350);
            this.btnToMap.Location = new System.Drawing.Point(1266, 332);
            this.btnToMap.Name = "btnToMap";
            this.btnToMap.PressedState.ImageSize = new System.Drawing.Size(400, 400);
            this.btnToMap.Size = new System.Drawing.Size(420, 309);
            this.btnToMap.TabIndex = 6;
            this.btnToMap.UseTransparentBackground = true;
            this.btnToMap.Click += new System.EventHandler(this.btnToMap_Click);
            // 
            // btnToAsk
            // 
            this.btnToAsk.BackColor = System.Drawing.Color.Transparent;
            this.btnToAsk.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnToAsk.HoverState.ImageSize = new System.Drawing.Size(400, 400);
            this.btnToAsk.Image = global::STIDiscover.Properties.Resources.STIers;
            this.btnToAsk.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnToAsk.ImageRotate = 0F;
            this.btnToAsk.ImageSize = new System.Drawing.Size(350, 350);
            this.btnToAsk.Location = new System.Drawing.Point(316, 332);
            this.btnToAsk.Name = "btnToAsk";
            this.btnToAsk.PressedState.ImageSize = new System.Drawing.Size(400, 400);
            this.btnToAsk.Size = new System.Drawing.Size(423, 325);
            this.btnToAsk.TabIndex = 1;
            this.btnToAsk.UseTransparentBackground = true;
            this.btnToAsk.Click += new System.EventHandler(this.btnToAsk_Click);
            // 
            // MultipleLoginUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MultipleLoginUser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btnToAsk;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton btnToMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
    }
}