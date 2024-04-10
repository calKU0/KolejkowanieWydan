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
        public static List<Wydanie> wydania = new List<Wydanie>();
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
            month--;
            CountWydania(month);
            DisplayDays(month);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            month++;
            CountWydania(month);
            DisplayDays(month);
        }

        private void CountWydania(int month)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"SELECT STUFF((select ',' + TrN_DokumentObcy
FROM cdn.Atrybuty USA
JOIN cdn.TraNag US ON Atr_ObiNumer = TrN_GIDNumer AND Atr_ObiTyp = TrN_GIDTyp
JOIN cdn.KntKarty USAA ON TrN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = TrN_KntTyp
WHERE Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
and USAA.Knt_Akronim = SSSA.Knt_Akronim
and USA.Atr_Wartosc = SSA.Atr_Wartosc
FOR XML PATH ('')), 1, 1, '') AS [Numer],
sum(TrN_Waga) as [Waga],
Knt_Akronim AS [Akronim],
CONVERT(date, DATEADD(DAY, CONVERT(int, Atr_Wartosc), '18001228')) AS [Date]
FROM cdn.Atrybuty SSA
JOIN cdn.TraNag SS ON Atr_ObiNumer = TrN_GIDNumer AND Atr_ObiTyp = TrN_GIDTyp
JOIN cdn.KntKarty SSSA ON TrN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = TrN_KntTyp
WHERE Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
group by Knt_Akronim, Atr_Wartosc
having sum(TrN_Waga) > 900";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wydania.Add(new Wydanie(
                         reader["Numer"].ToString()
                        ,Convert.ToDecimal(reader["Waga"].ToString())
                        , reader["Akronim"].ToString()
                        , reader["Date"].ToString()
                        ));
                }
                reader.Dispose();
                cmd.Dispose();
            }
        }
    }
}
