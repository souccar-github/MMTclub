using Abp.ObjectMapping;
using Ahc.Club.Ahc.Complaints.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _complaintDomainService.Get().ToList();
            IEnumerable<ReadComplaintDto> data = ObjectMapper.Map<List<ReadComplaintDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }

            if (dm.Sorted != null)
            {
                data = operations.PerformSorting(data, dm.Sorted);
            }

            IEnumerable groupDs = new List<ReadComplaintDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformGrouping(data, dm.Group);
            }

            var count = data.Count();
            if (dm.Skip != 0)
            {
                data = operations.PerformSkip(data, dm.Skip);
            }

            if (dm.Take != 0)
            {
                data = operations.PerformTake(data, dm.Take);
            }

            return new ReadGrudDto() { result = data, count = count, groupDs = groupDs };
        }

    }
}
