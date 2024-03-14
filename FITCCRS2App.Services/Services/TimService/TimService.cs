using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.TimService
{
    public class TimService : BaseCRUDService<Models.Models.Tim, Database.Tim, BaseSearchObject, TimInsertRequest, TimUpdateRequest>, ITimService
    {
        public TimService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
