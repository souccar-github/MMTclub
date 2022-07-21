using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public interface IQrCodeRequestDomainService : IDomainService
     {
        IQueryable<QrCodeRequest> Get();
        Task<IList<QrCodeRequest>> GetAllAsync();
        Task<QrCodeRequest> GetByIdAsync(int id);
        Task<QrCodeRequest> CreateAsync(QrCodeRequest qrCodeRequest);
        Task<QrCodeRequest> UpdateAsync(QrCodeRequest qrCodeRequest);
        Task DeleteAsync(int id);
    }
}

