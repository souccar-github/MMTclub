using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Levels.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.Levels.Services
{
    public class LevelAppService : ExchangeAppServiceBase, ILevelAppService
    {
        private readonly ILevelDomainService _levelDomainService;
        public LevelAppService(ILevelDomainService levelDomainService)
        {
            _levelDomainService = levelDomainService;
        }

        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _levelDomainService.Get().OrderBy(x => x.Order).ToList();
            IEnumerable<ReadLevelDto> data = ObjectMapper.Map<List<ReadLevelDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<LevelDto>();
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
            
            return new ReadGrudDto() { result = data,count = 0, groupDs = groupDs };
        }
        public async Task<IList<LevelDto>> GetAllAsync()
        {
            var list = await _levelDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<LevelDto>>(list);
        }
        public async Task<LevelDto> GetByIdAsync(int id)
        {
            var level = await _levelDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<LevelDto>(level);
        }
        public async Task<UpdateLevelDto> GetForEditAsync(int id)
        {
            var level = await _levelDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateLevelDto>(level);
        }
        public async Task<CreateLevelDto> CreateAsync(CreateLevelDto levelDto)
        {
            var level = ObjectMapper.Map<Level>(levelDto);
            var createdLevel = await _levelDomainService.CreateAsync(level);
            return ObjectMapper.Map<CreateLevelDto>(createdLevel);
        }
        public async Task<UpdateLevelDto> UpdateAsync(UpdateLevelDto levelDto)
        {
            var level = ObjectMapper.Map<Level>(levelDto);
            var updatedLevel = await _levelDomainService.UpdateAsync(level);
            return ObjectMapper.Map<UpdateLevelDto>(updatedLevel);
        }
        public async Task DeleteAsync(int id)
        {
            await _levelDomainService.DeleteAsync(id);
        }

        public LevelDto GetByPoint(double point)
        {
            var level = _levelDomainService.GetByPoint(point);
            return ObjectMapper.Map<LevelDto>(level);
        }

        public LevelDto GetByOrder(int? order)
        {
            if (order == null)
            {
                order = _levelDomainService.Get().Min(x => x.Order);
            }

            var level = _levelDomainService.Get().FirstOrDefault(x => x.Order == order);

            return ObjectMapper.Map<LevelDto>(level);
        }

        public LevelDto GetFirstLevel()
        {
            var level = _levelDomainService.GetFirstLevel();
            return ObjectMapper.Map<LevelDto>(level);
        }

        public IList<LevelDto> GetAllLevel()
        {
            var levels = _levelDomainService.GetAllLevel();
            return ObjectMapper.Map<List<LevelDto>>(levels);
        }
    }
}

