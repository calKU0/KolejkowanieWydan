using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolejkowanieWydan
{
    public partial class EventsForm : Form
    {
        private List<Wydanie> Wydania;
        public EventsForm(List<Wydanie> wydania)
        {
            this.Wydania = wydania;
            InitializeComponent();
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text += $" {Wydania[0].Date}";

                foreach (Wydanie wydanie in Wydania)
                {
                    dataGridView1.Rows.Add(wydanie.Number, wydanie.Wage + " kg", wydanie.Acronym);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania listy wydań " + ex, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

    }
}
