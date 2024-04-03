using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class Form1 : Form
    {
        int month, year;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["GaskaConnectionString"].ConnectionString;
        public static string staticMonth, staticYear;
        public static List<WydaniaCount> wydaniaCounts = new List<WydaniaCount>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            CountWydania(month);
            DisplayDays(month);
        }

        private void DisplayDays(int month)
        {
            daycontainer.Controls.Clear();

            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            dateLabel.Text = $"{monthName} {year}";

            staticMonth = month.ToString("D2");
            staticYear = year.ToString();

            DateTime startOfTheMonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                daycontainer.Controls.Add(ucBlank);
            }

            for (int i = 1; i < days; i++)
            {
                UserControlDays ucDays = new UserControlDays(connectionString);
                ucDays.Days(i);
                daycontainer.Controls.Add(ucDays);
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            DisplayDays(month--);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            DisplayDays(month++);
        }

        private void CountWydania(int month)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"Select 
                count(*) as count
                ,convert(date,Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) as date
                from cdn.Atrybuty
				join cdn.TraNag on Atr_ObiNumer = TrN_GIDNumer and Atr_ObiTyp = TrN_GIDTyp
                where Atr_AtkId = 375
				and TrN_Waga > 900
				and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
                group by Atr_Wartosc";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wydaniaCounts.Add(new WydaniaCount(
                        (int)reader["count"]
                        , reader["date"].ToString()
                        ));
                }
                reader.Dispose();
                cmd.Dispose();
            }
        }
    }
}
