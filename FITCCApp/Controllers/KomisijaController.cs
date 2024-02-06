using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.KomisijaService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class KomisijaController : BaseCRUDController<Komisija, BaseSearchObject, KomisijaInsertRequest, KomisijaUpdateRequest>
    {
        public KomisijaController(ILogger<BaseController<Komisija, BaseSearchObject>> logger, IKomisijaService service) : base(logger, service)
        {

        }

    }
}


