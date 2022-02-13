using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Core.Tenants
{
    public class Tenant
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public int NoOfSemesters { get; set; }

        public int Id { get; set; }
    }
}
