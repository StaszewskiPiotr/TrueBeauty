using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_TrueBeauty.Models
{
    public class ZabiegUsluga
    {
        public int ZabiegUslugaId { get; set; }
        public virtual Zabieg zabieg { get; set; }
        public virtual Usluga usluga { get; set; }

        public void setZabieg(Zabieg newZabieg)
        {
            if (zabieg == null)
            {
                zabieg = newZabieg;
                newZabieg.addZabiegUsluga(this);
            }
        }

        public void setUsluga(Usluga newUsluga)
        {
            if (usluga == null)
            {
                usluga = newUsluga;
                newUsluga.addZabiegUsluga(this);
            }
        }
    }
}
