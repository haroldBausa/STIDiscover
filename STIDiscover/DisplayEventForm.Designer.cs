namespace STIDiscover
{
    partial class DisplayEventForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureEvent = new System.Windows.Forms.PictureBox();
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1046, 546);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 36);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureEvent
            // 
            this.pictureEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureEvent.Location = new System.Drawing.Point(29, 145);
            this.pictureEvent.Name = "pictureEvent";
            this.pictureEvent.Size = new System.Drawing.Size(1175, 395);
            this.pictureEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEvent.TabIndex = 6;
            this.pictureEvent.TabStop = false;
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.AutoSize = true;
            this.lblEventDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDescription.Location = new System.Drawing.Point(23, 62);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(95, 36);
            this.lblEventDescription.TabIndex = 5;
            this.lblEventDescription.Text = "label1";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.Location = new System.Drawing.Point(23, 11);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(95, 36);
            this.lblEventName.TabIndex = 4;
            this.lblEventName.Text = "label1";
            // 
            // DisplayEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 593);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureEvent);
            this.Controls.Add(this.lblEventDescription);
            this.Controls.Add(this.lblEventName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayEventForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayEventForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureEvent;
        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.Label lblEventName;
    }
}