using PPPK_Projekt.Models;
using PPPK_Projekt.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PPPK_Projekt
{
    /// <summary>
    /// Interaction logic for PutniNalozi.xaml
    /// </summary>
    public partial class PutniNalozi : Window
    {
        PutniNalog putniNalog = null;
        List<PutniNalog> putniNalozi;

        public PutniNalozi()
        {
            InitializeComponent();

            putniNalozi = PutniNalogRepo.InstancaPutniNalog.DohvatiPutneNaloge();

            Filtriraj();
            OsvjeziCombo();
        }


        private void DodajNovi_Click(object sender, RoutedEventArgs e)
        {
            OcistiFormu();
            putniNalog = null;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            putniNalog = listView_PutniNalozi.SelectedItem as PutniNalog;


            if (listView_PutniNalozi.SelectedItems.Count < 1)
            {

                OcistiFormu();
            }
            if (putniNalog != null)
            {
                txt_Naslov.Text = "Uredi Putni Nalog:";

                cb_Vozac.Text = putniNalog.Vozac.ToString();
                cb_Vozilo.Text = putniNalog.Vozilo.ToString();
                cb_PocetniGrad.Text = putniNalog.Pocetni_Grad.ToString();
                cb_ZavrsniGrad.Text = putniNalog.Zavrsni_Grad.ToString();
                cb_Status.Text = putniNalog.Status.ToString();
            }

        }

        private void btn_Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (putniNalog != null)
            {
                PutniNalogRepo.InstancaPutniNalog.ObrisiPutniNalog(putniNalog);
                putniNalog = null;
                Filtriraj();
            }
        }

        private void btn_Spremi_Click(object sender, RoutedEventArgs e)
        {
            if (cb_PocetniGrad.SelectedIndex != cb_ZavrsniGrad.SelectedIndex)
            {

                if (putniNalog != null)
                {

                    PutniNalog tempPutniNalog = new PutniNalog();
                    tempPutniNalog.Vozac = cb_Vozac.SelectedItem as Vozac;
                    tempPutniNalog.Vozilo = cb_Vozilo.SelectedItem as Vozilo;
                    tempPutniNalog.Pocetni_Grad = cb_PocetniGrad.SelectedItem as Grad;
                    tempPutniNalog.Zavrsni_Grad = cb_ZavrsniGrad.SelectedItem as Grad;
                    tempPutniNalog.Status = (Status)(cb_Status.SelectedIndex + 1);
                    tempPutniNalog.Id = putniNalog.Id;
                    int pozicija = listView_PutniNalozi.SelectedIndex;
                    PutniNalogRepo.InstancaPutniNalog.UrediPutniNalog(tempPutniNalog);
                    Filtriraj();


                    listView_PutniNalozi.SelectedIndex = pozicija;


                }
                else
                {
                    PutniNalog tempPutniNalog = new PutniNalog();
                    tempPutniNalog.Vozac = cb_Vozac.SelectedItem as Vozac;
                    tempPutniNalog.Vozilo = cb_Vozilo.SelectedItem as Vozilo;
                    tempPutniNalog.Pocetni_Grad = cb_PocetniGrad.SelectedItem as Grad;
                    tempPutniNalog.Zavrsni_Grad = cb_ZavrsniGrad.SelectedItem as Grad;
                    tempPutniNalog.Status = (Status)(cb_Status.SelectedIndex + 1);

                    PutniNalogRepo.InstancaPutniNalog.DodajPutniNalog(tempPutniNalog);
                    Filtriraj();


                }
            }
            else
            {
                MessageBox.Show("Početni i završni grad ne smiju biti isti Grad.");
            }
        }

        private void OcistiFormu()
        {

            txt_Naslov.Text = "Dodaj Putni Nalog:";
            cb_Vozac.SelectedIndex = 0;
            cb_Vozilo.SelectedIndex = 0;
            cb_PocetniGrad.SelectedIndex = 0;
            cb_ZavrsniGrad.SelectedIndex = 1;
            cb_Status.SelectedIndex = 0;


        }

      


        private void OsvjeziCombo()
        {
            List<Grad> gradovi = PutniNalogRepo.InstancaPutniNalog.DohvatiGradove();

            cb_Vozac.ItemsSource = VozaciRepo.InstancaVozaca.DohvatiVozace();
            cb_Vozilo.ItemsSource = VozilaRepo.InstancaVozila.DohvatiVozila();
            cb_PocetniGrad.ItemsSource = gradovi;
            cb_ZavrsniGrad.ItemsSource = gradovi;
            cb_Status.ItemsSource = Enum.GetNames(typeof(Status));
            List<string> enumi = new List<string>();
            enumi.Add("Prikaži sve");
            enumi.AddRange(Enum.GetNames(typeof(Status)));
            cb_FilterStatus.ItemsSource = enumi;
        }

        private void cb_FilterStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtriraj();

        }

        private void Filtriraj()
        {
            if (cb_FilterStatus.SelectedIndex == 0)
            {
                putniNalozi = PutniNalogRepo.InstancaPutniNalog.DohvatiPutneNaloge();
                listView_PutniNalozi.ItemsSource = putniNalozi;
            }
            else
            {
                putniNalozi = PutniNalogRepo.InstancaPutniNalog.DohvatiPutneNaloge();
                putniNalozi = putniNalozi.Where(x => (int)x.Status == cb_FilterStatus.SelectedIndex).ToList();
                listView_PutniNalozi.ItemsSource = putniNalozi;


            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            OsvjeziCombo();
            cb_Vozac.SelectedIndex = 0;
            cb_Vozilo.SelectedIndex = 0;
            cb_PocetniGrad.SelectedIndex = 0;
            cb_ZavrsniGrad.SelectedIndex = 1;
        }
    }
}
