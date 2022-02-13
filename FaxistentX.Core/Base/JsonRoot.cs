using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Core.Base
{
    public class JsonRoot<T>
    {
        public T Result { get; set; }

        public bool Success { get; set; }
    }
}
