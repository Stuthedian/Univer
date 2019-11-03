using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab4_Postavki
{
    public partial class ProduktyForm : Form
    {
        DataRow row;
        string oldProdukt;
        DataSet1 dataSet1;
        Ed edited;
        BindingSource produktBindingSource = new BindingSource();
        bool is_insert;
        public ProduktyForm(Ed edited, DataSet1 dataSet1)
        {
            InitializeComponent();
            this.dataSet1 = dataSet1;
            this.edited = edited;
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel3.Visible = true;
            listBox1.Enabled = false;
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.ReadOnly = false;
                textbox.Text = "";
            }
            textBox1.Focus();
            is_insert = true;
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel3.Visible = true;
            listBox1.Enabled = false;
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.ReadOnly = false;
            }
            is_insert = false;

            row = dataSet1.produkt.Rows.Find(int.Parse(listBox1.SelectedValue.ToString()));
            oldProdukt = textBox1.Text;
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow temprow = dataSet1.produkt.Rows.Find(int.Parse(listBox1.SelectedValue.ToString()));
                if (dataSet1.postavki.Select("pr='" + temprow[0].ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Продукт есть в поставках.");
                    return;
                }
                if (dataSet1.sostav.Select("pr='" + temprow[0].ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Продукт есть в составе.");
                    return;
                }
                if (dataSet1.nalishie.Select("pr='" + temprow[0].ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Продукт есть в наличии.");
                    return;
                }
                try
                {
                    temprow.Delete();
                    edited.Value = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel3.Visible = false;
            listBox1.Enabled = true;
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.ReadOnly = true;
            }
            produktBindingSource.MoveFirst();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            #region
            TextBox[] textBoxes = Controls.OfType<TextBox>().Reverse().ToArray<TextBox>();
            /*foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                if (textbox.Text.Trim() == "")
                {
                    MessageBox.Show("Присутсвует незаполненное поле");
                    textbox.Focus();
                    return;
                }
            }*/
            for (int i = 0; i < textBoxes.Count(); i++)
            {
                double s;
                if (textBoxes[i].Text.Trim() == "")
                {
                    MessageBox.Show("Присутсвует незаполненное поле");
                    textBoxes[i].Focus();
                    
                    return;
                }
                if(i != 0 && !double.TryParse(textBoxes[i].Text, out s))
                {
                    MessageBox.Show("Некорректное значение поля");
                    textBoxes[i].Focus();
                    return;
                }
            }
            if (is_insert || !is_insert && oldProdukt != textBox1.Text)
                if (dataSet1.produkt.Select("produkt='" + textBox1.Text + "'").Count() > 0)
                {
                    MessageBox.Show("Такой продукт" +
                        " уже существует");
                    textBox1.Focus();
                    return;
                }
            #endregion
            if (is_insert)
            {
                row = dataSet1.produkt.NewRow();
                for (int i = 1; i < row.ItemArray.Length; i++)
                {
                    row[i] = textBoxes[i-1].Text;
                }
                int kol = listBox1.Items.Count;
                dataSet1.produkt.Rows.Add(row);
                listBox1.SelectedIndex = kol;
            }
            else
            {
                String[] temp = new String[textBoxes.Count()];
                for (int i = 0; i < textBoxes.Count(); i++)
                {
                    temp[i] = textBoxes[i].Text;
                }
                for (int i = 1; i < row.ItemArray.Length; i++)
                {
                    row[i] = temp[i-1];
                }
            }
            edited.Value = true;
            panel2.Enabled = true;
            panel3.Visible = false;
            listBox1.Enabled = true;
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.ReadOnly = true;
            }
        }

        private void ProduktyForm_Load(object sender, EventArgs e)
        {
            produktBindingSource.DataSource = dataSet1.produkt;
            listBox1.DataSource = produktBindingSource;
            listBox1.DisplayMember = "produkt";
            listBox1.ValueMember = "pr";
            textBox1.DataBindings.Add("Text", produktBindingSource, "produkt", false, DataSourceUpdateMode.Never);
            textBox2.DataBindings.Add("Text", produktBindingSource, "belki", false, DataSourceUpdateMode.Never);
            textBox3.DataBindings.Add("Text", produktBindingSource, "ziri", false, DataSourceUpdateMode.Never);
            textBox4.DataBindings.Add("Text", produktBindingSource, "uglevod", false, DataSourceUpdateMode.Never);
            textBox5.DataBindings.Add("Text", produktBindingSource, "k", false, DataSourceUpdateMode.Never);
            textBox6.DataBindings.Add("Text", produktBindingSource, "ca", false, DataSourceUpdateMode.Never);
            textBox7.DataBindings.Add("Text", produktBindingSource, "na", false, DataSourceUpdateMode.Never);
            textBox8.DataBindings.Add("Text", produktBindingSource, "b2", false, DataSourceUpdateMode.Never);
            textBox9.DataBindings.Add("Text", produktBindingSource, "pp", false, DataSourceUpdateMode.Never);
            textBox10.DataBindings.Add("Text", produktBindingSource, "c", false, DataSourceUpdateMode.Never);
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.ReadOnly = true;
            }
            panel3.Visible = false;
            if (produktBindingSource.Count == 0)
            {
                Editbutton.Enabled = false;
                Delbutton.Enabled = false;
            }
        }

        private void ViewRowbutton_Click(object sender, EventArgs e)
        {
            new ProduktyExtra(edited, dataSet1).ShowDialog();
        }
    }
}
