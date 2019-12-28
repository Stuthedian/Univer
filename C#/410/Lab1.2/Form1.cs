using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._2
{
    public partial class Form1 : Form
    {
        double[,] a;
        double[] f;
        double[] x;
        public Form1()
        {
            InitializeComponent();
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(numericUpDown1.Value);
            a = new double[val, val];
            f = new double[val];
            x = new double[val];

            dataGridView1.Columns.Clear();
            for (int i = 1; i <= val; i++)
            {
                dataGridView1.Columns.Add("", "");
            }
            dataGridView1.Rows.Add(val);

            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("", "");
            dataGridView2.Rows.Add(val);

            dataGridView3.Columns.Clear();
            dataGridView3.Visible = false;
            dataGridView3.Columns.Add("", "");
            dataGridView3.Rows.Add(val);

            //panel1.Enabled = false;
            panel2.Enabled = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*
            double n;
            DataGridView dataGrid = (DataGridView)sender;
            if (dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                return;
            if (double.TryParse(dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out n) == false)
                dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Требуется число!";
            else
                dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool forward = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if(dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        //dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.DarkRed;
                        dataGridView1.Rows[i].Cells[j].ErrorText = "Ячейка должна быть заполнена!";
                        forward = false;
                    }
                    else
                    {
                        //dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dataGridView1.Rows[i].Cells[j].ErrorText = "";
                        a[i, j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }                  
                    /*
                    else if ()
                    {
                        MessageBox.Show("Присутствует ячейка с ошибкой!");
                        return;
                    }
                    */
                    
                }
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value == null)
                {
                    //dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.DarkRed;
                    dataGridView2.Rows[i].Cells[0].ErrorText = "Ячейка должна быть заполнена!";
                    forward = false;
                }
                else
                {
                    //dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.White;
                    dataGridView2.Rows[i].Cells[0].ErrorText = "";
                    f[i] = double.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                }
                /*
                if (dataGridView2.Rows[i].Cells[0].Value == null)
                {
                    MessageBox.Show("Присутствует пустая ячейка!");
                    return;
                }

                else if (dataGridView2.Rows[i].Cells[0].ErrorText != "")
                {
                    MessageBox.Show("Присутствует ячейка с ошибкой!");
                    return;
                }
                */
                
            }
            if (!forward)
                return;
            try { gauss_method(ref a, ref f); }
            catch(DivideByZeroException)
            {
                MessageBox.Show("Система не имеет решений/ имеет беск. множество решений");
            }
            
        }
        
        private void gauss_method(ref double[,] a, ref double[] f)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                method1(ref a, ref f, i);
                method2(ref a, ref f, i);
            }
            method3(a, f, out x);
            method4(a, f, x);
        }

        private void method1(ref double[,] a, ref double[] f, int k)
        {
            double max = a[k, 0];
            int imax = k;
            for (int i = k + 1; i < a.GetLength(0); i++)
            {
                if(Math.Abs(a[i, 0]) > max)
                {
                    max = a[i, 0];
                    imax = i;
                }
            }
            
            double at;
            for (int j = 0; j < a.GetLength(0); j++)
            {
                at = a[imax, j];
                a[imax, j] = a[k, j];
                a[k, j] = at;
            }
            at = f[imax];
            f[imax] = f[k];
            f[k] = at;
        }

        private void method2(ref double[,] a, ref double[] f, int k)
        {
            double c;
            for (int i = k + 1; i < a.GetLength(0); i++)
            {
                if(a[k, k] == 0)
                    throw new DivideByZeroException();
                c = a[i, k] / a[k, k];
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    a[i, j] -= c * a[k, j];
                    f[i] -= c * f[k];
                }
            }
        }

        private void method3(double[,] a, double[] f, out double[] x)
        {
            x = new double[f.Length];
            int last = f.Length - 1;
            if (a[last, last] == 0)
                throw new DivideByZeroException();
            x[last] = f[last] / a[last, last];
            double s;
            for (int k = last - 1; k >= 0; k--)
            {
                s = 0;
                for (int i = k + 1; i < x.Length; i++)
                    s += a[k, i] * x[i];
                if (a[k, k] == 0)
                    throw new DivideByZeroException();
                x[k] = (f[k] - s) / a[k, k];
            }
            for (int i = 0; i < x.Length; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = x[i];
            }
            dataGridView3.Visible = true;
        }

        private void method4(double[,] a, double[] f, double[] x)
        {
            double max = -1;
            double s;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = 0;
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    s += a[i, j] * x[j];
                }
                s = Math.Abs(f[i] - s);
                if (s > max)
                    max = s;
            }
            MessageBox.Show("Max == " + max.ToString());
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = (TextBox)e.Control;
            textBox.KeyPress += TextBox_KeyPress;
            
            //e.CellStyle.BackColor = Color.White;
            //((DataGridView)sender).SelectedCells[0].Style.BackColor = Color.White;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            TextBox tb = ((TextBox)sender);
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                if (tb.Text.Contains(',') && tb.Text.Substring(tb.Text.IndexOf(',') + 1).Length >= 2)
                    e.Handled = true;
            }
            else if (e.KeyChar == '\b' || e.KeyChar == ' ')
                    e.Handled = false;
            else if (e.KeyChar == ',' && !tb.Text.Contains(','))
                e.Handled = false;
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
                TextBox_KeyPress(sender, e);
            }
            else if (e.KeyChar == '-' && tb.Text.Trim().Length == 0)
                e.Handled = false;
        }
    }
}
