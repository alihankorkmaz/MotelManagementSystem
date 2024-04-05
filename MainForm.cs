using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motel_Management_system
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 adminpanel = new Form1();
            adminpanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_new_customers new_Customers = new add_new_customers();
            new_Customers.Show();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
        }
    }
}
