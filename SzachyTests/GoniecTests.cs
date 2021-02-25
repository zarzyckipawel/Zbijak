using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SzachyTests
{
    [TestClass]
    public class GoniecTests
    {
        [TestMethod]
        public void SprawdzPolaGoncaWRoguSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("B7/8/8/8/8/8/8/8");
            var goniec = szachownica.GetPole('a', 8).Bierka;
            Assert.AreEqual(7, goniec.DajDostepnePola().Count());
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('b',7)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('c',6)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('d',5)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('e',4)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('f',3)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('g',2)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('h',1)));
        }
        [TestMethod]
        public void SprawdzPolaGoncaWSrodkuSzachownicy()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/1B6/8/8/8/8/8/8");
            var goniec = szachownica.GetPole('b', 7).Bierka;
            Assert.AreEqual(9, goniec.DajDostepnePola().Count());
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('c', 6)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('d', 5)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('e', 4)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('f', 3)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('g', 2)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('h', 1)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('a', 8)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
        }

        [TestMethod]
        public void SprawdzPolaGoncaWSrodkuSzachownicyZablokowanegoPrzezSkoczka()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/1B6/2N5/8/8/8/8/8");
            var goniec = szachownica.GetPole('b', 7).Bierka;
            Assert.AreEqual(3, goniec.DajDostepnePola().Count());            
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('a', 8)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
        }

        [TestMethod]
        public void SprawdzPolaGoncaWSrodkuSzachownicyZObcaFiguraDoBicia()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/1B6/2n5/8/8/8/8/8");
            var goniec = szachownica.GetPole('b', 7).Bierka;
            Assert.AreEqual(4, goniec.DajDostepnePola().Count());
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('a', 8)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('c', 8)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('a', 6)));
            Assert.IsTrue(goniec.DajDostepnePola().Contains(szachownica.GetPole('c', 6)));
        }

        [TestMethod]
        public void SprawdzCzyGoniecRozpoznaFigureDoBicia()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/1B6/2n5/8/8/8/8/8");
            var goniec = szachownica.GetPole('b', 7).Bierka;
            Assert.AreEqual(1, goniec.DajZaatakowaneBierki().Count());
            Assert.IsTrue(goniec.DajZaatakowaneBierki().Contains(szachownica.GetPole('c', 6)));
        }
    }
}
