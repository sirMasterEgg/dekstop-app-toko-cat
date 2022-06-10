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
    public partial class FormInvoiceAdmin : Form
    {
        String invoice;
        public FormInvoiceAdmin(string invoice)
        {
            InitializeComponent();
            this.invoice = invoice;
        }

        private void FormInvoiceAdmin_Load(object sender, EventArgs e)
        {
            Invoice rpt = new Invoice();
            rpt.SetParameterValue("invoice", invoice);

            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
