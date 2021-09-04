using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Message_box_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<ClassOfSchool> MyClassOfSchool = new List<ClassOfSchool>();
            MyClassOfSchool.Add(
                new ClassOfSchool()
                {
                    classname = "12A",
                    liststudent = new List<string>(){ "nguyen van a","tran thi be","pham van ce"}
                }
            );
            MyClassOfSchool.Add(
                new ClassOfSchool()
                {
                    classname = "11A",
                    liststudent = new List<string>(){ "Le thi tao", "Duong van na", "Mai thi thanh long" }
                }
            );
            cbx_Class_var.DataSource = MyClassOfSchool;
            cbx_Class_var.DisplayMember = "classname";

            dateTimePicker1.Value = new DateTime(2022, 1, 22);

            DateTime mydate = dateTimePicker1.Value;
            mydate.AddDays(-6);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("context of notify", "caption of notify", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);

            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    //nguoi dung an cancel
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    //nguoi dung da an yes
                    break;
                case DialogResult.No:
                    //nguoi dung an No
                    break;
                default:
                    break;
            }
            //if(result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    //khi nguoi dung bam yes
            //}
            //else
            //{
            //    //khi nguoi dung khong bam yes
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = !panel1.Enabled;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;
            //MessageBox.Show(cb.SelectedIndex.ToString());
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;
            ////MessageBox.Show(cb.SelectedItem.ToString());
            //if(cb.SelectedValue != null)
            //{
            //    food fb = cb.SelectedValue as food;
            //    Tbx_price_var.Text = fb.price.ToString();
            //}
        }
        //List<string> mylist;
        //private void Btn_loadItem_var_Click(object sender, EventArgs e)
        //{
        //    mylist = new List<string>() { "abc xyz", "nguyen van a", "tran thi be" };
        //    comboBox1.DataSource = mylist;
        //}
        List<food> mylist;
        private void Btn_loadItem_var_Click(object sender, EventArgs e)
        {
            mylist = new List<food>()
            {
                new food("muc kho", 100),
                new food("ca tuoi", 22.5f),
                new food("thit cuu", 12.3f)
            };
            comboBox1.DataSource = mylist;
            comboBox1.DisplayMember = "name";
            //comboBox1.DisplayMember = "price";
        }

        private void cbx_Class_var_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedValue != null)
            {
                ClassOfSchool ClassOfSchool_temp = cb.SelectedValue as ClassOfSchool;
                cbx_student_var.DataSource = ClassOfSchool_temp.liststudent;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if(timer1.Enabled)
            //{
            //    timer1.Stop();
            //    button4.Text = "start";
            //}
            //else
            //{
            //    timer1.Start();
            //    button4.Text = "stop";
            //}
            timer1.Enabled = !timer1.Enabled;
            button4.Text = (button4.Text == "start") ? "stop" : "start";
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            label1.Text = i.ToString();
        }

        private void goProcess_btn_Click(object sender, EventArgs e)
        {
            string link = @"http:\\howkteam.com";// neu nhu ko co ki tu @ thi cai cho \\ bi mat mat mot dau \, chi con mot dau \
            Process myprc = new Process();
            myprc.StartInfo.FileName = link;
            myprc.Start();
        }
    }
    public class food
    {
        private string _name;
        private float _price;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }
        public food(string para_name, float para_price)
        {
            this._name = para_name;
            this._price = para_price;
        }
        public override string ToString()
        {
            return (_name + ": " + _price);
        }
    }
    class ClassOfSchool
    {
        public string classname { set; get; }
        public List<string> liststudent { set; get; }
    }
}
