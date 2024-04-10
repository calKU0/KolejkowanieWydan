using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolejkowanieWydan
{
    public partial class AddEventForm : Form
    {
        private readonly string connectionString;
        public AddEventForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            DateTextBox.Text = $"{Form1.staticYear}-{Form1.staticMonth}-{UserControlDays.staticDay}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO dbo.KolejkaWydan (Kw_Data, Kw_Akronim, Kw_Waga, Kw_Uwagi) VALUES (@date, @acronym, @wage, @fvNumber)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@date", DateTextBox.Text); ;
                command.Parameters.AddWithValue("@acronym", AcronymTextBox.Text);
                command.Parameters.AddWithValue("@wage", Convert.ToDecimal(WageTextBox.Text));
                command.Parameters.AddWithValue("@fvNumber", fvNumberextBox.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Zapisano");
                command.Dispose();
            }
        }
    }
}
