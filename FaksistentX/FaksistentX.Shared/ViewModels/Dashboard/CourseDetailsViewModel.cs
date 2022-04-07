using FaksistentX.Services.Comments;
using FaksistentX.Services.Comments.Dtos;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.UserSemesters.SemesterCourses;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Dashboard
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class CourseDetailsViewModel : BaseViewModel
    {
        public string Id { get; set; }

        private string _totalPoints;

        public string TotalPoints
        {
            get => _totalPoints;
            set => SetProperty(ref _totalPoints, value);
        }

        public SemesterCourseDto SemesterCourse { get; set; }

        public ObservableCollection<CourseTestDto> Tests { get; set; }

        public ObservableCollection<CommentDto> Comments { get; set; }

        private string _failedTestsPass = "";
        public string FailedTestsPass
        {
            get => _failedTestsPass;
            set => SetProperty(ref _failedTestsPass, value);
        }

        private string _failedTestsSignature = "";
        public string FailedTestsSignature
        {
            get => _failedTestsSignature;
            set => SetProperty(ref _failedTestsSignature, value);
        }

        private SemesterCourseAppService _semesterCourseAppService;
        private CommentAppService _commentAppService;

        public Command WriteCommentCommand { get; set; }
        public Command<CommentDto> ReplyCommentCommand { get; set; }
        public Command<CommentDto> CommentCommand { get; set; }

        public CourseDetailsViewModel()
        {
            _semesterCourseAppService = new SemesterCourseAppService();
            _commentAppService = new CommentAppService();

            Tests = new ObservableCollection<CourseTestDto>();
            Comments = new ObservableCollection<CommentDto>();

            WriteCommentCommand = new Command(OnWriteCommentCommand);
            ReplyCommentCommand = new Command<CommentDto>(OnReplyCommentCommand);
            CommentCommand = new Command<CommentDto>(OnCommentCommand);
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            SemesterCourse = await _semesterCourseAppService.GetAsync(Id);

            Tests.Clear();
            foreach (var test in SemesterCourse.CourseTemplate.CourseTests)
            {
                if(SemesterCourse.SemesterCourseTests.Any(x => x.CourseTestId == test.Id))
                {
                    test.MyPoints = SemesterCourse.SemesterCourseTests.FirstOrDefault(x => x.CourseTestId == test.Id).Points;

                    if(test.MyPoints < test.PointsForPass)
                    {
                        FailedTestsPass += (FailedTestsPass.Length == 0 ? "You can't pass because of: " : ", ") + test.Name;
                    }
                    if(test.MyPoints < test.PointsForSignature)
                    {
                        FailedTestsSignature += (FailedTestsSignature.Length == 0 ? "You can't get signature because of: " : ", ") + test.Name;
                    }
                }
                Tests.Add(test);
            }
            foreach (var restriction in SemesterCourse.CourseTemplate.CourseRestrictions)
            {
                var show = true;
                decimal total = 0;
                var testStrings = "";
                foreach(var test in restriction.Tests)
                {
                    if (SemesterCourse.SemesterCourseTests.Any(x => x.CourseTestId == test.CourseTestId))
                    {
                        var semesterCourseTest = SemesterCourse.SemesterCourseTests.FirstOrDefault(x => x.CourseTestId == test.CourseTestId);
                        total += semesterCourseTest.Points;
                        testStrings += (testStrings.Length == 0 ? "" : " + ") + Tests.FirstOrDefault(x => x.Id == semesterCourseTest.CourseTestId).Name;
                    }
                    else
                    {
                        show = false;
                    }
                }
                if (show && total < restriction.PointsForPass)
                {
                    FailedTestsPass += (FailedTestsPass.Length == 0 ? "You can't pass because of: " : ", ") + testStrings;
                }
                if (show && total < restriction.PointsForSignature)
                {
                    FailedTestsSignature += (FailedTestsSignature.Length == 0 ? "You can't get signature because of: " : ", ") + testStrings;
                }
            }

            TotalPoints = Tests.Select(x => x.MyPoints).Sum().ToString() + "/" + Tests.Select(x => x.TotalPoints).Sum().ToString();

            var comments = await _commentAppService.GetAllAsync(new CommentRequestDto { CourseId = SemesterCourse.CourseId });

            Comments.Clear();
            foreach(var comment in comments)
            {
                Comments.Add(comment);
            }

            IsBusy = false;
        }

        public async void SetPoints(string testId, decimal points)
        {
            await _semesterCourseAppService.SetPoints(new SetPointsDto { CourseTestId = testId, Points = points, SemesterCourseId = Id });
        }

        private async void OnWriteCommentCommand()
        {
            InvokeControllerMethod("Dashboard", "WriteComment", new EntityDto(SemesterCourse.CourseTemplateId));
        }

        private async void OnReplyCommentCommand(CommentDto comment)
        {
            InvokeControllerMethod("Dashboard", "WriteComment", new { Id = SemesterCourse.CourseTemplateId, CommentId = comment.Id});
        }

        public async void OnCommentCommand(CommentDto comment)
        {
            InvokeControllerMethod("Dashboard", "Comment", new { Id = SemesterCourse.CourseTemplateId, CommentId = comment.Id });
        }
    }
}
