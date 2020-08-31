using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Sala
    {
        public int SalaId { get; set; }
        public double powierzchnia { get; set; }
        public virtual ICollection<Sprzet> sprzetLista { get; set; }
        private static HashSet<Sprzet> calySprzetLista = new HashSet<Sprzet>();
        public virtual ICollection<WizytaKonsultacyjna> wizytyKonsultacyjneLista { get; set; }
        public virtual ICollection<Zabieg> zabiegiLista { get; set; }

        public Sala(int SalaId, double powierzchnia)
        {
            this.SalaId = SalaId;
            this.powierzchnia = powierzchnia;
        }

        public Sala()
        {

        }

        public void addSprzet(Sprzet sprzet)
        {
            if(!sprzetLista.Contains(sprzet)) {
                if(calySprzetLista.Contains(sprzet)) {
                    throw new Exception("Podany sprzęt już znajduje się w tej sali!");
                }

                sprzetLista.Add(sprzet);
                calySprzetLista.Add(sprzet);
            }
        }

        public void addWizyta(WizytaKonsultacyjna newWizytaKonsultacyjna)
        {
            if (!wizytyKonsultacyjneLista.Contains(newWizytaKonsultacyjna))
            {
                wizytyKonsultacyjneLista.Add(newWizytaKonsultacyjna);
                newWizytaKonsultacyjna.setSala(this);
            }
        }

        public void addZabieg(Zabieg newZabieg)
        {
            if (!zabiegiLista.Contains(newZabieg))
            {
                zabiegiLista.Add(newZabieg);
                newZabieg.setSala(this);
            }
        }
    }
}
