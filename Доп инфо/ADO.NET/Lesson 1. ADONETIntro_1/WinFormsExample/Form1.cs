using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExample
{
	public partial class Form1 : Form
	{
		DBWorker db = new DBWorker();
		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = db.LoadData();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			db.Save();
		}
	}
}
