using AutoMapper;
using Tamrin12shahrivar.Model;
using Tamrin12shahrivar.Model.Dto;

namespace Tamrin12shahrivar.Mapping
{
    public class GemDto : Profile
    {
        public GemDto()
        {
            CreateMap<Gem,GemRequestDto>().ReverseMap();
            CreateMap<Gem, GemRequestUpdateDto>().ReverseMap();

        }
    }
}
