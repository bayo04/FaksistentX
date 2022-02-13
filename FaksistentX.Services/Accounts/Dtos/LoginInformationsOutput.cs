using FaksistentX.Services.Tenants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Accounts.Dtos
{
    public class LoginInformationsOutput
    {
        public UserDto User { get; set; }

        public TenantDto Tenant { get; set; }
    }
}
