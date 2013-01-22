using System;
using System.Threading;
using appweckern.contracts;

namespace appweckern.host
{
    public class Sync<T> : ISync<T>
    {
        private readonly SynchronizationContext _syncCtx;

        public Sync()
        {
            _syncCtx = SynchronizationContext.Current;
        } 

        public void Process(T input)
        {
            _syncCtx.Send(_ => Result(input), null);    
        }

        public event Action<T> Result;
    }
}