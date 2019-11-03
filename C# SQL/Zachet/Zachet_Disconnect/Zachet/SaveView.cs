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
    public partial class SaveView : Form
    {
        DataSet dataSet;
        IspolnitelView IspolnitelView = null;
        JanrView JanrView = null;
        SotrudnikView SotrudnikView = null;
        ZapisView ZapisView = null;
        private void SaveView_Load(object sender, EventArgs e)
        {
            
            if(dataSet.Ispolnitel.HasErrors)
                исполнительToolStripMenuItem_Click(sender, e);
            if (dataSet.Janr.HasErrors)
                жанрToolStripMenuItem_Click(sender, e);
            if (dataSet.Sotrudnik.HasErrors)
                сотрудникToolStripMenuItem_Click(sender, e);
            if (dataSet.Zapis.HasErrors)
                записьToolStripMenuItem_Click(sender, e);
        }

        public SaveView(DataSet ds)
        {
            InitializeComponent();
            dataSet = ds;
        }

        private void исполнительToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IspolnitelView == null)
            {
                IspolnitelView = new IspolnitelView(this, dataSet, true);
                IspolnitelView.MdiParent = this;
                IspolnitelView.Show();
            }
            else
            {
                //IspolnitelView.Focus();
            }
        }

        private void жанрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (JanrView == null)
            {
                JanrView = new JanrView(this, dataSet, true);
                JanrView.MdiParent = this;
                JanrView.Show();
            }
            else
            {
                //JanrView.Focus();
            }
        }

        private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SotrudnikView == null)
            {
                SotrudnikView = new SotrudnikView(this, dataSet, true);
                SotrudnikView.MdiParent = this;
                SotrudnikView.Show();
            }
            else
            {
                //SotrudnikView.Focus();
            }
        }

        private void записьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ZapisView == null)
            {
                ZapisView = new ZapisView(this, dataSet, true);
                ZapisView.MdiParent = this;
                ZapisView.Show();
            }
            else
            {
                //ZapisView.Focus();
            }
        }

        public void null_child(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Ispolnitel:
                    IspolnitelView = null;
                    break;
                case ViewType.Janr:
                    JanrView = null;
                    break;
                case ViewType.Sotrudnik:
                    SotrudnikView = null;
                    break;
                default:
                    ZapisView = null;
                    break;
            }
        }
    }

    public enum ViewType
    {
        Ispolnitel, Janr, Sotrudnik, Zapis
    };
}
