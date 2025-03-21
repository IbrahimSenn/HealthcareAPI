﻿namespace HealthcareAPI.DataAccess.Abstracts
{
    public interface IMongoRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task DeleteAsync(string id);
    }
}
