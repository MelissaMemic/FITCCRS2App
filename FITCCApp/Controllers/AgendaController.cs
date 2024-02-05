using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.AgendaService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AgendaController : BaseCRUDController<Agenda, BaseSearchObject, AgendaUpsertRequest, AgendaUpsertRequest>
    {
        public AgendaController(ILogger<BaseController<Agenda, BaseSearchObject>> logger, IAgendaService service) : base(logger, service)
        {

        }

    }
}