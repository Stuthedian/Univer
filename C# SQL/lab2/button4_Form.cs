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
    public partial class button4_Form : Form
    {
        public button4_Form()
        {
            InitializeComponent();
        }

        private void button4_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet11.postavkiYearMonth". При необходимости она может быть перемещена или удалена.
            this.postavkiYearMonthTableAdapter.Fill(this.dataSet11.postavkiYearMonth);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.MonthTable". При необходимости она может быть перемещена или удалена.
            this.monthTableTableAdapter.Fill(this.dataSet1.MonthTable);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Yeartable". При необходимости она может быть перемещена или удалена.
            this.yeartableTableAdapter.Fill(this.dataSet1.Yeartable);
            postavkiYearMonthBindingSource.Filter = "yearexpr=" + yearBox.SelectedValue + " and " +
            " monthexpr='" + monthBox.SelectedValue + "'";
        }

        private void yearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            postavkiYearMonthBindingSource.Filter = "yearexpr=" + yearBox.SelectedValue + " and " +
           " monthexpr='" + monthBox.SelectedValue + "'";
        }

        private void monthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            postavkiYearMonthBindingSource.Filter = "yearexpr=" + yearBox.SelectedValue + " and " +
           " monthexpr='" + monthBox.SelectedValue + "'";
        }
    }
}
