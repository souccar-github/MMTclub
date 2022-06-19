using Ahc.Club.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahc.Club.Shared.Interfaces
{
    public interface ICrudEjAppService<IReadDto, ICreateDto, IUpdateDto> 
        where IReadDto : class
        where ICreateDto : class
        where IUpdateDto : class
    {
        Task<IList<IReadDto>> GetAllAsync();
        ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm);
        IUpdateDto GetForEdit(int id);
        Task<IReadDto> CreateAsync(ICreateDto input);
        Task<IReadDto> UpdateAsync(IUpdateDto input);
        Task DeleteAsync(int id);
    }
}
