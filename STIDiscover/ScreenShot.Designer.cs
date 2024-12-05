namespace STIDiscover
{
    partial class ScreenShot
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtConcern = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSendEmail = new Guna.UI2.WinForms.Guna2Button();
            this.btnCaptureScreenshot = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseScreenshot = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pictureBoxScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please provide us your concern";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConcern
            // 
            this.txtConcern.BorderRadius = 5;
            this.txtConcern.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConcern.DefaultText = "Type Here...";
            this.txtConcern.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConcern.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConcern.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConcern.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConcern.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtConcern.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConcern.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcern.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConcern.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConcern.Location = new System.Drawing.Point(5, 90);
            this.txtConcern.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConcern.Multiline = true;
            this.txtConcern.Name = "txtConcern";
            this.txtConcern.PasswordChar = '\0';
            this.txtConcern.PlaceholderText = "";
            this.txtConcern.SelectedText = "";
            this.txtConcern.Size = new System.Drawing.Size(507, 552);
            this.txtConcern.TabIndex = 8;
            this.txtConcern.Click += new System.EventHandler(this.txtConcern_Click);
            this.txtConcern.Enter += new System.EventHandler(this.txtConcern_Enter);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.AutoRoundedCorners = true;
            this.btnSendEmail.BackColor = System.Drawing.Color.Transparent;
            this.btnSendEmail.BorderRadius = 18;
            this.btnSendEmail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendEmail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendEmail.FillColor = System.Drawing.Color.Navy;
            this.btnSendEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSendEmail.ForeColor = System.Drawing.Color.White;
            this.btnSendEmail.Location = new System.Drawing.Point(331, 588);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(154, 39);
            this.btnSendEmail.TabIndex = 27;
            this.btnSendEmail.Text = "Submit";
            this.btnSendEmail.UseTransparentBackground = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnCaptureScreenshot
            // 
            this.btnCaptureScreenshot.AutoRoundedCorners = true;
            this.btnCaptureScreenshot.BorderRadius = 18;
            this.btnCaptureScreenshot.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaptureScreenshot.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaptureScreenshot.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaptureScreenshot.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaptureScreenshot.FillColor = System.Drawing.Color.Navy;
            this.btnCaptureScreenshot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptureScreenshot.ForeColor = System.Drawing.Color.White;
            this.btnCaptureScreenshot.Location = new System.Drawing.Point(1173, 976);
            this.btnCaptureScreenshot.Name = "btnCaptureScreenshot";
            this.btnCaptureScreenshot.Size = new System.Drawing.Size(154, 39);
            this.btnCaptureScreenshot.TabIndex = 28;
            this.btnCaptureScreenshot.Text = "Capture";
            this.btnCaptureScreenshot.Visible = false;
            this.btnCaptureScreenshot.Click += new System.EventHandler(this.btnCaptureScreenshot_Click);
            // 
            // btnCloseScreenshot
            // 
            this.btnCloseScreenshot.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnCloseScreenshot.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCloseScreenshot.Image = global::STIDiscover.Properties.Resources.circle_xmark_solid__1_1;
            this.btnCloseScreenshot.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCloseScreenshot.ImageRotate = 0F;
            this.btnCloseScreenshot.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCloseScreenshot.Location = new System.Drawing.Point(1953, 3);
            this.btnCloseScreenshot.Name = "btnCloseScreenshot";
            this.btnCloseScreenshot.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCloseScreenshot.Size = new System.Drawing.Size(64, 54);
            this.btnCloseScreenshot.TabIndex = 29;
            this.btnCloseScreenshot.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // pictureBoxScreenshot
            // 
            this.pictureBoxScreenshot.Location = new System.Drawing.Point(519, 90);
            this.pictureBoxScreenshot.Name = "pictureBoxScreenshot";
            this.pictureBoxScreenshot.Size = new System.Drawing.Size(1577, 852);
            this.pictureBoxScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScreenshot.TabIndex = 9;
            this.pictureBoxScreenshot.TabStop = false;
            // 
            // ScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnCloseScreenshot);
            this.Controls.Add(this.btnCaptureScreenshot);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.pictureBoxScreenshot);
            this.Controls.Add(this.txtConcern);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenShot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ScreenShot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScreenShot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtConcern;
        private System.Windows.Forms.PictureBox pictureBoxScreenshot;
        private Guna.UI2.WinForms.Guna2Button btnSendEmail;
        private Guna.UI2.WinForms.Guna2Button btnCaptureScreenshot;
        private Guna.UI2.WinForms.Guna2ImageButton btnCloseScreenshot;
    }
}