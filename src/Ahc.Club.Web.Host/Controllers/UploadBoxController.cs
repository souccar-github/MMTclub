using Abp.UI;
using Abp.Web.Models;
using Ahc.Club.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ahc.Club.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UploadBoxController : ExchangeControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadBoxController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<JsonResult> Save()
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

        [HttpPost]
        public JsonResult Delete()
        {
            try
            {
                var files = Request.Form.Files;
                var rootPath = _webHostEnvironment.WebRootPath;
                foreach (var formFile in files)
                {
                    var fileName = formFile.FileName;
                    var filePath = rootPath + $"\\temp\\{fileName}";

                    System.IO.File.Delete(filePath);
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
