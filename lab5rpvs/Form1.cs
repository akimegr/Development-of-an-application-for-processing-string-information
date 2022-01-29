using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5rpvs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] arrayStrings = { "11111 10101 1010 010101", "1001 10101 01001", "11 010 101" };
            comboBox1.Items.AddRange(arrayStrings);

        }

        static void findNumberLines(string str, TextBox textBox1)
        {
            string result = "";
            string checkResult = "";
            int count = 0;
            int checkCount= str.Length;

            if (str.Length != 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if ((int)str[i] == 48 || (int)str[i] == 49)// 0 и 1
                    {
                        count += 1;
                        result += str[i];
                    }
                    else if (str[i] == ' ')
                    {
                        if (count < checkCount && count != 0)
                        {
                            checkCount = count;
                            checkResult = result;
                        }
                        count = 0;
                        result = "";
                    }


                }
                textBox1.Text += "Строка: " + str + " Наименшее: " + checkResult + " С длиной: "+ checkCount +"\r\n";
            }
            else
            {
                textBox1.Text = "Ошибка, нет символов";
            }
        }


        static void findWord(string str, TextBox textBox1, string tb)
        {
            string result = "";
            string checkResult = "";
            int count = 0;
            int checkCount = str.Length;

            if (str.Length != 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        break;
                    }
                    else
                    {
                        result += str[i];
                    }
                }
                if (result == tb)
                {
                    textBox1.Text += tb + " найдено";
                }
                else
                    textBox1.Text += tb + " не найдено";
            }
            else
            {
                textBox1.Text = "Ошибка, нет символов";
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = comboBox1.SelectedItem.ToString();
            
            if (radioButton2.Checked)
            {
                findNumberLines(str, textBox1);
            }
            else
            {
                findWord(str, textBox1,textBox2.Text);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
