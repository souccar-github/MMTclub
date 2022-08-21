using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Settings.Services
{
    public class GeneralSettingDomainService : IGeneralSettingDomainService
    {
        private readonly IRepository<GeneralSetting, int> _generalSettingRepository;
        public GeneralSettingDomainService(IRepository<GeneralSetting, int> generalSettingRepository)
        {
            _generalSettingRepository = generalSettingRepository;
        }
        public IQueryable<GeneralSetting> Get()
        {
            return _generalSettingRepository.GetAll();
        }
        public async Task<IList<GeneralSetting>> GetAllAsync()
        {
            return await _generalSettingRepository.GetAllListAsync();
        }
        public async Task<GeneralSetting> GetByIdAsync(int id)
        {
            return await _generalSettingRepository.FirstOrDefaultAsync(id);
        }
        public async Task<GeneralSetting> CreateAsync(GeneralSetting generalSetting)
        {
            return await _generalSettingRepository.InsertAsync(generalSetting);
        }
        public async Task<GeneralSetting> UpdateAsync(GeneralSetting generalSetting)
        {
            return await _generalSettingRepository.UpdateAsync(generalSetting);
        }
        public async Task DeleteAsync(int id)
        {
            var generalSetting = await _generalSettingRepository.FirstOrDefaultAsync(id);
            await _generalSettingRepository.DeleteAsync(generalSetting);
        }
    }
}

