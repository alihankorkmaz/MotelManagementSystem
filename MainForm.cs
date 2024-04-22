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
            adminLoginPanel adminpanel = new adminLoginPanel();
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

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Korkmaz Motel Managament /2024 - Poznan by Alihan");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RoomsForm roomsform = new RoomsForm();
            roomsform.Show();
        }
    }
}
