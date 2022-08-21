using Abp.ObjectMapping;
using Ahc.Club.Ahc.Complaints.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Complaints.Services
{
    public class ComplaintAppService : ExchangeAppServiceBase,IComplaintAppService
    {
        private readonly IComplaintDomainService _complaintDomainService;
        public ComplaintAppService(IComplaintDomainService complaintDomainService)
        {
            _complaintDomainService = complaintDomainService;
        }
        public async Task<ComplaintDto> CreateAsync(ComplaintDto complaintdto)
        {
            var complaint = ObjectMapper.Map<Complaint>(complaintdto);
            var createdComplaint = await _complaintDomainService.CreateAsync(complaint);
            return ObjectMapper.Map<ComplaintDto>(createdComplaint);
        }

        public async Task DeleteAsync(int id)
        {
            await _complaintDomainService.DeleteAsync(id);
        }

        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ComplaintDto>> GetAllAsync()
        {
            var list = await _complaintDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<ComplaintDto>>(list);
        }

        public async Task<ComplaintDto> GetByIdAsync(int id)
        {
            var complaint = await _complaintDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<ComplaintDto>(complaint);
        }

        public async Task<ComplaintDto> UpdateAsync(ComplaintDto complaintDto)
        {
            var complaint = await _complaintDomainService.GetByIdAsync(complaintDto.Id);
            ObjectMapper.Map<ComplaintDto, Complaint>(complaintDto, complaint);
            var updatedComplaint = await _complaintDomainService.UpdateAsync(complaint);
            return ObjectMapper.Map<ComplaintDto>(updatedComplaint);
        }
    }
}
