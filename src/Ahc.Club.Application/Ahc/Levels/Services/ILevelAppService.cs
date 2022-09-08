using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Levels.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Levels.Services
{
    public interface ILevelAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<LevelDto>> GetAllAsync();
        IList<LevelDto> GetAllLevel();
        LevelDto GetByOrder(int? order);
        Task<LevelDto> GetByIdAsync(int id);
        Task<UpdateLevelDto> GetForEditAsync(int id);
        Task<CreateLevelDto> CreateAsync(CreateLevelDto level);
        Task<UpdateLevelDto> UpdateAsync(UpdateLevelDto level);
        Task DeleteAsync(int id);
        LevelDto GetByPoint(double point);
        LevelDto GetFirstLevel();
    }
}

