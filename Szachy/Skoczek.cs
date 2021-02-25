using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class Skoczek : Bierka
    {
        public Skoczek(Szachownica sz, Kolor k) : base(sz, k)
        {
        }

        public override IEnumerable<Pole> DajDostepnePola()
        {
            var ruchySkoczka = new[] { (-1, -2), (-2,-1), (1,2), (2,1), (-1, 2), (1, -2), (2, -1), (-2, 1)};

            foreach(var ruch in ruchySkoczka)
            {
                var rzad = Pole.Rzad + ruch.Item1;
                var kolumna = Pole.Kolumna + ruch.Item2;
                if(!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, Kolor))
                {
                    yield return Szachownica.GetPole(rzad, kolumna);
                }
            }
        }
    }
}
