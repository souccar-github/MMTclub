using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Levels.Services
{
    public interface ILevelDomainService : IDomainService
     {
        IQueryable<Level> Get();
        Task<IList<Level>> GetAllAsync();
        IList<Level> GetAllLevel();
        Task<Level> GetByIdAsync(int id);
        Task<Level> CreateAsync(Level level);
        Task<Level> UpdateAsync(Level level);
        Task DeleteAsync(int id);
        Level GetByPoint(double point);
        public Level GetFirstLevel();
        public Level GetLastLevel();
    }
}

