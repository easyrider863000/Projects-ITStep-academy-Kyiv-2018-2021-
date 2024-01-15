
using HR.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class FormPerson : Form
    {
        List<Person> list;
        Person person;
        BindingSource bsPerson = new BindingSource();
        FileManager fileManager;


        public FormPerson()
        {
            InitializeComponent();
            fileManager = new FileManager();
            textBox1.AllowDrop = true;
            textBox1.DragOver += new DragEventHandler(textBox1_DragEnter);
            textBox1.DragDrop += new DragEventHandler(textBox1_DragDrop);

        }

        private void lbPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            person = list.Where(p => p.Id == Convert.ToInt32(lbPerson.SelectedValue))
                .FirstOrDefault();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Update();
            foreach (var photo in person.Photos)
            {
                Image img = Image.FromFile(photo.PhotoPath);
                PictureBox p = new PictureBox();
                p.Width = 120;
                p.Height = 100;
                p.Image = ResizeImage.FixedSize(img, p.Width, p.Height, true);
                flowLayoutPanel1.Controls.Add(p);
            }
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            //list = DataLayer.GetPerson();
            list = fileManager.Persons;
            bsPerson.DataSource = list;
            //dgvPerson.DataSource = bsPerson;
            lbPerson.ValueMember = "Id";
            lbPerson.DisplayMember =   "ToString";//"FirstName";
            lbPerson.DataSource = bsPerson;
            tbFirtName.DataBindings.Add("Text", bsPerson, "FirstName",
                true, DataSourceUpdateMode.OnPropertyChanged);
            tbLastName.DataBindings.Add("Text", bsPerson, "LastName",
                false, DataSourceUpdateMode.OnPropertyChanged);
            textBox1.DataBindings.Add("Text", bsPerson, "Textd",
                false, DataSourceUpdateMode.OnPropertyChanged);
            txtInn.DataBindings.Add("Text", bsPerson,
                "INN", false, DataSourceUpdateMode.Never);
            dtpBirthday.DataBindings.Add("Value", bsPerson, "DateBirthday",
                false, DataSourceUpdateMode.OnPropertyChanged);
        }

      

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                string ext = Path.GetExtension(FileList[0]);
                string fullpath = Path.Combine("Photos", Guid.NewGuid().ToString() + "." + ext);

                File.Copy(FileList[0], fullpath);

                Image img = Image.FromFile(fullpath);
                PictureBox p = new PictureBox();
                p.Width = 120;
                p.Height = 100;

                p.Image = ResizeImage.FixedSize(img, p.Width, p.Height, true); ;

                flowLayoutPanel1.Controls.Add(p);
                person.Photos.Add(new Photo() { PhotoPath = fullpath });
            }
        }

        private void flowLayoutPanel1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileManager.SaveData();
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
            
                string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
                string ext = Path.GetExtension(FileList[0]);
                string fullpath = Path.Combine(Guid.NewGuid().ToString() + "." + ext);
            
                File.Copy(FileList[0], fullpath);
                using (StreamReader sr = new StreamReader(fullpath))
                {
                    textBox1.Text = sr.ReadToEnd();
                    person.Textd = sr.ReadToEnd();
                }
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            
        }
    }
}
