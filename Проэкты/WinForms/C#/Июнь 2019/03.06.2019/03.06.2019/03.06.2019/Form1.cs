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

namespace _03._06._2019
{
    public partial class Form1 : Form
    {
            OpenFileDialog fd = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            fd.Title = "TestOpenDialog";
            //fd.InitialDirectory = @"D:\";
            fd.RestoreDirectory = true;
            fd.Filter = "All files(*.*)|*.*|Text files(*.txt)|*.txt|Bitmap(*.bmp)|*.bmp|Images(*.jpg)|*.jpg";
            fd.FilterIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(fd.FileName, Encoding.Default))
                {
                    label1.Text = sr.ReadToEnd();
                }
                //MessageBox.Show(fd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                button2.Font = fd.Font;
            }
        }
    }
}
