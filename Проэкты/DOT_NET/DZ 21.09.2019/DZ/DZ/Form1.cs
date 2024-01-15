using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace DZ
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        string cs = "";
        List<string> sql = new List<string>();
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.
            ConnectionStrings["ShopAdoConnectionString"].
            ConnectionString;
            conn.ConnectionString = cs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(textBox1.Text, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataTable dt in ds.Tables)
                    {
                        tabControl1.TabPages.Add(dt.TableName);
                        ListView listView = new ListView();
                        listView.View = View.Details;
                        listView.Columns.Add("");
                        foreach(DataColumn colmn in dt.Columns)
                        {
                            listView.Columns.Add(colmn.ColumnName);
                        }
                        listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                        listView.Items.Clear();
                        listView.FullRowSelect = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem();
                            item.SubItems.RemoveAt(0);
                            for (int i = 0; i < row.ItemArray.Length; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            listView.Items.Add(item);
                        }
                        listView.Size = new Size(500, 300);
                        tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                        tabControl1.SelectedTab.Controls.Add(listView);
                        Button closeButton = new Button();
                        closeButton.Height = 50;
                        closeButton.Width = 50;
                        closeButton.Text = "Close this tab";
                        closeButton.Location = new Point(510, 10);
                        closeButton.Click += CloseButton_Click;
                        tabControl1.SelectedTab.Controls.Add(closeButton);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Probably wrong request syntax");
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
    }
}
