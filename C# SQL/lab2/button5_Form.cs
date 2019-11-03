using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Pansionat
{
    public partial class button5_Form : Form
    {
        public button5_Form()
        {
            InitializeComponent();
        }

        private void button5_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.PostavshikAll". При необходимости она может быть перемещена или удалена.
            this.postavshikAllTableAdapter.Fill(this.dataSet1.PostavshikAll);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.PostavshikAny". При необходимости она может быть перемещена или удалена.
            this.postavshikAnyTableAdapter.Fill(this.dataSet1.PostavshikAny);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.bluda". При необходимости она может быть перемещена или удалена.
            this.bludaTableAdapter.Fill(this.dataSet1.bluda);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
