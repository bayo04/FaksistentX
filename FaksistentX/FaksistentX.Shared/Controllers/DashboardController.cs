using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Controllers
{
    public class DashboardController : BaseController
    {
        public async Task DashboardPage()
        {
            await ChangeView();
        }
    }
}
