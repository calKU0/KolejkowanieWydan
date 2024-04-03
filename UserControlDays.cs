using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolejkowanieWydan
{
    public partial class UserControlDays : UserControl
    {
        public static string staticDay;
        private readonly string connectionString;
        private string fullDate;
        public UserControlDays(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void UserControlDay_Load(object sender, EventArgs e)
        {
            DisplayEvent();
        }

        public void Days(int numday)
        {

            daysLabel.Text = numday.ToString("D2") + "";

            fullDate = $"{Form1.staticYear}/{Form1.staticMonth}/{daysLabel.Text}";

            DateTime day = DateTime.ParseExact(fullDate, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            if (day.DayOfWeek.ToString() == "Sunday")
            {
                daysLabel.ForeColor = Color.Red;
            }
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            staticDay = daysLabel.Text;
            timer1.Start();
            EventForm eventForm = new EventForm(connectionString);
            eventForm.Show();
        }

        private void DisplayEvent()
        {
            WydaniaCount foundWydania = Form1.wydaniaCounts.FirstOrDefault(w => w.date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear} 00:00:00");

            if (foundWydania != null)
            {
                eventLabel.Text = $"Liczba wydań: {foundWydania.count}";
            }
            else
            {
                eventLabel.Text = "Liczba wydań: 0";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayEvent();
        }
    }
}
