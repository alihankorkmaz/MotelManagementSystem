using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        NpgsqlConnection connect = new NpgsqlConnection("Server=localhost; Port=5432; Database=motelkorkmaz; User Id=postgres; Password=ali4161;");

        private void showdata()
        {
            connect.Open();
            listView1.Items.Clear();
            string query = "select * from addcustomers";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            NpgsqlDataReader read = cmd.ExecuteReader();

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
            connect.Close();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata();
        }
        int id = 0;

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textName.Text= listView1.SelectedItems[0].SubItems[1].Text;
            textSurname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBoxGender.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textPhonenumber.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textIdnumber.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textRoomNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textCharge.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textEnterDate.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textLeaveDate.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("delete from addcustomers where no= (" + id + ")", connect);
            command.ExecuteNonQuery();
            connect.Close();
            showdata();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command = new NpgsqlCommand("update addcustomers set name ='"+textName.Text+"',surname ='"+textSurname.Text+"',gender = '"+comboBoxGender.Text+"',phone_no ='"+textPhonenumber.Text+"',mail='"+textMail.Text+"',id='"+textIdnumber.Text+"',room_no='"+textRoomNo.Text+"',charge='"+textCharge.Text+"',enter_date='"+textEnterDate.Value.ToString("yyyy-MM-dd")+"',leave_Date='"+ textLeaveDate.Value.ToString("yyyy-MM-dd") + "' where no= "+id+"", connect);
            command.ExecuteNonQuery();
            connect.Close();
            showdata();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            connect.Open();
            listView1.Items.Clear();
            string query = "select * from addcustomers where name ilike '%"+textBox1.Text+"%'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            NpgsqlDataReader read = cmd.ExecuteReader();

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
            connect.Close();
        }
    }
}
