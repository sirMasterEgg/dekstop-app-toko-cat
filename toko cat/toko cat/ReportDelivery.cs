using System;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class ReportDelivery : Form
    {
        public ReportDelivery()
        {
            InitializeComponent();
        }

        private void ReportDelivery_Load(object sender, EventArgs e)
        {
            DeliveryReport report = new DeliveryReport();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
