using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_1
{
    public partial class Form1 : Form
    {
        Int32 id = 0;
        Int32 type = 0;
        string voltage;
        string current;
        string activepower;
        string status;
        string[] subs;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //serialPort1.Encoding = Encoding.GetEncoding(28591);
            //serialPort1.Encoding = Encoding.Unicode;
            //serialPort1.Encoding = Encoding.UTF8;
            try
            {
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("failue to open ComPort");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private delegate void delegate_function(string str);
        
        string buffer;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            delegate_function data_handler = new delegate_function(process_mess);
            this.BeginInvoke(data_handler, serialPort1.ReadExisting());
        }
        public void process_mess(string input)
        {
            buffer += input;
            if (input[0] == '\n')//input.ElementAt(0) == 'U'
            {
                //xu ly chuoi tai day
                handle_data(buffer);
                //reset lai string buffer
                buffer = "";
            }

            //txt_Received_Character.Text += input;
            //txt_Received_Ascii.Text += ((byte)input[0]).ToString("x") + " ";
        }

        /* ham cat chuoi va hien thi */
        /*  2 1 was_off
            3 0 U:215.00 I:270.17 X
            1 0 U:225.30 I:19.52 P:2.61
        */
        private void handle_data(string data)
        {
            subs = data.Split(' ');

            if (!Int32.TryParse(subs[0],out id))
            {
                MessageBox.Show("ID invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Int32.TryParse(subs[1], out type))
            {
                MessageBox.Show("data's type invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (type == 0)//dong dien, dien ap, cong suat
            {
                voltage = subs[2].Substring(2);
                current = subs[3].Substring(2);
                if (subs[4] == "X\r\n")
                {
                    activepower = "X";
                }
                else
                {
                    activepower = subs[4].Substring(2);
                    activepower = activepower.Replace('\n', '\0');//xoa ki tu \n de in ra ko bi xuong dong
                }
                switch (id)
                {
                    case 1:
                        {
                            textBox1_V.Text = voltage;
                            textBox1_A.Text = current;
                            textBox1_P.Text = activepower;
                            break;
                        }
                    case 2:
                        {
                            textBox2_V.Text = voltage;
                            textBox2_A.Text = current;
                            textBox2_P.Text = activepower;
                            break;
                        }
                    case 3:
                        {
                            textBox3_V.Text = voltage;
                            textBox3_A.Text = current;
                            textBox3_P.Text = activepower;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("ID valid but not found", "warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                }

            }
            else//thong bao
            {
                status = subs[2].Replace('\n','\0');//xoa ki tu \n de in ra ko bi xuong dong
                switch (id)
                {
                    case 1:
                        {
                            textBox1_Status.Text = status;
                            break;
                        }
                    case 2:
                        {
                            textBox2_Status.Text = status;
                            break;
                        }
                    case 3:
                        {
                            textBox3_Status.Text = status;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("ID valid but not found", "warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1on\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1off\r\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2on\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2off\r\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Write("3on\r\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Write("3off\r\n");
        }
    }
}
