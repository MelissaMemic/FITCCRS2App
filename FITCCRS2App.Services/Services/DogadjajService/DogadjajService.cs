using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.DogadjajService
{
    public class DogadjajService : BaseCRUDService<Models.Models.Dogadjaj, Database.Dogadjaj, BaseSearchObject, DogadjajInsertRequest, DogadjajUpdateRequest>, IDogadjajService
    {

        public DogadjajService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}

