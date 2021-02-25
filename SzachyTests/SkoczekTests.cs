using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SzachyTests
{
    [TestClass]
    public class SkoczekTests
    {
        [TestMethod]
        public void SprawdzPolaSkoczkaWRoguSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("N7/8/8/8/8/8/8/8");
            var Skoczek = szachownica.GetPole('a', 8).Bierka;
            Assert.AreEqual(2, Skoczek.DajDostepnePola().Count());
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('b',6)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('c',7)));
        }
        [TestMethod]
        public void SprawdzPolaSkoczkaWSrodkuSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2N5/8/8/8/8/8");
            var Skoczek = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(8, Skoczek.DajDostepnePola().Count());
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('a', 7)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('b', 8)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('d', 8)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('e', 7)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('e', 5)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('d', 4)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('a', 5)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('b', 4)));
        }

        [TestMethod]
        public void SprawdzPolaSkoczkaWSrodkuSzachownicyZablokowanegoPrzezSkoczka()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("1Q6/8/2N5/8/3P4/8/8/8");
            var Skoczek = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(6, Skoczek.DajDostepnePola().Count());
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('d', 8)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('b', 4)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('e', 7)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('e', 5)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('a', 5)));
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('a', 7)));
        }

        [TestMethod]
        public void SprawdzCzySkoczekRozpoznajeFigureDoBicia()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("1q6/8/2N5/8/3P4/8/8/8");
            var Skoczek = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(1, Skoczek.DajZaatakowaneBierki().Count());
            Assert.IsTrue(Skoczek.DajDostepnePola().Contains(szachownica.GetPole('b', 8)));
        }
    }
}
