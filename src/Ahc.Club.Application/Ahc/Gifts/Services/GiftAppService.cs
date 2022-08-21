using Ahc.Club.Ahc.Gifts.Dto;
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
using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public class GiftAppService : ExchangeAppServiceBase, IGiftAppService
    {
        private readonly IGiftDomainService _giftDomainService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GiftAppService(
            IGiftDomainService giftDomainService,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            _giftDomainService = giftDomainService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public ReadGrudDto Get([FromBody] AhcDataManagerRequest dm)
        {
            var list = _giftDomainService.GetByLevelId(dm.id).ToList();
            IEnumerable<ReadGiftDto> data = ObjectMapper.Map<List<ReadGiftDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }

            IEnumerable groupDs = new List<GiftDto>();
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
        public async Task<IList<GiftDto>> GetAllAsync()
        {
            var list = await _giftDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<GiftDto>>(list);
        }
        public async Task<GiftDto> GetByIdAsync(int id)
        {
            var gift = await _giftDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<GiftDto>(gift);
        }
        public async Task<UpdateGiftDto> GetForEditAsync(int id)
        {
            var gift = await _giftDomainService.GetByIdAsync(id);
            var output = ObjectMapper.Map<UpdateGiftDto>(gift);

            if (!string.IsNullOrEmpty(gift.Image))
            {
                var file = new FileUploadDto();
                try
                {
                    var fileName = gift.Image.GetFileName();
                    var path = _webHostEnvironment.WebRootPath + "\\gift\\" + fileName;

                    file.FileAsBase64 = path.GetBase64Data();
                    file.FileName = fileName;
                    file.FileType = file.FileName.GetFileType();
                    file.FilePath = $"gift/{fileName}";
                    output.Image = file;
                }
                catch { }
            }

            return output;
        }
        public async Task<CreateGiftDto> CreateAsync(CreateGiftDto giftDto)
        {
            var gift = ObjectMapper.Map<Gift>(giftDto);

            if (giftDto.Image != null)
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                gift.Image = giftDto.Image.SaveFileAndGetUrl(rootPath, "gift");
            }

            var createdGift = await _giftDomainService.CreateAsync(gift);
            return ObjectMapper.Map<CreateGiftDto>(createdGift);
        }
        public async Task<UpdateGiftDto> UpdateAsync(UpdateGiftDto giftDto)
        {
            var gift = await _giftDomainService.GetByIdAsync(giftDto.Id);
            ObjectMapper.Map<UpdateGiftDto, Gift>(giftDto, gift);

            if (giftDto.Image != null && gift.Image.GetFileName() != giftDto.Image.FileName)
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                gift.Image = giftDto.Image.SaveFileAndGetUrl(rootPath, "gift");
            }

            var updatedGift = await _giftDomainService.UpdateAsync(gift);
            return ObjectMapper.Map<UpdateGiftDto>(updatedGift);
        }
        public async Task DeleteAsync(int id)
        {
            await _giftDomainService.DeleteAsync(id);
        }

        public IList<GiftDto> GetByLevelId(int giftId)
        {
            var gifts = _giftDomainService.GetByLevelId(giftId);
            return ObjectMapper.Map<IList<GiftDto>>(gifts);
        }

        
    }
}
