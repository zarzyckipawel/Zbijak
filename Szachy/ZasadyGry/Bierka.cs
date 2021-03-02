using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Szachy
{
    public abstract class Bierka
    {
        public Kolor Kolor { get; set; }

        public Szachownica Szachownica { get; set; }

        public Pole Pole { get; set; }

        protected abstract IEnumerable<Pole> DajRuchyZgodneZZasadaDzialaniaTejBierki();
        public IEnumerable<Pole> DajDostepnePola()
        {
            return DajRuchyZgodneZZasadaDzialaniaTejBierki().Where(ruch => !Szachownica.CzyNaSkutekTegoRuchuZostanieZaatakowanyNaszKrol(Pole, ruch));
        }

        public IEnumerable<Bierka> DajZaatakowaneBierki()
        {
            return DajRuchyZgodneZZasadaDzialaniaTejBierki().Where(d => d.Bierka != null).Select(d => d.Bierka).ToList();
        }

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
                    var pole = Szachownica.GetPole(rzad, kolumna);
                    yield return pole;
                    if (pole.Bierka != null && pole.Bierka.Kolor != Kolor)
                    {
                        break;
                    }
                    kolumna += kierunek.Item1;
                    rzad += kierunek.Item2;
                }
            }
        }
    }
}
