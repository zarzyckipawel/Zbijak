using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SzachyTests
{
    [TestClass]
    public class KrolTests
    {
        [TestMethod]
        public void SprawdzPolaKrolaWRoguSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("R7/8/8/8/8/8/8/8");
            var Krol = szachownica.GetPole('a', 8).Bierka;
            Assert.AreEqual(3, Krol.DajDostepnePola().Count());
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('a',7)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b',7)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b',8)));
        }
        [TestMethod]
        public void SprawdzPolaKrolaWSrodkuSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2R5/8/8/8/8/8");
            var Krol = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(8, Krol.DajDostepnePola().Count());
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('c', 5)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 5)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 7)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 7)));
        }

        [TestMethod]
        public void SprawdzPolaKrolaWSrodkuSzachownicyZablokowanegoPrzezKrola()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/2R5/2Q5/8/8/8/8");
            var Krol = szachownica.GetPole('c', 6).Bierka;
            Assert.AreEqual(7, Krol.DajDostepnePola().Count());
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('c', 7)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 5)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 6)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 7)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 6)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 7)));
        }
    }
}
