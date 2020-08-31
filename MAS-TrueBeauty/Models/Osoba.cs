using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Osoba
    {
        public int OsobaId { get; set; }

        public string imie { get; set; }

        public string nazwisko { get; set; }

        public string daneKontaktowe { get; set; }

        public DateTime dataUrodzenia { get; set; }

        public string plec { get; set; }

        public string adresZamieszkania { get; set; }

        public List<Osoba> tytulyLista = new List<Osoba>();

        private static HashSet<Osoba> wszystkieTytulyLista = new HashSet<Osoba>();

        public Osoba(string imie, string nazwisko, string daneKontaktowe, DateTime dataUrodzenia, string plec, string adresZamieszkania)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.daneKontaktowe = daneKontaktowe;
            this.dataUrodzenia = dataUrodzenia;
            this.plec = plec;
            this.adresZamieszkania = adresZamieszkania;
        }

        public Osoba()
        {

        }

        public double wyliczWiek()
        {
            var dataTeraz = DateTime.Today;

            var wiek = dataTeraz.Year - dataUrodzenia.Year;

            if (dataUrodzenia.Date > dataTeraz.AddYears(-wiek))
            {
                wiek--;
            }

            return wiek;
        }

        public void addOsoba(Osoba osoba)
        {
            if (!tytulyLista.Contains(osoba))
            {
                if (wszystkieTytulyLista.Contains(osoba))
                {
                    throw new Exception("Podany tytuł klient/lekarz jest już przypisany!");
                }

                tytulyLista.Add(osoba);
                wszystkieTytulyLista.Add(osoba);
            }
        }
    }
}
