using Shared.ResponseModel;
using static Shared.Constants;

namespace TriviaRepository.Services.Interfaces
{
    public interface IStandardRepository<TModel, TViewModel> where TModel : class where TViewModel : class
    {
        public Task<Response> GetAllAsync();
        public Task<Response> GetByOidAsync(decimal oid);
        public Task<Response> UpdateAsync(TViewModel entity);
        public Task<Response> InsertAsync(TViewModel entity);
        public Task<Response> DeleteAsync(decimal oid);
    }
}
