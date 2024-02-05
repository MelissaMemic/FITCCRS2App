using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.TakmicenjeService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TakmicenjeController : BaseCRUDController<Takmicenje, BaseSearchObject, TakmicenjeUpsertRequest, TakmicenjeUpsertRequest>
    {
        public TakmicenjeController(ILogger<BaseController<Takmicenje, BaseSearchObject>> logger, ITakmicenjeService service) : base(logger, service)
        {

        }

    }
}