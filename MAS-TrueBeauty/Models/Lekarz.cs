using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Lekarz : Osoba
    {
        public string specjalizacja { get; set; }
        public const int znizka = 15;
        public ICollection<WizytaKonsultacyjna> wizytyKonsultacyjneLista = new List<WizytaKonsultacyjna>();
        public virtual Osoba osoba { get; set; }

        private Lekarz(Osoba osoba, string imie, string nazwisko, string daneKontaktowe, DateTime dataUrodzenia, string plec, string adresZamieszkania, string specjalizacja)
           : base(imie, nazwisko, daneKontaktowe, dataUrodzenia, plec, adresZamieszkania)
        {
            this.specjalizacja = specjalizacja;
            this.osoba = osoba;
        }

        private Lekarz()
           : base()
        {

        }

        public static Lekarz stworzLekarza(Osoba osoba, string imie, string nazwisko, string daneKontaktowe, DateTime dataUrodzenia, string plec, string adresZamieszkania, Boolean czyBylaWizyta, string specjalizacja)
        {
            if (osoba == null)
            {
                throw new Exception("Podana osoba nie istnieje!");
            }

            Lekarz lekarz = new Lekarz(osoba, imie, nazwisko, daneKontaktowe, dataUrodzenia, plec, adresZamieszkania, specjalizacja);
            osoba.addOsoba(lekarz);

            return lekarz;
        }

        public void addWizyta(WizytaKonsultacyjna newWizytaKonsultacyjna)
        {
            if (!wizytyKonsultacyjneLista.Contains(newWizytaKonsultacyjna))
            {
                wizytyKonsultacyjneLista.Add(newWizytaKonsultacyjna);
                newWizytaKonsultacyjna.setLekarz(this);
            }
        }
    }
}
