using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SzachyTests
{
    [TestClass]
    public class WiezaTests
    {
        [TestMethod]
        public void SprawdzPolaWiezyWRoguSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("R7/8/8/8/8/8/8/8");
            var Wieza = szachownica.GetPole('a', 8).Bierka;
            Assert.AreEqual(14, Wieza.DajDostepnePola().Count());
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',1)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',2)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',3)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',4)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',5)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a',7)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('b', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('d', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('e', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('f', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('g', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('h', 8)));
        }
        [TestMethod]
        public void SprawdzPolaWiezyWSrodkuSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2R5/8/8/8/8/8");
            var Wieza = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(14, Wieza.DajDostepnePola().Count());
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 1)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 2)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 3)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 4)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 5)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('e', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('f', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('g', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('h', 6)));
        }

        [TestMethod]
        public void SprawdzPolaWiezyWSrodkuSzachownicyZablokowanegoPrzezWiezy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2R5/8/2Q5/8/8/8");
            var Wieza = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(10, Wieza.DajDostepnePola().Count());
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 5)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('e', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('f', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('g', 6)));
            Assert.IsTrue(Wieza.DajDostepnePola().Contains(szachownica.GetPole('h', 6)));
        }
    }
}
