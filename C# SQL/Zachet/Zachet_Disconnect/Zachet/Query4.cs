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
    public partial class Query4 : Form
    {
        DataSet dataSet;
        Tuple<string, int>[] tuple;
        public Query4(DataSet data)
        {
            InitializeComponent();
            dataSet = data;
        }

        private void Query4_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tuple = new Tuple<string, int>[dataSet.Janr.Rows.Count];
            int quarter = Convert.ToInt32(Math.Ceiling(DateTime.Today.Month / 3.0));
            string str;
            switch (quarter)
            {
                case 1: str = "('01','02','03')"; break;
                case 2: str = "('04','05','06')"; break;
                case 3: str = "('07','08','09')"; break;
                case 4: str = "('10','11','12')"; break;
                default:str = "-1";
                    break;
            }
            for (int i = 0; i < dataSet.Janr.Rows.Count; i++)
            {
                tuple[i] = new Tuple<string, int>(dataSet.Janr.Rows[i].ItemArray[1].ToString(),
                    dataSet.Zapis.Select("cod_janr= " + dataSet.Janr.Rows[i].ItemArray[0].ToString()
                 + " and (substring(convert(data, System.String), 4, 2)) in " + str).Count());
            }
            Tuple<string, int>[] r = tuple.Where(x => x.Item2 == tuple.Max(y => y.Item2)).ToArray();
            foreach (var item in r)
            {
                listBox1.Items.Add(item.Item1);
            }
            label2.Text += r[0].Item2.ToString();
        }
    }
}
