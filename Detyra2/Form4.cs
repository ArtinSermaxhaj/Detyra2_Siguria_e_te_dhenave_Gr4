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
            Form3 billsForm = new Form3();
            billsForm.ShowDialog();
            billsForm.Dispose();
            Show();
        }

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            string lloji = llojiField.SelectedItem.ToString();
            string viti = vitiField.Text;
            string cmimi = cmimiField.Text;
            string muaji = muajiField.Text;
            if (!checkInput(viti,muaji,cmimi))
            {
                MessageBox.Show("Te dhenat e formes nuk jane mbushur si duhet. Provoni perseri");
                vitiField.Clear();
                muajiField.Clear();
                cmimiField.Clear();
            }
            else
            {
                String mesazhi = "fatura?" + lloji + "?" + viti + "?" + muaji + "?" + cmimi;
                c1.ClientSend(mesazhi);
                string pergjigja = c1.DekriptoPergjigjen();
                if (pergjigja.Equals("OK"))
                {
                    Hide();
                    Form3 billsForm = new Form3();
                    billsForm.ShowDialog();
                    billsForm.Dispose();
                    Show();
                }
            }
        }
        private bool checkInput(string viti, string muaji, string cmimi) {
            Boolean valid = true;
            try
            {
                int vitiValid = Int32.Parse(viti);
                int muajiValid = Int32.Parse(muaji);
                double cmimiValid = Double.Parse(cmimi);
                if (vitiValid > 2021 || vitiValid < 2010) {
                    throw new Exception();
                }
                if (muajiValid > 12 || muajiValid < 1) {
                    throw new Exception();
                }
            }
            catch (Exception ex) {
                valid = false;
            }
            
            return valid;
        }


    }
}
