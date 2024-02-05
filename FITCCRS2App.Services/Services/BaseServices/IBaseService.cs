
using FITCCRS2App.Models.Models;

namespace FITCCRS2App.Services.Services.BaseServices
{
    public interface IService<T, TSearch> where TSearch : class
    {
        Task<PagedResult<T>> Get(TSearch? search = null);

        Task<T> GetById(int id);
    }
}
