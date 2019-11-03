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
    public partial class button2_Form : Form
    {
        public button2_Form()
        {
            InitializeComponent();
        }

        private void button2_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable2". При необходимости она может быть перемещена или удалена.
            this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.produkt". При необходимости она может быть перемещена или удалена.
            this.produktTableAdapter.Fill(this.dataSet1.produkt);

        }
    }
}
