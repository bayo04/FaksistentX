using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Core.UserSemesters
{
    public class UserSemester
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SemesterNo { get; set; }

        public bool IsSelected { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Color => IsSelected ? "GreenYellow" : "White";
    }
}
