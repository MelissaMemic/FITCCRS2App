using AutoMapper;
using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.Models.RequestObjects;
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
            CreateMap<Database.Projekat, Models.Models.Projekat>()
    .ForMember(x => x.TimId, opt => opt.MapFrom((src, dest) => src.Tim?.TimId))
    .ForMember(dest => dest.Tim, opt => opt.MapFrom(src => src.Tim))
    .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
    .ForMember(dest => dest.ProjekatId, opt => opt.MapFrom(src => src.ProjekatId))
    .ForMember(dest => dest.KategorijaId, opt => opt.MapFrom(src => src.KategorijaId))
    .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis));

            CreateMap<Database.Rezultat, Models.Models.Rezultat>()
                .ForMember(x => x.ProjekatId, opt => opt.MapFrom((src, dest) => src.Projekat?.ProjekatId))
                //.ForMember(dest => dest.Projekat, opt => opt.MapFrom(src => src.Projekat))
                .ForMember(dest => dest.Bod, opt => opt.MapFrom(src => src.Bod))
                .ForMember(dest => dest.RezultatId, opt => opt.MapFrom(src => src.RezultatId))
                .ForMember(dest => dest.Napomena, opt => opt.MapFrom(src => src.Napomena));

            CreateMap<KriterijUpsertRequest, Database.Kriterij>();
            CreateMap<KomisijaInsertRequest, Database.Komisija>();
            CreateMap<DogadjajInsertRequest, Database.Dogadjaj>()
                            .ForMember(dest => dest.Agenda, opt => opt.Ignore())
;
            CreateMap<DogadjajUpdateRequest, Database.Dogadjaj>();
            CreateMap<RezultatUpsertRequest, Database.Rezultat>();
            CreateMap<TimUpsertRequest, Database.Tim>();


            CreateMap<Database.Skategorije, Models.Models.SKategorije>();
            CreateMap<Database.Sponzor, Models.Models.Sponzor>();
            CreateMap<Database.Takmicenje, Models.Models.Takmicenje>();
            CreateMap<Database.Tim, Models.Models.Tim>();
            CreateMap<AgendaUpsertRequest, Database.Agendum>();
            CreateMap<TakmicenjeUpsertRequest, Database.Takmicenje>();
            CreateMap<Database.User, Models.Models.User>()
                .ForMember(x => x.Roles, opt => opt.MapFrom(y => y.Roles.Select(z => z.Role)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.WebSite, opt => opt.MapFrom(src => src.WebSite))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                ;

            CreateMap<Models.Models.User, Database.User>();

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
