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
    public partial class ReportHR : Form
    {
        public ReportHR()
        {
            InitializeComponent();
        }

        private void ReportHR_Load(object sender, EventArgs e)
        {
            EmployeeReport report = new EmployeeReport();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
