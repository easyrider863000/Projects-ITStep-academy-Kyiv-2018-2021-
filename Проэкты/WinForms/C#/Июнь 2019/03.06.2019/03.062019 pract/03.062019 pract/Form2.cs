using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03._062019_pract
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f,string txt)
        {
            InitializeComponent();
            form1 = f;
            textBox1.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(form1.fd.FileName))
            {
                sw.Write(textBox1.Text);
                form1.Textbox = textBox1.Text;
                form1.enabledBut1 = true;
                form1.enabledBut2 = true;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.enabledBut2 = true;
            form1.enabledBut1 = true;
            Close();
        }
    }
}
