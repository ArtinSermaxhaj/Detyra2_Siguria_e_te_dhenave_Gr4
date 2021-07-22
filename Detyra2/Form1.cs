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
        public Form1()
        {
            InitializeComponent();
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
            if (DatabaseManipulation.checkIfUserAlreadyExists(username))
            {
                User user = DatabaseManipulation.getUserBills(username);
                string salt = user.salt;
                string hashedpassword = GenerateHash(password, salt);
                if (hashedpassword.Equals(user.password))
                {
                    MessageBox.Show("Mund te shikoni ose shtoni faturat");
                }
                else
                {
                    MessageBox.Show("Kredencialet e derguara jane gabim");
                }
            }
            else
            {
                MessageBox.Show("Kredencialet e derguara jane gabim.");
            }
        }
        public string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed SHA256String = new SHA256Managed();
            byte[] hash = SHA256String.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
