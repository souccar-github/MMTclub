using Abp.UI;
using Abp.Web.Models;
using Ahc.Club.Ahc.Categories.Dto;
using Ahc.Club.Ahc.Categories.Services;
using Ahc.Club.Models.Categories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahc.Club.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : ExchangeControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(
            IWebHostEnvironment webHostEnvironment,
            ICategoryAppService categoryAppService
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _categoryAppService = categoryAppService;
        }

        //[HttpPost]
        //public async Task<JsonResult> CreateCategory(CreateCategoryViewModel model)
        //{
        //    try
        //    {
        //        string fileName = "";
        //        string extension = "";
        //        if (model.Image != null)
        //        {
        //            extension = Path.GetExtension(model.Image.FileName);
        //            fileName = $"{Guid.NewGuid().ToString()}{extension}";
        //            var rootPath = _webHostEnvironment.WebRootPath;
        //            var filePath = rootPath + $"\\categories\\{fileName}";
        //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await model.Image.CopyToAsync(fileStream);
        //            }
        //        }

        //        var webPath = $"/categories/{fileName}";
        //        var inputDto = new CreateCategoryDto(model.Name, model.Description, model.Point, model.ParentCategoryId);
        //        inputDto.ImagePath = webPath;
        //        var category = await _categoryAppService.CreateAsync(inputDto);

        //        return Json(new AjaxResponse(new { result = category, success = true }));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        //[HttpPost]
        //public async Task<JsonResult> UpdateCategory(UpdateCategoryViewModel model)
        //{
        //    try
        //    {
        //        var categoryDto = await _categoryAppService.GetForEditAsync(model.Id);

        //        string fileName = "";
        //        string extension = "";
        //        if (model.Image != null)
        //        {
        //            extension = Path.GetExtension(model.Image.FileName);
        //            fileName = $"{Guid.NewGuid().ToString()}{extension}";
        //            var rootPath = _webHostEnvironment.WebRootPath;
        //            var filePath = rootPath + $"\\categories\\{fileName}";
        //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                //await model.Image.CopyToAsync(fileStream);
        //            }
        //        }

        //        //var webPath = $"/categories/{fileName}";
        //        //var inputDto = new UpdateCategoryDto(model.Name, model.Description, model.Point, model.ParentCategoryId);
        //        //inputDto.ImagePath = webPath;
        //        //var category = await _categoryAppService.UpdateAsync(inputDto);

        //        return Json(new AjaxResponse(new { result = new CategoryDto(), success = true }));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}
    }
}
