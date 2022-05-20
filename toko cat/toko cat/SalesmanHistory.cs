using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class SalesmanHistory : Form
    {
        public SalesmanHistory()
        {
            InitializeComponent();
        }

        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesmanCatalog cata = new SalesmanCatalog();

            cata.StartPosition = FormStartPosition.CenterScreen;

            cata.ShowDialog();
            cata.Dispose();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesmanOrder order = new SalesmanOrder();

            order.StartPosition = FormStartPosition.CenterScreen;

            order.ShowDialog();
            order.Dispose();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SalesmanHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
