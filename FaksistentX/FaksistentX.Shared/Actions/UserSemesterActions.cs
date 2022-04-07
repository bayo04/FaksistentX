using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.Actions
{
    public class UserSemesterActions
    {
        public void GetCurrentSemester()
        {
            DependencyService.Get<Dispatcher>().Invoke<object>(UserSemesterActionTypes.GET_SEMESTER, null);
        }
    }

    public class UserSemesterActionTypes
    {
        public const string GET_SEMESTER = "get_semester";
    }
}
