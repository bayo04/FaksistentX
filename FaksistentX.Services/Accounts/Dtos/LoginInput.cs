using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Accounts.Dtos
{
    public class LoginInput
    {
        public string UserNameOrEmailAddress { get; set; }

        public string Password { get; set; }

        public string TenancyName { get; set; }

        public bool RememberClient { get; set; }
    }
}
