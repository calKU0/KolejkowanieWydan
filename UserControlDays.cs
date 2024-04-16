using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly string ConnectionString;
        private string fullDate;
        public UserControlDays(string connectionString)
        {
            InitializeComponent();
            this.ConnectionString = connectionString;
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
            List<Wydanie> foundWydania = Form1.wydania
                                        .Where(w => w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}")
                                        .Distinct()
                                        .ToList();

            if (foundWydania.Count() == 0)
            {
                return;
            }

            staticDay = daysLabel.Text;

            EventsForm eventForm = new EventsForm(foundWydania);
            eventForm.Show();
        }

        private void DisplayEvent()
        {
            int countForDate = Form1.wydania
                .Count(w => w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}");
            eventLabel.Text = $"Liczba wydań: {countForDate}";

            decimal sumWage = Form1.wydania
                .Where(w => w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}")
                .Sum(w => w.Wage);
            wageLabel.Text = $"Waga: {sumWage} kg";
        }

        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
