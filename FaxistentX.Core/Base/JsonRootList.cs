using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Core.Base
{
    public class JsonRootList<T>
    {
        public JsonResult<T> Result { get; set; }

        public bool Success { get; set; }
    }
    public class JsonResult<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
