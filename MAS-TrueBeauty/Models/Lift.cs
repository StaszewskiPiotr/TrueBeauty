using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public partial class Lift : Usluga
    {
        public List<String> listaCzesciCiala = new List<String>();

        public Lift(int UslugaId, string okresPrzygotowania, int liczbaOsobDoPomocy)
            : base(UslugaId, okresPrzygotowania, liczbaOsobDoPomocy)
        {
            listaCzesciCiala.Add("Uda");
            listaCzesciCiala.Add("Brzuch");
            listaCzesciCiala.Add("Ręce");
            listaCzesciCiala.Add("Podbródek");
        }
    }
}
