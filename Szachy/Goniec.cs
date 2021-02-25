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
            var kolumna = this.Pole.Kolumna - 1;
            var rzad = this.Pole.Rzad - 1;            

            while (!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, this.Kolor))
            {               
                yield return Szachownica.GetPole(rzad, kolumna);
                kolumna--;
                rzad--;
            }

            kolumna = this.Pole.Kolumna + 1;
            rzad = this.Pole.Rzad - 1;

            while (!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, this.Kolor))
            {
                yield return Szachownica.GetPole(rzad, kolumna);
                kolumna++;
                rzad--;
            }

            kolumna = this.Pole.Kolumna + 1;
            rzad = this.Pole.Rzad + 1;

            while (!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, this.Kolor))
            {
                yield return Szachownica.GetPole(rzad, kolumna);
                kolumna++;
                rzad++;
            }

            kolumna = this.Pole.Kolumna - 1;
            rzad = this.Pole.Rzad + 1;

            while (!Szachownica.PoleNaKtorymNieMoznaPostawicFigury(rzad, kolumna, this.Kolor))
            {
                yield return Szachownica.GetPole(rzad, kolumna);
                kolumna--;
                rzad++;
            }
        }
    }
}
