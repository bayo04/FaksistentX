using FaxistentX.Core.Base;
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

        public async Task CourseDetailsPage(string Id)
        {
            await ChangeView(new EntityDto(Id));
        }

        public async Task EditLecturesPage(string Id)
        {
            await ChangeView(new EntityDto(Id));
        }

        public async Task WriteCommentPage(string Id, string CommentId)
        {
            await ChangeView(new { Id = Id, CommentId = CommentId});
        }

        public async Task CommentPage(string Id, string CommentId)
        {
            await ChangeView(new { Id = Id, CommentId = CommentId });
        }
    }
}
