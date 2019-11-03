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
    public partial class PostavkiForm : Form
    {
        DataRow row;
        DataSet1 dataSet1;
        Ed edited;
        BindingSource postavkiBindingSource = new BindingSource();
        BindingSource produktBindingSource = new BindingSource();
        BindingSource postavshikiBindingSource = new BindingSource();
        bool is_insert, loaded = false;
        public PostavkiForm(Ed edited, DataSet1 dataSet1)
        {
            InitializeComponent();
            this.dataSet1 = dataSet1;
            this.edited = edited;
        }

        private void PostavkiForm_Load(object sender, EventArgs e)
        {
            postavshikiBindingSource.DataSource = dataSet1.postavshiki;
            produktBindingSource.DataSource = dataSet1.produkt;
            postavkiBindingSource.DataSource = dataSet1.postavki;

            PostavshikBox.DataSource = postavshikiBindingSource;
            PostavshikBox.DisplayMember = "nazvanie";
            PostavshikBox.ValueMember = "pc";
            ProduktBox.DataSource = produktBindingSource;
            ProduktBox.DisplayMember = "produkt";
            ProduktBox.ValueMember = "pr";
            dataGridView1.DataSource = postavkiBindingSource;
            dataGridView1.Columns[2].DataPropertyName = "data";
            dataGridView1.Columns[3].DataPropertyName = "kol";
            dataGridView1.Columns[4].DataPropertyName = "cena";
            dataGridView1.Columns[2].HeaderText = "Дата";
            dataGridView1.Columns[3].HeaderText = "Кол-во";
            dataGridView1.Columns[4].HeaderText = "Цена";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            Editpanel.Visible = false;
            panel3.Visible = false;
            postavkiBindingSource.Filter = "pc= " + PostavshikBox.SelectedValue +
                " and pr= " + ProduktBox.SelectedValue;
            if (postavkiBindingSource.Count == 0)
            {
                Editbutton.Enabled = false;
                Delbutton.Enabled = false;
            }
            else
            {
                Editbutton.Enabled = true;
                Delbutton.Enabled = true;
            }
            loaded = true;
        }

        private void PostavshikBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
                postavkiBindingSource.Filter = "pc= " + PostavshikBox.SelectedValue +
                " and pr= " + ProduktBox.SelectedValue;
            if (postavkiBindingSource.Count == 0)
            {
                Editbutton.Enabled = false;
                Delbutton.Enabled = false;
            }
            else
            {
                Editbutton.Enabled = true;
                Delbutton.Enabled = true;
            }
        }

        private void ProduktBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loaded)
                postavkiBindingSource.Filter = "pc= " + PostavshikBox.SelectedValue +
                " and pr= " + ProduktBox.SelectedValue;
            if (postavkiBindingSource.Count == 0)
            {
                Editbutton.Enabled = false;
                Delbutton.Enabled = false;
            }
            else
            {
                Editbutton.Enabled = true;
                Delbutton.Enabled = true;
            }
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            PostavshikBox.Enabled = false;
            ProduktBox.Enabled = false;
            panel2.Enabled = false;
            panel3.Visible = true;
            Editpanel.Visible = true;
            is_insert = false;
            row = dataSet1.postavki.FindBypcprdata(int.Parse(PostavshikBox.SelectedValue.ToString()),
                int.Parse(ProduktBox.SelectedValue.ToString()), 
                DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
            dateTimePicker1.Value = DateTime.Parse(row[4].ToString());
            Colvotext.Text = row[2].ToString();
            Cenatext.Text = row[3].ToString();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            PostavshikBox.Enabled = true;
            ProduktBox.Enabled = true;
            panel2.Enabled = true;
            panel3.Visible = false;
            Editpanel.Visible = false;
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (Colvotext.Text.Trim() == "")
            {
                MessageBox.Show("Отсутсвует количество поставки");
                Colvotext.Focus();
                return;
            }
            if (Cenatext.Text.Trim() == "")
            {
                MessageBox.Show("Отсутсвует цена поставки");
                Cenatext.Focus();
                return;
            }
            if (is_insert)
                if (dataSet1.postavki.Select("pc= " + PostavshikBox.SelectedValue +
                " and pr= " + ProduktBox.SelectedValue
                + " and data = '" + dateTimePicker1.Value.Date.ToString() + "'").Count() > 0)
                {
                    MessageBox.Show("Такая поставка уже существует");
                    return;
                }
            if (is_insert)
            {
                row = dataSet1.postavki.NewRow();
                row[0] = PostavshikBox.SelectedValue;
                row[1] = ProduktBox.SelectedValue;
                row[2] = Colvotext.Text;
                row[3] = Cenatext.Text;
                row[4] = dateTimePicker1.Value.Date.ToString();
                dataSet1.postavki.Rows.Add(row);
            }
            else
            {
                row[2] = Colvotext.Text;
                row[3] = Cenatext.Text;
                row[4] = dateTimePicker1.Value.Date.ToString();
            }
            edited.Value = true;
            PostavshikBox.Enabled = true;
            ProduktBox.Enabled = true;
            panel2.Enabled = true;
            panel3.Visible = false;
            Editpanel.Visible = false;
            if (postavkiBindingSource.Count == 0)
            {
                Editbutton.Enabled = false;
                Delbutton.Enabled = false;
            }
            else
            {
                Editbutton.Enabled = true;
                Delbutton.Enabled = true;
            }
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dataSet1.postavki.FindBypcprdata(int.Parse(PostavshikBox.SelectedValue.ToString()),
                        int.Parse(ProduktBox.SelectedValue.ToString()),
                        DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString())).Delete();
                    edited.Value = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ViewRowbutton_Click(object sender, EventArgs e)
        {
            new PostavkiExtra(edited, dataSet1).ShowDialog();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            PostavshikBox.Enabled = false;
            ProduktBox.Enabled = false;
            panel2.Enabled = false;
            panel3.Visible = true;
            Editpanel.Visible = true;
            Colvotext.Text = "";
            Cenatext.Text = "";
            is_insert = true;
        }
    }
}
