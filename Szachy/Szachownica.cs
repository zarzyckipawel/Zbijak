using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Szachy
{
    public class Szachownica
    {
        public IEnumerable<Pole> Pola { get; set; }

        public IEnumerable<Bierka> GetBierki()
        {
            return Pola.Where(d => d.Bierka != null).Select(d => d.Bierka);
        }

        public Szachownica()
        {
            var pola = new List<Pole>();
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    pola.Add(new Pole(i,j));
                }
            }
            Pola = pola;
        }

        internal bool PoleNaKtorymNieMoznaPostawicFigury(int rzad, int kolumna, Kolor kolor)
        {
            return PozaSzachownica(rzad, kolumna) || PoleZajetePrzezWlasnaFigure(rzad, kolumna, kolor);
        }

        internal bool PoleZajetePrzezWlasnaFigure(int rzad, int kolumna, Kolor kolor)
        {
            return GetPole(rzad, kolumna).Bierka?.Kolor == kolor;
        }

        internal bool PozaSzachownica(int rzad, int kolumna)
        {
            return rzad < 1 || rzad > 8 || kolumna < 1 || kolumna > 8;
        }

        public Pole GetPole(int rzad, int kolumna)
        {
            return Pola.Single(d => d.Rzad == rzad && d.Kolumna == kolumna);
        }
        public Pole GetPole(char kolumna, int rzad)
        {
            return Pola.Single(d => d.Rzad == 9 - rzad && d.Kolumna == (kolumna - 'a' + 1));
        }

        public string GetFEN()
        {
            return FEN.GetFEN(this);
        }

        public void WgrajFEN(string v)
        {
            FEN.Wgraj(this, v);
        }

        internal void PostawBierke(Bierka bierka, int rzad, int kolumna)
        {
            var pole = this.GetPole(rzad, kolumna);
            bierka.Pole = pole;
            pole.Bierka = bierka;
        }
    }
}
