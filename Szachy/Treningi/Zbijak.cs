using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Szachy.Treningi
{
    public class Zbijak
    {
        public Szachownica szachownica = new Szachownica();
        public IList<Bierka> atakiDoZnalezienia = new List<Bierka>();
        public IList<Bierka> atakiZnalezione = new List<Bierka>();
        public int bledy = 0;
        public IList<Bierka> bierkiZaznaczone = new List<Bierka>();
        public IList<string> fenRepository = new List<String>(); 
        public Random random = new Random();

        public Zbijak(string[] fens)
        {
            fenRepository = fens.ToList();
        }

        public Zbijak()
        {
        }

        public void PokazBierkiZaatakoanePrzez(Bierka b)
        {
            bierkiZaznaczone.Clear();
            foreach (var bierka in b.DajZaatakowaneBierki())
            {
                bierkiZaznaczone.Add(bierka);
            }
        }

        public void SchowajBierkiZaatakowane()
        {
            bierkiZaznaczone.Clear();
        }

        public bool WskazanoBierke(Bierka b)
        {
            if (atakiDoZnalezienia.Except(atakiZnalezione).Contains(b))
            {
                atakiZnalezione.Add(b);
                return true;
                
            }
            else
            {                
                bledy++;
                return false;
            }
        }

        public void NastepnaPozycja()
        {
            do
            {
                szachownica.WgrajFEN(fenRepository[random.Next(0, fenRepository.Count())]);
                atakiDoZnalezienia = szachownica.GetZaataKowaneBierki();
            } while (atakiDoZnalezienia.Count() == 0);
        }
    }
}
