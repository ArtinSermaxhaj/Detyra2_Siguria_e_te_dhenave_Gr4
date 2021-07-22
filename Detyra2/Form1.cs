using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detyra
{
    public partial class Form1 : Form
    {
        Client c1;
     public Form1() 
        {
         InitializeComponent();       
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
                c1 = new Client();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Form2 signupForm = new Form2();
            signupForm.ShowDialog();
            signupForm.Dispose();
            Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            
            string username = usernameField.Text;
            string password = passwordField.Text;
            String mesazhi = "Login?"+username+"?"+password;
            c1.ClientSend(mesazhi);
            MessageBox.Show(c1.DekriptoPergjigjen());
        }

    }
}
