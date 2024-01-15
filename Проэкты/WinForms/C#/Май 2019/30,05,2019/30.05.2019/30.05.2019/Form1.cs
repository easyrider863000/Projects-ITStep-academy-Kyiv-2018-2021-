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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string SomeText{get;set;}
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            DialogResult dr = f.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                listBox1.Items.Add(SomeText);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
