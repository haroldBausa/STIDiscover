namespace STIDiscover
{
    partial class Map
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenMap = new Guna.UI2.WinForms.Guna2Button();
            this.btnGetHelp = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenMap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenMap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpenMap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpenMap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnOpenMap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenMap.ForeColor = System.Drawing.Color.White;
            this.btnOpenMap.Location = new System.Drawing.Point(857, 407);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(434, 60);
            this.btnOpenMap.TabIndex = 15;
            this.btnOpenMap.Text = "Click to view map";
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // btnGetHelp
            // 
            this.btnGetHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnGetHelp.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnGetHelp.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.btnGetHelp.Image = global::STIDiscover.Properties.Resources.info;
            this.btnGetHelp.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnGetHelp.ImageRotate = 0F;
            this.btnGetHelp.ImageSize = new System.Drawing.Size(70, 70);
            this.btnGetHelp.Location = new System.Drawing.Point(3, 3);
            this.btnGetHelp.Name = "btnGetHelp";
            this.btnGetHelp.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.btnGetHelp.Size = new System.Drawing.Size(92, 82);
            this.btnGetHelp.TabIndex = 16;
            this.btnGetHelp.UseTransparentBackground = true;
            this.btnGetHelp.Click += new System.EventHandler(this.btnGetHelp_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGetHelp);
            this.Controls.Add(this.btnOpenMap);
            this.Name = "Map";
            this.Size = new System.Drawing.Size(2036, 875);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnOpenMap;
        private Guna.UI2.WinForms.Guna2ImageButton btnGetHelp;
    }
}
