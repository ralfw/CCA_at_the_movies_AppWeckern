using System;

namespace appweckern.contracts
{
    public interface IUI
    {
        void Öffnen();
        void Uhrzeit(DateTime uhrzeit);
        void Restzeit(TimeSpan restzeit);
        void Abgelaufen();
        void Gestoppt();

        event Action<Tuple<DateTime, TimeSpan>>  Weckzeit_geändert;
        event Action Stopp_gedrückt;
    }
}
