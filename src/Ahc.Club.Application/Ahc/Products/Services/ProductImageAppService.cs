using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Products.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.Products.Services
{
    public class ProductImageAppService : ExchangeAppServiceBase, IProductImageAppService
    {
        private readonly IProductImageDomainService _productImageDomainService;
        public ProductImageAppService(IProductImageDomainService productImageDomainService)
        {
            _productImageDomainService = productImageDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _productImageDomainService.Get().ToList();
            IEnumerable<ReadProductImageDto> data = ObjectMapper.Map<List<ReadProductImageDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<ProductImageDto>();
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
        public async Task<IList<ProductImageDto>> GetAllAsync()
        {
            var list = await _productImageDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<ProductImageDto>>(list);
        }
        public async Task<ProductImageDto> GetByIdAsync(int id)
        {
            var productImage = await _productImageDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<ProductImageDto>(productImage);
        }
        public async Task<UpdateProductImageDto> GetForEditAsync(int id)
        {
            var productImage = await _productImageDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateProductImageDto>(productImage);
        }
        public async Task<CreateProductImageDto> CreateAsync(CreateProductImageDto productImageDto)
        {
            var productImage = ObjectMapper.Map<ProductImage>(productImageDto);
            var createdProductImage = await _productImageDomainService.CreateAsync(productImage);
            return ObjectMapper.Map<CreateProductImageDto>(createdProductImage);
        }
        public async Task<UpdateProductImageDto> UpdateAsync(UpdateProductImageDto productImageDto)
        {
            var productImage = ObjectMapper.Map<ProductImage>(productImageDto);
            var updatedProductImage = await _productImageDomainService.UpdateAsync(productImage);
            return ObjectMapper.Map<UpdateProductImageDto>(updatedProductImage);
        }
        public async Task DeleteAsync(int id)
        {
            await _productImageDomainService.DeleteAsync(id);
        }
    }
}

