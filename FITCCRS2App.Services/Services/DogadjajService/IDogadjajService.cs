using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.BaseServices;

namespace FITCCRS2App.Services.Services.DogadjajService
{
    public interface IDogadjajService : ICRUDService<Dogadjaj, BaseSearchObject, DogadjajInsertRequest, DogadjajUpdateRequest>
    {
    }
}