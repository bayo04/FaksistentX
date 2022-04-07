using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Stores
{
    public abstract class BaseStore<T>
    {
        public T Data { get; set; }


        public abstract Task Invoke<TData>(string eventType, TData data);
    }
}
