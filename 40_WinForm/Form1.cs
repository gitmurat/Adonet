using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _40_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int clickCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            clickCount++;
            textBox1.Text = "Merhaba" + " " + clickCount;
        }
    }
}
