using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.AgendaService;
using FITCCRS2App.Services.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class UserController : BaseCRUDController<User, BaseSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        private readonly IUserService _userService;
        public UserController(ILogger<BaseController<User, BaseSearchObject>> logger, IUserService service) : base(logger, service)
        {
            _userService = service;
        }
        [HttpGet("getUserByRole")]
        public async Task<List<User>> GetUserByRole(string role)
        {
            var user = await _userService.GetByRole(role);
            return user;
        }
    }
}