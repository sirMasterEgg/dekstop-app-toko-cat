﻿using System;
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
