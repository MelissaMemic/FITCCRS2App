using AutoMapper;
using FITCCRS2App.Models.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.RezultatService
{
    public class RezultatService : BaseCRUDService<Models.Models.Rezultat, Database.Rezultat, BaseSearchObject, RezultatUpsertRequest, RezultatUpsertRequest>, IRezultatService
    {
        public RezultatService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
