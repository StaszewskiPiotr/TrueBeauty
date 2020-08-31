using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Zabieg
    {
        [Key, ForeignKey("wizytaKonsultacyjna")]
        public int ZabiegId { get; set; }
        public string opisZabiegu { get; set; }
        public double sredniaDlugoscWykonywaniaH { get; set; }
        public int trudnoscOd1Do5 { get; set; }
        public double cena { get; set; }
        public ZabiegUsluga[] uslugiTablica = new ZabiegUsluga[3];
        public virtual Sala sala { get; set; }
        public virtual WizytaKonsultacyjna wizytaKonsultacyjna { get; set; }

        public Zabieg(int ZabiegId, string opisZabiegu, double sredniaDlugoscWykonywaniaH, int trudnoscOd1Do5, double cena) {
            this.ZabiegId = ZabiegId;
            this.opisZabiegu = opisZabiegu;
            this.sredniaDlugoscWykonywaniaH = sredniaDlugoscWykonywaniaH;
            this.trudnoscOd1Do5 = trudnoscOd1Do5;
            this.cena = cena;
        }

        public void addZabiegUsluga(ZabiegUsluga newUsluga)
        {
            int licznik = 0;
            int licznikZajetych = 0;

            for (int x = 0; x < uslugiTablica.Length; x++)
            {
                if(uslugiTablica[x] == newUsluga)
                {
                    licznik++;
                }

                if (uslugiTablica[x] != null)
                {
                    licznikZajetych++;
                }
            }

            if (licznik != 0)
            {
                throw new Exception("Podana usluga jest już w liście usług!");
            }

            if (licznikZajetych == 3)
            {
                throw new Exception("Limit trzech usług został osiągnięty!");
            }

            if (licznik == 0)
            {
                for (int y = 0; y < uslugiTablica.Length; y++)
                {
                    if (uslugiTablica[y] == null)
                    {
                        uslugiTablica[y] = newUsluga;
                        break;
                    }
                }

                newUsluga.setZabieg(this);
            }    
        }

        public void setSala(Sala newSala)
        {
            if (sala == null)
            {
                sala = newSala;
                newSala.addZabieg(this);
            }
        }

        public void setWizytaKonsultacyjna(WizytaKonsultacyjna newWizytaKonsultacyjna)
        {
            if (wizytaKonsultacyjna == null)
            {
                wizytaKonsultacyjna = newWizytaKonsultacyjna;
                newWizytaKonsultacyjna.setZabieg(this);
            }
        }
    }
}
