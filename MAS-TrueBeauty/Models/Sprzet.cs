using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Sprzet
    {
        public int SprzetId { get; set; }
        public string opis { get; set; }
        public int rokZakupu { get; set; }
        public virtual Sala sala { get; set; }
        public ICollection<WizytaKonsultacyjnaSprzet> wizytyLista = new List<WizytaKonsultacyjnaSprzet>();

        private Sprzet(Sala sala, int SprzetId, string opis, int rokZakupu)
        {
            this.SprzetId = SprzetId;
            this.opis = opis;
            this.rokZakupu = rokZakupu;
            this.sala = sala;
        }

        public Sprzet()
        {

        }

        public static Sprzet stworzSprzet(Sala sala, int SprzetId, string opis, int rokZakupu)
        {
            if(sala == null) {
                throw new Exception("Podana sala nie istnieje!");
            }

            Sprzet sprzet = new Sprzet(sala, SprzetId, opis, rokZakupu);
            sala.addSprzet(sprzet);
 
            return sprzet;
        }

        public void addWizytaKonsultacyjnaSprzet(WizytaKonsultacyjnaSprzet wizytaKonsultacyjna)
        {
            if (!wizytyLista.Contains(wizytaKonsultacyjna))
            {
                wizytyLista.Add(wizytaKonsultacyjna);
                wizytaKonsultacyjna.setSprzet(this);
            }
        }
    }
}
