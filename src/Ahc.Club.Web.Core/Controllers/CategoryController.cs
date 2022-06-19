using Abp.UI;
using Abp.Web.Models;
using Ahc.Club.Models.Categories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahc.Club.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : ExchangeControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<JsonResult> CreateCategory(CreateCategoryViewModel model)
        {
            try
            {
                var files = Request.Form.Files;
                var rootPath = _webHostEnvironment.WebRootPath;
                foreach (var formFile in files)
                {
                    var fileName = formFile.FileName;
                    var filePath = rootPath + $"\\temp\\{fileName}";

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                        stream.Close();
                    }
                }

                return Json(new AjaxResponse(success: true));
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
}
