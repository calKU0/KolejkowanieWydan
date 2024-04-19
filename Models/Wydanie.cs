using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkowanieWydan
{
    public class Wydanie
    {
        public string Type;
        public string Number;
        public decimal Wage;
        public string Acronym;
        public string Date;
        public string Status;
        public string Courier;
        public int ProductsCount;
        public Wydanie(string type, string number, decimal wage, string acronym, string date, string status, string courier, int productsCount)
        {
            Type = type;
            Number = number;
            Wage = wage;
            Acronym = acronym;
            Date = date;
            Status = status;
            Courier = courier;
            ProductsCount = productsCount;
        }
    }
}
