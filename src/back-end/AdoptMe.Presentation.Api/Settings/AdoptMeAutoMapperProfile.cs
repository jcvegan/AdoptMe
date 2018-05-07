namespace AdoptMe.Presentation.Api.Settings
{
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Data.Domains.Security;
    using AutoMapper;

    public class AdoptMeAutoMapperProfile : Profile
    {
        public AdoptMeAutoMapperProfile() : base()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}