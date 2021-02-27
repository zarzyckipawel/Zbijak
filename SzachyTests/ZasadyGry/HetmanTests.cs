using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SzachyTests
{
    [TestClass]
    public class HetmanTests
    {
        [TestMethod]
        public void SprawdzPolaHetmanaWRoguSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("Q7/8/8/8/8/8/8/8");
            var hetman = szachownica.GetPole('a', 8).Bierka;
            Assert.AreEqual(21, hetman.DajDostepnePola().Count());
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',1)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',2)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',3)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a',7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 3)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 2)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 1)));
        }
        [TestMethod]
        public void SprawdzPolaHetmanaWSrodkuSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2Q5/8/8/8/8/8");
            var Hetman = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(25, Hetman.DajDostepnePola().Count());
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 1)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 2)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 3)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 4)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 5)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 6)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 4)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 5)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 8)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 7)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 7)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 8)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 4)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 3)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 2)));
            Assert.IsTrue(Hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 1)));
        }

        [TestMethod]
        public void SprawdzPolaHetmanaWSrodkuSzachownicyZablokowanegoPrzezHetmana()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2Q5/8/2Q5/8/8/8");
            var hetman = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(21, hetman.DajDostepnePola().Count());
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 3)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 2)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 1)));
        }

        [TestMethod]
        public void SprawdzPolaHetmanaWSrodkuSzachownicyZablokowanegoPrzezObcegoHetmana()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2Q5/8/2q5/8/8/8");
            var hetman = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(22, hetman.DajDostepnePola().Count());
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 6)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('a', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('b', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 7)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 8)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('e', 4)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('f', 3)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('g', 2)));
            Assert.IsTrue(hetman.DajDostepnePola().Contains(szachownica.GetPole('h', 1)));
        }

        [TestMethod]
        public void SprawdzCzyHetmanRozpoznajeBicie()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2Q5/8/2q5/8/8/8");
            var hetman = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(1, hetman.DajZaatakowaneBierki().Count());
            Assert.IsTrue(hetman.DajZaatakowaneBierki().Contains(szachownica.GetPole('c', 4).Bierka));
        }
    }
}
