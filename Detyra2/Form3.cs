using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serveri;

namespace Detyra
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show(SessionManager.user.username);

        }

        private void addBillsBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 addBillsForm = new Form4();
            addBillsForm.ShowDialog();
            addBillsForm.Dispose();
            addBillsForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Lloji", typeof(string));
            table.Columns.Add("Viti", typeof(int));
            table.Columns.Add("Muaji", typeof(int));
            table.Columns.Add("Cmimi", typeof(double));
            table.Rows.Add("Test", 1, 12, 13);
            dataGridView1.DataSource = table;
        }
    }
}
