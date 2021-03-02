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

        protected override IEnumerable<Pole> DajRuchyZgodneZZasadaDzialaniaTejBierki()
        {
            var kierunki = new[] { (-1, 0), (0, 1), (0, -1), (1, 0), (-1, -1), (-1, 1), (1, -1), (1, 1) };
            return IdzWKierunkach(kierunki);
        }
    }
}
