using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class Hetman : Bierka
    {
        public Hetman(Szachownica sz, Kolor k) : base(sz, k)
        {
        }

        public override IEnumerable<Pole> DajDostepnePola()
        {
            throw new NotImplementedException();
        }
    }
}
