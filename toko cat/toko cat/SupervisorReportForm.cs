using System;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class SupervisorReportForm : Form
    {
        public SupervisorReportForm()
        {
            InitializeComponent();
        }

        private void SupervisorReportForm_Load(object sender, EventArgs e)
        {
            SupervisorRpt report = new SupervisorRpt();

            crystalReportViewer1.ReportSource = report;
        }
    }
}
