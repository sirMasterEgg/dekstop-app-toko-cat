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
    public partial class SupervisorScheduleReportForm : Form
    {
        public SupervisorScheduleReportForm()
        {
            InitializeComponent();
        }

        private void SupervisorScheduleReportForm_Load(object sender, EventArgs e)
        {
            ScheduleReport rpt = new ScheduleReport();

            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
