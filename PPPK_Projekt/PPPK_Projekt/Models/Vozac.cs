using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Projekt.Models
{
    class Vozac
    {

        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojMobitela { get; set; }
        public string BrojVozacke { get; set; }

        public override string ToString() => $"{Ime} {Prezime}";

    }
}
