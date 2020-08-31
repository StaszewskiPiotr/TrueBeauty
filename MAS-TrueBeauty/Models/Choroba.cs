using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Choroba
    {
        public int ChorobaID { get; set; }
        public string nazwa { get; set; }
        public string opisObjawow { get; set; }
        public virtual ZabiegTradycyjny zabiegTradycyjny { get; set; }

        private Choroba(ZabiegTradycyjny zabiegTradycyjny, int ChorobaID, string nazwa, string opisObjawow)
        {
            this.ChorobaID = ChorobaID;
            this.nazwa = nazwa;
            this.opisObjawow = opisObjawow;
            this.zabiegTradycyjny = zabiegTradycyjny;
        }

        public static Choroba stworzChoroba(ZabiegTradycyjny zabiegTradycyjny, int ChorobaID, string nazwa, string opisObjawow)
        {
            if (zabiegTradycyjny == null)
            {
                throw new Exception("Podany zabieg nie istnieje!");
            }

            Choroba choroba = new Choroba(zabiegTradycyjny, ChorobaID, nazwa, opisObjawow);
            zabiegTradycyjny.addChoroba(choroba);

            return choroba;
        }
    }
}
