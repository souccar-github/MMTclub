using AutoMapper;
using Ahc.Club.Ahc.QrCodes.Dto;

namespace Ahc.Club.Ahc.QrCodes.Map
{
   public class QrCodeMapProfile : Profile
    {
        public QrCodeMapProfile()
        {
            CreateMap<QrCode, QrCodeDto>();
            CreateMap<QrCode, ReadQrCodeDto>();
            CreateMap<CreateQrCodeDto, QrCode>();
            CreateMap<QrCode, CreateQrCodeDto>();
            CreateMap<UpdateQrCodeDto, QrCode>();
            CreateMap<QrCode, UpdateQrCodeDto>();
        }
    }
}

