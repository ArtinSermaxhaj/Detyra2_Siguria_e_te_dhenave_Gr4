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
            string password = passwordField.Text;
            string confirmpw = confirmPwField.Text;
            if (password.Equals(confirmpw) && checkInput(firstname, lastname, moshatxt))
            {
                String mesazhi = "Regjistro?" + firstname + "?" + lastname + "?" + username + "?" + moshatxt + "?" + password;
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
            } else {
                MessageBox.Show("Te dhenat e formes jane te gabuara");
                firstNameField.Clear();
                lastNameField.Clear();
                usernameField.Clear();
                moshaField.Clear();
                passwordField.Clear();
                confirmPwField.Clear();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private bool checkInput(string firstname, string lastname, string mosha) {
            bool valid = true;
            foreach (char c in firstname.ToArray()) {
                if (Char.IsDigit(c)) {
                    valid = false;
                    return valid;
                }
            }
            foreach (char c in lastname.ToCharArray()) {
                if (Char.IsDigit(c)) {
                    valid = false;
                    return valid;
                }
            }
            try
            {
                int moshaValid = Int32.Parse(mosha);
            }
            catch (Exception ex) {
                valid = false;
                return valid;
            }
            return valid;
        } 


    }
}
