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
    public partial class Query1 : Form
    {
        public Query1(DataSet data)
        {
            InitializeComponent();
            dataSet = data;
        }

        private void Query1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ispolnitelBindingSource.DataSource = dataSet;
            fKZapiscodisp5070F446BindingSource.DataSource = ispolnitelBindingSource;
        }
    }
}
