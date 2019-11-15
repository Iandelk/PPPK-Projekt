using PPPK_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Projekt.Repo
{
    class VozaciRepo
    {

        private static VozaciRepo instanca;
        private string cs;

        public static VozaciRepo InstancaVozaca
        {
            get
            {
                if (instanca == null)
                {
                    instanca = new VozaciRepo();
                }
                return instanca;
            }
        }

        private VozaciRepo()
        {
            cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        public List<Vozac> DohvatiVozace()
        {
            var vozaci = new List<Vozac>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "select * from Vozac";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                vozaci.Add(new Vozac { ID = (int)r["IDVozac"], Ime = r["Ime"].ToString(),
                                    Prezime = r["Prezime"].ToString(),BrojMobitela = r["BrojMobitela"].ToString(),
                                    BrojVozacke = r["BrojVozacke"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return vozaci;
        }

        public void DodajVozaca(Vozac vozac)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke) values(@param1, @param2, @param3, @param4)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@param1", vozac.Ime);
                    cmd.Parameters.AddWithValue("@param2", vozac.Prezime);
                    cmd.Parameters.AddWithValue("@param3", vozac.BrojMobitela);
                    cmd.Parameters.AddWithValue("@param4", vozac.BrojVozacke);

                    cmd.ExecuteNonQuery();

                }

            }

        }

        public void UrediVozaca(Vozac vozac)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"Update Vozac set Ime = @param1, Prezime=@param2, BrojMobitela= @param3, BrojVozacke=@param4 where IDVozac=@param5";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@param1", vozac.Ime);
                    cmd.Parameters.AddWithValue("@param2", vozac.Prezime);
                    cmd.Parameters.AddWithValue("@param3", vozac.BrojMobitela);
                    cmd.Parameters.AddWithValue("@param4", vozac.BrojVozacke);
                    cmd.Parameters.AddWithValue("@param5", vozac.ID);

                    cmd.ExecuteNonQuery();

                }

            }

        }

        public void ObrisiVozaca(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"delete from Vozac where IDVozac=@param1";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@param1", id);
                    
                    cmd.ExecuteNonQuery();

                }

            }

        }

    }
}
