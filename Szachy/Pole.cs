using System;

namespace Szachy
{
    public class Pole
    {

        public Pole(int i, int j)
        {
            Rzad = i;
            Kolumna = j;
        }

        public string Koordynaty
        {
            get
            {
                return $"{(char)('a' - 1 + Kolumna)} {9 - Rzad}";
            }
        }

        public string GetFEN()
        {
            if (Bierka == null)
            {
                return null;
            }
            else
            {
                return FEN.GetFEN(Bierka).ToString();
            }
        }

        public override string ToString()
        {
            return $"{Bierka} {Koordynaty}";
        }

        public Bierka Bierka {get;set;}
        public int Rzad { get; set; }
        public int Kolumna { get; set; }
    }
}
