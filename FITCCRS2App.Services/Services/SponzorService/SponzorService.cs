using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.SponzorService
{
    public class SponzorService : BaseCRUDService<Models.Models.Sponzor, Database.Sponzor, BaseSearchObject, SponzorUpsertRequest, SponzorUpsertRequest>, ISponzorService
    {

        public SponzorService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
