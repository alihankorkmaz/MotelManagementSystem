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
    public partial class add_new_customers : Form
    {
        public add_new_customers()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; database=motelkorkmaz; user Id=postgres; password=ali4161");
        private void button101_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "101";
        }

        private void button102_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "102";
        }

        private void button103_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "103";
        }

        private void button104_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "104";
        }

        private void button201_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "201";
        }

        private void button202_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "202";
        }

        private void button203_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "203";
        }

        private void button204_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "204";
        }

        private void button301_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "301";
        }

        private void butto302_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "302";
        }


        private void button304_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "304";
        }

        private void button_303_Click(object sender, EventArgs e)
        {
            textRoomNo.Text = "303";
        }

        private void buttonOccupied_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Red button shows occupied rooms");
        }

        private void buttonAvailable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("green buttons shows occupied rooms");
        }

        private void textLeaveDate_ValueChanged(object sender, EventArgs e)
        {
            int charge;
            DateTime firstDate = Convert.ToDateTime(textEnterDate.Text);
            DateTime lastDate = Convert.ToDateTime(textLeaveDate.Text);

            TimeSpan result = lastDate - firstDate;
            textCharge.Text = result.TotalDays.ToString();

            charge = Convert.ToInt32(textCharge.Text) * 100;
            textCharge.Text = Convert.ToString(charge);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; database=motelkorkmaz; user Id=postgres; password=ali4161"))
            {
                try
                {
                    baglanti.Open();
                    string query = "INSERT INTO addcustomers ( name, surname, gender, phone_no, mail, id, room_no, charge, enter_date, leave_date) VALUES ( @Name, @Surname, @Gender, @Phone_no, @Mail, @Id, @Room_no, @Charge, @Enter_date, @Leave_date)";
                    using (NpgsqlCommand komut = new NpgsqlCommand(query, baglanti))
                    {
                        
                        komut.Parameters.AddWithValue("@Name", textName.Text);
                        komut.Parameters.AddWithValue("@Surname", textSurname.Text);
                        komut.Parameters.AddWithValue("@Gender", textSurname.Text);
                        komut.Parameters.AddWithValue("@Phone_no", textPhonenumber.Text);
                        komut.Parameters.AddWithValue("@Mail", textMail.Text);
                        komut.Parameters.AddWithValue("@Id", textIdnumber.Text);
                        komut.Parameters.AddWithValue("@Room_no", textRoomNo.Text);
                        komut.Parameters.AddWithValue("@Charge", Convert.ToInt32(textCharge.Text));
                        komut.Parameters.AddWithValue("@Enter_date",Convert.ToDateTime(textEnterDate.Text));
                        komut.Parameters.AddWithValue("@Leave_date", Convert.ToDateTime(textLeaveDate.Text));
                        
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Added new customer!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    } 
}
