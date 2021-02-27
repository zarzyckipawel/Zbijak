using System;
using System.Collections.Generic;
using System.Text;

namespace Szachy
{
    public class FEN
    {
        public static Bierka NowaBierkaFEN(Szachownica sz, char ch) 
        {
            if (ch == 'P') return new Pion(sz, Kolor.Bialy);
            if (ch == 'B') return new Goniec(sz, Kolor.Bialy);
            if (ch == 'N') return new Skoczek(sz, Kolor.Bialy);
            if (ch == 'R') return new Wieza(sz, Kolor.Bialy);
            if (ch == 'Q') return new Hetman(sz, Kolor.Bialy);
            if (ch == 'K') return new Krol(sz, Kolor.Bialy);
            if (ch == 'p') return new Pion(sz, Kolor.Czarny);
            if (ch == 'b') return new Goniec(sz, Kolor.Czarny);
            if (ch == 'n') return new Skoczek(sz, Kolor.Czarny);
            if (ch == 'r') return new Wieza(sz, Kolor.Czarny);
            if (ch == 'q') return new Hetman(sz, Kolor.Czarny);
            if (ch == 'k') return new Krol(sz, Kolor.Czarny);
            throw new Exception("Nie ma takiego kodu bierki");
         }

        public static string GetFEN(Szachownica szachownica)
        {
            var fen = "";            
            for (int rzad =1; rzad < 9; rzad++ )
            {
                int zliczeniePustych = 0;
                for (int kolumna = 1; kolumna < 9; kolumna++)
                {
                    var bierka = szachownica.GetPole(rzad, kolumna).Bierka;
                    if(bierka == null)
                    {
                        zliczeniePustych++;
                    }
                    else
                    {
                        if(zliczeniePustych > 0)
                        {
                            fen += zliczeniePustych.ToString();
                            zliczeniePustych = 0;
                        }
                        fen += FEN.GetFEN(bierka).ToString();
                    }
                }
                if (zliczeniePustych > 0)
                {
                    fen += zliczeniePustych.ToString();
                    zliczeniePustych = 0;
                }
                if (rzad < 8)
                {
                    fen += "/";
                }
            }
            return fen;
        }

        public static char GetFEN(Bierka bierka)
        {
            string ret = null;
            if (bierka is Pion) ret = "p";
            if (bierka is Wieza) ret = "r";
            if (bierka is Skoczek) ret = "N";
            if (bierka is Goniec) ret = "B";
            if (bierka is Hetman) ret = "Q";
            if (bierka is Krol) ret = "K";

            return bierka.Kolor == Kolor.Bialy ? ret.ToUpper()[0] : ret.ToLower()[0];
        }

        internal static void Wgraj(Szachownica szachownica, string fen)
        {
            var linieFEN = fen.Split(" ")[0].Split("/");
            var rzad = 1;
            var kolumna = 1;
            foreach (var linia in linieFEN)
            {
                foreach (var ch in linia)
                {
                    int number;
                    if (int.TryParse(ch.ToString(), out number))
                    {
                        for (int i = 0; i < number; i++)
                        {
                            szachownica.GetPole(rzad, kolumna).Bierka = null;
                            kolumna++;
                        }
                    }
                    else
                    {
                        var bierka = NowaBierkaFEN(szachownica, ch);
                        szachownica.PostawBierke(bierka, rzad, kolumna);
                        kolumna++;
                    }                    
                }
                kolumna = 1;
                rzad++;
            }
        }
    }
}
