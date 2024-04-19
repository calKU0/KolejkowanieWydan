using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolejkowanieWydan
{
    public partial class Form1 : Form
    {
        /* DLL for rounded form */
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        /* Movable form */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /* Form Shadow */
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        /* My variables */
        int month, year;
        private HashSet<int> monthsOpened = new HashSet<int>();
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["GaskaConnectionString"].ConnectionString;
        public static string staticMonth, staticYear;
        public static bool hideRealizedChecked;
        public static List<Wydanie> wydania = new List<Wydanie>();
        public static Operator ope;

        public Form1(string[] args)
        {
            InitializeComponent();
            ope = new Operator(Convert.ToInt32(args[0]));
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            CountWydania(month);
            comboBox1.SelectedIndex = 0;
            hideRealizedCheck.Checked = true;

            welcomeLabel.Text += $" {ope.Name}";

            // Seeding Model Async in order to optimize loading new months
            await SeedTask(6);
        }

        private void DisplayDays(int month)
        {
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            dateLabel.Text = $"{monthName} {year}";

            staticMonth = month.ToString("D2");
            staticYear = year.ToString();

            if (comboBox1.SelectedIndex == 0)
            {
                mondayLabel.Visible = true;
                tuesdayLabel.Visible = true;
                thursdayLabel.Visible = true;
                wednesdayLabel.Visible = true;
                fridayLabel.Visible = true;
                saturdayLabel.Visible = true;
                sundayLabel.Visible = true;

                daycontainer.Controls.Clear();
                daycontainer.Location = new Point(6, 185);
                daycontainer.Size = new Size(1241, 560);

                DateTime startOfTheMonth = new DateTime(year, month, 1);
                int days = DateTime.DaysInMonth(year, month);
                int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

                for (int i = 1; i < dayOfTheWeek; i++)
                {
                    UserControlBlank ucBlank = new UserControlBlank();
                    daycontainer.Controls.Add(ucBlank);
                }

                for (int i = 1; i <= days; i++)
                {
                    UserControlDays ucDays = new UserControlDays();
                    ucDays.Days(i);
                    daycontainer.Controls.Add(ucDays);
                }
            }
            else
            {
                mondayLabel.Visible = false;
                tuesdayLabel.Visible = false;
                thursdayLabel.Visible = false;
                wednesdayLabel.Visible = false;
                fridayLabel.Visible = false;
                saturdayLabel.Visible = false;
                sundayLabel.Visible = false;

                daycontainer.Controls.Clear();
                daycontainer.Location = new Point(6, 136);
                daycontainer.Size = new Size(1241, 609);

                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                List<Wydanie> wydania = new List<Wydanie>();
                if (ope.CanSeeDelivery)
                {
                    wydania = Form1.wydania
                    .Where(w => DateTime.ParseExact(w.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) >= startDate 
                        && DateTime.ParseExact(w.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) <= endDate
                        &&
                        (
                            (hideRealizedChecked && w.Status != "zrealizowane" && w.Status != "zrealizowane z brakami") ||
                            !hideRealizedChecked
                        ))
                    .Distinct()
                    .OrderBy(w => w.Date)
                    .ToList();
                }
                else
                {
                    wydania = Form1.wydania
                    .Where(w => w.Type == "Wydanie" && DateTime.ParseExact(w.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) >= startDate 
                        && DateTime.ParseExact(w.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) <= endDate &&
                        (
                            (hideRealizedChecked && w.Status != "zrealizowane" && w.Status != "zrealizowane z brakami") ||
                            !hideRealizedChecked
                        ))
                    .Distinct()
                    .OrderBy(w => w.Date)
                    .ToList();
                }

                UserControlList ucList = new UserControlList(wydania);
                daycontainer.Controls.Add(ucList);
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
                string query = $@"SELECT 
'Wydanie' AS [Type],
STUFF((select ',' + TrN_DokumentObcy
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
WMS.Atr_Wartosc AS [Status],
COUNT(TrE_TwrNumer) AS [ProductsCount],
CONVERT(varchar, CONVERT(date, DATEADD(DAY, CONVERT(int, SSA.Atr_Wartosc), '18001228')),104) as [Date]
FROM cdn.Atrybuty SSA with (nolock)
JOIN cdn.TraNag SS with (nolock) ON Atr_ObiNumer = TrN_GIDNumer AND Atr_ObiTyp = TrN_GIDTyp
JOIN cdn.Atrybuty WMS with (nolock) on TrN_GIDNumer = WMS.Atr_ObiNumer and TrN_GIDTyp = WMS.Atr_ObiTyp and WMS.Atr_AtkId = 355
JOIN cdn.KntKarty SSSA with (nolock) ON TrN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = TrN_KntTyp
JOIN cdn.TraElem with (nolock) on tre_gidnumer = trn_gidnumer
JOIN cdn.TwrKarty with (nolock) on tre_twrnumer = twr_gidnumer
WHERE SSA.Atr_AtkId = 375
and convert(date, Dateadd(DAY, convert(int,SSA.Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
group by Knt_Akronim, SSA.Atr_Wartosc, TrN_SposobDostawy, WMS.Atr_Wartosc
having case when sum(distinct TrN_Waga) <> 0.00 then sum(distinct TrN_Waga) else sum(TrE_Ilosc * Twr_Waga) end > 900

UNION ALL

SELECT
'Wydanie' AS [Type],
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
'' AS [Status],
COUNT(ZaE_TwrNumer) AS [ProductsCount],
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
having sum(ZaE_Ilosc * twr_waga) > 900

UNION ALL

SELECT
'Dostawa' AS [Type],
ISNULL(CDN.NumerDokumentuTRN(ImN_GIDTyp, 0, 0, ImN_ImNNumer, ImN_ImNRok, ImN_ImNSeria),'') AS [Number],
convert(decimal(15,2), sum(ImE_Ilosc * Twr_Waga)) as [Wage],
Knt_Akronim AS [Acronym],
'' AS [Courier],
'' AS [Status],
COUNT(ImE_TwrNumer) AS [ProductsCount],
CONVERT(varchar, CONVERT(date, DATEADD(DAY, CONVERT(int, Atr_Wartosc), '18001228')),104) AS [Date]
FROM cdn.Atrybuty with (nolock)
JOIN cdn.ImpNag with (nolock) ON Atr_ObiNumer = ImN_GIDNumer AND Atr_ObiTyp = ImN_GIDTyp
join cdn.ImpElem with (nolock) on ImN_GIDNumer = ImE_GIDNumer
JOIN cdn.KntKarty with (nolock) ON ImN_KntNumer = Knt_GIDNumer AND Knt_GIDTyp = ImN_KntTyp
join cdn.TwrKarty with (nolock) on ImE_TwrNumer = Twr_GIDNumer
where Atr_AtkId = 348
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) >= '2024-04-17'
and convert(date, Dateadd(DAY, convert(int,Atr_Wartosc), '18001228')) between '2024-{month}-01' and EOMONTH('2024-{month}-15',0)
group by Knt_Akronim, Atr_Wartosc, ImN_GIDTyp, ImN_ImNNumer, ImN_ImNRok, ImN_ImNSeria";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wydania.Add(new Wydanie(
                        reader["Type"].ToString()
                        , reader["Number"].ToString()
                        , Convert.ToDecimal(reader["Wage"].ToString())
                        , reader["Acronym"].ToString()
                        , reader["Date"].ToString()
                        , reader["Status"].ToString()
                        , reader["Courier"].ToString()
                        , (int)reader["ProductsCount"]
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDays(month);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            this.Cursor = Cursors.WaitCursor;
            wydania.RemoveAll(x => DateTime.ParseExact(x.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) >= startDate && DateTime.ParseExact(x.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture) <= endDate);
            monthsOpened.Remove(month);

            CountWydania(month);
            DisplayDays(month);
            this.Cursor = Cursors.Default;
        }

        private void HideRealizedCheck_CheckedChanged(object sender, EventArgs e)
        {
            hideRealizedChecked = hideRealizedCheck.Checked;
            DisplayDays(month);
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int lineY = viewLabel.Top - 10;
            int lineWidth = this.ClientRectangle.Width;

            using (Pen pen = new Pen(Color.Black))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawLine(pen, 0, lineY, lineWidth, lineY);
            }
        }
    }
}
