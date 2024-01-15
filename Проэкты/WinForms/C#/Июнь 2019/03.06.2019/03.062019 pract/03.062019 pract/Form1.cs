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
    public partial class Form1 : Form
    {
        Form2 form2;
        public string Textbox { set => textBox1.Text = value;
            get => textBox1.Text; }
        public bool enabledBut2 { get => button2.Enabled; set => button2.Enabled = value; }
        public bool enabledBut1 { get => button1.Enabled; set => button1.Enabled = value; }
        public OpenFileDialog fd = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            fd.Filter = "Text files(*.txt)|*.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(fd.FileName))
                { this.textBox1.Text = sr.ReadToEnd(); }
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            form2 = new Form2(this, this.textBox1.Text);
            form2.Show();
        }
    }
}
