using System;
using System.Windows;
using appweckern.contracts;
using appweckern.uhr;

namespace appweckern.host
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Build
            IUI ui = new ui.MainWindow();
            IUhr uhr = new Uhr();
            ISync<DateTime> syncUhrzeit = new Sync<DateTime>();

            // Bind
            uhr.Zeitzeichen += syncUhrzeit.Process;
            syncUhrzeit.Result += ui.Uhrzeit;

            // Run
            uhr.Start();
            ((Window)ui).ShowDialog();
        }
    }
}
