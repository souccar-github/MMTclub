using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public class QrCodeRequestDomainService : IQrCodeRequestDomainService
    {
        private readonly IRepository<QrCodeRequest, int> _qrCodeRequestRepository;
        public QrCodeRequestDomainService(IRepository<QrCodeRequest, int> qrCodeRequestRepository)
        {
            _qrCodeRequestRepository = qrCodeRequestRepository;
        }
        public IQueryable<QrCodeRequest> Get()
        {
            return _qrCodeRequestRepository.GetAll();
        }
        public async Task<IList<QrCodeRequest>> GetAllAsync()
        {
            return await _qrCodeRequestRepository.GetAllListAsync();
        }
        public async Task<QrCodeRequest> GetByIdAsync(int id)
        {
            return await _qrCodeRequestRepository.FirstOrDefaultAsync(id);
        }
        public async Task<QrCodeRequest> CreateAsync(QrCodeRequest qrCodeRequest)
        {
            return await _qrCodeRequestRepository.InsertAsync(qrCodeRequest);
        }
        public async Task<QrCodeRequest> UpdateAsync(QrCodeRequest qrCodeRequest)
        {
            return await _qrCodeRequestRepository.InsertOrUpdateAsync(qrCodeRequest);
        }
        public async Task DeleteAsync(int id)
        {
            var qrCodeRequest = await _qrCodeRequestRepository.FirstOrDefaultAsync(id);
            await _qrCodeRequestRepository.DeleteAsync(qrCodeRequest);
        }
    }
}

