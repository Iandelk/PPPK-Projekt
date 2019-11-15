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
    /// Interaction logic for Vozaci.xaml
    /// </summary>
    public partial class Vozaci : Window
    {
        Vozac vozac = null;

        public Vozaci()
        {
            InitializeComponent();

            OsvjeziPogled();

        }

      

        private void DodajNovog_Click(object sender, RoutedEventArgs e)
        {
            OcistiFormu();
            vozac = null;
        }


        private void btn_Spremi_Click(object sender, RoutedEventArgs e)
        {

            if(vozac != null)
            {

                Vozac tempVozac = new Vozac();
                tempVozac.Ime = tb_Ime.Text;
                tempVozac.Prezime = tb_Prezime.Text;
                tempVozac.BrojMobitela = tb_Mobitel.Text;
                tempVozac.BrojVozacke = tb_BrojVozacke.Text;
                tempVozac.ID = vozac.ID;
                int pozicija = listView_Vozaci.SelectedIndex;
                VozaciRepo.InstancaVozaca.UrediVozaca(tempVozac);
                OsvjeziPogled();
              

                listView_Vozaci.SelectedIndex = pozicija;
               

            }
            else
            {
                Vozac tempVozac = new Vozac();
                tempVozac.Ime = tb_Ime.Text;
                tempVozac.Prezime = tb_Prezime.Text;
                tempVozac.BrojMobitela = tb_Mobitel.Text;
                tempVozac.BrojVozacke = tb_BrojVozacke.Text;

                VozaciRepo.InstancaVozaca.DodajVozaca(tempVozac);
                OsvjeziPogled();
              

            }

        }

        private void btn_Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if(vozac != null)
            {
                VozaciRepo.InstancaVozaca.ObrisiVozaca(vozac.ID);
                vozac = null;
                OsvjeziPogled();
            }
        }

        private void listView_Vozaci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            vozac = listView_Vozaci.SelectedItem as Vozac;

            if(listView_Vozaci.SelectedItems.Count < 1)
            {
                
                OcistiFormu();
            }

            if (vozac != null)
            {
                txt_Naslov.Text = "Uredi Vozača:";

                tb_Ime.Text = vozac.Ime;
                tb_Prezime.Text = vozac.Prezime;
                tb_Mobitel.Text = vozac.BrojMobitela;
                tb_BrojVozacke.Text = vozac.BrojVozacke.ToString();
            }
        }

        private void OcistiFormu()
        {

            txt_Naslov.Text = "Dodaj Vozača:";
            tb_Ime.Text = String.Empty;
            tb_Prezime.Text = String.Empty;
            tb_Mobitel.Text = String.Empty;
            tb_BrojVozacke.Text = String.Empty;
                
      
        }

        private void OsvjeziPogled()
        {
            listView_Vozaci.ItemsSource = VozaciRepo.InstancaVozaca.DohvatiVozace();
        }
    }
}
