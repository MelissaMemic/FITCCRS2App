using AutoMapper;
using FITCCRS2App.Models.RequestObjects;

namespace FITCCRS2App.Services
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Agendum, Models.Models.Agenda>();
            CreateMap<AgendaUpsertRequest, Database.Agendum>();

            CreateMap<Database.Takmicenje, Models.Models.Takmicenje>();
            CreateMap<TakmicenjeUpsertRequest, Database.Takmicenje>();

            CreateMap<Database.Kategorija, Models.Models.Kategorija>();
            CreateMap<Database.Tim, Models.Models.Tim>();
            CreateMap<Database.Projekat, Models.Models.Projekat>();
            //CreateMap<Database.User, Models.Models.User>();
            CreateMap<Database.User, Models.Models.User>()
    .ForMember(x => x.Roles, opt => opt.MapFrom(y => y.Roles.Select(z => z.Role)));

            CreateMap<Models.Models.User, Database.User>()
                .ForMember(x => x.CityId, opt => opt.MapFrom((src, dest) => src.City?.CityId))
                .ForMember(x => x.City, opt => opt.Ignore())
                .ForMember(x => x.CitizenshipId, opt => opt.MapFrom((src, dest) => src.Citizenship?.CountryId))
                .ForMember(x => x.Citizenship, opt => opt.Ignore());

            CreateMap<Database.UserRole, Models.Models.UserRole>();
            CreateMap<Models.Models.UserRole, Database.UserRole>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.User.UserId))
                .ForMember(x => x.Role, opt => opt.MapFrom(y => y.User.UserId))
                .ForMember(x => x.User, opt => opt.Ignore());

        }
    }

}
