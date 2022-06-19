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
    public class ProductSizeAppService : ExchangeAppServiceBase, IProductSizeAppService
    {
        private readonly IProductSizeDomainService _productSizeDomainService;
        public ProductSizeAppService(IProductSizeDomainService productSizeDomainService)
        {
            _productSizeDomainService = productSizeDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _productSizeDomainService.Get().ToList();
            IEnumerable<ReadProductSizeDto> data = ObjectMapper.Map<List<ReadProductSizeDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<ProductSizeDto>();
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
        public async Task<IList<ProductSizeDto>> GetAllAsync()
        {
            var list = await _productSizeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<ProductSizeDto>>(list);
        }
        public async Task<ProductSizeDto> GetByIdAsync(int id)
        {
            var productSize = await _productSizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<ProductSizeDto>(productSize);
        }
        public async Task<UpdateProductSizeDto> GetForEditAsync(int id)
        {
            var productSize = await _productSizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateProductSizeDto>(productSize);
        }
        public async Task<CreateProductSizeDto> CreateAsync(CreateProductSizeDto productSizeDto)
        {
            var productSize = ObjectMapper.Map<ProductSize>(productSizeDto);
            var createdProductSize = await _productSizeDomainService.CreateAsync(productSize);
            return ObjectMapper.Map<CreateProductSizeDto>(createdProductSize);
        }
        public async Task<UpdateProductSizeDto> UpdateAsync(UpdateProductSizeDto productSizeDto)
        {
            var productSize = ObjectMapper.Map<ProductSize>(productSizeDto);
            var updatedProductSize = await _productSizeDomainService.UpdateAsync(productSize);
            return ObjectMapper.Map<UpdateProductSizeDto>(updatedProductSize);
        }
        public async Task DeleteAsync(int id)
        {
            await _productSizeDomainService.DeleteAsync(id);
        }
    }
}

