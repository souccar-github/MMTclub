using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using Microsoft.AspNetCore.Hosting;
using Ahc.Club.Shared.Dto;
using Ahc.Club.Reflection.Extensions;
using Microsoft.AspNetCore.Http;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryAppService : ExchangeAppServiceBase, ICategoryAppService
    {
        private readonly ICategoryDomainService _categoryDomainService;
        private readonly ICategoryNewsDomainService _categoryNewsDomainService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryAppService(
            ICategoryDomainService categoryDomainService, 
            ICategoryNewsDomainService categoryNewsDomainService, 
            IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor)
        {
            _categoryDomainService = categoryDomainService;
            _categoryNewsDomainService = categoryNewsDomainService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
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

            return new ReadGrudDto() { result = data, count = 0, groupDs = groupDs };
        }
        public async Task<IList<CategoryDto>> GetAllAsync()
        {
            var list = await _categoryDomainService.GetAllAsync();
            var listDto = ObjectMapper.Map<IList<CategoryDto>>(list);
            //var baseUrl = GetBaseUrl();
            //foreach (var dto in listDto)
            //{
            //    if (!string.IsNullOrEmpty(dto.Image))
            //    {
            //        dto.Image = $"{baseUrl}/{dto.Image}";
            //    }
            //}
            return listDto;
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<CategoryDto>(category);
        }
        public async Task<UpdateCategoryDto> GetForEditAsync(int id)
        {
            var category = await _categoryDomainService.GetByIdAsync(id);
            var output = ObjectMapper.Map<UpdateCategoryDto>(category);

            if (!string.IsNullOrEmpty(category.Image))
            {
                var fileName = category.Image.GetFileName();
                var path = _webHostEnvironment.WebRootPath + "\\categories\\" + fileName;
                var file = new FileUploadDto();
                file.FileAsBase64 = path.GetBase64Data();
                file.FileName = fileName;
                file.FileType = file.FileName.GetFileType();
                file.FilePath = $"categories/{fileName}";
                output.Image = file;
            }

            return output;
        }
        public async Task<CreateCategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            var category = ObjectMapper.Map<Category>(categoryDto);

            if (categoryDto.Image != null)
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                category.Image = categoryDto.Image.SaveFileAndGetUrl(rootPath,"categories");
            }

            var createdCategory = await _categoryDomainService.CreateAsync(category);
            return ObjectMapper.Map<CreateCategoryDto>(createdCategory);

        }
        public async Task<UpdateCategoryDto> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = await _categoryDomainService.GetByIdAsync(categoryDto.Id);
            ObjectMapper.Map<UpdateCategoryDto, Category>(categoryDto, category);

            if (categoryDto.Image != null && category.Image.GetFileName() != categoryDto.Image.FileName)
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                category.Image = categoryDto.Image.SaveFileAndGetUrl(rootPath, "categories");
            }

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

        public IList<ParentCategoryDto> GetParent()
        {
            var parentCategories = _categoryDomainService.Get().Where(x => x.ParentCategoryId == null);
            var list = ObjectMapper.Map<List<ParentCategoryDto>>(parentCategories);

            foreach(var dto in list)
            {
                var news = _categoryNewsDomainService.GetByCategoryId(dto.Id, 3);
                if (news.Any())
                {
                    dto.News = ObjectMapper.Map<List<CategoryNewsDto>>(news);
                }
            }

            return list;
        }

        #region Helper Methods
        private string GetBaseUrl()
        {
            return $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";
        }

        
        #endregion
    }
}

