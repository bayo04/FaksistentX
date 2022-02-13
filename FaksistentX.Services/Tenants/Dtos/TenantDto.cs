using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Tenants.Dtos
{
    public class TenantDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public int NoOfSemesters { get; set; }

        public int Id { get; set; }
    }
}
