using System;
using System.Windows;
using NUnit.Framework;

namespace appweckern.ui.tests
{
    [TestFixture]
    public class MainWindowTests
    {
        [Test, Explicit, RequiresSTA]
        public void Uhrzeit_anzeigen() {
            var sut = new MainWindow();
            sut.Uhrzeit(DateTime.Now);
            sut.ShowDialog();
        }

        [Test, Explicit, RequiresSTA]
        public void Restzeit_anzeigen() {
            var sut = new MainWindow();
            sut.Restzeit(new TimeSpan(1, 2, 3));
            sut.ShowDialog();
        }

        [Test, Explicit, RequiresSTA]
        public void Weckzeit_geändert() {
            var sut = new MainWindow();
            sut.Weckzeit_geändert += e => MessageBox.Show("Weckzeit = " + e.Item1.ToLongTimeString() + ", Ruheziet = " + e.Item2.ToString());
            sut.ShowDialog();
        }

        [Test, Explicit, RequiresSTA]
        public void Stop_gedrückt()
        {
            var sut = new MainWindow();
            sut.Stopp_gedrückt += () => MessageBox.Show("Stopp gedrück!");
            sut.ShowDialog();
        }
    }
}