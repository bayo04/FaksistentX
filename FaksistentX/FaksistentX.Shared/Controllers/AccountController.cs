using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Controllers
{
    public class AccountController : BaseController
    {
        public async Task RegisterPage()
        {
            await ChangeView();
        }
    }
}
