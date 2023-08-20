using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Products.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using Ahc.Club.Reflection.Extensions;
using Ahc.Club.Shared.Dto;
using Microsoft.AspNetCore.Hosting;

namespace Ahc.Club.Ahc.Products.Services
{
    public class ProductAppService : ExchangeAppServiceBase, IProductAppService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductAppService(IProductDomainService productDomainService, IWebHostEnvironment webHostEnvironment)
        {
            _productDomainService = productDomainService;
            _webHostEnvironment = webHostEnvironment;
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
            var output = ObjectMapper.Map<UpdateProductDto>(product);

            if (!string.IsNullOrEmpty(product.FirstImage))
            {
                output.FirstImage = GenerateUploadDtoFile(product.FirstImage);
            }
            if (!string.IsNullOrEmpty(product.SecondImage))
            {
                output.SecondImage = GenerateUploadDtoFile(product.SecondImage);
            }
            if (!string.IsNullOrEmpty(product.ThirdImage))
            {
                output.ThirdImage = GenerateUploadDtoFile(product.ThirdImage);
            }

            return output;
        }
        public async Task<CreateProductDto> CreateAsync(CreateProductDto productDto)
        {
            var Product = ObjectMapper.Map<Product>(productDto);

            var rootPath = _webHostEnvironment.WebRootPath;

            if (productDto.FirstImage != null)
            {
                Product.FirstImage = productDto.FirstImage.SaveFileAndGetUrl(rootPath, "products");
            }

            if (productDto.SecondImage != null)
            {
                Product.SecondImage = productDto.SecondImage.SaveFileAndGetUrl(rootPath, "products");
            }

            if (productDto.ThirdImage != null)
            {
                Product.ThirdImage = productDto.ThirdImage.SaveFileAndGetUrl(rootPath, "products");
            }

            var createdProduct = await _productDomainService.CreateAsync(Product);
            return ObjectMapper.Map<CreateProductDto>(createdProduct);
        }
        public async Task<UpdateProductDto> UpdateAsync(UpdateProductDto productDto)
        {
            var Product = await _productDomainService.GetByIdAsync(productDto.Id);
            ObjectMapper.Map<UpdateProductDto, Product>(productDto, Product);

            var rootPath = _webHostEnvironment.WebRootPath;

            if (productDto.FirstImage != null && Product.FirstImage.GetFileName() != productDto.FirstImage.FileName)
            {
                Product.FirstImage = productDto.FirstImage.SaveFileAndGetUrl(rootPath, "products");
            }

            if (productDto.SecondImage != null && Product.SecondImage.GetFileName() != productDto.SecondImage.FileName)
            {
                Product.SecondImage = productDto.SecondImage.SaveFileAndGetUrl(rootPath, "products");
            }

            if (productDto.ThirdImage != null && Product.ThirdImage.GetFileName() != productDto.ThirdImage.FileName)
            {
                Product.ThirdImage = productDto.ThirdImage.SaveFileAndGetUrl(rootPath, "products");
            }

            var updatedProduct = await _productDomainService.UpdateAsync(Product);
            return ObjectMapper.Map<UpdateProductDto>(updatedProduct);
        }
        public async Task DeleteAsync(int id)
        {
            await _productDomainService.DeleteAsync(id);
        }

        public IList<ProductDto> GetProducts(int? categoryId, string keyword, int skip,int take)
        {
            //var  products = _productDomainService.Get().Where(x =>
            //(categoryId != null && x.CategoryId == categoryId) &&
            //(!string.IsNullOrEmpty(keyword) && x.Name.Contains(keyword))
            //).ToList();

            IEnumerable<Product> products = _productDomainService.Get();
            if(categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            }
            if(categoryId == null)
            {
                products = products.Skip(skip * take).Take(take);
            }

            return ObjectMapper.Map<List<ProductDto>>(products);
        }

        private FileUploadDto GenerateUploadDtoFile(string image)
        {
            var file = new FileUploadDto();
            try
            {
                var fileName = image.GetFileName();
                var path = _webHostEnvironment.WebRootPath + "\\products\\" + fileName;

                file.FileAsBase64 = path.GetBase64Data();
                file.FileName = fileName;
                file.FileType = file.FileName.GetFileType();
                file.FilePath = $"products/{fileName}";

            }
            catch { }
            return file;
        }
    }
}

