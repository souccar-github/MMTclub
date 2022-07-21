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
    public class ProductAppService : ExchangeAppServiceBase, IProductAppService
    {
        private readonly IProductDomainService _productDomainService;
        public ProductAppService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _productDomainService.Get().ToList();
            IEnumerable<ReadProductDto> data = ObjectMapper.Map<List<ReadProductDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }

            IEnumerable groupDs = new List<ProductDto>();
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
        public async Task<IList<ProductDto>> GetAllAsync()
        {
            var list = await _productDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<ProductDto>>(list);
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<ProductDto>(product);
        }
        public async Task<UpdateProductDto> GetForEditAsync(int id)
        {
            var product = await _productDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateProductDto>(product);
        }
        public async Task<CreateProductDto> CreateAsync(CreateProductDto productDto)
        {
            var product = ObjectMapper.Map<Product>(productDto);
            var createdProduct = await _productDomainService.CreateAsync(product);
            return ObjectMapper.Map<CreateProductDto>(createdProduct);
        }
        public async Task<UpdateProductDto> UpdateAsync(UpdateProductDto productDto)
        {
            var product = await _productDomainService.GetByIdAsync(productDto.Id);
            ObjectMapper.Map<UpdateProductDto, Product>(productDto, product);
            var updatedProduct = await _productDomainService.UpdateAsync(product);
            return ObjectMapper.Map<UpdateProductDto>(updatedProduct);
        }
        public async Task DeleteAsync(int id)
        {
            await _productDomainService.DeleteAsync(id);
        }
    }
}

