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
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography.Xml;
using System.IO;


namespace Detyra
{
    public partial class Form1 : Form
    {
        public static string useri;
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
            String mesazhi = "Login?" + username + "?" + password;
            c1.ClientSend(mesazhi);
            string pergjigjja = c1.DekriptoPergjigjen();
            string[] array = pergjigjja.Split('?');
            if (array[0].Equals("OK"))
            {

                MessageBox.Show("Kredencialet jane ne rregull por duhet te verifikoni nenshkrimin");
                string signedXml = array[1].TrimEnd('\u0000');
                string perdoruesi = array[2];
                useri = perdoruesi;
                XmlDocument objXml = new XmlDocument();
                objXml.LoadXml(signedXml);
                objXml.Save(perdoruesi + "_nenshkruar.xml");
            }
            else
            {
                MessageBox.Show("Kredencialet jane te gabuara.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument objXml = new XmlDocument();
            if (File.Exists(useri + "_nenshkruar.xml") == true)
            {
                objXml.Load(useri + "_nenshkruar.xml");
                SignedXml objSignedXml = new SignedXml(objXml);

                XmlNodeList signatureNodes = objXml.GetElementsByTagName("Signature");
                XmlElement nenshkrimi = (XmlElement)signatureNodes[0];

                objSignedXml.LoadXml(nenshkrimi);
                if (objSignedXml.CheckSignature() == true)
                {
                    MessageBox.Show("Nenshkrimi eshte valid");
                    Hide();
                    Form3 billsForm = new Form3();
                    billsForm.ShowDialog();
                    billsForm.Dispose();
                    Show();
                }
                else {
                    MessageBox.Show("Nenshkrimi nuk eshte valid");
                }
            }
     
        }
    }
}
