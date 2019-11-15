using Microsoft.ApplicationBlocks.Data;
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
    class PutniNalogRepo
    {
        private static PutniNalogRepo instanca;
        private string cs;

        public static PutniNalogRepo InstancaPutniNalog
        {
            get
            {
                if (instanca == null)
                {
                    instanca = new PutniNalogRepo();
                }
                return instanca;
            }
        }

        private PutniNalogRepo()
        {
            cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        public List<PutniNalog> DohvatiPutneNaloge()
        {
            var putniNalozi = new List<PutniNalog>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();
                try
                {


                    var dataSet = SqlHelper.ExecuteDataset(cs, "dohvatiPutneNaloge");

                    foreach (DataRow redak in dataSet.Tables[0].Rows)
                    {
                        putniNalozi.Add(new PutniNalog
                        {


                            Id = (int)redak["IDPutniNalog"],
                            Vozac = VozaciRepo.InstancaVozaca.DohvatiVozace().Where(x => x.ID == (int)redak["VozacID"]).Single(),
                            Vozilo = VozilaRepo.InstancaVozila.DohvatiVozila().Where(x => x.Id == (int)redak["VoziloID"]).Single(),
                            Pocetni_Grad = PutniNalogRepo.InstancaPutniNalog.DohvatiGradove().Where(x => x.IDGrad == (int)redak["Pocetni_Grad"]).Single(),
                            Zavrsni_Grad = PutniNalogRepo.InstancaPutniNalog.DohvatiGradove().Where(x => x.IDGrad == (int)redak["Zavrsni_Grad"]).Single(),
                            Status = (Status)Enum.Parse(typeof(Status), redak["Status"].ToString())

                        });
                    }
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

                return putniNalozi;
            }
        }

        public void DodajPutniNalog(PutniNalog p)
        {
           
            using(SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(cs, "dodajPutniNalog", p.Vozac.ID, p.Vozilo.Id, p.Pocetni_Grad.IDGrad, p.Zavrsni_Grad.IDGrad, p.Status);
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

            }

           
        }

        public void UrediPutniNalog(PutniNalog p)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(cs, "urediPutniNalog", p.Id, p.Vozac.ID, p.Vozilo.Id, p.Pocetni_Grad.IDGrad, p.Zavrsni_Grad.IDGrad, p.Status);
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

            }


        }

        public void ObrisiPutniNalog(PutniNalog p)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(cs, "obrisiPutniNalog", p.Id);
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

            }


        }

        public List<Grad> DohvatiGradove()
        {
            var Gradovi = new List<Grad>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();
                try
                {


                    var dataSet = SqlHelper.ExecuteDataset(cs, "dohvatiGradove");

                    foreach (DataRow redak in dataSet.Tables[0].Rows)
                    {
                        Gradovi.Add(new Grad
                        {


                            IDGrad = (int)redak["IDGrad"],
                            Naziv = redak["Naziv"].ToString(),


                        });
                    }
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }

                return Gradovi;
            }
        }


    }
}
