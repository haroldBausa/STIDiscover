using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STIDiscover
{
    public partial class CountDown : Form
    {
        private int countdownTime;
        private Timer countdownTimer;

        public CountDown(int seconds)
        {
            InitializeComponent();
            countdownTime = seconds;

            // Initialize Timer
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 second
            countdownTimer.Tick += timer1_Tick;
        }

        private void CountDown_Load(object sender, EventArgs e)
        {
            lblCount.Text = countdownTime.ToString(); // Show initial countdown value
            countdownTimer.Start(); // Start timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCount.Text = countdownTime.ToString(); // Update label with current countdown time

            if (countdownTime <= 0)
            {
                countdownTimer.Stop();
                this.DialogResult = DialogResult.No; // Signal timeout
                this.Close(); // Close the CountDown form
            }

            countdownTime--;  // Decrement countdown time
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            this.DialogResult = DialogResult.Yes; // User wants to continue
            this.Close();

        }

    }
}