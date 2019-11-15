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
    /// Interaction logic for Vozila.xaml
    /// </summary>
    public partial class Vozila : Window
    {
        Vozilo vozilo = null;

        public Vozila()
        {
            InitializeComponent();
            OsvjeziPogled();
            tb_Godina.MaxValue = DateTime.Now.Year;
        }

        private void btn_Spremi_Click(object sender, RoutedEventArgs e)
        {

            if (vozilo != null)
            {

                Vozilo tempVozilo = new Vozilo();
                tempVozilo.Marka = tb_Marka.Text;
                tempVozilo.Tip = tb_Tip.Text;
                if(checkIFnumber(tb_Godina)) tempVozilo.Godina = int.Parse(tb_Godina.Text); else { return; }
                if (checkIFnumber(tb_Kilometraza)) tempVozilo.PocetniKilometri = int.Parse(tb_Kilometraza.Text); else { return;  }
                tempVozilo.Id = vozilo.Id;
                int pozicija = listView_Vozila.SelectedIndex;
                VozilaRepo.InstancaVozila.UrediVozilo(tempVozilo);
                OsvjeziPogled();


                listView_Vozila.SelectedIndex = pozicija;


            }
            else
            {
                Vozilo tempVozilo = new Vozilo();
                tempVozilo.Marka = tb_Marka.Text;
                tempVozilo.Tip = tb_Tip.Text;
                if (checkIFnumber(tb_Godina)) tempVozilo.Godina = int.Parse(tb_Godina.Text); else { return; }
                if (checkIFnumber(tb_Kilometraza)) tempVozilo.PocetniKilometri = int.Parse(tb_Kilometraza.Text); else { return; }

                VozilaRepo.InstancaVozila.DodajVozilo(tempVozilo);
                OsvjeziPogled();


            }
        }

        private void btn_Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (vozilo != null)
            {
                VozilaRepo.InstancaVozila.ObrisiVozilo(vozilo);
                vozilo = null;
                OsvjeziPogled();
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vozilo = listView_Vozila.SelectedItem as Vozilo;

            if (listView_Vozila.SelectedItems.Count < 1)
            {
                OcistiFormu();
            }

            if (vozilo != null)
            {
                txt_Naslov.Text = "Uredi Vozilo:";

                tb_Marka.Text = vozilo.Marka;
                tb_Tip.Text = vozilo.Tip;
                tb_Godina.Text = vozilo.Godina.ToString();
                tb_Kilometraza.Text = vozilo.PocetniKilometri.ToString();
            }

        }

        private void DodajNovo_Click(object sender, RoutedEventArgs e)
        {
            OcistiFormu();
            vozilo = null;
        }

        private void OsvjeziPogled()
        {
            listView_Vozila.ItemsSource = VozilaRepo.InstancaVozila.DohvatiVozila();
        }

        private void OcistiFormu()
        {

            txt_Naslov.Text = "Dodaj Vozilo:";
            tb_Marka.Text = String.Empty;
            tb_Tip.Text = String.Empty;
            tb_Godina.Text = DateTime.Now.Year.ToString();
            tb_Kilometraza.Text = "0";


        }

        private bool checkIFnumber(TextBox tb)
        {
            bool isAllNumbers = true ;

            foreach (var letter in tb.Text)
            {
                if (!Char.IsDigit(letter))
                {
                    isAllNumbers = false;
                }
            }

            if (isAllNumbers)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Godina i Kilometraža moraju biti brojevi!");
                return false;
            }

        }

    }
}
