using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30._05._2019
{
    public partial class Form2 : Form
    {
        Form1 f1_;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f1)
        {
            InitializeComponent();
            f1_ = f1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            f1_.SomeText = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
