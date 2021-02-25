using Microsoft.VisualStudio.TestTools.UnitTesting;
using Szachy;

namespace SzachyTests
{
    [TestClass]
    public class SzachownicaTests
    {
        private string poczatkoweUstawienie = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
        private string pustaSzachownica = "8/8/8/8/8/8/8/8";
        [TestMethod]
        public void StworzSzachowniceISprawdzPola()
        {
            var szachownica = new Szachy.Szachownica();
            Assert.AreEqual(pustaSzachownica, szachownica.GetFEN());
        }

        [TestMethod]
        public void StworzSzachowniceUsatawieniePoczatkowe()
        {
            var testFEN = poczatkoweUstawienie;
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN(testFEN);
            Assert.AreEqual(testFEN, szachownica.GetFEN());
        }

        [TestMethod]
        public void GetPoleKoordynatyVsSzachoweWspolzedne()
        {
            var testFEN = poczatkoweUstawienie;
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN(testFEN);
            Assert.AreEqual(szachownica.GetPole(1,1), szachownica.GetPole('a', 8));
            Assert.IsTrue(szachownica.GetPole('a', 8).Bierka is Wieza);
            Assert.IsTrue(szachownica.GetPole('a', 8).Bierka.Kolor == Kolor.Czarny);
            Assert.IsTrue(szachownica.GetPole('e', 1).Bierka is Krol);
            Assert.IsTrue(szachownica.GetPole('e', 1).Bierka.Kolor == Kolor.Bialy);
        }
    }
}
