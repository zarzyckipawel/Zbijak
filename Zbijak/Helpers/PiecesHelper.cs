using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Szachy;

namespace SzkolneGryEdukacyjne.Helpers
{
    public class PiecesHelper
    {
        public string GetImageSrc(Bierka b)
        {
            var literaKoloru = b.Kolor == Kolor.Bialy ? "w" : "b";
            var literaBierki =  DajLitereRodzajuBierki(b);
            return $"sets/standard/{literaBierki}{literaKoloru}.png";
        }

        private static string DajLitereRodzajuBierki(Bierka b)
        {
            if (b is Krol) return "k";
            if (b is Hetman) return "q";
            if (b is Wieza) return "r";
            if (b is Goniec) return "b";
            if (b is Skoczek) return "n";
            if (b is Pion) return "p";
            throw new Exception("nie ma takiej bierki");
        }       
    }
}
