using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Core.Base
{
    public class EntityDto
    {
        public EntityDto(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
