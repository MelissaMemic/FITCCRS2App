using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.KomisijaService
{
    public class KomisijaService : BaseCRUDService<Models.Models.Komisija, Database.Komisija, BaseSearchObject, KomisijaInsertRequest, KomisijaUpdateRequest>, IKomisijaService
    {

        public KomisijaService( FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
