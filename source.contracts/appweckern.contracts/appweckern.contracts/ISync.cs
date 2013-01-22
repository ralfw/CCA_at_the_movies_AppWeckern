using System;

namespace appweckern.contracts
{
    public interface ISync<T>
    {
        void Process(T input);

        event Action<T> Result;
    }
}