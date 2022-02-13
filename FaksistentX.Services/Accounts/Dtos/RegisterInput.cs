using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Accounts.Dtos
{
    public class RegisterInput
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public int TenantId { get; set; }
    }
}
