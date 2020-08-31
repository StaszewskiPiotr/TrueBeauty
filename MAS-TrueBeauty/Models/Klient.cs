using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Klient : Osoba
    {
        public Boolean pierwszaOperacjaPlastyczna { get; set; }
        public ICollection<WizytaKonsultacyjna> WizytyKonsultacyjneLista = new List<WizytaKonsultacyjna>();
        public virtual Osoba osoba { get; set; }
        public Boolean czyBylaWizyta { get; set; }

        private Klient(Osoba osoba, string imie, string nazwisko, string daneKontaktowe, DateTime dataUrodzenia, string plec, string adresZamieszkania, Boolean czyBylaWizyta,Boolean pierwszaOperacjaPlastyczna)
            :base(imie, nazwisko, daneKontaktowe, dataUrodzenia, plec, adresZamieszkania)
        {
            this.pierwszaOperacjaPlastyczna = pierwszaOperacjaPlastyczna;
            this.osoba = osoba;
            this.czyBylaWizyta = czyBylaWizyta;
        }

        private Klient()
           : base()
        {
       
        }

        public static Klient stworzKlienta(Osoba osoba, string imie, string nazwisko, string daneKontaktowe, DateTime dataUrodzenia, string plec, string adresZamieszkania, Boolean czyBylaWizyta, Boolean pierwszaOperacjaPlastyczna)
        {
            if (osoba == null)
            {
                throw new Exception("Podana osoba nie istnieje!");
            }

            Klient klient = new Klient(osoba, imie, nazwisko, daneKontaktowe, dataUrodzenia, plec, adresZamieszkania, czyBylaWizyta, pierwszaOperacjaPlastyczna);
            osoba.addOsoba(klient);

            return klient;
        }

        public void addWizyta(WizytaKonsultacyjna newWizytaKonsultacyjna)
        {

            if (WizytyKonsultacyjneLista.Contains(newWizytaKonsultacyjna) != true)
            {
                WizytyKonsultacyjneLista.Add(newWizytaKonsultacyjna);
                newWizytaKonsultacyjna.setKlient(this);
            }
        }

        public void deleteWizyta(WizytaKonsultacyjna wizytaKonsultacyjna)
        {
            if (WizytyKonsultacyjneLista.Contains(wizytaKonsultacyjna))
            {
                WizytyKonsultacyjneLista.Remove(wizytaKonsultacyjna);
            }
        }

    }
}
