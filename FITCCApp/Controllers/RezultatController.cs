using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.RezultatService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class RezultatController : BaseCRUDController<Rezultat, BaseSearchObject, RezultatUpsertRequest, RezultatUpsertRequest>
    {
        public RezultatController(ILogger<BaseController<Rezultat, BaseSearchObject>> logger, IRezultatService service) : base(logger, service)
        {

        }
    }
}