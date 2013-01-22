using System;

namespace appweckern.contracts
{
    public interface IWecker
    {
        void Starten(Tuple<DateTime, TimeSpan> weckzeit);
        void Zeitzeichen(DateTime zeitzeichen);
        void Stoppen();

        event Action<TimeSpan> Restzeit;
        event Action Abgelaufen;
        event Action Gestoppt;
    }
}