using AutoMapper;
using Ahc.Club.Ahc.QrCodes.Dto;

namespace Ahc.Club.Ahc.QrCodes.Map
{
   public class QrCodeRequestMapProfile : Profile
    {
        public QrCodeRequestMapProfile()
        {
            CreateMap<QrCodeRequest, QrCodeRequestDto>();
            CreateMap<QrCodeRequest, ReadQrCodeRequestDto>();
            CreateMap<CreateQrCodeRequestDto, QrCodeRequest>();
            CreateMap<QrCodeRequest, CreateQrCodeRequestDto>();
            CreateMap<UpdateQrCodeRequestDto, QrCodeRequest>();
            CreateMap<QrCodeRequest, UpdateQrCodeRequestDto>();
        }
    }
}

