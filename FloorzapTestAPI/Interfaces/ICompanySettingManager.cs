using FloorzapTestAPI.Model;

namespace FloorzapTestAPI.Interfaces
{
    public interface ICompanySettingManager
    {
        Task<CompanySetting> GetCompanySettingAsync();
    }
}