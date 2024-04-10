using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkowanieWydan
{
    public class Wydanie
    {
        public string Number;
        public decimal Wage;
        public string Acronym;
        public string Date;

        public Wydanie(string number, decimal wage, string acronym, string date)
        {
            this.Number = number;
            this.Wage = wage;
            this.Acronym = acronym;
            this.Date = date;
        }
    }
}
