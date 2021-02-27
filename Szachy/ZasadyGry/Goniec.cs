using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class Goniec : Bierka
    {
        public Goniec(Szachownica sz, Kolor k) : base(sz, k)
        {
        }

        public override IEnumerable<Pole> DajDostepnePola()
        {
            var kierunki = new[] { (-1, -1), (-1, 1), (1, -1), (1, 1) };
            return IdzWKierunkach(kierunki);
        }
    }
}
