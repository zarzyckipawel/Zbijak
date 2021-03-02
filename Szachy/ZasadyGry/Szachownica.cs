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

        public IList<Bierka> GetZaataKowaneBierki()
        {
            return GetBierki().SelectMany(d => d.DajZaatakowaneBierki()).Distinct().ToList();
        }

        internal bool CzyNaSkutekTegoRuchuZostanieZaatakowanyNaszKrol(Pole skad, Pole dokad)
        {
            var naszKolor = skad.Bierka.Kolor;
            var szachownica = new Szachownica();
            szachownica.WgrajFEN(this.GetFEN());
            szachownica.WykonajRuch(skad, dokad);
            return szachownica.GetZaataKowaneBierki().Where(e => e.Kolor == naszKolor && e is Krol).Any();
        }

        public Szachownica()
        {
            var pola = new List<Pole>();
            var kolor = Kolor.Bialy;
            for (int rzad = 1; rzad < 9; rzad++)
            {
                for (int kolumna = 1; kolumna < 9; kolumna++)
                {
                    pola.Add(new Pole(rzad,kolumna, kolor));
                    kolor = kolor == Kolor.Bialy ? Kolor.Czarny : Kolor.Bialy;
                }
                kolor = kolor == Kolor.Bialy ? Kolor.Czarny : Kolor.Bialy;
            }
            Pola = pola;
        }

        internal void WykonajRuch(Pole zPola, Pole naPole)
        {
            //zabierz bierke
            var bierka = this.GetPole(zPola.Rzad, zPola.Kolumna).Bierka;
            bierka.Pole.Bierka = null;
            //postaw na nowym polu
            bierka.Pole = this.GetPole(naPole.Rzad, naPole.Kolumna);
            bierka.Pole.Bierka = bierka;
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
