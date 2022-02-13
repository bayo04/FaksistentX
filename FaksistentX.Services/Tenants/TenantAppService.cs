using FaksistentX.Services.Base;
using FaksistentX.Services.Tenants.Dtos;
using FaxistentX.Core;
using FaxistentX.Core.Tenants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaksistentX.Services.Tenants
{
    public class TenantAppService : BaseAppService
    {
        public async Task<List<TenantDto>> GetAllAsync()
        {
            var result = await GetListAsync<TenantDto>("services/app/Tenant/GetAll?userId=10004");

            return result.Result.Items;
        }

        public async Task SelectTenant(int tenantId)
        {
            var tenantDto = (await GetAllAsync()).FirstOrDefault(x => x.Id == tenantId);

            await SqliteDbContext.Instance.GetConnection().Table<Tenant>().DeleteAsync(x => true);

            await SqliteDbContext.Instance.GetConnection().InsertAsync(new Tenant
            {
                Id = tenantDto.Id,
                Name = tenantDto.Name,
                TenancyName = tenantDto.TenancyName,
                NoOfSemesters = tenantDto.NoOfSemesters,
            });
        }

        public async Task<TenantDto> GetSelectedTenant()
        {
            var table = SqliteDbContext.Instance.GetConnection().Table<Tenant>();

            if(await table.CountAsync() > 0)
            {
                var tenant = await SqliteDbContext.Instance.GetConnection().Table<Tenant>().FirstOrDefaultAsync();

                return new TenantDto
                {
                    Id = tenant.Id,
                    Name = tenant.Name,
                    TenancyName = tenant.TenancyName,
                    NoOfSemesters = tenant.NoOfSemesters,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
