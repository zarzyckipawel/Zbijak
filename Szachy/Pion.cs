using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class Pion : Bierka
    {
        public Pion(Szachownica sz, Kolor bialy): base(sz, bialy)
        {
        }

        public override IEnumerable<Pole> DajDostepnePola()
        {
            throw new NotImplementedException();
        }
    }
}
