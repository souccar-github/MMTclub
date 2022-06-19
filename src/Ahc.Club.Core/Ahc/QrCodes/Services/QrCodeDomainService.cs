using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public class QrCodeDomainService : IQrCodeDomainService
    {
        private readonly IRepository<QrCode, int> _qrCodeRepository;
        public QrCodeDomainService(IRepository<QrCode, int> qrCodeRepository)
        {
            _qrCodeRepository = qrCodeRepository;
        }
        public IQueryable<QrCode> Get()
        {
            return _qrCodeRepository.GetAll();
        }
        public async Task<IList<QrCode>> GetAllAsync()
        {
            return await _qrCodeRepository.GetAllListAsync();
        }
        public async Task<QrCode> GetByIdAsync(int id)
        {
            return await _qrCodeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<QrCode> CreateAsync(QrCode qrCode)
        {
            return await _qrCodeRepository.InsertAsync(qrCode);
        }
        public async Task<QrCode> UpdateAsync(QrCode qrCode)
        {
            return await _qrCodeRepository.InsertOrUpdateAsync(qrCode);
        }
        public async Task DeleteAsync(int id)
        {
            var qrCode = await _qrCodeRepository.FirstOrDefaultAsync(id);
            await _qrCodeRepository.DeleteAsync(qrCode);
        }
    }
}

