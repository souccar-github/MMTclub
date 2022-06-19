using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public interface IQrCodeDomainService : IDomainService
     {
        IQueryable<QrCode> Get();
        Task<IList<QrCode>> GetAllAsync();
        Task<QrCode> GetByIdAsync(int id);
        Task<QrCode> CreateAsync(QrCode qrCode);
        Task<QrCode> UpdateAsync(QrCode qrCode);
        Task DeleteAsync(int id);
    }
}

