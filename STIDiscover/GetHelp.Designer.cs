namespace STIDiscover
{
    partial class GetHelp
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnOpenContact = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.faQs1 = new STIDiscover.FAQs();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(49)))), ((int)(((byte)(83)))));
            this.guna2GradientPanel1.Controls.Add(this.btnOpenContact);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Aqua;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Fuchsia;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(484, 1080);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // btnOpenContact
            // 
            this.btnOpenContact.AutoRoundedCorners = true;
            this.btnOpenContact.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenContact.BorderColor = System.Drawing.Color.White;
            this.btnOpenContact.BorderRadius = 32;
            this.btnOpenContact.BorderThickness = 1;
            this.btnOpenContact.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenContact.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenContact.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpenContact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpenContact.FillColor = System.Drawing.Color.Transparent;
            this.btnOpenContact.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Underline);
            this.btnOpenContact.ForeColor = System.Drawing.Color.White;
            this.btnOpenContact.Image = global::STIDiscover.Properties.Resources.Email;
            this.btnOpenContact.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOpenContact.ImageSize = new System.Drawing.Size(50, 50);
            this.btnOpenContact.Location = new System.Drawing.Point(92, 615);
            this.btnOpenContact.Name = "btnOpenContact";
            this.btnOpenContact.Size = new System.Drawing.Size(317, 67);
            this.btnOpenContact.TabIndex = 2;
            this.btnOpenContact.Text = "Contact us";
            this.btnOpenContact.UseTransparentBackground = true;
            this.btnOpenContact.Click += new System.EventHandler(this.btnOpenContact_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.faQs1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(484, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1436, 1080);
            this.panel1.TabIndex = 2;
            // 
            // faQs1
            // 
            this.faQs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faQs1.Location = new System.Drawing.Point(0, 0);
            this.faQs1.Name = "faQs1";
            this.faQs1.Size = new System.Drawing.Size(1436, 1080);
            this.faQs1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(58, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 98);
            this.label1.TabIndex = 0;
            this.label1.Text = "GetHelp";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GetHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GetHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetHelp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnOpenContact;
        private System.Windows.Forms.Panel panel1;
        private FAQs faQs1;
        private System.Windows.Forms.Label label1;
    }
}