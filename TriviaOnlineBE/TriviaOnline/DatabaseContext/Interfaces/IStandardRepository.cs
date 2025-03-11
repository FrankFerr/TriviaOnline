﻿using Shared.Response;
using static Shared.Constants;

namespace TriviaRepository.Interfaces
{
    public interface IStandardRepository<T> where T : class
    {
        public Task<Response> GetAllAsync();
        public Task<Response> GetByOidAsync(decimal oid);
        public Task<Response> UpdateAsync(T entity);
        public Task<Response> InsertAsync(T entity);
        public Task<Response> DeleteAsync(decimal oid);
    }
}
