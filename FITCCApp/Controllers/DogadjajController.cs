using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.DogadjajService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class DogadjajController : BaseCRUDController<Dogadjaj, BaseSearchObject, DogadjajInsertRequest, DogadjajUpdateRequest>
    {
        public DogadjajController(ILogger<BaseController<Dogadjaj, BaseSearchObject>> logger, IDogadjajService service) : base(logger, service)
        {

        }
    }
}
