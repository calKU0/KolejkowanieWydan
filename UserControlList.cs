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
    public partial class UserControlList : UserControl
    {
        private readonly List<Wydanie> Wydania;
        public UserControlList(List<Wydanie> wydania)
        {
            Wydania = wydania;
            InitializeComponent();
        }
        private void UserControlList_Load(object sender, EventArgs e)
        {
            foreach (Wydanie wydanie in Wydania)
            {
                int i = dataGridView1.Rows.Add(wydanie.Date, wydanie.Type, wydanie.Number, wydanie.Courier, wydanie.Wage + " kg", wydanie.ProductsCount, wydanie.Acronym);

                if (dataGridView1.Rows[i].Cells["date"].Value.ToString() == DateTime.Now.Date.ToString("dd.MM.yyyy"))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }
    }
}
