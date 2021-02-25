using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class Pion : Bierka
    {
        public Pion(Szachownica sz, Kolor bialy): base(sz, bialy)
        {
        }

        public override IEnumerable<Pole> DajDostepnePola()
        {
            var kierunek = Kolor == Kolor.Bialy ? -1 : 1;
            var kolorPrzeciwnika = Kolor == Kolor.Bialy ? Kolor.Czarny : Kolor.Bialy;
            var rzadStartowy = Kolor == Kolor.Bialy ? 7 : 2;
            var ukosy = new[] { (kierunek, -1) , (kierunek, 1)};

            var poleDoPrzodu = Szachownica.GetPole(Pole.Rzad + kierunek, Pole.Kolumna);

            
            if (!Szachownica.PozaSzachownica(poleDoPrzodu.Rzad, poleDoPrzodu.Kolumna) && poleDoPrzodu.Bierka == null ) 
            {
                yield return poleDoPrzodu; // zwykly ruch do przodu
                if (Pole.Rzad == rzadStartowy) // ruch startowy o dwa pola
                {
                    var dwaPolaDoPrzodu = Szachownica.GetPole(rzadStartowy + kierunek * 2, Pole.Kolumna);
                    if (dwaPolaDoPrzodu.Bierka == null)
                    {
                        yield return dwaPolaDoPrzodu;
                    }
                }
            }

            

            foreach(var ukos in ukosy) // bicia
            {
                var rzad = Pole.Rzad + ukos.Item1;
                var kolumna = Pole.Kolumna + ukos.Item2;
                if (Szachownica.PozaSzachownica(rzad, kolumna))
                {
                    continue;
                }
                var poleNaUkos = Szachownica.GetPole(rzad, kolumna);
                var bierka = poleNaUkos.Bierka;
                if (bierka != null && bierka.Kolor == kolorPrzeciwnika)
                {
                    yield return poleNaUkos;
                }
            }

            // todo bicie w przelocie
        }
    }
}
