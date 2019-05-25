using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCopy.SERVICES.IServices
{
    public interface IReadService<TResult, TSearch, TPk>
    {
        Task<List<TResult>> GetAllAsync();
        Task<TResult> GetByIdAsync(TPk id);
        Task<List<TResult>> GetByParametersAsync(TSearch search);
        Task<List<TResult>> GetDataForDataTable();
        Task<int> GetNumberOfRecords();
        Task<List<TResult>> TakeRecordsByNumber(int take);
    }
}
