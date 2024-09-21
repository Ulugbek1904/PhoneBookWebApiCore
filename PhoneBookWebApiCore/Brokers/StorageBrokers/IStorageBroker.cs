using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Brokers.StorageBrokers
{
    public partial interface IStorageBroker
    {
        Task<T> InsertAsync<T>(T entity) where T : class;
        Task<List<T>> SelectAllAsync<T>() where T : class;
        Task<T> SelectByIdAsync<T>(Guid itemGuid) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        Task<T> DeleteAsync<T>(T entity) where T : class;

    }
}