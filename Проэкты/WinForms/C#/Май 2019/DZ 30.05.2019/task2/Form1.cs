using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class OrderForm : Form
    {
        Component newComponet;

        List<Component> Comp;
        public OrderForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Comp = new List<Component>();

            newComponet = null;

            of_cb_components.SelectedIndexChanged += Of_cb_components_SelectedIndexChanged;

            of_b_add.Click += Of_b_add_Click;

            of_lb_selectedComp.DoubleClick += Of_lb_selectedComp_DoubleClick;

            of_b_close.Click += Of_b_close_Click;

            of_b_createComp.Click += Of_b_createComp_Click;

            of_b_edit.Click += Of_b_edit_Click;
        }
        private void Of_b_edit_Click(object sender, EventArgs e)
        {
            int index = of_cb_components.SelectedIndex;
            int n = 0; int jj;
            int[] j = new int[1];
            string oldTitle = of_cb_components.SelectedItem.ToString();
            string newTitle = "";
            bool isEdit = false;
            foreach (Component item in Comp)
            {
                if (item.Title == oldTitle)
                {
                    CEdit f = new CEdit(item, false);
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        
                        of_cb_components.Items.RemoveAt(index);
                        of_cb_components.Items.Insert(index, item.Title);
                        
                        Comp.RemoveAt(n);
                        Comp.Insert(n, item);

                        newTitle = item.Title;

                        of_cb_components.SelectedIndex = -1;
                        of_b_add.Enabled = false;
                        of_b_edit.Enabled = false;
                        of_rtb_characteristics.Clear();
                        of_rtb_description.Clear();
                        of_tb_price.Clear();

                        isEdit = true;
                    }

                    break;
                }
                n++;
            }
            n = 0;
            jj = 1;
            if (isEdit)
            {
                
                foreach (string title in of_lb_selectedComp.Items)
                {
                    if (title == oldTitle)
                    {
                        Array.Resize(ref j, jj);

                        j[jj - 1] = n;
                        jj++;
                    }
                    n++;
                }
                ChangeListItem(j, newTitle);
                SetTotalPrice();
            }

        }
        private void Of_b_createComp_Click(object sender, EventArgs e)
        {
            newComponet = new Component();
            CEdit f = new CEdit(newComponet, true);

            if (f.ShowDialog() == DialogResult.OK)
            {
                Comp.Add(newComponet);
                of_cb_components.Items.Add(newComponet.Title);

                int n = 0;
                foreach (string title in of_cb_components.Items)
                {
                    if (title == newComponet.Title)
                    {
                        break;
                    }
                    n++;
                }
                of_cb_components.SelectedIndex = n;
            }
        }
        private void Of_b_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Of_lb_selectedComp_DoubleClick(object sender, EventArgs e)
        {
            if (of_lb_selectedComp.SelectedIndex != -1)
            {
                foreach (Component item in Comp)
                {
                    if (item.Title == of_lb_selectedComp.SelectedItem.ToString())
                    {
                        MessageBox.Show(item.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            
        }
        private void Of_b_add_Click(object sender, EventArgs e)
        {

            of_lb_selectedComp.Items.Add(of_cb_components.SelectedItem.ToString());
            SetTotalPrice();
        }
        private void Of_cb_components_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (of_cb_components.SelectedIndex >= 0)
            {
                of_b_add.Enabled = true;
                of_b_edit.Enabled = true;

                foreach (Component item in Comp)
                {
                    if (item.Title == of_cb_components.SelectedItem.ToString())
                    {
                        of_rtb_characteristics.Text = item.Characteristic;
                        of_rtb_description.Text = item.Description;
                        of_tb_price.Text = item.Price.ToString();
                    }
                }
            }
            else
            {
                of_b_add.Enabled = false;
                of_b_edit.Enabled = false;
            }
        }
        private void SetTotalPrice()
        {
            float res = 0;
            
            if (of_lb_selectedComp.Items.Count > 0)
            {
                foreach (string c in of_lb_selectedComp.Items)
                {
                    foreach (Component item in Comp)
                    {
                        if (c == item.Title)
                        {
                            res += item.Price;
                        }
                    }
                }
            }
            of_l_totalPrice.Text = res.ToString();
        }
        private float GetComponentPrice(string component)
        {
            foreach (Component item in Comp)
            {
                if (item.Title == component)
                {
                    return item.Price;
                }
            }
            return -1;
        }
        private void ChangeListItem(int[] positions, string newTitle)
        {
            foreach(int position in positions)
            {
                of_lb_selectedComp.Items.RemoveAt(position);
                of_lb_selectedComp.Items.Insert(position, newTitle);
            }
        }
    }
   
}
