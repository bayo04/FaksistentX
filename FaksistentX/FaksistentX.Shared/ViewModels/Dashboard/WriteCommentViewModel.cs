using FaksistentX.Services.Comments;
using FaksistentX.Services.Comments.Dtos;
using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Dashboard
{
    [QueryProperty(nameof(Id), nameof(Id))]
    [QueryProperty(nameof(CommentId), nameof(CommentId))]
    public class WriteCommentViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public string CommentId { get; set; }

        public List<CourseTestDto> Tests { get; set; }

        private string _selectedTestId;
        public string SelectedTestId
        {
            get => _selectedTestId;
            set => SetProperty(ref _selectedTestId, value);
        }

        private string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private bool _showSelectedTest = true;
        public bool ShowSelectedTest
        {
            get => _showSelectedTest;
            set => SetProperty(ref _showSelectedTest, value);
        }

        public CourseTemplateDto Template { get; set; }

        public CourseTemplateAppService _courseTemplateAppService { get; set; }
        public CommentAppService _commentAppService { get; set; }

        public Command SaveCommand { get; set; }

        public WriteCommentViewModel()
        {
            Tests = new List<CourseTestDto>();

            _courseTemplateAppService = new CourseTemplateAppService();
            _commentAppService = new CommentAppService();

            SaveCommand = new Command(OnSaveCommand);
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            Template = await _courseTemplateAppService.GetAsync(Id);
            Tests.Clear();
            Tests.Add(new CourseTestDto { Id = "All", Name = "Nije odabran test" });
            Tests.AddRange(Template.CourseTests);
            SelectedTestId = "All";

            ShowSelectedTest = string.IsNullOrEmpty(CommentId);

            IsBusy = false;
        }

        private async void OnSaveCommand()
        {
            await _commentAppService.CreateAsync(new CreateCommentDto { 
                Content = Content,
                CourseId = Template.CourseId,
                Tag = SelectedTestId == "All" ? "" : Template.CourseTests.FirstOrDefault(x => x.Id == SelectedTestId).Name,
                ParentId = CommentId
            });
            GoBack();
        }
    }
}
