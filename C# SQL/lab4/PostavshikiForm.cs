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
    public partial class PostavshikiForm : Form
    {
        DataRow row;
        DataSet1 dataSet1;
        BindingSource postavshikiBindingSource = new BindingSource();
        string oldName;
        bool is_insert;
        Ed edited;
        public PostavshikiForm(Ed edited, DataSet1 dataSet1)
        {
            InitializeComponent();
            this.dataSet1 = dataSet1;
            this.edited = edited;
        }

        private void PostavshikiForm_Load(object sender, EventArgs e)
        {
            postavshikiBindingSource.DataSource = dataSet1;
            postavshikiBindingSource.DataMember = "postavshiki";
            
            Nametext.DataBindings.Add("Text", postavshikiBindingSource, "nazvanie", false, DataSourceUpdateMode.Never);
            Gorodtext.DataBindings.Add("Text", postavshikiBindingSource, "gorod", false, DataSourceUpdateMode.Never);
            Statustext.DataBindings.Add("Text", postavshikiBindingSource, "status", false, DataSourceUpdateMode.Never);
            Teltext.DataBindings.Add("Text", postavshikiBindingSource, "tel", false, DataSourceUpdateMode.Never);
            Adrestext.DataBindings.Add("Text", postavshikiBindingSource, "adres", false, DataSourceUpdateMode.Never);
            Nametext.ReadOnly = Gorodtext.ReadOnly 
                = Statustext.ReadOnly = Teltext.ReadOnly = Adrestext.ReadOnly = true;
            panel3.Visible = false;
            buttons();
            if(postavshikiBindingSource.Count == 0)
            {
                Editbutton.Enabled = false;
                Delbutton.Enabled = false; 
            }
        }

        private void buttons()
        {
            Nextbutton.Enabled = true;
            Prevbutton.Enabled = true;
            Firstbutton.Enabled = true;
            Lastbutton.Enabled = true;
            if (postavshikiBindingSource.Position == 0)
            {
                Firstbutton.Enabled = false;
                Prevbutton.Enabled = false;
            }
            if (postavshikiBindingSource.Position == postavshikiBindingSource.Count - 1)
            {
                Lastbutton.Enabled = false;
                Nextbutton.Enabled = false;
            }
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            postavshikiBindingSource.MoveNext();
            buttons();
        }

        private void Prevbutton_Click(object sender, EventArgs e)
        {
            postavshikiBindingSource.MovePrevious();
            buttons();
        }

        private void Firstbutton_Click(object sender, EventArgs e)
        {
            postavshikiBindingSource.MoveFirst();
            buttons();
        }

        private void Lastbutton_Click(object sender, EventArgs e)
        {
            postavshikiBindingSource.MoveLast();
            buttons();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Visible = true;
            Nametext.ReadOnly = Gorodtext.ReadOnly
                = Statustext.ReadOnly = Teltext.ReadOnly = Adrestext.ReadOnly = false;
            Nametext.Text = Gorodtext.Text
                = Statustext.Text = Teltext.Text = Adrestext.Text = "";
            Nametext.Focus();
            is_insert = true;
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Visible = true;
            Nametext.ReadOnly = Gorodtext.ReadOnly
                = Statustext.ReadOnly = Teltext.ReadOnly = Adrestext.ReadOnly = false;
            is_insert = false;
            oldName = Nametext.Text;
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            #region
            if (Nametext.Text.Trim() == "")
            {
                MessageBox.Show("Введите название поставщика");
                Nametext.Focus();
                return;
            }
            if (is_insert || !is_insert && oldName != Nametext.Text)
                if (dataSet1.postavshiki.Select("nazvanie='" + Nametext.Text + "'").Count() > 0)
                {
                    MessageBox.Show("Такое поставщик уже существует");
                    Nametext.Focus();
                    return;
                }
            if (Gorodtext.Text.Trim() == "")
            {
                MessageBox.Show("Введите город поставщика");
                Gorodtext.Focus();
                return;
            }
            if (Statustext.Text.Trim() == "")
            {
                MessageBox.Show("Введите статус поставщика");
                Statustext.Focus();
                return;
            }
            if (Adrestext.Text.Trim() == "")
            {
                MessageBox.Show("Введите адрес поставщика");
                Adrestext.Focus();
                return;
            }
            if (Teltext.Text.Trim() == "")
            {
                MessageBox.Show("Введите телефон поставщика");
                Teltext.Focus();
                return;
            }
            #endregion
            if(is_insert)
            {
                row = dataSet1.postavshiki.NewRow();
                //MessageBox.Show(row[0].ToString());
                row[1] = Nametext.Text;
                row[2] = Statustext.Text;
                row[3] = Gorodtext.Text;
                row[4] = Adrestext.Text;
                row[5] = Teltext.Text;
                dataSet1.postavshiki.Rows.Add(row);
            }
            else
            {
                String[] vs = { Nametext.Text, Statustext.Text, Gorodtext.Text, Adrestext.Text, Teltext.Text };
                row = dataSet1.postavshiki.Rows.Find(((DataRowView)postavshikiBindingSource.Current)[0]);
                for (int i = 0; i < vs.Length; i++)
                {
                    row[i + 1] = vs[i];
                }
            }
            edited.Value = true;
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Visible = false;
            Nametext.ReadOnly = Gorodtext.ReadOnly
                = Statustext.ReadOnly = Teltext.ReadOnly = Adrestext.ReadOnly = true;
            if(is_insert) 
                postavshikiBindingSource.MoveLast();
            buttons();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Visible = false;
            Nametext.ReadOnly = Gorodtext.ReadOnly
                = Statustext.ReadOnly = Teltext.ReadOnly = Adrestext.ReadOnly = true;
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow temprow = dataSet1.postavshiki.Rows.Find(((DataRowView)postavshikiBindingSource.Current)[0]);
                if (dataSet1.postavki.Select("pc='"+temprow[0].ToString()+"'").Count()!=0)
                {
                    MessageBox.Show("Удаление не возможно. Поставщик есть в поставках.");
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

        private void ViewRowbutton_Click(object sender, EventArgs e)
        {
            new PostavshikiExtra(edited, dataSet1).ShowDialog();
        }
    }
}
