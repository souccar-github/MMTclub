using Abp.Application.Services;
using Ahc.Club.Ahc.Complaints.Dto;
using Ahc.Club.Ahc.Products.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Complaints.Services
{
    public interface IComplaintAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<ComplaintDto>> GetAllAsync();
        Task<ComplaintDto> GetByIdAsync(int id);
        Task<ComplaintDto> CreateAsync(ComplaintDto complaint);
        Task<ComplaintDto> UpdateAsync(ComplaintDto complaint);
        Task DeleteAsync(int id);
    }
}
