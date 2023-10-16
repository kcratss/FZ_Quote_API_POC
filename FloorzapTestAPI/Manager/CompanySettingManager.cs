using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Model;
using Microsoft.Extensions.Caching.Memory;
namespace FloorzapTestAPI.Manager
{
    public class CompanySettingManager : ICompanySettingManager
    {
        private readonly IMemoryCache cacheProvider;
        private readonly IRepository<CompanySetting> repository;

        public CompanySettingManager(IMemoryCache cacheProvider, IRepository<CompanySetting> repository)
        {
            this.cacheProvider = cacheProvider;
            this.repository = repository;
        }
        public async Task<CompanySetting> GetCompanySettingAsync()
        {
            CompanySetting? companySetting;
            cacheProvider.TryGetValue("CompanySettings", out companySetting);
            if (companySetting is null)
            {
                companySetting = await repository.ExecuteSPSingleAsync("CompanySettingSelectAll");
                cacheProvider.Set<CompanySetting>("CompanySettings", companySetting);
            }

            return companySetting;
        }
    }
}
