using FaksistentX.Services.Comments;
using FaksistentX.Services.Comments.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Dashboard
{
    [QueryProperty(nameof(Id), nameof(Id))]
    [QueryProperty(nameof(CommentId), nameof(CommentId))]
    public class CommentViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public string CommentId { get; set; }

        private CommentAppService _commentAppService;

        private CommentDto _comment;
        public CommentDto Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        public Command ReplyCommentCommand { get; set; }

        public CommentViewModel()
        {
            _commentAppService = new CommentAppService();

            ReplyCommentCommand = new Command(OnReplyCommentCommand);
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            Comment = await _commentAppService.GetAsync(CommentId);

            IsBusy = false;
        }

        private async void OnReplyCommentCommand()
        {
            InvokeControllerMethod("Dashboard", "WriteComment", new { Id = Id, CommentId = CommentId });
        }
    }
}
