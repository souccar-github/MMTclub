using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Levels.Services
{
    public class LevelDomainService : ILevelDomainService
    {
        private readonly IRepository<Level, int> _levelRepository;
        public LevelDomainService(IRepository<Level, int> levelRepository)
        {
            _levelRepository = levelRepository;
        }
        public IQueryable<Level> Get()
        {
            return _levelRepository.GetAllIncluding(c => c.Gifts);
        }
        public async Task<IList<Level>> GetAllAsync()
        {
            return await _levelRepository.GetAllListAsync();
        }
        public async Task<Level> GetByIdAsync(int id)
        {
            return await _levelRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Level> CreateAsync(Level level)
        {
            return await _levelRepository.InsertAsync(level);
        }
        public async Task<Level> UpdateAsync(Level level)
        {
            return await _levelRepository.InsertOrUpdateAsync(level);
        }
        public async Task DeleteAsync(int id)
        {
            var level = await _levelRepository.FirstOrDefaultAsync(id);
            await _levelRepository.DeleteAsync(level);
        }

        public Level GetByPoint(double point)
        {
            return _levelRepository.GetAllIncluding(c => c.Gifts)
                .FirstOrDefault(x => x.Point >= point);
        }
    }
}

