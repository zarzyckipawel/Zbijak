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
            var kierunki = new[] { (-1, 0), (0, 1), (0, -1), (1, 0), (-1, -1), (-1, 1), (1, -1), (1, 1) };
            foreach (var kierunek in kierunki)
            {
                var kolumna = this.Pole.Kolumna + kierunek.Item1;
                var rzad = this.Pole.Rzad + kierunek.Item2;

                if (!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, this.Kolor))
                {
                    yield return Szachownica.GetPole(rzad, kolumna);
                }
            }
        }
    }
}
