using MAS_TrueBeauty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.DAL
{
    public class ZabiegiDbService
    {
        private ZabiegiDbContext _context = new ZabiegiDbContext();

        public Osoba GetOsoba(int id)
        {
            return _context.Osoby.Where(b => b.OsobaId == id).FirstOrDefault();
        }

        public Klient GetKlient(int id)
        {
            return _context.Klienci.Where(b => b.OsobaId == id).FirstOrDefault();
        }

        public IEnumerable<Klient> GetKlienci()
        {
            return _context.Klienci.ToList();
        }

        public IEnumerable<Lekarz> GetLekarze()
        {
            return _context.Lekarze.ToList();
        }

        public Lekarz GetLekarz(int id)
        {
            return _context.Lekarze.Where(b => b.OsobaId == id).FirstOrDefault();
        }

        public void AddOsoba(Osoba osoba)
        {
            _context.Osoby.Add(osoba);
            _context.SaveChanges();
        }

        public void AddKlient(Klient klient)
        {
            _context.Klienci.Add(klient);
            _context.SaveChanges();
        }

        public void UpdateWizyteKlientNaTrue(Klient klient)
        {

                Klient result = GetKlient(klient.OsobaId);
                if (result != null)
                {
                    result.czyBylaWizyta = true;
                    _context.SaveChanges();
                }
            
        }

        public void DeleteKlient(Klient klient)
        {
            _context.Klienci.Remove(klient);
            _context.SaveChanges();
        }

        public void AddLekarz(Lekarz lekarz)
        {
            _context.Lekarze.Add(lekarz);
            _context.SaveChanges();
        }

        public void DeleteLekarz(Lekarz lekarz)
        {
            _context.Lekarze.Remove(lekarz);
            _context.SaveChanges();
        }

        public IEnumerable<Klient> GetKlienciOczekujacy()
        {
            return _context.Klienci.Where(b => b.czyBylaWizyta == false).ToList(); 
        }

        public IEnumerable<Object> GetKlienciZrealizowani()
        {
            IEnumerable<Object> innerjoin = (from o in _context.Klienci
                                  join l in _context.WizytyKonsultacyjne on o.OsobaId equals l.klient.OsobaId
                                  select new
                                  {
                                     WizytaKonsultacyjnaId = l.WizytaKonsultacyjnaId, 
                                     OsobaId = o.OsobaId,
                                     imie = o.imie,
                                     nazwisko = o.nazwisko,
                                     daneKontaktowe = o.daneKontaktowe,
                                     dataUrodzenia = o.dataUrodzenia,
                                     plec = o.plec,
                                     adresZamieszkania = o.adresZamieszkania,
                                     pierwszaOperacjaPlastyczna = o.pierwszaOperacjaPlastyczna

                                 }).ToList();

            return innerjoin;
        }

        public void AddWizytaKonsultacyjna(WizytaKonsultacyjna wizytaKonsultacyjna)
        {
            _context.WizytyKonsultacyjne.Add(wizytaKonsultacyjna);
            _context.SaveChanges();
        }

        public void AddWizytaKonsultacyjnaSprzet(WizytaKonsultacyjnaSprzet wizytaKonsultacyjnaSprzet)
        {
            _context.WizytyKonsultacyjneSprzety.Add(wizytaKonsultacyjnaSprzet);
            _context.SaveChanges();
        }

        public IEnumerable<Sala> GetSale()
        {
            return _context.Sale.ToList();
        }

        public Sala GetSala(int id)
        {
            return _context.Sale.Where(b => b.SalaId == id).FirstOrDefault();
        }

        public IEnumerable<Sprzet> GetSprzetW(int idSala)
        {
           return _context.Sprzety.Where(b => b.sala.SalaId == idSala);
        }

        public Sprzet GetSprzet(int id)
        {
            return _context.Sprzety.Where(b => b.SprzetId == id).FirstOrDefault();
        }

        public WizytaKonsultacyjna GetWizytaKonsultacyjna(int id)
        {
            return _context.WizytyKonsultacyjne.Where(b => b.WizytaKonsultacyjnaId == id).FirstOrDefault();
        }

        public IEnumerable<Object> GetSprzetWizyty(int idWizyty)
        {
          var x = from p in _context.WizytyKonsultacyjne
                  from c in _context.WizytyKonsultacyjneSprzety
                  from m in _context.Sprzety
                  where c.WizytaKonsultacyjnaSprzetId == p.WizytaKonsultacyjnaId && m.SprzetId == p.WizytaKonsultacyjnaId && p.WizytaKonsultacyjnaId == idWizyty
                  select new
                  {
                      m.SprzetId
                  };
            return x;
        }
    }
}
