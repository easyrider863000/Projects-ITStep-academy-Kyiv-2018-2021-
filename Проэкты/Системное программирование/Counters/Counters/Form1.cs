using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Counters
{
    public partial class Form1 : Form
    {
        bool f { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            if (radioButton1.Checked)
                FirstConfig();
            else if (radioButton2.Checked)
                SecondConfig();
            else if (radioButton3.Checked)
                ThirdConfig();
            else if (radioButton4.Checked)
                FourthConfig();
            else if (radioButton5.Checked)
                FivethConfig();
            button2.Enabled = true;
        }
        private async void FirstConfig()
        {
            CountAsync(label1);
            CountAsync(label2);
            CountAsync(label3);
            CountAsync(label4);
            await CountAsync(label5);
            button2.Enabled = false;
            button3.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
        }
        private async void SecondConfig()
        {
            await CountAsync(label1);
            await CountAsync(label2);
            await CountAsync(label3);
            await CountAsync(label4);
            await CountAsync(label5);
            button2.Enabled = false;
            button3.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
        }
        private async void ThirdConfig()
        {
            await CountAsync(label5);
            await CountAsync(label4);
            await CountAsync(label3);
            await CountAsync(label2);
            await CountAsync(label1);
            button3.Enabled = true;
            button2.Enabled = false;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
        }
        private async void FourthConfig()
        {
            await CountAsync(label1);
            await CountAsync(label3);
            await CountAsync(label5);
            await CountAsync(label2);
            await CountAsync(label4);
            button3.Enabled = true;
            button2.Enabled = false;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
        }
        private async void FivethConfig()
        {
            CountAsync(label1);
            await CountAsync(label5);
            await CountAsync(label2);
            await CountAsync(label3);
            await CountAsync(label4);
            button3.Enabled = true;
            button2.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
        }


        private Task CountAsync(Label lbl)
        {
            return Task.Run(() =>
            {
                int n = Convert.ToInt32(lbl.Text);
                for (int i = 0; i < 10&&n<10; i++)
                {
                    if (!f)
                    {
                        Task.WaitAny();
                    }
                    else
                    {

                        n = Convert.ToInt32(lbl.Text);
                        n++;
                        lbl.Text = n.ToString();
                        Thread.Sleep(500);
                    }
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f = false;
            button1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            button2.Enabled = false;
            button1.Enabled = true;
        }
    }
}
