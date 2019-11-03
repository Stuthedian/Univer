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
    public partial class SotrudnikEdit : Form
    {
        bool is_insert;
        string Famoriginal;
        string Imoriginal;
        string Otchoriginal;
        DateTime Droriginal;
        char Poloriginal;
        DataSet dataSet;
        BindingSource bindingSource;
        Ed edited;
        public SotrudnikEdit(bool v, DataSet dataSet, Ed ed)
        {
            InitializeComponent();
            is_insert = v;
            FamBox.Text = ImBox.Text = OtchBox.Text = "";
            this.dataSet = dataSet;
            comboBox1.SelectedIndex = 0;
            edited = ed;
        }

        public SotrudnikEdit(bool v, BindingSource bindingSource, DataSet dataSet, Ed ed)
        {
            InitializeComponent();
            is_insert = v;
            this.dataSet = dataSet;
            this.bindingSource = bindingSource;
            Famoriginal = FamBox.Text = ((DataRowView)bindingSource.Current)[1].ToString();
            Imoriginal = ImBox.Text = ((DataRowView)bindingSource.Current)[2].ToString();
            Otchoriginal = OtchBox.Text = ((DataRowView)bindingSource.Current)[3].ToString();
            Droriginal = dateTimePicker1.Value = DateTime.Parse(((DataRowView)bindingSource.Current)[4].ToString());
            char p = Poloriginal = ((DataRowView)bindingSource.Current)[5].ToString()[0];
            comboBox1.SelectedIndex = (p == 'м'?0:1);
            edited = ed;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            DataRow row;
            if(FamBox.Text.Trim() == "")
            {
                MessageBox.Show("Не введена фамилия сотрудника");
                return;
            }
            if (ImBox.Text.Trim() == "")
            {
                MessageBox.Show("Не введено имя сотрудника");
                return;
            }
            if (is_insert || 
                (Famoriginal != FamBox.Text || Imoriginal != ImBox.Text
                    || Otchoriginal != OtchBox.Text || Droriginal != dateTimePicker1.Value
                    || comboBox1.SelectedItem.ToString()[0] != Poloriginal))
                if (dataSet.Sotrudnik.Select("fam='" + FamBox.Text.Trim() + "' and im='" 
                    + ImBox.Text.Trim() + "' and otch='" + OtchBox.Text.Trim() + "' and " +
                    "dr='" + dateTimePicker1.Value.Date.ToString() + "' and " +
                    "pol='" + comboBox1.SelectedItem.ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Сотрудник с такими данными уже существует");
                    return;
                }
            if (is_insert)
            {
                row = dataSet.Sotrudnik.NewRow();
                row[1] = FamBox.Text.Trim();
                row[2] = ImBox.Text.Trim();
                row[3] = OtchBox.Text.Trim();
                row[4] = dateTimePicker1.Value.ToShortDateString();
                row[5] = (comboBox1.SelectedIndex == 0 ? 'м' : 'ж');
                dataSet.Sotrudnik.Rows.Add(row);   
            }
            else
            {
                row = dataSet.Sotrudnik.Rows.Find(((DataRowView)bindingSource.Current)[0]);
                row[1] = FamBox.Text.Trim();
                row[2] = ImBox.Text.Trim();
                row[3] = OtchBox.Text.Trim();
                row[4] = dateTimePicker1.Value.ToShortDateString();
                row[5] = (comboBox1.SelectedIndex == 0 ? 'м' : 'ж');
            }
            edited.Value = true;
            Close();
        }

        private void SotrudnikEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
