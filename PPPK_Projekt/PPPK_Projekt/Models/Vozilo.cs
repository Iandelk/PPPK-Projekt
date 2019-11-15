using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Projekt.Models
{
    class Vozilo
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public string Marka { get; set; }
        public int Godina { get; set; }
        public int PocetniKilometri { get; set; }

        public override string ToString() => $"{Marka} {Tip}";

    }
}
