using Ahc.Club.Ahc.Complaints.Dto;
using AutoMapper;

namespace Ahc.Club.Ahc.Complaints.Map
{
    public class ComplaintMapProfile : Profile
    {
        public ComplaintMapProfile()
        {
            CreateMap<Complaint, ComplaintDto>();
            CreateMap<ComplaintDto, Complaint>();
        }
    }
}
