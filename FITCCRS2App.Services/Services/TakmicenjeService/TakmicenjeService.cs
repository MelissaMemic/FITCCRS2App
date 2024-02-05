using AutoMapper;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;

namespace FITCCRS2App.Services.Services.TakmicenjeService
{
	public class TakmicenjeService : BaseCRUDService<Models.Models.Takmicenje, Database.Takmicenje, BaseSearchObject, TakmicenjeUpsertRequest, TakmicenjeUpsertRequest>, ITakmicenjeService
    {
        public TakmicenjeService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public Models.Models.Takmicenje GetLastTakmicenje()
        {
            var TakmicenjaSorted = _context.Takmicenjes.OrderByDescending(x => x.Pocetak).ToList();
            var lastTakmicenje = TakmicenjaSorted.FirstOrDefault();
            return _mapper.Map<Models.Models.Takmicenje>(lastTakmicenje);
        }

        public int GetLastTakmicenjeId()
        {
            var TakmicenjaSorted = _context.Takmicenjes.OrderByDescending(x => x.Pocetak).ToList();
            var lastTakmicenje = TakmicenjaSorted.FirstOrDefault();
            return lastTakmicenje.TakmicenjeId;
        }
    }
}
