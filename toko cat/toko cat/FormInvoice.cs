using System;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class FormInvoice : Form
    {
        String invoice;
        public FormInvoice(String Invoice)
        {
            InitializeComponent();
            this.invoice = Invoice;
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            Invoice rpt = new Invoice();
            rpt.SetParameterValue("invoice", invoice);

            crystalReportViewer1.ReportSource = rpt;

            crystalReportViewer1.ShowPrintButton = false;
            crystalReportViewer1.ShowExportButton = false;
            crystalReportViewer1.ShowRefreshButton = false;
        }
    }
}
