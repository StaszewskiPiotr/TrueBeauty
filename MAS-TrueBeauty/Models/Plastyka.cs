using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Plastyka : Usluga
    {
        public double kosztMaterialow { get; set; }

        public Plastyka(int UslugaId, string okresPrzygotowania, int liczbaOsobDoPomocy, double kosztMaterialow)
            : base(UslugaId, okresPrzygotowania, liczbaOsobDoPomocy)
        {
            this.kosztMaterialow = kosztMaterialow;
        }
    }
}
