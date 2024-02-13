using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.BaseServices;
namespace FITCCRS2App.Services.Services.AgendaService
{

    public interface IAgendaService :ICRUDService<Agenda, BaseSearchObject, AgendaUpsertRequest, AgendaUpsertRequest>
    {
        List<Agenda> getLastTakmicenjeAgenda();
        List<Models.Models.DogadjajPerAgenda> getLastAgendasDogadjaj();
    }
}