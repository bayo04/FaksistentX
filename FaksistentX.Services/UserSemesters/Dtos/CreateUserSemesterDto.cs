using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.Dtos
{
    public class CreateUserSemesterDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SemesterNo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
