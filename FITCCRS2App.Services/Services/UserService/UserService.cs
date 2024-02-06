using System;
using AutoMapper;
using FITCCRS2App.Models.Helpers;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace FITCCRS2App.Services.Services.UserService
{
    public class UserService : BaseCRUDService<Models.Models.User, Database.User, BaseSearchObject,UserInsertRequest, UserUpdateRequest>, IUserService
    {

        public UserService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Models.Models.User> GetByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _context
                .Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x =>
                    x.Email == email &&
                    x.Password == EncryptionHelpers.Hash(password)
                );

            return _mapper.Map<Models.Models.User>(user);
        }
    }
}