using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.TimService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class TimController : BaseCRUDController<Tim, BaseSearchObject, TimInsertRequest, TimUpdateRequest>
    {
        public TimController(ILogger<BaseController<Tim, BaseSearchObject>> logger, ITimService service) : base(logger, service)
        {

        }
    }
}

