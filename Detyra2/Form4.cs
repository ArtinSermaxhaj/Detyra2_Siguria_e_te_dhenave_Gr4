using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detyra
{
    public partial class Form4 : Form
    {
        Client c1;
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            c1 = new Client();
        }
        private void AnuloBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 signupForm = new Form3();
            signupForm.ShowDialog();
            signupForm.Dispose();
            Show();
        }

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            string lloji = llojiField.Text;
            int viti = 0;
            double cmimi = 0;
            int muaji = 0;
            try
            {
                viti = Int32.Parse(vitiField.Text);
                cmimi = Double.Parse(cmimiField.Text);
                muaji = Int32.Parse(muajiField.Text);
                if (muaji < 1 || muaji > 12) {
                    throw new Exception();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ju lutem plotesoni te dhenat ne menyren e duhur");
            }
            String mesazhi = "Fatura?" + lloji + "?" + viti + "?" + muaji + "?" + cmimi;
            c1.ClientSend(mesazhi);     
        }


    }
}
