using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class Krol : Bierka
    {
        public Krol(Szachownica sz, Kolor k) : base(sz, k)
        {
        }

        public override IEnumerable<Pole> DajDostepnePola()
        {
            throw new NotImplementedException();
        }
    }
}
