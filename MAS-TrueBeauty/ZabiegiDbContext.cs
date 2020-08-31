namespace MAS_TrueBeauty
{
    using MAS_TrueBeauty.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ZabiegiDbContext : DbContext
    {
    
        public ZabiegiDbContext()
            : base("name=ZabiegiDbContext")
        {
        }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<WizytaKonsultacyjna> WizytyKonsultacyjne { get; set; }
        public DbSet<WizytaKonsultacyjnaSprzet> WizytyKonsultacyjneSprzety { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Zabieg> Zabiegi { get; set; }
        public DbSet<ZabiegUsluga> ZabiegiUslugi { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<Plastyka> Plastyka { get; set; }
        public DbSet<Lift> Lifty { get; set; }
        public DbSet<ZabiegTradycyjny> ZabiegiTradycyjne { get; set; }
        public DbSet<Choroba> Choroby { get; set; }


    }
}