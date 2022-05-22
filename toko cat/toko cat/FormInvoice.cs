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
        }
    }
}
