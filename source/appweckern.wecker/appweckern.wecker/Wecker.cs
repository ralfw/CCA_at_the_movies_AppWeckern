using System;
using appweckern.contracts;

namespace appweckern.wecker
{
    public class Wecker : IWecker
    {
        public Wecker(IBimmel bimmel)
        {
            var rechner = new Restzeitrechner();

            _starten += _ => Weckzeit_bestimmen(_, rechner.Starten);
            _zeitzeichen += rechner.Zeitzeichen;
            rechner.Restzeit += _ => Ist_Weckzeit_erreicht(_, 
                                            Restzeit, () => {

                                            bimmel.Läuten();
                                            rechner.Stoppen(); 
                                            Abgelaufen();
                                        });
            rechner.Gestoppt += () => Gestoppt();

            _stoppen += rechner.Stoppen;
        }


        private readonly Action<Tuple<DateTime, TimeSpan>> _starten;
        public void Starten(Tuple<DateTime, TimeSpan> weckzeit) { _starten(weckzeit); }

        private readonly Action<DateTime> _zeitzeichen;
        public void Zeitzeichen(DateTime zeitzeichen) { _zeitzeichen(zeitzeichen); }

        private readonly Action _stoppen;
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


        public void Ist_Weckzeit_erreicht(TimeSpan restzeit, Action<TimeSpan> on_restzeit, Action on_abgelaufen)
        {
            if (((int)restzeit.TotalSeconds) == 0)
                on_abgelaufen();
            on_restzeit(restzeit);
        }
    }
}
