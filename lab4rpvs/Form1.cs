using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4rpvs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            
                int N = int.Parse(textBox2.Text);
                int M = int.Parse(textBox2.Text);
                double[,] matrix = new double[N, M];

                GetArray(matrix);

                Write(matrix, dataGridView1);           

        }


        public static double[] Transform(double[,] matrix, double[] array)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++) 
                {
                    if (matrix[i, j] >= matrix[i, j + 1])
                    {
                        count += 1;
                    }
                }
                if (count == matrix.GetLength(0) - 1)
                    array[i] = 1;
                else
                    array[i] = 0;

                count = 0;
            }
            return array;
        }
        // Чтение массива из DataGridVeiw
        public static double[,] Read(DataGridView dataGridView)
        {
            double[,] matrix = new double[dataGridView.RowCount, dataGridView.ColumnCount];
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    matrix[i, j] = Convert.ToDouble(dataGridView.Rows[i].Cells[j].Value);//!!!!!!!!!!!!!!!!!!!!!!
                }
            }
            return matrix;
        }


        public void GetArray(double[,] matrix)
        {
            Random msg = new Random(); 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = msg.Next(1, 10);
                }
            }
        }

        // Запись массива в DataGridView
        public void Write(double[,] matrix, DataGridView dataGridView)
        {
            dataGridView.RowCount = matrix.GetLength(0);
            dataGridView.ColumnCount = matrix.GetLength(1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = (i+1).ToString();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView.Columns[j].HeaderCell.Value = (j+1).ToString();
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];
                    
                }
            }
        }

        public void Write1(double[] array, DataGridView dataGridView)
        {
            dataGridView.RowCount = array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView.Rows[i].Cells[0].Value = array[i];
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            int M = int.Parse(textBox2.Text);
            double[,] matrix = new double[N, M];
            double[] array = new double[N];

            matrix = Read(dataGridView1);

            array = Transform(matrix, array);

            Write1(array, dataGridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentCell.Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
