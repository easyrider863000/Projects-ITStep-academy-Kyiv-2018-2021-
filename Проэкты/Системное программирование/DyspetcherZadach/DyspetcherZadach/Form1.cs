using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DyspetcherZadach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateList();
        }
        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Process proc in Process.GetProcesses())
            {
                listBox1.Items.Add(proc.Id+"\t"+proc.ProcessName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Process workProc = Process.GetProcessById(Convert.ToInt32(listBox1.SelectedItem.ToString().Split(new char[] { '\t' })[0]));
                workProc.Kill();
                UpdateList();
            }
        }
    }
}
