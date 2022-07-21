using Ahc.Club.Ahc.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryNewsAppService : ExchangeAppServiceBase, ICategoryNewsAppService
    {
        private readonly ICategoryNewsDomainService _newsDomainService;
        public CategoryNewsAppService(ICategoryNewsDomainService newsDomainService)
        {
            _newsDomainService = newsDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _newsDomainService.Get().ToList();
            IEnumerable<ReadCategoryNewsDto> data = ObjectMapper.Map<List<ReadCategoryNewsDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }

            IEnumerable groupDs = new List<CategoryNewsDto>();
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

            return new ReadGrudDto() { result = data, count = 0, groupDs = groupDs };
        }
        public async Task<IList<CategoryNewsDto>> GetAllAsync()
        {
            var list = await _newsDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<CategoryNewsDto>>(list);
        }
        public async Task<CategoryNewsDto> GetByIdAsync(int id)
        {
            var news = await _newsDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<CategoryNewsDto>(news);
        }
        public async Task<UpdateCategoryNewsDto> GetForEditAsync(int id)
        {
            var news = await _newsDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateCategoryNewsDto>(news);
        }
        public async Task<CreateCategoryNewsDto> CreateAsync(CreateCategoryNewsDto newsDto)
        {
            var news = ObjectMapper.Map<CategoryNews>(newsDto);
            var createdCategoryNews = await _newsDomainService.CreateAsync(news);
            return ObjectMapper.Map<CreateCategoryNewsDto>(createdCategoryNews);
        }
        public async Task<UpdateCategoryNewsDto> UpdateAsync(UpdateCategoryNewsDto newsDto)
        {
            var news = await _newsDomainService.GetByIdAsync(newsDto.Id);
            ObjectMapper.Map<UpdateCategoryNewsDto, CategoryNews>(newsDto, news);
            var updatedCategoryNews = await _newsDomainService.UpdateAsync(news);
            return ObjectMapper.Map<UpdateCategoryNewsDto>(updatedCategoryNews);
        }
        public async Task DeleteAsync(int id)
        {
            await _newsDomainService.DeleteAsync(id);
        }

        public IList<CategoryNewsDto> GetByCategoryId(int categoryId)
        {
            var categories = _newsDomainService.GetByCategoryId(categoryId);
            return ObjectMapper.Map<IList<CategoryNewsDto>>(categories);
        }
    }
}
