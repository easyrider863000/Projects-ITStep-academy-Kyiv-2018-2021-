using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace DZ_22._05._2019
{
    [Serializable]
    public class Data
    {
        public DateTime date { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return $"{date.ToLongDateString()} {date.Hour}:{date:mm} {Text}";
        }
    }
    public partial class Form1 : Form
    {
        BinaryFormatter formatter;
        DateTime dateTime;
        public List<Data> dataForList;
        public Form1()
        {
            InitializeComponent();
            dateTime = new DateTime();
            dateTimePicker1.Value = DateTime.Now;
            formatter = new BinaryFormatter();
            if(!File.Exists("tasks.bin"))
            {
                using (Stream fStream = new FileStream("tasks.bin", FileMode.Create, FileAccess.Write))
                {
                    dataForList = formatter.Deserialize(fStream) as ListView;
                    listView1 = dataForList;
                }
            }
            foreach (var item in dataForList)
            {
                item.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&dateTime.Ticks>DateTime.Now.Ticks)
            {
                ListViewItem item = new ListViewItem($"{dateTime.ToLongDateString()} {dateTime.Hour}:{dateTime:mm} {textBox1.Text}");
                listView1.Items.Add(item);
                dataForList = listView1;
                using (Stream fStream = new FileStream("tasks.bin", FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(fStream, dataForList);
                }

                dateTimePicker1.Value = DateTime.Now;
                textBox1.Text = "";
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateTime = e.Start;
            dateTimePicker1.Value = dateTime;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTime = dateTimePicker1.Value;
        }
    }
}
