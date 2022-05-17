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
    public partial class InventoryDelivery : Form
    {
        public InventoryDelivery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryStatus form = new DeliveryStatus();
            form.ShowDialog();
            form.Dispose();
            this.Show();
        }
    }
}
