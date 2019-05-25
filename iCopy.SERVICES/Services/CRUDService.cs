using AutoMapper;
using iCopy.SERVICES.Context;
using iCopy.SERVICES.IServices;
using System;
using System.Threading.Tasks;

namespace iCopy.SERVICES.Services
{
    public class CRUDService<TModel, TInsert, TUpdate, TResult, TSearch, TPk> : ReadService<TModel, TResult, TSearch, TPk>, ICRUDService<TInsert, TUpdate, TResult, TSearch, TPk> where TModel : class
    {
        private readonly DBContext ctx;
        private readonly IMapper mapper;
        public CRUDService(DBContext ctx, IMapper mapper) : base(ctx, mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<TResult> DeleteAsync(TPk id)
        {
            TModel model = await ctx.Set<TModel>().FindAsync(id);
            ctx.Set<TModel>().Remove(model);
            try
            {
                await ctx.SaveChangesAsync();
                // TODO: Dodati log u bazu
            } catch(Exception e)
            {
                //  TODO: Dodati log u bazu
                throw e;
            }
            return mapper.Map<TResult>(model);
        }

        public async Task<TResult> InsertAsync(TInsert entity)
        {
            TModel model = mapper.Map<TModel>(entity);
            ctx.Set<TModel>().Add(model);
            try
            {
                await ctx.SaveChangesAsync();
                // TODO: Dodati log u bazu
            } catch(Exception e)
            {
                // TODO: Dodati log u bazu
                throw e;
            }
            return mapper.Map<TResult>(model);
        }
        
        public async Task<TResult> UpdateAsync(TPk id, TUpdate entity)
        {
            TModel model = await ctx.Set<TModel>().FindAsync(id);
            ctx.Set<TModel>().Attach(model);
            ctx.Set<TModel>().Update(model);

            mapper.Map(entity, model);
            try
            {
                await ctx.SaveChangesAsync();
                // TODO: Dodati log operaciju
            } catch(Exception e)
            {
                //TODO: Dodati log operaciju
            }

            return mapper.Map<TResult>(model);
        }
    }
}
