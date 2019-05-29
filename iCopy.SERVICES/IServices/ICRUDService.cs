using System.Threading.Tasks;

namespace iCopy.SERVICES.IServices
{
    public interface ICRUDService <TInsert, TUpdate, TResult, TSearch, TPk> : IReadService<TResult, TSearch, TPk>
    {
        Task<TResult> InsertAsync(TInsert entity);
        Task<TResult> UpdateAsync(TPk id, TUpdate entity);
        Task<TResult> DeleteAsync(TPk id);
        Task<TResult> ChangeActiveStatusAsync(TPk id);
    }
}
