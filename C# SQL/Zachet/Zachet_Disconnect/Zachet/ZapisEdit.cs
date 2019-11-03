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
    public partial class ZapisEdit : Form
    {
        bool is_insert;
        int[] keys;
        string origstr;
        DateTime origDate;
        DataSet dataSet;
        BindingSource bindingSource;
        Ed edited;
        public ZapisEdit(bool v, BindingSource bindingSource, DataSet dataSet, int[] k, Ed ed)
        {
            InitializeComponent();
            is_insert = v;
            this.dataSet = dataSet;
            this.bindingSource = bindingSource;
            keys = k;
            if(is_insert)
            {
                textBox1.Text = ""; 
            }
            else
            {
                textBox1.Text = origstr = ((DataRowView)bindingSource.Current)["naim_zapis"].ToString();
                dateTimePicker1.Value = origDate = DateTime.Parse(((DataRowView)bindingSource.Current)["data"].ToString());
            }
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
                MessageBox.Show("Не введено наименование записи");
                return;
            }
            if(is_insert || (origDate != dateTimePicker1.Value || keys[0] != int.Parse(Ispcombo.SelectedValue.ToString()) 
                || keys[1] != int.Parse(Janrcombo.SelectedValue.ToString()) 
                || keys[2] != int.Parse(Sotrcombo.SelectedValue.ToString()) || textBox1.Text.Trim() != origstr))
                if(dataSet.Zapis.Select("cod_isp=" + Ispcombo.SelectedValue + " and cod_janr=" +
                    Janrcombo.SelectedValue + " and cod_sotr=" + Sotrcombo.SelectedValue 
                    + " and data='" + dateTimePicker1.Value.Date.ToString() + "'"
                    + " and naim_zapis='" + textBox1.Text.Trim() + "'").Count() != 0)
                {
                    MessageBox.Show("Такая запись уже присутствует");
                    return;
                }
            if (is_insert)
            {
                row = dataSet.Zapis.NewRow();
                row[1] = textBox1.Text.Trim();
                row[2] = dateTimePicker1.Value.ToShortDateString();
                row[3] = Ispcombo.SelectedValue;
                row[4] = Janrcombo.SelectedValue;
                row[5] = Sotrcombo.SelectedValue;
                dataSet.Zapis.Rows.Add(row);   
            }
            else
            {
                row = dataSet.Zapis.FindBycod_zap(keys[3]);
                row[1] = textBox1.Text.Trim();
                row[2] = dateTimePicker1.Value.ToShortDateString();
                row[3] = Ispcombo.SelectedValue;
                row[4] = Janrcombo.SelectedValue;
                row[5] = Sotrcombo.SelectedValue;
            }
            edited.Value = true;
            Close();
        }

        private void ZapisEdit_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ispolnitelBindingSource.DataSource = dataSet;
            janrBindingSource.DataSource = dataSet;
            sotrudnikBindingSource.DataSource = dataSet;
            if(is_insert)
            {
                Ispcombo.SelectedIndex = 0;
                Janrcombo.SelectedIndex = 0;
                Sotrcombo.SelectedIndex = 0;
            }
            else
            {
                Ispcombo.SelectedValue = keys[0];
                Janrcombo.SelectedValue = keys[1];
                Sotrcombo.SelectedValue = keys[2];
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
