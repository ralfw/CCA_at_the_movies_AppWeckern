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
            var sut = new Wecker();

            var result = new TimeSpan(0);
            sut.Restzeit += _ => result = _;

            sut.Starten(new Tuple<DateTime, TimeSpan>(new DateTime(2013,1,24,10,0,0), new TimeSpan(0)));
            sut.Zeitzeichen(new DateTime(2013,1,24,9,58,0));

            Assert.AreEqual(new TimeSpan(0,2,0), result);
        }

        [Test]
        public void Ohne_Weckzeit_keine_Restzeit()
        {
            var sut = new Wecker();

            var result = new TimeSpan(0);
            sut.Restzeit += _ => result = _;

            sut.Zeitzeichen(new DateTime(2013, 1, 24, 9, 58, 0));

            Assert.AreEqual(new TimeSpan(0), result);
        }
    }
}
