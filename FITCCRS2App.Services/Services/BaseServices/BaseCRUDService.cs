using AutoMapper;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FITCCRS2App.Services.Services.BaseService
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch> where TDb : class where T : class where TSearch : BaseSearchObject
    {
        public BaseCRUDService(FITCCRS2v2Context context, IMapper mapper) : base(context, mapper)
        {

        }
        
        public virtual async Task BeforeInsert(TDb entity, TInsert insert)
        {
            if (entity is Database.Komisija komisijaEntity)
            {
                var exists = await _context.Komisijas
                    .AnyAsync(k => k.KategorijaId == komisijaEntity.KategorijaId && k.Role == komisijaEntity.Role&& k.Role==Models.Enums.UlogaKomisija.Predsjednik);
                if (exists)
                    throw new DuplicateEntityException("Ova komisija ima predsjednika, odaberite drugu ulogu.");
            }
        }
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context
                .Set<TDb>()
                .FindAsync(id);

            if (entity is null) return false;

            _context.Set<TDb>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<T> Insert(TInsert insert)
        {
            var set = _context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(insert);

            set.Add(entity);
            await BeforeInsert(entity, insert);

            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }


        public virtual async Task<T> Update(int id, TUpdate update)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            _mapper.Map(update, entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

    }
}
