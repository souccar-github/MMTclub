using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Logging;
using Abp.UI;
using Ahc.Club.Authorization.Users;
using Microsoft.EntityFrameworkCore;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public class QrCodeDomainService : IQrCodeDomainService
    {
        private readonly IRepository<QrCode, int> _qrCodeRepository;
        private readonly UserManager _userManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public QrCodeDomainService(IRepository<QrCode, int> qrCodeRepository, UserManager userManager, IUnitOfWorkManager unitOfWorkManager)
        {
            _qrCodeRepository = qrCodeRepository;
            _userManager = userManager;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public IQueryable<QrCode> Get()
        {
            return _qrCodeRepository.GetAllIncluding(u => u.User, p => p.Product, r => r.QrCodeRequest);
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

        public async Task<QrCode> ReadCode(string code, long userId)
        {
            QrCode updatedQrCode = null;

            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                var qrCode = await Get().FirstOrDefaultAsync(x => x.Code == code);
                if(qrCode == null)
                {
                    throw new UserFriendlyException("A problem occurred during the operation", LogSeverity.Error);
                }

                if (qrCode.IsTaken)
                {
                    throw new UserFriendlyException(3,"AlreadyTaken");
                }

                qrCode.UserId = userId;
                qrCode.IsTaken = true;
                await _userManager.IncreasePointsAsync(qrCode.Product.Point, userId);
                updatedQrCode = await _qrCodeRepository.UpdateAsync(qrCode);

                unitOfWork.Complete();
            }

            return updatedQrCode;
        }

        public async Task<IList<QrCode>> GetAllByRequestIdAsync(int requestId)
        {
            return await _qrCodeRepository.GetAllListAsync(x => x.QrCodeRequestId == requestId);
        }
    }
}

