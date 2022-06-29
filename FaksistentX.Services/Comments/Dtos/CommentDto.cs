using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Comments.Dtos
{
    public class CommentDto
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string ParentId { get; set; }

        public string CourseId { get; set; }

        public string Tag { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatorUserUserName { get; set; }

        public string UserText => CreatorUserUserName + (!string.IsNullOrEmpty(Tag) ? " za " + Tag : "");

        public string CreationTimeString => CreationTime.ToString("HH:mm dd.MM.yyyy");

        public List<CommentDto> Children { get; set; }

        public string NoOfReplies => Children.Count.ToString() + " odgovora";
    }
}
