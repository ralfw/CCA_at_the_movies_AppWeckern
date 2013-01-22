using System;
using System.Threading;
using appweckern.contracts;

namespace appweckern.host
{
    public class Uhr : IUhr
    {
        private Timer _zeitzeichengeber;

        public void Start()
        {
            _zeitzeichengeber = new Timer(_ => Zeitzeichen(DateTime.Now), null, 0, 1000);
        }

        public event Action<DateTime> Zeitzeichen;
    }
}