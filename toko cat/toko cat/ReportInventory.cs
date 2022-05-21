using System;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class ReportInventory : Form
    {
        public ReportInventory()
        {
            InitializeComponent();
        }

        private void ReportInventory_Load(object sender, EventArgs e)
        {
            InventoryReport report = new InventoryReport();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
