using AutoMapper;
using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;

namespace FITCCRS2App.Services
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Agendum, Models.Models.Agenda>().ReverseMap();
            CreateMap<Database.City, Models.Models.City>();
            CreateMap<Database.Country, Models.Models.Country>();

            CreateMap<Database.Dogadjaj, Models.Models.Dogadjaj>();
            CreateMap<Database.Kategorija, Models.Models.Kategorija>();
            CreateMap<Database.Komisija, Models.Models.Komisija>();
            CreateMap<Database.Kriterij, Models.Models.Kriterij>();

            CreateMap<Database.Napomena, Models.Models.Napomena>();
            CreateMap<Database.Predavac, Models.Models.Predavac>();
            CreateMap<Database.PredavacDogadjaj, Models.Models.PredavacDogadjaj>();
            CreateMap<Database.Projekat, Models.Models.Projekat>();

            CreateMap<Database.Rezultat, Models.Models.Rezultat>()
                .ForMember(x => x.ProjekatId, opt => opt.MapFrom((src, dest) => src.Projekat?.ProjekatId))
                .ForMember(dest => dest.Projekat, opt => opt.MapFrom(src => src.Projekat))
                .ForMember(dest => dest.Bod, opt => opt.MapFrom(src => src.Bod))
                .ForMember(dest => dest.RezultatId, opt => opt.MapFrom(src => src.RezultatId))
                .ForMember(dest => dest.Napomena, opt => opt.MapFrom(src => src.Napomena));

            CreateMap<KriterijUpsertRequest, Database.Kriterij>();
            CreateMap<KomisijaInsertRequest, Database.Komisija>();
            CreateMap<DogadjajInsertRequest, Database.Dogadjaj>();
            CreateMap<DogadjajUpdateRequest, Database.Dogadjaj>();
            
            CreateMap<Database.Skategorije, Models.Models.SKategorije>();
            CreateMap<Database.Sponzor, Models.Models.Sponzor>();
            CreateMap<Database.Takmicenje, Models.Models.Takmicenje>();
            CreateMap<Database.Tim, Models.Models.Tim>();
            CreateMap<AgendaUpsertRequest, Database.Agendum>();
            CreateMap<TakmicenjeUpsertRequest, Database.Takmicenje>();
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
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<Dogadjaj, DogadjajPerAgenda>()
            .ForMember(dest => dest.DogadjajId, opt => opt.MapFrom(src => src.DogadjajId))
            .ForMember(dest => dest.Kraj, opt => opt.MapFrom(src => src.Kraj))
            .ForMember(dest => dest.Pocetak, opt => opt.MapFrom(src => src.Pocetak))
            .ForMember(dest => dest.Lokacija, opt => opt.MapFrom(src => src.Lokacija))
            .ForMember(dest => dest.Trajanje, opt => opt.MapFrom(src => src.Trajanje))
            .ForMember(dest => dest.Napomena, opt => opt.MapFrom(src => src.Napomena))
            .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Napomena))
            .ForMember(dest => dest.AgendaId, opt => opt.Ignore())
            .ForMember(dest => dest.TakmicenjeId, opt => opt.Ignore())
            .ForMember(dest => dest.Dan, opt => opt.Ignore());

            CreateMap<Agenda, DogadjajPerAgenda>()
                .ForMember(dest => dest.DogadjajId, opt => opt.Ignore())
                .ForMember(dest => dest.Kraj, opt => opt.Ignore())
                .ForMember(dest => dest.Pocetak, opt => opt.Ignore())
                .ForMember(dest => dest.Lokacija, opt => opt.Ignore())
                .ForMember(dest => dest.Trajanje, opt => opt.Ignore())
                .ForMember(dest => dest.Napomena, opt => opt.Ignore())
                .ForMember(dest => dest.Naziv, opt => opt.Ignore())
                .ForMember(dest => dest.AgendaId, opt => opt.MapFrom(src => src.AgendaId))
                .ForMember(dest => dest.Dan, opt => opt.MapFrom(src => src.Dan))
                .ForMember(dest => dest.TakmicenjeId, opt => opt.MapFrom(src => src.TakmicenjeId));
        }
    }

}
