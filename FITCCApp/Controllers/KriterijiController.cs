using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.KriterijService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class KriterijiController : BaseCRUDController<Kriterij, BaseSearchObject, KriterijInsertRequest, KriterijUpdateRequest>
    {
        public KriterijiController(ILogger<BaseController<Kriterij, BaseSearchObject>> logger, IKriterijService service) : base(logger, service)
        {

        }
    }
}