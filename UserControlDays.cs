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
        private string fullDate;
        private Color borderColor = Color.Red;
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh();
            }
        }
        public UserControlDays()
        {
            InitializeComponent();
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
            else if (day.DayOfWeek.ToString() == "Saturday")
            {
                daysLabel.ForeColor = Color.DimGray;
            }
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            List<Wydanie> foundWydania = new List<Wydanie>();
            if (Form1.ope.CanSeeDelivery)
            {
                foundWydania = Form1.wydania
                    .Where(w =>
                        w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}" &&
                        (
                            (Form1.hideRealizedChecked && w.Status != "zrealizowane" && w.Status != "zrealizowane z brakami") ||
                            !Form1.hideRealizedChecked
                        )
                    )
                    .Distinct()
                    .ToList();
            }
            else
            {
                foundWydania = Form1.wydania
                    .Where(w =>
                        w.Type == "Wydanie" && w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}" &&
                        (
                            (Form1.hideRealizedChecked && w.Status != "zrealizowane" && w.Status != "zrealizowane z brakami") ||
                            !Form1.hideRealizedChecked
                        )
                    )
                    .Distinct()
                    .ToList();
            }

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
            decimal sumWageWydania = Form1.wydania
                .Where(w => w.Type == "Wydanie" && w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}"
                &&
                        (
                            (Form1.hideRealizedChecked && w.Status != "zrealizowane" && w.Status != "zrealizowane z brakami") ||
                            !Form1.hideRealizedChecked
                        ))
                .Sum(w => w.Wage);

            decimal sumWageDeliveries = Form1.wydania
                .Where(w => w.Type == "Dostawa" && w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}")
                .Sum(w => w.Wage);

            int countWydania = Form1.wydania
                .Count(w => w.Type == "Wydanie" && w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}" &&
                        (
                            (Form1.hideRealizedChecked && w.Status != "zrealizowane" && w.Status != "zrealizowane z brakami") ||
                            !Form1.hideRealizedChecked
                        ));

            if (Form1.ope.CanSeeDelivery)
            {
                int countDeliveries = Form1.wydania
                .Count(w => w.Type == "Dostawa" && w.Date == $"{daysLabel.Text}.{Form1.staticMonth}.{Form1.staticYear}");
                
                eventLabel.Text = $"Wydania: {countWydania}";
                opionalLabel.Text = $"Dostawy: {countDeliveries}";
                wageWydaniaLabel.Text = $"({sumWageWydania} kg)";
                wageDeliveriesLabel.Text = $"({sumWageDeliveries} kg)";
            }
            else
            {
                eventLabel.Text = $"Liczba wydań: {countWydania}";
                opionalLabel.Text = $"Waga: {sumWageWydania} kg";
            }
        }

        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DateTime day = DateTime.ParseExact(fullDate, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            if (day == DateTime.Now.Date)
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, 2, ButtonBorderStyle.Dashed, borderColor, 2, ButtonBorderStyle.Dashed, borderColor, 2, ButtonBorderStyle.Dashed, borderColor, 2, ButtonBorderStyle.Dashed);
            }
        }
    }
}
