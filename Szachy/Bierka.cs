using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public abstract class Bierka
    {
        public Kolor Kolor { get; set; }

        public Szachownica Szachownica { get; set; }

        public Pole Pole { get; set; }

        public abstract IEnumerable<Pole> DajDostepnePola();

        public Bierka(Szachownica sz, Kolor k)
        {
            Kolor = k;
            Szachownica = sz;
        }
    }
}
