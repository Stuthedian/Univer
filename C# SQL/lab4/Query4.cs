using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Postavki
{
    public partial class Query4 : Form
    {
        DataSet1 dataSet1;
        DataView bludodataView = new DataView();
        bool[] isChecked = { false, false };
        public Query4(DataSet1 dataSet1)
        {

            InitializeComponent();
            this.dataSet1 = dataSet1;
        }

        private void Query4_Load(object sender, EventArgs e)
        {
            Ccalpanel.Enabled = false;
            Colvopanel.Enabled = false;
            Errorlabel.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Sortpanel.Enabled = false;

            bludodataView.Table = dataSet1.bluda;
            if (!bludodataView.Table.Columns.Contains("osnova"))
                bludodataView.Table.Columns.Add("osnova", typeof(System.String),
                    "parent(osnova_bluda).osnova");
            if (!bludodataView.Table.Columns.Contains("vid"))
                bludodataView.Table.Columns.Add("vid", typeof(System.String),
                    "parent(vid_blud_bluda).vid");
            if (!bludodataView.Table.Columns.Contains("colpr"))
                bludodataView.Table.Columns.Add("colpr", typeof(System.Int32),
                    "count(child(bluda_sostav).pr)");
            if (!bludodataView.Table.Columns.Contains("vec"))
                bludodataView.Table.Columns.Add("vec", typeof(System.Decimal),
                    "sum(child(bluda_sostav).vec)");
            if (!dataSet1.sostav.Columns.Contains("belki"))
                dataSet1.sostav.Columns.Add("belki", 
                    typeof(System.Decimal), "parent(produkt_sostav).belki");
            if (!dataSet1.sostav.Columns.Contains("ziri"))
                dataSet1.sostav.Columns.Add("ziri", typeof(System.Decimal), 
                    "parent(produkt_sostav).ziri");
            if (!dataSet1.sostav.Columns.Contains("uglevod"))
                dataSet1.sostav.Columns.Add("uglevod", typeof(System.Decimal), 
                    "parent(produkt_sostav).uglevod");
            if (!bludodataView.Table.Columns.Contains("ccal"))
                bludodataView.Table.Columns.Add("ccal", typeof(System.Decimal),
                    "(sum(child(bluda_sostav).belki) + sum(child(bluda_sostav).uglevod))*0.41 " +
                    " + sum(child(bluda_sostav).ziri) * 0.93");
            dataGridView1.DataSource = bludodataView;
            dataGridView1.Columns.Remove("bl");
            dataGridView1.Columns.Remove("kod_osnova");
            dataGridView1.Columns.Remove("b");
            dataGridView1.Columns.Remove("trud");
            dataGridView1.Columns["bludo"].HeaderText = "Блюдо";
            dataGridView1.Columns["vihod"].HeaderText = "Выход";
            dataGridView1.Columns["osnova"].HeaderText = "Основа";
            dataGridView1.Columns["vid"].HeaderText = "Вид";
            dataGridView1.Columns["colpr"].HeaderText = "Кол-во продуктов";
            dataGridView1.Columns["vec"].HeaderText = "Общий вес продуктов";
            dataGridView1.Columns["ccal"].HeaderText = "Калорийность";
            dataGridView1.AutoResizeColumns();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Ccalpanel.Enabled = true;
                isChecked[0] = radioButton1.Checked;
                radioButton2.Checked = false;
                isChecked[1] = radioButton2.Checked;
                textBox1_TextChanged(sender, e);
            }
            else
            {
                isChecked[0] = radioButton1.Checked;
                Ccalpanel.Enabled = false;
                bludodataView.RowFilter = "";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Colvopanel.Enabled = true;
                isChecked[1] = radioButton2.Checked;
                radioButton1.Checked = false;
                isChecked[0] = radioButton1.Checked;
                textBox3_Validated(sender, e);
            }
            else
            {
                Colvopanel.Enabled = false;
                isChecked[1] = radioButton2.Checked;
                bludodataView.RowFilter = "";
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && !isChecked[0])
                radioButton1.Checked = false;
            else
            {
                radioButton1.Checked = true;
                isChecked[0] = false;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked && !isChecked[1])
                radioButton2.Checked = false;
            else
            {
                radioButton2.Checked = true;
                isChecked[1] = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Double d1, d2;
            if (!Double.TryParse(textBox1.Text, out d1))
            {
                textBox1.BackColor = Color.Red;
                return;
            }
            else if (!Double.TryParse(textBox2.Text, out d2))
            {
                textBox2.BackColor = Color.Red;
                return;
            }
            else if (d1 > d2)
            {
                Errorlabel.Visible = true;
                return;
            }
            else
            {
                Errorlabel.Visible = false;
                textBox1.BackColor = SystemColors.Window;
                textBox2.BackColor = SystemColors.Window;
                bludodataView.RowFilter = "ccal >= " + d1 + " and ccal <= " + d2;
            }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            int d1, d2;
            if (!int.TryParse(textBox3.Text, out d1))
            {
                textBox3.BackColor = Color.Red;
                return;
            }
            else if (!int.TryParse(textBox4.Text, out d2))
            {
                textBox4.BackColor = Color.Red;
                return;
            }
            else if (d1 > d2)
            {
                Errorlabel.Visible = true;
                return;
            }
            else
            {
                Errorlabel.Visible = false;
                textBox3.BackColor = SystemColors.Window;
                textBox4.BackColor = SystemColors.Window;
            }
            bludodataView.RowFilter = "colpr >= " + d1 + " and colpr <= " + d2;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                Sortpanel.Enabled = true;
                listBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                Sortpanel.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    {
                        bludodataView.Sort = "ccal";
                    }
                    break;
                case 1:
                    {
                        bludodataView.Sort = "colpr";
                    }
                    break;
                case 2:
                    {
                        bludodataView.Sort = "vid, bludo";
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
