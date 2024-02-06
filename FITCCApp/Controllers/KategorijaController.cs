using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.KategorijaService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class KategorijaController : BaseCRUDController<Kategorija, BaseSearchObject, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        public KategorijaController(ILogger<BaseController<Kategorija, BaseSearchObject>> logger, IKategorijaService service) : base(logger, service)
        {

        }

    }
}