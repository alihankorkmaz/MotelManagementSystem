using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Motel_Management_system
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=motelkorkmaz; User Id=postgres; Password=ali4161;");

        private void showdata()
        {
            baglanti.Open();
            listView1.Items.Clear();
            string query = "select * from addcustomers";
            NpgsqlCommand komut = new NpgsqlCommand(query, baglanti);
            NpgsqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["no"].ToString();
                add.SubItems.Add(read["name"].ToString());
                add.SubItems.Add(read["surname"].ToString());
                add.SubItems.Add(read["gender"].ToString());
                add.SubItems.Add(read["phone_no"].ToString());
                add.SubItems.Add(read["mail"].ToString());
                add.SubItems.Add(read["id"].ToString());
                add.SubItems.Add(read["room_no"].ToString());
                add.SubItems.Add(read["charge"].ToString());
                add.SubItems.Add(read["enter_date"].ToString());
                add.SubItems.Add(read["leave_date"].ToString());

                listView1.Items.Add(add);
            }

            read.Close();
            baglanti.Close();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata();
        }

  
    }
}
