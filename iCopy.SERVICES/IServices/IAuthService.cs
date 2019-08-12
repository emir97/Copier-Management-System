using System.Threading.Tasks;

namespace iCopy.SERVICES.IServices
{
    public interface IAuthService<TInsert, TUpdate, TResult, TSearch, TKey>
    {
        Task<TResult> InsertAsync(TInsert entity);
        Task<TResult> UpdateAsync(TKey id, TUpdate entity);
        Task<TResult> DeleteAsync(TKey id);
    }
}
