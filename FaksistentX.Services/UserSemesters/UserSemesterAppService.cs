using FaksistentX.Services.Base;
using FaksistentX.Services.UserSemesters.Dtos;
using FaxistentX.Core;
using FaxistentX.Core.Base;
using FaxistentX.Core.UserSemesters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters
{
    public class UserSemesterAppService : BaseAppService
    {
        public async Task<List<UserSemesterDto>> GetAllAsync()
        {
            var result = await GetListAsync<UserSemesterDto>("services/app/UserSemester/GetAll");

            await WriteToDb(result.Result.Items);

            return result.Result.Items;
        }

        public async Task WriteToDb(List<UserSemesterDto> list)
        {
            await SqliteDbContext.Instance.GetConnection().Table<UserSemester>().DeleteAsync(x => true);

            await SqliteDbContext.Instance.GetConnection().InsertAllAsync(list.Select(x => new UserSemester
            {
                Id = x.Id,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                IsSelected = x.IsSelected,
                Name = x.Name,
                SemesterNo = x.SemesterNo
            }));
        }

        public async Task<UserSemesterDto> GetAsync(string id)
        {
            var result = await GetAsync<UserSemesterDto>("services/app/UserSemester/Get", new EntityDto(id));

            return result.Result;
        }

        public async Task<UserSemesterDto> CreateOrEditAsync(CreateUserSemesterDto input)
        {
            if (!string.IsNullOrEmpty(input.Id))
            {
                var result = await PutAsync<UserSemesterDto>("services/app/UserSemester/Update", input);

                GetAllAsync();

                return result.Result;
            }
            else
            {
                var result = await PostAsync<UserSemesterDto>("services/app/UserSemester/Create", input);

                GetAllAsync();

                return result.Result;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await DeleteAsync<UserSemesterDto>("services/app/UserSemester/Delete", new EntityDto(id));

            GetAllAsync();

            return result.Success;
        }

        public async Task<bool> SetIsSelectedAsync(string id)
        {
            var result = await PostAsync<UserSemesterDto>("services/app/UserSemester/SetIsSelected", new EntityDto(id));

            await GetAllAsync();

            return result.Success;
        }

        public async Task<UserSemesterDto> GetSelectedAsync()
        {
            try
            {
                var table = SqliteDbContext.Instance.GetConnection().Table<UserSemester>();
                if ((await SqliteDbContext.Instance.GetConnection().Table<UserSemester>().ToListAsync()).Any()){

                    var semester = await SqliteDbContext.Instance.GetConnection().Table<UserSemester>().FirstOrDefaultAsync(x => x.IsSelected);

                    return new UserSemesterDto
                    {
                        Id = semester.Id,
                        EndDate = semester.EndDate,
                        IsSelected = semester.IsSelected,
                        Name = semester.Name,
                        SemesterNo = semester.SemesterNo,
                        StartDate = semester.StartDate
                    };
                }
                else { return null; }
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<UserSemesterDto> GetSelectedFromApiAsync()
        {
            var result = await GetAsync<UserSemesterDto>("services/app/UserSemester/GetSelected");

            return result.Result;
        }
    }
}
