using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Indexes.Services
{
    public class SizeDomainService : ISizeDomainService
    {
        private readonly IRepository<Size, int> _sizeRepository;
        public SizeDomainService(IRepository<Size, int> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        public IQueryable<Size> Get()
        {
            return _sizeRepository.GetAll();
        }
        public async Task<IList<Size>> GetAllAsync()
        {
            return await _sizeRepository.GetAllListAsync();
        }
        public async Task<Size> GetByIdAsync(int id)
        {
            return await _sizeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Size> CreateAsync(Size size)
        {
            return await _sizeRepository.InsertAsync(size);
        }
        public async Task<Size> UpdateAsync(Size size)
        {
            return await _sizeRepository.InsertOrUpdateAsync(size);
        }
        public async Task DeleteAsync(int id)
        {
            var size = await _sizeRepository.FirstOrDefaultAsync(id);
            await _sizeRepository.DeleteAsync(size);
        }
    }
}

