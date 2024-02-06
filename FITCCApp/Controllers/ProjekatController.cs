using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.ProjekatService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class ProjekatController : BaseCRUDController<Projekat, BaseSearchObject, ProjekatUpsertRequest, ProjekatUpsertRequest>
    {
        public ProjekatController(ILogger<BaseController<Projekat, BaseSearchObject>> logger, IProjekatService service) : base(logger, service)
        {

        }
    }
}