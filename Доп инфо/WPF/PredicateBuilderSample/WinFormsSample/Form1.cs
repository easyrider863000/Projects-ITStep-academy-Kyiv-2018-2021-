using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqKit;

namespace WinFormsSample
{
    public partial class Form1 : Form
    {
        IEnumerable<Student> students = Student.GetStudents();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = students.ToList();
          

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dict = new Dictionary<Control, Expression<Func<Student, bool>>>
            {
                [checkBox1] = x => x.Name.ToLower().Contains((string)checkBox1.Tag),
                [checkBox2] = x => x.Year < (Convert.ToInt32(checkBox2.Tag))

            };

            var predicate = PredicateBuilder.New<Student>(true);
            foreach (var elem in dict)
            {
                if (elem.Key is CheckBox cb && cb.Checked )
                {
                    predicate.And(dict[elem.Key]);
                }
            }

            var res = students.Where(predicate);
            dataGridView1.DataSource = res.ToList();
        }

        Dictionary<Control, Expression<Func<Student, bool>>> dict;
    }
}
