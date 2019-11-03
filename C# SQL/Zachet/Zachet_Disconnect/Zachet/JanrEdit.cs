using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zachet
{
    public partial class JanrEdit : Form
    {
        bool is_insert;
        string originalName;
        DataSet dataSet;
        BindingSource bindingSource;
        Ed edited;
        public JanrEdit(bool v, DataSet dataSet, Ed ed)
        {
            InitializeComponent();
            is_insert = v;
            textBox1.Text = "";
            this.dataSet = dataSet;
            edited = ed;
        }

        public JanrEdit(bool v, BindingSource bindingSource, DataSet dataSet, Ed ed)
        {
            InitializeComponent();
            is_insert = v;
            this.dataSet = dataSet;
            this.bindingSource = bindingSource;
            textBox1.Text = originalName = ((DataRowView)bindingSource.Current)[1].ToString();
            edited = ed;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            DataRow row;
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Не введено наименование жанра");
                return;
            }
            if (is_insert || (!is_insert && originalName != textBox1.Text))
                if (dataSet.Janr.Select("naim='" + textBox1.Text.Trim() + "'").Count() != 0)
                {
                    MessageBox.Show("Жанр с таким наименованием уже присутствует");
                    return;
                }
            if(is_insert)
            {
                row = dataSet.Janr.NewRow();
                row[1] = textBox1.Text.Trim();
                dataSet.Janr.Rows.Add(row);   
            }
            else
            {
                row = dataSet.Janr.Rows.Find(((DataRowView)bindingSource.Current)[0]);
                row[1] = textBox1.Text.Trim();
            }
            edited.Value = true;
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                Savebutton_Click(sender, e);
        }

        private void JanrEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
