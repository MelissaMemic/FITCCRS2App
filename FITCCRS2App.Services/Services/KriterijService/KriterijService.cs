using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.KriterijService
{
    public class KriterijService : BaseCRUDService<Models.Models.Kriterij, Database.Kriterij, BaseSearchObject, KriterijUpsertRequest, KriterijUpsertRequest>, IKriterijService
    {

        public KriterijService( FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
