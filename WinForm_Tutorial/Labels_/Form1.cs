using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labels_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "free edu";
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label1.Text = "clicked form";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button_open.Text == "open")
            {
                button_open.Text = "close";
            }
            else
            {
                button_open.Text = "open";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label2.Text = textBox1.Text;
            int num = 0;
            //num = Convert.ToInt32(textBox1.Text);
            if (Int32.TryParse(textBox1.Text, out num))
            {
                label2.Text = (num * num).ToString();
            }
            else
            {
                label2.Text = "type number";
            }
            //string mystate = (checkBox1.CheckState == CheckState.Checked) ? "checked" : (checkBox1.CheckState == CheckState.Unchecked ? "uncheck" : "float");
            //MessageBox.Show(mystate);
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //moi khi co su thay doi trong text thi no se nhay vao day.
        }
    }
}
