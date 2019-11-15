using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Projekt.Models
{
    class Grad
    {

        public int IDGrad { get; set; }
        public String Naziv { get; set; }

        public override string ToString() => $"{Naziv}";

    }
}
