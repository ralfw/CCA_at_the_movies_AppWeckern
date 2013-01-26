using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appweckern.wecker
{
    class Restzeitrechner
    {
        private DateTime? _weckzeit;

        public Restzeitrechner()
        {
            _starten += _ => _weckzeit = _;
            _zeitzeichen += uhrzeit => Restzeit_berechnen(_weckzeit, uhrzeit, Restzeit);
            _stoppen += () =>
            {
                _weckzeit = null;
                Gestoppt();
            };
        }


        private void Restzeit_berechnen(DateTime? weckzeit, DateTime uhrzeit, Action<TimeSpan> on_restzeit)
        {
            if (!weckzeit.HasValue) return;

            on_restzeit(weckzeit.Value.Subtract(uhrzeit));
        }


        private readonly Action<DateTime> _starten;
        public void Starten(DateTime weckzeit) { _starten(weckzeit); }

        private readonly Action<DateTime> _zeitzeichen;
        public void Zeitzeichen(DateTime zeitzeichen) { _zeitzeichen(zeitzeichen); }

        private readonly Action _stoppen;
        public void Stoppen() { _stoppen(); }


        public event Action<TimeSpan> Restzeit;
        public event Action Gestoppt;
    }
}
