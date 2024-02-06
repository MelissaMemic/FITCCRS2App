using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.ProjekatService
{
    public class ProjekatService : BaseCRUDService<Models.Models.Projekat, Database.Projekat, BaseSearchObject, ProjekatUpsertRequest, ProjekatUpsertRequest>, IProjekatService
    {

        public ProjekatService( FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
