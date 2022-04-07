using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Comments.Dtos
{
    public class CommentRequestDto
    {
        public string CourseId { get; set; }

        public string Tag { get; set; }
    }
}
