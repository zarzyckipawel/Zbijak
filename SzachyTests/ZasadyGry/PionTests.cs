using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SzachyTests
{
    [TestClass]
    public class PionTests
    {
        [TestMethod]
        public void SprawdzPolaCzarnegoPionaWRoguSzachownicyNaPoluStartowym()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/p7/8/8/8/8/8/8");
            var Pion = szachownica.GetPole('a', 7).Bierka;
            Assert.AreEqual(2, Pion.DajDostepnePola().Count());
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('a',6)));
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('a',5)));
        }

        [TestMethod]
        public void SprawdzPolaBialegoPionaWRoguSzachownicyNaPoluStartowym()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/8/8/1P6/8");
            var Pion = szachownica.GetPole('b', 2).Bierka;
            Assert.AreEqual(2, Pion.DajDostepnePola().Count());
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('b', 3)));
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('b', 4)));
        }

        [TestMethod]
        public void SprawdzPolaCzarnegoPionaNaSrodku()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/p7/8/8/8/8/8");
            var Pion = szachownica.GetPole('a', 6).Bierka;
            Assert.AreEqual(1, Pion.DajDostepnePola().Count());
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('a', 5)));
        }

        [TestMethod]
        public void SprawdzPolaBialegoPionaNaSrodku()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/8/1P6/8/8");
            var Pion = szachownica.GetPole('b', 3).Bierka;
            Assert.AreEqual(1, Pion.DajDostepnePola().Count());
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('b', 4)));
        }

        [TestMethod]
        public void SprawdzPolaBialegoPionaZablokowanegoPrzezWlasnego()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/1P6/1P6/8/8");
            var Pion = szachownica.GetPole('b', 3).Bierka;
            Assert.AreEqual(0, Pion.DajDostepnePola().Count());
        }

        [TestMethod]
        public void SprawdzPolaBialegoPionaZablokowanegoPrzezCudzego()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/1p6/1P6/8/8");
            var Pion = szachownica.GetPole('b', 3).Bierka;
            Assert.AreEqual(0, Pion.DajDostepnePola().Count());
        }

        [TestMethod]
        public void SprawdzPolaBialegoPionaZBiciem()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/2p5/1P6/8/8");
            var Pion = szachownica.GetPole('b', 3).Bierka;
            Assert.AreEqual(2, Pion.DajDostepnePola().Count());
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('b', 4)));
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('c', 4)));
        }

        [TestMethod]
        public void SprawdzPolaCzarnegoPionaZBiciem()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/2p5/1P6/8/8");
            var Pion = szachownica.GetPole('c', 4).Bierka;
            Assert.AreEqual(2, Pion.DajDostepnePola().Count());
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('c', 3)));
            Assert.IsTrue(Pion.DajDostepnePola().Contains(szachownica.GetPole('b', 3)));
        }

        [TestMethod]
        public void OdslonaAtakuNaKrolaJuzNieLegalna()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/8/rPK5/8/8");
            var Pion = szachownica.GetPole('b', 3).Bierka;
            Assert.AreEqual(0, Pion.DajDostepnePola().Count());
        }

        [TestMethod]
        public void GdyZaatakowanyNaszKrolToMusimyGoZAtakuZabrac()
        {
            var szachownica = new Szachy.Szachownica();
            szachownica.WgrajFEN("8/8/8/8/8/r1KP4/8/8");
            var Pion = szachownica.GetPole('d', 3).Bierka;
            var Krol = szachownica.GetPole('c', 3).Bierka;
            Assert.AreEqual(0, Pion.DajDostepnePola().Count());
            Assert.AreEqual(6, Krol.DajDostepnePola().Count());
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 2)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('c', 2)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 2)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('b', 4)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('c', 4)));
            Assert.IsTrue(Krol.DajDostepnePola().Contains(szachownica.GetPole('d', 4)));
        }



    }
}
