using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.QrCodes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using Microsoft.AspNetCore.Hosting;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using Abp.Domain.Uow;
using System.Threading;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public class QrCodeRequestAppService : ExchangeAppServiceBase, IQrCodeRequestAppService
    {
        private readonly IQrCodeRequestDomainService _qrCodeRequestDomainService;
        private readonly IQrCodeDomainService _qrCodeDomainService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        
        public QrCodeRequestAppService(
            IQrCodeRequestDomainService qrCodeRequestDomainService, 
            IQrCodeDomainService qrCodeDomainService, 
            IWebHostEnvironment webHostEnvironment, 
            IUnitOfWorkManager unitOfWorkManager)
        {
            _qrCodeRequestDomainService = qrCodeRequestDomainService;
            _qrCodeDomainService = qrCodeDomainService;
            _webHostEnvironment = webHostEnvironment;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _qrCodeRequestDomainService.Get().ToList();
            IEnumerable<ReadQrCodeRequestDto> data = ObjectMapper.Map<List<ReadQrCodeRequestDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<QrCodeRequestDto>();
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
        public async Task<IList<QrCodeRequestDto>> GetAllAsync()
        {
            var list = await _qrCodeRequestDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<QrCodeRequestDto>>(list);
        }
        public async Task<QrCodeRequestDto> GetByIdAsync(int id)
        {
            var qrCodeRequest = await _qrCodeRequestDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<QrCodeRequestDto>(qrCodeRequest);
        }
        public async Task<UpdateQrCodeRequestDto> GetForEditAsync(int id)
        {
            var qrCodeRequest = await _qrCodeRequestDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateQrCodeRequestDto>(qrCodeRequest);
        }
        public async Task<CreateQrCodeRequestDto> CreateAsync(CreateQrCodeRequestDto qrCodeRequestDto)
        {
            QrCodeRequest createdQrCodeRequest;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                qrCodeRequestDto.Date = DateTime.Now;
                var qrCodeRequest = ObjectMapper.Map<QrCodeRequest>(qrCodeRequestDto);
                createdQrCodeRequest = await _qrCodeRequestDomainService.CreateAsync(qrCodeRequest);

                // Generate QrCode
                for (int i = 0; i < qrCodeRequestDto.Count; i++)
                {
                    var code = CreateQrCode(createdQrCodeRequest, i);
                    var qrCode = new QrCode()
                    {
                        ProductId =qrCodeRequest.ProductId,
                        QrCodeRequestId = qrCodeRequest.Id,
                        ImagePath = $"qr-code/{code}.png",
                        Code = code
                    };
                    await _qrCodeDomainService.CreateAsync(qrCode);
                    Thread.Sleep(50);
                }

                unitOfWork.Complete();
            }
            
            return ObjectMapper.Map<CreateQrCodeRequestDto>(createdQrCodeRequest);
        }
        public async Task<UpdateQrCodeRequestDto> UpdateAsync(UpdateQrCodeRequestDto qrCodeRequestDto)
        {
            var qrCodeRequest = ObjectMapper.Map<QrCodeRequest>(qrCodeRequestDto);
            var updatedQrCodeRequest = await _qrCodeRequestDomainService.UpdateAsync(qrCodeRequest);
            return ObjectMapper.Map<UpdateQrCodeRequestDto>(updatedQrCodeRequest);
        }
        public async Task DeleteAsync(int id)
        {
            await _qrCodeRequestDomainService.DeleteAsync(id);
        }

        private string CreateQrCode(QrCodeRequest qrCodeRequest,int i)
        {
            var code = $"{i}{qrCodeRequest.ProductId}{qrCodeRequest.Id}{qrCodeRequest.Date.ToString("ddMMyy")}";
            var rootPath = _webHostEnvironment.WebRootPath;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                qrCodeImage.Save($"{rootPath}\\qr-code\\{code}.png", ImageFormat.Png);
            }
            return code;
        }
    }
}

