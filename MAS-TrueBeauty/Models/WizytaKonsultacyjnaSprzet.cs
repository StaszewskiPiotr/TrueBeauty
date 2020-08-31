using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public class WizytaKonsultacyjnaSprzet
    {
        public int WizytaKonsultacyjnaSprzetId { get; set; }
        public virtual WizytaKonsultacyjna wizytaKonsultacyjna { get; set; }
        public virtual Sprzet sprzet { get; set; }

        public WizytaKonsultacyjnaSprzet(WizytaKonsultacyjna wizytaKonsultacyjna, Sprzet sprzet)
        {
            this.wizytaKonsultacyjna = wizytaKonsultacyjna;
            this.sprzet = sprzet;
        }

        public WizytaKonsultacyjnaSprzet()
        {

        }

        public void setWizytaKonsultacyjna(WizytaKonsultacyjna newWizytaKonsultacyjna)
        {
            if (wizytaKonsultacyjna == null)
            {
                wizytaKonsultacyjna = newWizytaKonsultacyjna;
                newWizytaKonsultacyjna.addWizytaKonsultacyjnaSprzet(this);
            }
        }

        public void setSprzet(Sprzet newSprzet)
        {
            if (sprzet == null)
            {
                sprzet = newSprzet;
                newSprzet.addWizytaKonsultacyjnaSprzet(this);
            }
        }
    }
}
