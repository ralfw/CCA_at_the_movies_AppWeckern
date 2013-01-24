using System;
using System.Windows;
using appweckern.contracts;
using appweckern.uhr;
using appweckern.wecker;

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
            IWecker wecker = new Wecker();
            IUhr uhr = new Uhr();
            ISync<DateTime> syncUhrzeit = new Sync<DateTime>();
            ISync<TimeSpan> syncRestzeit = new Sync<TimeSpan>();

            // Bind
            ui.Weckzeit_geändert += wecker.Starten;
            wecker.Restzeit += syncRestzeit.Process;
            syncRestzeit.Result += ui.Restzeit;

            uhr.Zeitzeichen += syncUhrzeit.Process;
            syncUhrzeit.Result += ui.Uhrzeit;
            uhr.Zeitzeichen += wecker.Zeitzeichen;

            // Run
            uhr.Start();
            ((Window)ui).ShowDialog();
        }
    }
}
