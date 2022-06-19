using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryAppService : ExchangeAppServiceBase, ICategoryAppService
    {
        private readonly ICategoryDomainService _categoryDomainService;
        public CategoryAppService(ICategoryDomainService categoryDomainService)
        {
            _categoryDomainService = categoryDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _categoryDomainService.Get().ToList();
            IEnumerable<ReadCategoryDto> data = ObjectMapper.Map<List<ReadCategoryDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<CategoryDto>();
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
        public async Task<IList<CategoryDto>> GetAllAsync()
        {
            var list = await _categoryDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<CategoryDto>>(list);
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<CategoryDto>(category);
        }
        public async Task<UpdateCategoryDto> GetForEditAsync(int id)
        {
            var category = await _categoryDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateCategoryDto>(category);
        }
        public async Task<CreateCategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            var category = ObjectMapper.Map<Category>(categoryDto);
            var createdCategory = await _categoryDomainService.CreateAsync(category);
            return ObjectMapper.Map<CreateCategoryDto>(createdCategory);
        }
        public async Task<UpdateCategoryDto> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = ObjectMapper.Map<Category>(categoryDto);
            var updatedCategory = await _categoryDomainService.UpdateAsync(category);
            return ObjectMapper.Map<UpdateCategoryDto>(updatedCategory);
        }
        public async Task DeleteAsync(int id)
        {
            await _categoryDomainService.DeleteAsync(id);
        }

        public IList<CategoryForDropdownDto> GetAllForDropdown()
        {
            var categories = _categoryDomainService.Get().ToList();
            return ObjectMapper.Map<List<CategoryForDropdownDto>>(categories);
        }

        #region Helper Methods

        #endregion
    }
}

