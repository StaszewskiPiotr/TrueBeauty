using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public abstract class Usluga
    {
        public int UslugaId { get; set; }
        public string okresPrzygotowania { get; set; }
        public int liczbaOsobDoPomocy { get; set; }
        public virtual ICollection<ZabiegUsluga> zabiegiLista { get; set; }

        public Usluga(int UslugaId, string okresPrzygotowania, int liczbaOsobDoPomocy)
        {
            this.UslugaId = UslugaId;
            this.okresPrzygotowania = okresPrzygotowania;
            this.liczbaOsobDoPomocy = liczbaOsobDoPomocy;
        }

        public void addZabiegUsluga(ZabiegUsluga newZabieg)
        {
            if (!zabiegiLista.Contains(newZabieg))
            {
                zabiegiLista.Add(newZabieg);
                newZabieg.setUsluga(this);
            }
        }
    }
}
