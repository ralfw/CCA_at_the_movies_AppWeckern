using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using appweckern.contracts;

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
            IUI ui = new appweckern.ui.MainWindow();
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
