using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace appweckern.wecker.tests
{
    [TestFixture]
    public class test_Wecker
    {
        [Test]
        public void Restzeit_berechnen()
        {
            var sut = new Wecker(null);

            var result = new TimeSpan(0);
            sut.Restzeit += _ => result = _;

            sut.Starten(new Tuple<DateTime, TimeSpan>(new DateTime(2013,1,24,10,0,0), new TimeSpan(0)));
            sut.Zeitzeichen(new DateTime(2013,1,24,9,58,0));

            Assert.AreEqual(new TimeSpan(0,2,0), result);
        }

        [Test]
        public void Ohne_Weckzeit_keine_Restzeit()
        {
            var sut = new Wecker(null);

            var result = new TimeSpan(0);
            sut.Restzeit += _ => result = _;

            sut.Zeitzeichen(new DateTime(2013, 1, 24, 9, 58, 0));

            Assert.AreEqual(new TimeSpan(0), result);
        }

        [Test]
        public void Weckzeit_noch_nicht_erreicht()
        {
            var sut = new Wecker(null);

            sut.Ist_Weckzeit_erreicht(new TimeSpan(0,0,10,42), Assert.Fail);
        }

        [Test]
        public void Weckzeit_erreicht()
        {
            var sut = new Wecker(null);

            var abgelaufen = false;
            sut.Ist_Weckzeit_erreicht(new DateTime(2000,1,1,10,0,0).Subtract(new DateTime(2000,1,1,10,0,0)), () => abgelaufen=true);

            Assert.IsTrue(abgelaufen);
        }
    }
}
