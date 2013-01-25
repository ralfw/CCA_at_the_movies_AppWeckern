using System;
using appweckern.contracts;

namespace appweckern.wecker
{
    public class Wecker : IWecker
    {
        private DateTime? _weckzeit;

        public Wecker()
        {
            _starten += _ => Weckzeit_bestimmen(_, weckzeit => _weckzeit = weckzeit);
            _zeitzeichen += uhrzeit => Restzeit_berechnen(_weckzeit, uhrzeit, _ => Restzeit(_));
        }


        private readonly Action<Tuple<DateTime, TimeSpan>> _starten;
        public void Starten(Tuple<DateTime, TimeSpan> weckzeit) { _starten(weckzeit); }

        private readonly Action<DateTime> _zeitzeichen;
        public void Zeitzeichen(DateTime zeitzeichen) { _zeitzeichen(zeitzeichen); }

        private Action _stoppen;
        public void Stoppen() { _stoppen(); }


        public event Action<TimeSpan> Restzeit;
        public event Action Abgelaufen;
        public event Action Gestoppt;


        private void Weckzeit_bestimmen(Tuple<DateTime, TimeSpan> weckzeit_oder_ruhezeit, Action<DateTime> on_weckzeit)
        {
            if (weckzeit_oder_ruhezeit.Item1 != new DateTime())
                on_weckzeit(weckzeit_oder_ruhezeit.Item1);
            else
                if (weckzeit_oder_ruhezeit.Item2 != new TimeSpan()) {
                    var weckzeit = DateTime.Now.Add(weckzeit_oder_ruhezeit.Item2);
                    on_weckzeit(weckzeit);
                }
        }

        private void Restzeit_berechnen(DateTime? weckzeit, DateTime uhrzeit, Action<TimeSpan> on_restzeit)
        {
            if (!weckzeit.HasValue) return;

            on_restzeit(weckzeit.Value.Subtract(uhrzeit));
        }
    }
}
