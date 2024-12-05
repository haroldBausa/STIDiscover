using System;
using System.Windows.Forms;

namespace STIDiscover
{
    public static class Inactivity
    {
        public static Timer InactivityTimer { get; private set; }
        public static int InactivityThreshold = 30000; // 30 seconds
        private static bool isCountdownActive = false; // Prevent multiple countdown forms
        private static Form currentForm;

        static Inactivity()
        {
            InactivityTimer = new Timer();
            InactivityTimer.Interval = InactivityThreshold;
            InactivityTimer.Tick += HandleInactivity;
        }

        private static void HandleInactivity(object sender, EventArgs e)
        {
            if (isCountdownActive) return; // Prevent multiple popups
            isCountdownActive = true;

            // Show the CountDown form
            using (CountDown countdown = new CountDown(10)) // 10-second countdown
            {
                DialogResult result = countdown.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    // User wants to continue
                    ResetTimer();
                }
                else
                {
                    // User timed out or clicked "No"
                    CloseAllFormsAndReturnToMain();
                }
            }

            isCountdownActive = false; // Reset flag
        }

        public static void SetCurrentForm(Form form)
        {
            currentForm = form;
        }

        public static void ResetTimer()
        {
            InactivityTimer.Stop();
            InactivityTimer.Start();
        }

        private static void CloseAllFormsAndReturnToMain()
        {
            if (currentForm != null)
            {
                // Hide the current form
                currentForm.Hide();
            }

            // Show the FrontPage form
            FrontPage frontPage = new FrontPage();
            frontPage.ShowDialog();

            // After the FrontPage is closed, the application exits or returns to the previous form.
            Application.Exit();
        }
    }
}
