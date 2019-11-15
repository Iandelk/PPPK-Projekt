using Microsoft.ApplicationBlocks.Data;
using PPPK_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Projekt.Repo
{

    class VozilaRepo
    {
        private static VozilaRepo instanca;
        private string cs;

        public static VozilaRepo InstancaVozila
        {
            get
            {
                if (instanca == null)
                {
                    instanca = new VozilaRepo();
                }
                return instanca;
            }
        }

        private VozilaRepo()
        {
            cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        public List<Vozilo> DohvatiVozila()
        {
            var vozila = new List<Vozilo>();
            var dataSet = SqlHelper.ExecuteDataset(cs, "dohvatiVozila");

            foreach (DataRow redak in dataSet.Tables[0].Rows)
            {
                vozila.Add(new Vozilo
                {


                    Id = (int)redak["IDVozila"],
                    Marka = redak["Marka"].ToString(),
                    Tip = redak["Tip"].ToString(),
                    Godina = Convert.ToDateTime(redak["Godina"].ToString()).Year,
                    PocetniKilometri = (int)redak["PocetniKilometri"]

                });
            }


            return vozila;
        }


        public int DodajVozilo(Vozilo v)
        {

            return SqlHelper.ExecuteNonQuery(cs, "dodajVozilo", v.Marka , v.Tip, Convert.ToDateTime("01-01-"+v.Godina.ToString()), v.PocetniKilometri);
        }

        public int UrediVozilo(Vozilo v)
        {

            return SqlHelper.ExecuteNonQuery(cs, "urediVozilo", v.Id, v.Marka, v.Tip, Convert.ToDateTime("01-01-"+v.Godina.ToString()), v.PocetniKilometri);
        }

        public int ObrisiVozilo(Vozilo v)
        {

            return SqlHelper.ExecuteNonQuery(cs, "obrisiVozilo", v.Id);
        }

    }
}
