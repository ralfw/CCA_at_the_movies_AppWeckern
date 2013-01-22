using System;

namespace appweckern.contracts
{
    public interface IUhr
    {
        void Start();

        event Action<DateTime> Zeitzeichen;
    }
}