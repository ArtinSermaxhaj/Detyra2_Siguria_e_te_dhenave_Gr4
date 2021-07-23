using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serveri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void serverStartBtn_Click(object sender, EventArgs e)
        {
            Server s1 = new Server();
            s1.ShtoCelesat();
            MessageBox.Show("Serveri u startua");
        }

    }
}
