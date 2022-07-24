using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using Abp.UI;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ILocalizationManager _localizationManager;
        private readonly IRepository<Category, int> _categoryRepository;
        public CategoryDomainService(
            IUnitOfWorkManager unitOfWorkManager,
            ILocalizationManager localizationManager,
            IRepository<Category, int> categoryRepository
            )
        {
            _unitOfWorkManager = unitOfWorkManager;
            _localizationManager = localizationManager;
            _categoryRepository = categoryRepository;
        }
        public IQueryable<Category> Get()
        {
            return _categoryRepository.GetAllIncluding(p=>p.ParentCategory);
        }
        public async Task<IList<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllListAsync();
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Category> CreateAsync(Category category)
        {
            int id;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                var nameAlreadyExist = await CheckIfCategoryNameExistAsync(category.Id, category.Name);
                if (nameAlreadyExist)
                {
                    throw new UserFriendlyException(L(ExchangeConsts.TheNameAlreadyExist));
                }

                id = await _categoryRepository.InsertAndGetIdAsync(category);

                unitOfWork.Complete();
            }
            return await _categoryRepository.GetAsync(id); ;
        }
        public async Task<Category> UpdateAsync(Category category)
        {
            Category updatedCategory;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                var nameAlreadyExist = await CheckIfCategoryNameExistAsync(category.Id, category.Name);
                if (nameAlreadyExist)
                {
                    throw new UserFriendlyException(L(ExchangeConsts.TheNameAlreadyExist));
                }

                updatedCategory = await _categoryRepository.UpdateAsync(category);

                unitOfWork.Complete();
            }

            return updatedCategory;
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        private async Task<bool> CheckIfCategoryNameExistAsync(int id, string name)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Name == name && x.Id != id);
            return category != null;
        }

        private new string L(string name)
        {
            return _localizationManager.GetString(ExchangeConsts.LocalizationSourceName, name);
        }

        
    }
}

