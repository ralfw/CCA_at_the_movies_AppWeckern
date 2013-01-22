using NUnit.Framework;

namespace appweckern.ui.tests
{
    [TestFixture]
    public class MainWindowTests
    {
        [Test, Explicit, RequiresSTA]
        public void Show() {
            var sut = new MainWindow();
            sut.ShowDialog();
        } 
    }
}