using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Projekt.Models
{
    enum Status{
       Zatvoreni = 1,
       Otvoreni,
       Buduci
    }

    class PutniNalog
    {

        public int Id { get; set; }
        public Vozac Vozac { get; set; }
        public Vozilo Vozilo { get; set; }
        public Grad Pocetni_Grad { get; set; }
        public Grad Zavrsni_Grad { get; set; }
        public Status Status { get; set; }

    }
}
