using Ahc.Club.Ahc.Categories.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ahc.Club.Reflection.Extensions;
using System.Threading.Tasks;
using Ahc.Club.Shared.Dto;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryNewsAppService : ExchangeAppServiceBase, ICategoryNewsAppService
    {
        private readonly ICategoryNewsDomainService _newsDomainService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CategoryNewsAppService(
            ICategoryNewsDomainService newsDomainService, 
            IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor)
        {
            _newsDomainService = newsDomainService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
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
            var output = ObjectMapper.Map<UpdateCategoryNewsDto>(news);

            if (!string.IsNullOrEmpty(news.Image))
            {
                var fileName = news.Image.GetFileName();
                var path = _webHostEnvironment.WebRootPath + "\\news\\" + fileName;
                var file = new FileUploadDto();
                file.FileAsBase64 = path.GetBase64Data();
                file.FileName = fileName;
                file.FileType = file.FileName.GetFileType();
                file.FilePath = $"news/{fileName}";
                output.Image = file;
            }

            return output;
        }
        public async Task<CreateCategoryNewsDto> CreateAsync(CreateCategoryNewsDto categoryNewsDto)
        {
            var categoryNews = ObjectMapper.Map<CategoryNews>(categoryNewsDto);

            if (categoryNewsDto.Image != null)
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                categoryNews.Image = categoryNewsDto.Image.SaveFileAndGetUrl(rootPath, "news");
            }

            var createdCategoryNews = await _newsDomainService.CreateAsync(categoryNews);
            return ObjectMapper.Map<CreateCategoryNewsDto>(createdCategoryNews);
        }
        public async Task<UpdateCategoryNewsDto> UpdateAsync(UpdateCategoryNewsDto newsDto)
        {
            var categoryNews = await _newsDomainService.GetByIdAsync(newsDto.Id);
            ObjectMapper.Map<UpdateCategoryNewsDto, CategoryNews>(newsDto, categoryNews);

            if (newsDto.Image != null && categoryNews.Image.GetFileName() != newsDto.Image.FileName)
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                categoryNews.Image = newsDto.Image.SaveFileAndGetUrl(rootPath, "categories");
            }

            var updatedCategoryNews = await _newsDomainService.UpdateAsync(categoryNews);
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
