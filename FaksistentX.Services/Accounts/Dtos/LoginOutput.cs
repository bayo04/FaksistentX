using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Services.Account
{
    public class LoginOutput
    {
        public string AccessToken { get; set; }

        public int ExpireInSeconds { get; set; }
    }
}
