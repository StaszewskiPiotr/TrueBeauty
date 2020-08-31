using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class ZabiegTradycyjny : Usluga
    {
        public virtual ICollection<Choroba> chorobyLista { get; set; }
        private static HashSet<Choroba> wszystkieChorobyLista = new HashSet<Choroba>();

        public ZabiegTradycyjny(int UslugaId, string okresPrzygotowania, int liczbaOsobDoPomocy)
            : base(UslugaId, okresPrzygotowania, liczbaOsobDoPomocy)
        {
            
        }


        public void addChoroba(Choroba choroba) 
        {
            if(!chorobyLista.Contains(choroba)) {
           
            if(wszystkieChorobyLista.Contains(choroba)) {
                throw new Exception("Choroba jest już dodana!");
            }

            chorobyLista.Add(choroba);
            wszystkieChorobyLista.Add(choroba);
            }
        }
    }
}
