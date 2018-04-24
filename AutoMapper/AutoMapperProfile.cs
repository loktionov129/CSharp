using AutoMapper;

namespace NetRore.Csharp.Cmd
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.User, Dto.User>();
        }
    }
}