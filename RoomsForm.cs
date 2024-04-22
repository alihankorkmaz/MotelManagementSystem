using Npgsql;
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
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("Server=localhost; Port=5432; Database=motelkorkmaz; User Id=postgres; Password=ali4161;");
        private void button101_Click(object sender, EventArgs e)
        {

        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            connect.Open();

            // Room numaralarını ve ilgili butonları bir dizi içinde tanımlayın
            string[] roomNumbers = { "101", "102", "103", "104", "201", "202", "203", "204", "301", "302", "303", "304"};
            Button[] buttons = { button101, button102, button103, button104, button201, button202, button203, button204, button301, button302, button303, button304 };

            // Her bir oda numarası için işlem yapın
            for (int i = 0; i < roomNumbers.Length; i++)
            {
                string roomNumber = roomNumbers[i];
                Button button = buttons[i];

                NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM addcustomers WHERE room_no = '{roomNumber}'", connect);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                // Eğer veri bulunursa, ilgili butonun metin özelliğini ve arka plan rengini ayarlayın
                if (reader.Read())
                {
                    button.Text = $"{reader["name"]} {reader["surname"]}";
                    button.BackColor = Color.Red;
                    //button.BackColor = (button.Text == roomNumber) ? Color.White : Color.Red; 
                }
                else
                {
                   
                }

                reader.Close(); 
            }

            connect.Close(); 
        }

    }
}
