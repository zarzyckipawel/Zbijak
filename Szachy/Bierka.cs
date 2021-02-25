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

        public IEnumerable<Pole> IdzWKierunkach((int, int)[] kierunki)
        {
            foreach (var kierunek in kierunki)
            {
                var kolumna = this.Pole.Kolumna + kierunek.Item1;
                var rzad = this.Pole.Rzad + kierunek.Item2;

                while (!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, this.Kolor))
                {
                    yield return Szachownica.GetPole(rzad, kolumna);
                    kolumna += kierunek.Item1;
                    rzad += kierunek.Item2;
                }
            }
        }
    }
}
