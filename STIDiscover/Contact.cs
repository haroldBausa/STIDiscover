﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
namespace STIDiscover
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string course = txtCourse.Text;
            string year = txtYear.Text;
            string section = txtSection.Text;
            string concernDescription = txtConcern.Text;

            if (string.IsNullOrWhiteSpace(course) || string.IsNullOrWhiteSpace(year) ||
                string.IsNullOrWhiteSpace(section) || string.IsNullOrWhiteSpace(concernDescription))
            {
                MessageBox.Show("Please fill out all fields before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string adminEmail = "heyitsmebausa@gmail.com"; 
            string subject = $"Concern from {course} {year}-{section}";
            string body = $"Course: {course}\nYear: {year}\nSection: {section}\n\nConcern:\n{concernDescription}";

            try
            {
                SendEmail(adminEmail, subject, body);
                MessageBox.Show("Your concern has been sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send the email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("heyitsmebausa@gmail.com"); 
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)) 
                {
                    smtp.Credentials = new NetworkCredential("heyitsmebausa@gmail.com", "zpzm hupc wotf lnbz"); 
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}