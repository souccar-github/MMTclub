using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Settings.Services
{
    public interface IGeneralSettingDomainService : IDomainService
     {
        IQueryable<GeneralSetting> Get();
        Task<IList<GeneralSetting>> GetAllAsync();
        Task<GeneralSetting> GetByIdAsync(int id);
        Task<GeneralSetting> CreateAsync(GeneralSetting generalSetting);
        Task<GeneralSetting> UpdateAsync(GeneralSetting generalSetting);
        Task DeleteAsync(int id);
    }
}

