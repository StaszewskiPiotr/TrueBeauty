using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class WizytaKonsultacyjna
    {
        public int WizytaKonsultacyjnaId { get; set; } 
        public DateTime data { get; set; }
        public double godzinaPrzyjecia { get; set; }
        public double godzinaZakonczenia { get; set; }
        public string opisProblemu { get; set; }
        public string decyzja { get; set; }
        public virtual Lekarz lekarz { get; set; }
        public virtual Klient klient { get; set; }
        public virtual Sala sala { get; set; }
        public ICollection<WizytaKonsultacyjnaSprzet> wykorzystanySprzetLista = new List<WizytaKonsultacyjnaSprzet>();
        public virtual Zabieg zabieg { get; set; }

        public WizytaKonsultacyjna(DateTime data, double godzinaPrzyjecia, double godzinaZakonczenia, string opisProblemu, string decyzja)
        {
            this.data = data;
            this.godzinaPrzyjecia = godzinaPrzyjecia;
            this.godzinaZakonczenia = godzinaZakonczenia;
            this.opisProblemu = opisProblemu;
            this.decyzja = decyzja;
        }

        public WizytaKonsultacyjna()
        {

        }


        public void setLekarz(Lekarz newLekarz)
        {
            if (lekarz == null)
            {
                lekarz = newLekarz;
                newLekarz.addWizyta(this);
            }
        }

        public void setKlient(Klient newKlient)
        {
            if(klient == null)
            {
                klient = newKlient;
                newKlient.addWizyta(this);
            }
        }

        public void setSala(Sala newSala)
        {
            if (sala == null)
            {
                sala = newSala;
                newSala.addWizyta(this);
            }
        }

        public void addWizytaKonsultacyjnaSprzet(WizytaKonsultacyjnaSprzet newSprzet)
        {
            if (!wykorzystanySprzetLista.Contains(newSprzet))
            {
                wykorzystanySprzetLista.Add(newSprzet);
                newSprzet.setWizytaKonsultacyjna(this);
            }
        }

        public void setZabieg(Zabieg newZabieg)
        {
            if (zabieg == null)
            {
                zabieg = newZabieg;
                newZabieg.setWizytaKonsultacyjna(this);
            }
        }
    }
}
