using Abp.Domain.Services;
using Ahc.Club.Ahc.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Complaints.Services
{
    public interface IComplaintDomainService : IDomainService
    {
        IQueryable<Complaint> Get();
        Task<IList<Complaint>> GetAllAsync();
        Task<Complaint> GetByIdAsync(int id);
        Task<Complaint> CreateAsync(Complaint complaint);
        Task<Complaint> UpdateAsync(Complaint complaint);
        Task DeleteAsync(int id);
    }
}
