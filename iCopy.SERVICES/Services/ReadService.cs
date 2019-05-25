using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iCopy.SERVICES.Context;
using iCopy.SERVICES.IServices;
using Microsoft.EntityFrameworkCore;

namespace iCopy.SERVICES.Services
{
    public class ReadService<TModel, TResult, TSearch, TPk> : IReadService<TResult, TSearch, TPk> where TModel : class
    {
        private readonly DBContext ctx;
        private readonly IMapper mapper;

        public ReadService(DBContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public virtual async Task<List<TResult>> GetAllAsync()
        {
            return mapper.Map<List<TResult>>(await ctx.Set<TModel>().ToListAsync());
        }

        public virtual async Task<TResult> GetByIdAsync(TPk id)
        {
            return mapper.Map<TResult>(await ctx.Set<TModel>().FindAsync(id));
        }

        public virtual async Task<List<TResult>> GetByParametersAsync(TSearch search)
        {
            return mapper.Map<List<TResult>>(await ctx.Set<TModel>().ToListAsync());
        }

        public Task<List<TResult>> GetDataForDataTable()
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<int> GetNumberOfRecords()
        {
            return await ctx.Set<TModel>().CountAsync();
        }

        public virtual async Task<List<TResult>> TakeRecordsByNumber(int take)
        {
            return mapper.Map<List<TResult>>(await ctx.Set<TModel>().Take(take).ToListAsync());
        }
    }
}
