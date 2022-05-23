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
    public partial class SupervisorReportForm : Form
    {
        public SupervisorReportForm()
        {
            InitializeComponent();
        }

        private void SupervisorReportForm_Load(object sender, EventArgs e)
        {
            SupervisorReport report = new SupervisorReport();

            crystalReportViewer1.ReportSource = report;
        }
    }
}
