using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.BaseServices;

namespace FITCCRS2App.Services.Services.UserService
{
    public interface IUserService : ICRUDService<User, BaseSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task<List<User>> GetByRole(string role);
    }
}