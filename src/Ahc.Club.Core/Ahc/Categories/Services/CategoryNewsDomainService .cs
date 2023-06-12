using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryNewsDomainService : ICategoryNewsDomainService
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly IRepository<CategoryNews, int> _newsRepository;
        public CategoryNewsDomainService(
            ILocalizationManager localizationManager,
            IRepository<CategoryNews, int> newsRepository
            )
        {
            _localizationManager = localizationManager;
            _newsRepository = newsRepository;
        }
        public IQueryable<CategoryNews> Get()
        {
            return _newsRepository.GetAllIncluding(p=>p.Category);
        }
        public IQueryable<CategoryNews> GetByCategoryId(int categoryId)
        {
            return Get().Where(x => x.CategoryId == categoryId);
        }
        public async Task<IList<CategoryNews>> GetAllAsync()
        {
            var news = await _newsRepository.GetAllListAsync();
            return news.OrderByDescending(x => x.CreationTime).ToList();
        }
        public async Task<CategoryNews> GetByIdAsync(int id)
        {
            return await _newsRepository.FirstOrDefaultAsync(id);
        }
        public async Task<CategoryNews> CreateAsync(CategoryNews news)
        {
            var id = await _newsRepository.InsertAndGetIdAsync(news);
            return await _newsRepository.GetAsync(id);
        }
        public async Task<CategoryNews> UpdateAsync(CategoryNews news)
        {
            return await _newsRepository.UpdateAsync(news);
        }
        public async Task DeleteAsync(int id)
        {
            var news = await _newsRepository.FirstOrDefaultAsync(id);
            await _newsRepository.DeleteAsync(news);
        }

        private new string L(string name)
        {
            return _localizationManager.GetString(ExchangeConsts.LocalizationSourceName, name);
        }

        public IList<CategoryNews> GetByCategoryId(int categoryId, int count)
        {
            return _newsRepository.GetAllList(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.Id).Take(count).ToList();
        }
    }
}

