using AutoMapper;
using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;
using FITCCRS2App.Services.Services.TakmicenjeService;

namespace FITCCRS2App.Services.Services.AgendaService
{
	public class AgendaService : BaseCRUDService<Agenda, Database.Agendum, BaseSearchObject, AgendaUpsertRequest, AgendaUpsertRequest>, IAgendaService
    {
        public ITakmicenjeService _takmicenjeService { get; set; }

        public AgendaService( ITakmicenjeService takmicenjeService,FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
            _takmicenjeService = takmicenjeService;
        }
        public List<Agenda> getLastTakmicenjeAgenda()
        {
            var lastTakmicenjeID = _takmicenjeService.GetLastTakmicenjeId();
            var listAgenda = _context.Agenda.Where(x => x.TakmicenjeId == lastTakmicenjeID).ToList();
            return _mapper.Map<List<Models.Models.Agenda>>(listAgenda);
        }
    }
}
