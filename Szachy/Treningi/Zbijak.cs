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

        public IEnumerable<int> wyniki = new List<int>();
        public int RundaDobre = 0;
        public int RundaBledy = 0;
        public int RundaZadania = 0;
        public int RundaPunkty => RundaZadania * 2 + RundaDobre - RundaBledy * 2;

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
            
            if (atakiDoZnalezienia.Contains(b))
            {
                if(atakiZnalezione.Contains(b))
                {
                    return true;
                }
                atakiZnalezione.Add(b);
                if(atakiDoZnalezienia.Except(atakiZnalezione).Count() == 0)
                {
                    NastepnaPozycja();
                    RundaZadania++;
                }
                RundaDobre++;

                return true;                
            }
            else
            {                
                bledy++;
                RundaBledy++;
                return false;
            }
        }

        public void NastepnaRunda()
        {
            RundaDobre = 0;
            RundaBledy = 0;
            RundaZadania = 0;

            NastepnaPozycja();
        }

        private void NastepnaPozycja()
        {
            bledy = 0;
            do
            {
                szachownica.WgrajFEN(fenRepository[random.Next(0, fenRepository.Count())]);
                atakiDoZnalezienia = szachownica.GetZaataKowaneBierki();
            } while (atakiDoZnalezienia.Count() == 0);
        }
    }
}
