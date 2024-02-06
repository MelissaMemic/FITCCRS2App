using AutoMapper;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FITCCRS2App.Services.Services.BaseServices
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch> where TDb : class where T : class where TSearch : BaseSearchObject
    {
        protected FITCCRS2v2Context _context;
        protected IMapper _mapper { get; set; }
        public BaseService(FITCCRS2v2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<PagedResult<T>> Get(TSearch? search = null)
        {
            var query = _context.Set<TDb>().AsQueryable();

            PagedResult<T> result = new PagedResult<T>();



            query = AddFilter(query, search);

            query = AddInclude(query, search);

            result.TotalCount = await query.CountAsync();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = await query.ToListAsync();


            var tmp = _mapper.Map<List<T>>(list);
            result.Result = tmp;
            return result;
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch? search = null)
        {
            if (typeof(TDb) == typeof(Database.Rezultat))
            {
                var specificQuery = query as IQueryable<Database.Rezultat>;
                specificQuery = specificQuery.Include(x => x.Projekat); 
                return specificQuery as IQueryable<TDb>;
            }
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<T>(entity);
        }
    }
}
