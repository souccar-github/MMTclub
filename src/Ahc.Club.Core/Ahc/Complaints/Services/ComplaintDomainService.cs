using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using Abp.Runtime.Session;
using Ahc.Club.Authorization.Users;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Complaints.Services
{
    public class ComplaintDomainService : IComplaintDomainService
    {
        public IAbpSession AbpSession { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ILocalizationManager _localizationManager;
        private readonly UserManager _userManager;
        private readonly IRepository<Complaint, int> _complaintRepository;
        public ComplaintDomainService(IUnitOfWorkManager unitOfWorkManager,
            ILocalizationManager localizationManager, 
            UserManager userManager,
            IRepository<Complaint, int> complaintRepository
            )
        {
            _unitOfWorkManager = unitOfWorkManager;
            _localizationManager = localizationManager;
            _complaintRepository = complaintRepository;
            _userManager = userManager;
            AbpSession = NullAbpSession.Instance;
        }
        public async Task<Complaint> CreateAsync(Complaint complaint)
        {
            int id;
            complaint.ComplaintDate = DateTime.Now;
            var userId = AbpSession.UserId;
            complaint.UserId = AbpSession.UserId;
            var user = _userManager.GetUserById(userId??0);
            complaint.User = user;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {

                id = await _complaintRepository.InsertAndGetIdAsync(complaint);

                unitOfWork.Complete();
            }
            return await _complaintRepository.GetAsync(id); ;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _complaintRepository.FirstOrDefaultAsync(id);
            await _complaintRepository.DeleteAsync(category);
        }
        public async Task<Complaint> UpdateAsync(Complaint complaint)
        {
            Complaint updatedComplaint;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {

                updatedComplaint = await _complaintRepository.UpdateAsync(complaint);

                unitOfWork.Complete();
            }

            return updatedComplaint;
        }

        public IQueryable<Complaint> Get()
        {
            return _complaintRepository.GetAllIncluding(x => x.User);
        }



        async Task <IList<Complaint>> IComplaintDomainService.GetAllAsync()
        {
            return await _complaintRepository.GetAllListAsync();
        }

        async Task<Complaint> IComplaintDomainService.GetByIdAsync(int id)
        {
            return await _complaintRepository.FirstOrDefaultAsync(id);
        }
    }
}
