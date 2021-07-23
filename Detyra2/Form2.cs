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
    public partial class Form2 : Form
    {
        Client c1;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            c1 = new Client();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void loginLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            string firstname = firstNameField.Text;
            string lastname = lastNameField.Text;
            string username = usernameField.Text;
            string moshatxt = moshaField.Text;
            int mosha = 0;
            try
            {
                    mosha = Int32.Parse(moshatxt);
            }
            catch {
                MessageBox.Show("Mosha nuk eshte numer");
            }
            string password = passwordField.Text;
            string confirmpw = confirmPwField.Text;
            if (password.Equals(confirmpw))
            {
                String mesazhi = "Regjistro?" + firstname + "?" + lastname + "?" + username + "?"+ mosha + "?" + password;
                c1.ClientSend(mesazhi);
                string pergjigjja = c1.DekriptoPergjigjen();
                if (pergjigjja.Equals("OK"))
                {
                    Hide();
                    Form1 loginForm = new Form1();
                    loginForm.ShowDialog();
                    loginForm.Dispose();
                    Show();
                }
                else
                {
                    MessageBox.Show("Te dhenat e formes jane te gabuara.");
                }
            }
            else
            {
                MessageBox.Show("Passwordi dhe Passwordi konfirmues nuk jane te njejte.");
                firstNameField.Clear();
                lastNameField.Clear();
                usernameField.Clear();
                passwordField.Clear();
                confirmPwField.Clear();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}
