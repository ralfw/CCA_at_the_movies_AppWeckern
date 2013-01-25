using NUnit.Framework;

namespace appweckern.bimmel.tests
{
    [TestFixture]
    public class BimmelTests
    {
        private Bimmel sut;

        [Test, Explicit]
        public void Die_Bimmel_kann_läuten() {
            sut = new Bimmel();
            sut.Läuten();
        }
    }
}