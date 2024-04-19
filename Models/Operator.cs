using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolejkowanieWydan
{
    public class Operator
    {
        public int Id { get; set; }
        public bool CanSeeDelivery { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string FullName
        {
            get { return $"{Name} {Surname}"; }
        }

        public Operator(int id)
        {
            try
            {
                Id = id;
                string query = @"SELECT DISTINCT
Prc_GIDNumer as [GidNumber],
Prc_Imie1 as [Name],
Prc_Nazwisko as [Surname],
case when FRS_ID is null then 1 else 0 end as [CanSeeDelivery]
FROM cdn.OpeKarty
left join cdn.PrcKarty on Prc_GIDNumer = Ope_PrcNumer
left join CDN.FrmStruktura ON FRS_GIDNumer = Prc_GIDNumer AND ((((FrS_GrOTyp=-4272 AND FrS_GrOFirma=449892 AND FrS_GrONumer in (2458,2459,2613,2629)) AND (FrS_GIDTyp=944 OR 0=1))) AND FrS_GrOLp=0)
WHERE Ope_GIDNumer = @Id";

                using (SqlConnection connection = new SqlConnection(Form1.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CanSeeDelivery = Convert.ToBoolean((int)reader["CanSeeDelivery"]);
                            Name = reader["Name"].ToString();
                            Surname = reader["Surname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Napotkano błąd przy próbie pobrania operatora\n" + ex, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
