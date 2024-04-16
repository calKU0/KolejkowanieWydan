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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        int month, year;
        private HashSet<int> monthsOpened = new HashSet<int>();
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["GaskaConnectionString"].ConnectionString;
        public static string staticMonth, staticYear;
        public static List<Wydanie> wydania = new List<Wydanie>();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            CountWydania(month);
            DisplayDays(month);

            // Seeding Model Async in otder to oprimize loading new months
            await SeedTask(6);
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

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CountWydania(int month)
        {
            if (monthsOpened.Contains(month))
            {
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"SELECT STUFF((select ',' + TrN_DokumentObcy
FROM cdn.Atrybuty USA with (nolock)
JOIN cdn.TraNag US with (nolock) ON Atr_ObiNumer = TrN_GIDNumer AND Atr_ObiTyp = TrN_GIDTyp
JOIN cdn.KntKarty USAA with (nolock) ON TrN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = TrN_KntTyp
WHERE Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
and USAA.Knt_Akronim = SSSA.Knt_Akronim
and USA.Atr_Wartosc = SSA.Atr_Wartosc
FOR XML PATH ('')), 1, 1, '') AS [Number],
convert(decimal(15,2), case when sum(distinct TrN_Waga) <> 0.00 then sum(distinct TrN_Waga) else sum(TrE_Ilosc * Twr_Waga) end) as [Wage],
Knt_Akronim AS [Acronym],
TrN_SposobDostawy as [Courier],
CONVERT(varchar, CONVERT(date, DATEADD(DAY, CONVERT(int, Atr_Wartosc), '18001228')),104) as [Date]
FROM cdn.Atrybuty SSA with (nolock)
JOIN cdn.TraNag SS with (nolock) ON Atr_ObiNumer = TrN_GIDNumer AND Atr_ObiTyp = TrN_GIDTyp
JOIN cdn.KntKarty SSSA with (nolock) ON TrN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = TrN_KntTyp
JOIN cdn.TraElem with (nolock) on tre_gidnumer = trn_gidnumer
JOIN cdn.TwrKarty with (nolock) on tre_twrnumer = twr_gidnumer
WHERE Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
group by Knt_Akronim, Atr_Wartosc, TrN_SposobDostawy
having case when sum(distinct TrN_Waga) <> 0.00 then sum(distinct TrN_Waga) else sum(TrE_Ilosc * Twr_Waga) end > 900

UNION ALL

SELECT
STUFF((select ',' + ISNULL(CDN.NumerDokumentuTRN ( CDN.DokMapTypDokumentu (ZaN_GIDTyp,ZaN_ZamTyp,ZaN_Rodzaj),0,0,ZaN_ZamNumer,ZaN_ZamRok,ZaN_ZamSeria),'')
FROM cdn.Atrybuty USA with (nolock)
JOIN cdn.ZamNag US with (nolock) ON Atr_ObiNumer = ZaN_GIDNumer AND Atr_ObiTyp = ZaN_GIDTyp
JOIN cdn.KntKarty USAA with (nolock) ON ZaN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = ZaN_KntTyp
WHERE Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
and USAA.Knt_Akronim = SSSA.Knt_Akronim
and USA.Atr_Wartosc = SSA.Atr_Wartosc
FOR XML PATH ('')), 1, 1, '') AS [Number],

convert(decimal(15,2), sum(ZaE_Ilosc * twr_waga)) as [Wage],
Knt_Akronim AS [Acronym],
ZaN_SpDostawy AS [Courier],
CONVERT(varchar, CONVERT(date, DATEADD(DAY, CONVERT(int, Atr_Wartosc), '18001228')),104) AS [Date]
FROM cdn.Atrybuty SSA with (nolock)
JOIN cdn.ZamNag SS with (nolock) ON Atr_ObiNumer = ZaN_GIDNumer AND Atr_ObiTyp = ZaN_GIDTyp
join cdn.ZamElem with (nolock) on ZaN_gidnumer = zae_gidnumer
JOIN cdn.KntKarty SSSA with (nolock) ON ZaN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = ZaN_KntTyp
join cdn.TwrKarty with (nolock) on zae_twrnumer = Twr_GIDNumer
where ZaN_ZamTyp=1280 and Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
and not exists (select * from cdn.TraNag where TrN_ZaNNumer = ZaN_GIDNumer)
group by Knt_Akronim, Atr_Wartosc, ZaN_SpDostawy
having sum(ZaE_Ilosc * twr_waga) > 900";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wydania.Add(new Wydanie(
                         reader["Number"].ToString()
                        , Convert.ToDecimal(reader["Wage"].ToString())
                        , reader["Acronym"].ToString()
                        , reader["Date"].ToString()
                        , reader["Courier"].ToString()
                        ));
                }
                reader.Dispose();
                cmd.Dispose();
                monthsOpened.Add(month);
            }
        }
        private async Task SeedTask(int count)
        {
            Task[] tasks = new Task[count];

            for (int i = 0; i < count; i++)
            {
                int offset = i - count / 2;
                tasks[i] = CreateAndStartTask(() => CountWydania(month + offset));
            }

            await Task.WhenAll(tasks);
        }

        public static Task CreateAndStartTask(Action action)
        {
            Task task = new Task(action);
            task.Start();
            return task;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
