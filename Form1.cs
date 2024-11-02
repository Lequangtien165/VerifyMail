using System;
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

namespace VerifyMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int vCode = 1000;
        private void button1_Click(object sender, EventArgs e)
        {
            timvcode.Stop();
            string to, from, pass, mail;
            to = textMail.Text;
            from = "Lebronjay165@gmail.com";
            mail = vCode.ToString();
            pass = "fgcd thkv euyy ajwk";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "Verification Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Sent");
                textMail.Enabled = true;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vCode += 100;
            if (vCode == 999)
            {
                vCode = 1000;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

      
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == vCode.ToString())
            {
                MessageBox.Show("Code Verified");
            }
            else
            {
                MessageBox.Show("Code Not Verified");
            }
        }
    }
}
