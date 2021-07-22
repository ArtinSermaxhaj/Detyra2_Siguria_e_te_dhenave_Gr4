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
        public Form2()
        {
            InitializeComponent();
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
            string firstName = firstNameField.Text;
            string lastName = lastNameField.Text;
            string username = usernameField.Text;
            string pw = passwordField.Text;
            string conpw = confirmPwField.Text;
            if(pw == conpw)
            {
             
                string salt = CreateSalt();
                string password = GenerateHash(pw, salt);
                User user = new User(firstName, lastName, username, password, salt);
                SessionManager.user = user;
                if (DatabaseManipulation.checkIfUserAlreadyExists(user.username))
                {
                    MessageBox.Show("this Username is already taken.");
                    firstNameField.Clear();
                    lastNameField.Clear();
                    usernameField.Clear();
                    passwordField.Clear();
                    confirmPwField.Clear();
                }
                else
                {
                    DatabaseManipulation.addUser(user);
                    MessageBox.Show("Useri do te shtohet ne bazen e te dhenave.");
                }
            }
            else
            {
                MessageBox.Show("Error, Password and Confirm Password do not match. Please try again.");
                firstNameField.Clear();
                lastNameField.Clear();
                usernameField.Clear();
                passwordField.Clear();
                confirmPwField.Clear();
            }
            
        }
        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed SHA256String = new SHA256Managed();
            byte[] hash = SHA256String.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
